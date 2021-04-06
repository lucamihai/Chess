using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using ChessApplication.Common;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.ChessPieces.Helpers;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.GUI.UserControls.Chessboard;
using ChessApplication.Network;

namespace ChessApplication.GUI
{
    [ExcludeFromCodeCoverage]
    public partial class ChessboardUserControl : UserControl
    {
        private NetworkManager networkManager;
        
        public bool BeginnersMode
        {
            get => ChessBoard.BeginnersMode;
            set => ChessBoard.BeginnersMode = value;
        }

        public bool SoundEnabled { get; set; } = true;

        private bool isNewGameRequested = false;
        private bool opponentMustSelect = false;

        private CapturedPieceBoxUserControl capturedWhitePawns, capturedWhiteRooks, capturedWhiteKnights, capturedWhiteBishops, capturedWhiteQueen;
        private CapturedPieceBoxUserControl capturedBlackPawns, capturedBlackRooks, capturedBlackKnights, capturedBlackBishops, capturedBlackQueen;
        
        private PieceColor PlayerTurn { get; set; } = PieceColor.White;
        private PieceColor OpponentsTurn { get; set; } = PieceColor.Black;

        public string PlayerUsername { get; private set; }
        private string usernameOpponent;

        private IChessboard ChessBoard { get; set; }
        private ChessboardType ChessboardType { get; set; }
        private BoxUserControl FirstClickedBox { get; set; }
        private BoxUserControl[,] BoxUserControls { get; set; }
        

        private SoundPlayer MoveSound1 { get; } = new SoundPlayer(Properties.Resources.movesound1);
        private SoundPlayer MoveSound2 { get; } = new SoundPlayer(Properties.Resources.movesound2);

        public delegate void MoveMade(BoxUserControl origin, BoxUserControl destination);
        public MoveMade OnMadeMove { get; set; }

        public delegate void ReceivedChatMessage(string username, string message);
        public ReceivedChatMessage OnReceivedChatMessage { get; set; }

        public delegate void Notification(string notificationMessage);
        public Notification OnNotification { get; set; }

        public ChessboardUserControl(ChessboardType chessboardType, UserType userType, string hostname = null)
        {
            ChessboardType = chessboardType;

            InitializeComponent();
            InitializeChessBoard();
            InitializeNetworkManager(userType, hostname);
            InitializeUsernames(userType);
            InitializeTurnsByUserType(userType);

            NewGame();
        }

        private void InitializeNetworkManager(UserType userType, string hostname)
        {
            if (userType == UserType.SinglePlayer)
            {
                return;
            }

            if (userType == UserType.Server)
            {
                networkManager = new NetworkManagerServer();
            }

            if (userType == UserType.Client)
            {
                networkManager = new NetworkManagerClient(hostname);
            }

            networkManager.OnChangedColor += (opponentsTurn) =>
            {
                var opponentChangedColors = new MethodInvoker(() =>
                {
                    PlayerTurn = opponentsTurn == PieceColor.White ? PieceColor.Black : PieceColor.White;
                    OpponentsTurn = opponentsTurn;
                });

                Invoke(opponentChangedColors);
            };

            networkManager.OnChangedUsername += username =>
            {
                var changeOpponentUsername = new MethodInvoker(() => usernameOpponent = username);
                Invoke(changeOpponentUsername);
            };

            networkManager.OnBegunRetakeSelection += () =>
            {
                var beginSelection = new MethodInvoker(() => {
                    opponentMustSelect = true;

                    var message = string.Format(Strings.UserBeginsSelection, usernameOpponent);
                    OnNotification(message);
                });

                Invoke(beginSelection);
            };

            networkManager.OnMadeRetakeSelection += (position, type, color) =>
            {
                var selection = new MethodInvoker(() =>
                {
                    var pieceType = ChessPieceInfoProvider.GetChessPieceTypeFromString(type);
                    var pieceColor = ChessPieceInfoProvider.GetPieceColorFromString(color);

                    ChessBoard.RetakePiece(position, pieceType, pieceColor);
                    NextTurn();

                    opponentMustSelect = false;
                });

                Invoke(selection);
            };

            networkManager.OnMadeMove += (origin, destination) =>
            {
                var move = new MethodInvoker(
                    () => MovePiece(ChessBoard[origin], ChessBoard[destination])
                );

                Invoke(move);
            };

            networkManager.OnRequestedNewGame += () =>
            {
                var request = new MethodInvoker(() => {
                    isNewGameRequested = true;
                    NotifyNewGameIsRequested();
                });

                Invoke(request);
            };

            networkManager.OnIssuedNewGame += () =>
            {
                var newGame = new MethodInvoker(() =>
                {
                    var message = Strings.NewGameHasBegun;
                    OnNotification(message);

                    NewGame();
                });
                Invoke(newGame);
            };

            networkManager.OnChatMessage += message =>
            {
                var addChatMessage = new MethodInvoker(() =>
                {
                    OnReceivedChatMessage(usernameOpponent, message);
                });
                Invoke(addChatMessage);
            };

            networkManager.OnNotification += message =>
            {
                var triggerNotification = new MethodInvoker(() =>
                {
                    OnNotification(message);
                });
                Invoke(triggerNotification);
            };
        }

        private void InitializeUsernames(UserType currentPlayerUserType)
        {
            if (currentPlayerUserType == UserType.Server)
            {
                PlayerUsername = Constants.DefaultUsernameServer;
                usernameOpponent = Constants.DefaultUsernameClient;
            }

            if (currentPlayerUserType == UserType.Client)
            {
                PlayerUsername = Constants.DefaultUsernameClient;
                usernameOpponent = Constants.DefaultUsernameServer;
            }
        }

        private void InitializeTurnsByUserType(UserType userType)
        {
            if (userType == UserType.Client)
            {
                PlayerTurn = PieceColor.Black;
                OpponentsTurn = PieceColor.White;
            }
            else
            {
                PlayerTurn = PieceColor.White;
                OpponentsTurn = PieceColor.Black;
            }
        }

        public void SetUsernameAndNotifyOpponent(string username)
        {
            PlayerUsername = username;
            networkManager?.ChangeUsername(username);
        }

        public void SetColorsAndNotifyOpponent(PieceColor chosenColor)
        {
            PlayerTurn = chosenColor;
            OpponentsTurn = chosenColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            networkManager?.ChangeColor(chosenColor);
        }

        public void RequestNewGame()
        {
            if (!isNewGameRequested)
            {
                networkManager?.RequestNewGame();
            }
            else
            {
                NewGame();
                isNewGameRequested = false;
                networkManager?.IssueNewGame();
            }
        }

        public void StopNetworkStuff()
        {
            networkManager?.Stop();
        }

        public void SendMessageToOpponent(string message)
        {
            networkManager?.SendChatMessage(message);
        }

        private void NotifyNewGameIsRequested()
        {
            var message = string.Format(Strings.UserRequestsNewGame, usernameOpponent);
            MessageBox.Show(message);
        }

        private void NewGame()
        {
            ChessBoard.NewGame();

            InitializeChessboardBoxesArea();
            InitializeCapturedPiecesArea();

            SetChessBoardBoxesColors();
            AssignClickEventToBoxes();
            UpdateCapturedPiecesCounter();

            PlayerTurn = OpponentsTurn == PieceColor.Black
                ? PieceColor.White
                : PieceColor.Black;
        }

        private void InitializeChessBoard()
        {
            if (ChessboardType == ChessboardType.Classic)
            {
                ChessBoard = new ChessboardClassic();
            }

            else if (ChessboardType == ChessboardType.Shatranj)
            {
                throw new NotImplementedException();
            }
        }

        private void InitializeChessboardBoxesArea()
        {
            panelChessBoard.Controls.Clear();
            BoxUserControls = new BoxUserControl[9, 9];

            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    BoxUserControls[row, column] = new BoxUserControl(ChessBoard[row, column]);
                    BoxUserControls[row, column].Location = new Point
                    {
                        X = (column - 1) * 64,
                        Y = (8 - row) * 64
                    };
                    panelChessBoard.Controls.Add(BoxUserControls[row, column]);
                }
            }
        }

        private void InitializeCapturedPiecesArea()
        {
            panelCapturedWhitePieces.Controls.Clear();
            panelCapturedBlackPieces.Controls.Clear();

            capturedWhitePawns = new CapturedPieceBoxUserControl(new Pawn(PieceColor.White));
            capturedWhiteRooks = new CapturedPieceBoxUserControl(new Rook(PieceColor.White));
            capturedWhiteKnights = new CapturedPieceBoxUserControl(new Knight(PieceColor.White));
            capturedWhiteBishops = new CapturedPieceBoxUserControl(new Bishop(PieceColor.White));
            capturedWhiteQueen = new CapturedPieceBoxUserControl(new Queen(PieceColor.White));

            capturedBlackPawns = new CapturedPieceBoxUserControl(new Pawn(PieceColor.Black));
            capturedBlackRooks = new CapturedPieceBoxUserControl(new Rook(PieceColor.Black));
            capturedBlackKnights = new CapturedPieceBoxUserControl(new Knight(PieceColor.Black));
            capturedBlackBishops = new CapturedPieceBoxUserControl(new Bishop(PieceColor.Black));
            capturedBlackQueen = new CapturedPieceBoxUserControl(new Queen(PieceColor.Black));

            panelCapturedWhitePieces.Controls.Add(capturedWhitePawns);
            panelCapturedWhitePieces.Controls.Add(capturedWhiteRooks);
            panelCapturedWhitePieces.Controls.Add(capturedWhiteKnights);
            panelCapturedWhitePieces.Controls.Add(capturedWhiteBishops);
            panelCapturedWhitePieces.Controls.Add(capturedWhiteQueen);

            panelCapturedBlackPieces.Controls.Add(capturedBlackPawns);
            panelCapturedBlackPieces.Controls.Add(capturedBlackRooks);
            panelCapturedBlackPieces.Controls.Add(capturedBlackKnights);
            panelCapturedBlackPieces.Controls.Add(capturedBlackBishops);
            panelCapturedBlackPieces.Controls.Add(capturedBlackQueen);

            capturedWhitePawns.Location = new Point(0, 0);
            capturedWhiteRooks.Location = new Point(64, 0);
            capturedWhiteKnights.Location = new Point(128, 0);
            capturedWhiteBishops.Location = new Point(192, 0);
            capturedWhiteQueen.Location = new Point(256, 0);

            capturedBlackPawns.Location = new Point(0, 0);
            capturedBlackRooks.Location = new Point(64, 0);
            capturedBlackKnights.Location = new Point(128, 0);
            capturedBlackBishops.Location = new Point(192, 0);
            capturedBlackQueen.Location = new Point(256, 0);

            capturedWhitePawns.Click += CapturedPieceBoxClick;
            capturedWhiteRooks.Click += CapturedPieceBoxClick;
            capturedWhiteKnights.Click += CapturedPieceBoxClick;
            capturedWhiteBishops.Click += CapturedPieceBoxClick;
            capturedWhiteQueen.Click += CapturedPieceBoxClick;

            capturedBlackPawns.Click += CapturedPieceBoxClick;
            capturedBlackRooks.Click += CapturedPieceBoxClick;
            capturedBlackKnights.Click += CapturedPieceBoxClick;
            capturedBlackBishops.Click += CapturedPieceBoxClick;
            capturedBlackQueen.Click += CapturedPieceBoxClick;
        }

        public void SetChessBoardBoxesColors(bool ignoreIsAvailableFlag = false)
        {
            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    var isAvailable = BoxUserControls[row, column].Box.Available;

                    if ((row % 2 == 0 && column % 2 == 0) || (row % 2 == 1 && column % 2 == 1))
                    {
                        BoxUserControls[row, column].BoxBackgroundColor = isAvailable && !ignoreIsAvailableFlag
                            ? Constants.BoxColorAvailable
                            : Constants.BoxColorDark;
                    }
                    else
                    {
                        BoxUserControls[row, column].BoxBackgroundColor = isAvailable && !ignoreIsAvailableFlag
                            ? Constants.BoxColorAvailable
                            : Constants.BoxColorLight;
                    }
                }
            }
        }

        private void AssignClickEventToBoxes()
        {
            for (var i = 1; i <= 8; i++)
            {
                for (var j = 1; j <= 8; j++)
                {
                    BoxUserControls[i, j].Click += BoxClick;
                }
            }
        }

        private void MovePiece(Box origin, Box destination)
        {
            // TODO: Check if move is valid

            if (ChessBoard.CurrentTurn == PlayerTurn)
            {
                networkManager?.NotifyOfMove(origin.Position, destination.Position);
            }

            SetChessBoardBoxesColors(ignoreIsAvailableFlag: true);
            TriggerOnMadeMove(origin, destination);
            ChessBoard.Move(origin.Position, destination.Position);

            //BeginPieceRecapturingIfPawnReachedTheEnd(destination);

            if (!ChessBoard.RetakingIsActive)
            {
                NextTurn();
            }

            if (SoundEnabled)
            {
                var soundToPlay = ChessBoard.CurrentTurn == PlayerTurn ? MoveSound1 : MoveSound2;
                soundToPlay.Play();
            }

            EndGameIfCheckMate();
        }

        private void TriggerOnMadeMove(Box origin, Box destination)
        {
            var originBoxUserControl = BoxUserControls[origin.Position.Row, origin.Position.Column];
            var destinationBoxUserControl = BoxUserControls[destination.Position.Row, destination.Position.Column];

            OnMadeMove(originBoxUserControl, destinationBoxUserControl);
        }

        private void UpdateCapturedPiecesCounter()
        {
            capturedWhitePawns.Count = ChessBoard.CapturedPieceCollection.GetEntry<Pawn>(PieceColor.White);
            capturedWhiteRooks.Count = ChessBoard.CapturedPieceCollection.GetEntry<Rook>(PieceColor.White);
            capturedWhiteKnights.Count = ChessBoard.CapturedPieceCollection.GetEntry<Knight>(PieceColor.White);
            capturedWhiteBishops.Count = ChessBoard.CapturedPieceCollection.GetEntry<Bishop>(PieceColor.White);
            capturedWhiteQueen.Count = ChessBoard.CapturedPieceCollection.GetEntry<Queen>(PieceColor.White);

            capturedBlackPawns.Count = ChessBoard.CapturedPieceCollection.GetEntry<Pawn>(PieceColor.Black);
            capturedBlackRooks.Count = ChessBoard.CapturedPieceCollection.GetEntry<Rook>(PieceColor.Black);
            capturedBlackKnights.Count = ChessBoard.CapturedPieceCollection.GetEntry<Knight>(PieceColor.Black);
            capturedBlackBishops.Count = ChessBoard.CapturedPieceCollection.GetEntry<Bishop>(PieceColor.Black);
            capturedBlackQueen.Count = ChessBoard.CapturedPieceCollection.GetEntry<Queen>(PieceColor.Black);
        }

        private void EndGameIfCheckMate()
        {
            if (ChessBoard.IsCheckmateForProvidedColor(PieceColor.White))
            {
                OnNotification(Strings.CheckmateWhite);

                Thread.Sleep(2000);
                var newGameInvoker = new MethodInvoker(NewGame);

                Invoke(newGameInvoker);
                networkManager?.IssueNewGame();
            }
            if (ChessBoard.IsCheckmateForProvidedColor(PieceColor.Black))
            {
                OnNotification(Strings.CheckmateBlack);

                Thread.Sleep(2000);
                var newGameInvoker = new MethodInvoker(NewGame);

                Invoke(newGameInvoker);
                networkManager?.IssueNewGame();
            }
        }

        private void NextTurn()
        {
            ChessBoard.SetChessBoardBoxesAsUnavailable();
            SetChessBoardBoxesColors(ignoreIsAvailableFlag: true);
            RedrawChessboardBoxes();
            UpdateCapturedPiecesCounter();

            labelTurn.Text = ChessBoard.CurrentTurn == PieceColor.White
                ? Strings.WhitesTurn
                : Strings.BlacksTurn;
        }

        private void BoxClick(object sender, EventArgs e)
        {
            if (ChessBoard.RetakingIsActive)
            {
                return;
            }

            if (ChessBoard.CurrentTurn != PlayerTurn)
            {
                return;
            }

            var clickedBox = (BoxUserControl)sender;
            
            // TODO: Clean if-else bodies
            if (FirstClickedBox == null && clickedBox.Piece != null)
            {
                if (PlayerTurn == clickedBox.Piece.Color)
                {
                    var boxPosition = clickedBox.Position;

                    ChessBoard.SetChessBoardBoxesAsUnavailable();
                    clickedBox.Box.Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, boxPosition);
                    SetChessBoardBoxesColors();

                    if (clickedBox.Box.Piece.CanMove)
                    {
                        FirstClickedBox = clickedBox;
                    }
                }
            }
            else if (FirstClickedBox != null)
            {
                if (clickedBox == FirstClickedBox)
                {
                    ChessBoard.SetChessBoardBoxesAsUnavailable();
                    SetChessBoardBoxesColors();
                    FirstClickedBox = null;
                }

                else if (clickedBox != FirstClickedBox && clickedBox.Available)
                {
                    MovePiece(FirstClickedBox.Box, clickedBox.Box);
                    FirstClickedBox = null;
                    ChessBoard.SetChessBoardBoxesAsUnavailable();
                    SetChessBoardBoxesColors();
                    RedrawChessboardBoxes();
                }
            }
            
        }

        private void CapturedPieceBoxClick(object sender, EventArgs e)
        {
            if (!ChessBoard.RetakingIsActive)
            {
                return;
            }

            var clickedCapturedPieceBox = (CapturedPieceBoxUserControl)sender;
            var chessPieceToRetake = clickedCapturedPieceBox.ChessPiece;
            var count = ChessBoard.CapturedPieceCollection.GetEntry(chessPieceToRetake);

            if (ChessBoard.CurrentTurn == PlayerTurn && count > 0)
            {
                var retakingPosition = ChessBoard.RetakingPosition;
                ChessBoard.RetakePiece(retakingPosition, chessPieceToRetake.GetType(), chessPieceToRetake.Color);
                networkManager?.NotifyOfRetakeSelection(retakingPosition, ChessBoard[retakingPosition].Piece);
                NextTurn();
            }
        }

        private void RedrawChessboardBoxes()
        {
            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    BoxUserControls[row, column].Draw();
                }
            }
        }
        
    }
}
