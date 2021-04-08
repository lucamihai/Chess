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
using ChessApplication.Network;

namespace ChessApplication.GUI.UserControls.Chessboard
{
    [ExcludeFromCodeCoverage]
    public partial class ChessboardUserControl : UserControl
    {
        private NetworkManager networkManager;
        
        public bool BeginnersMode
        {
            get => Chessboard.BeginnersMode;
            set => Chessboard.BeginnersMode = value;
        }

        public bool SoundEnabled { get; set; } = true;

        private bool isNewGameRequested;

        private CapturedPieceBoxUserControl capturedWhitePawns, capturedWhiteRooks, capturedWhiteKnights, capturedWhiteBishops, capturedWhiteQueen;
        private CapturedPieceBoxUserControl capturedBlackPawns, capturedBlackRooks, capturedBlackKnights, capturedBlackBishops, capturedBlackQueen;
        
        private PieceColor PlayerTurn { get; set; } = PieceColor.White;
        private PieceColor OpponentsTurn { get; set; } = PieceColor.Black;

        public string PlayerUsername { get; private set; }
        private string opponentUsername;

        private IChessboard Chessboard { get; set; }
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
            InitializeChessboard();
            InitializeNetworkManager(userType, hostname);
            InitializeUsernames(userType);
            InitializeTurns(userType);

            NewGame();
        }

        public void SetPlayerUsername(string username)
        {
            PlayerUsername = username;
            networkManager?.ChangeUsername(username);
        }

        public void SetPlayerColor(PieceColor chosenColor)
        {
            PlayerTurn = chosenColor;
            OpponentsTurn = chosenColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            networkManager?.ChangeColor(chosenColor);
        }

        private void InitializeChessboard()
        {
            if (ChessboardType == ChessboardType.Classic)
            {
                Chessboard = new ChessboardClassic();
            }

            else if (ChessboardType == ChessboardType.Shatranj)
            {
                throw new NotImplementedException();
            }
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

            networkManager.OnChangedColor += NetworkManagerOnChangedColor;
            networkManager.OnChangedUsername += NetworkManagerOnChangedUsername;
            networkManager.OnBegunRetakeSelection += NetworkManagerOnBegunRetakeSelection;
            networkManager.OnMadeRetakeSelection += NetworkManagerOnMadeRetakeSelection;
            networkManager.OnMadeMove += NetworkManagerOnMadeMove;
            networkManager.OnRequestedNewGame += NetworkManagerOnRequestedNewGame;
            networkManager.OnIssuedNewGame += NetworkManagerOnIssuedNewGame;
            networkManager.OnChatMessage += NetworkManagerOnChatMessage;
            networkManager.OnNotification += NetworkManagerOnNotification;
        }

        private void InitializeUsernames(UserType userType)
        {
            if (userType == UserType.Server)
            {
                PlayerUsername = Constants.DefaultUsernameServer;
                opponentUsername = Constants.DefaultUsernameClient;
            }

            if (userType == UserType.Client)
            {
                PlayerUsername = Constants.DefaultUsernameClient;
                opponentUsername = Constants.DefaultUsernameServer;
            }
        }

        private void InitializeTurns(UserType userType)
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
            var message = string.Format(Strings.UserRequestsNewGame, opponentUsername);
            MessageBox.Show(message);
        }

        private void NewGame()
        {
            Chessboard.NewGame();

            InitializeChessboardBoxesArea();
            InitializeCapturedPiecesArea();

            SetChessboardBoxesColors();
            AssignClickEventToBoxes();
            UpdateCapturedPiecesCounter();

            PlayerTurn = OpponentsTurn == PieceColor.Black
                ? PieceColor.White
                : PieceColor.Black;
        }

        private void InitializeChessboardBoxesArea()
        {
            panelChessBoard.Controls.Clear();
            BoxUserControls = new BoxUserControl[9, 9];

            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    BoxUserControls[row, column] = new BoxUserControl(Chessboard[row, column]);
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

        public void SetChessboardBoxesColors(bool ignoreIsAvailableFlag = false)
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

            if (Chessboard.CurrentTurn == PlayerTurn)
            {
                networkManager?.NotifyOfMove(origin.Position, destination.Position);
            }

            SetChessboardBoxesColors(ignoreIsAvailableFlag: true);
            TriggerOnMadeMove(origin, destination);
            Chessboard.Move(origin.Position, destination.Position);

            //BeginPieceRecapturingIfPawnReachedTheEnd(destination);

            if (!Chessboard.RetakingIsActive)
            {
                NextTurn();
            }

            if (SoundEnabled)
            {
                var soundToPlay = Chessboard.CurrentTurn == PlayerTurn ? MoveSound1 : MoveSound2;
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
            capturedWhitePawns.Count = Chessboard.CapturedPieceCollection.GetEntry<Pawn>(PieceColor.White);
            capturedWhiteRooks.Count = Chessboard.CapturedPieceCollection.GetEntry<Rook>(PieceColor.White);
            capturedWhiteKnights.Count = Chessboard.CapturedPieceCollection.GetEntry<Knight>(PieceColor.White);
            capturedWhiteBishops.Count = Chessboard.CapturedPieceCollection.GetEntry<Bishop>(PieceColor.White);
            capturedWhiteQueen.Count = Chessboard.CapturedPieceCollection.GetEntry<Queen>(PieceColor.White);

            capturedBlackPawns.Count = Chessboard.CapturedPieceCollection.GetEntry<Pawn>(PieceColor.Black);
            capturedBlackRooks.Count = Chessboard.CapturedPieceCollection.GetEntry<Rook>(PieceColor.Black);
            capturedBlackKnights.Count = Chessboard.CapturedPieceCollection.GetEntry<Knight>(PieceColor.Black);
            capturedBlackBishops.Count = Chessboard.CapturedPieceCollection.GetEntry<Bishop>(PieceColor.Black);
            capturedBlackQueen.Count = Chessboard.CapturedPieceCollection.GetEntry<Queen>(PieceColor.Black);
        }

        private void EndGameIfCheckMate()
        {
            if (Chessboard.IsCheckmateForProvidedColor(PieceColor.White))
            {
                OnNotification(Strings.CheckmateWhite);

                Thread.Sleep(2000);
                var newGameInvoker = new MethodInvoker(NewGame);

                Invoke(newGameInvoker);
                networkManager?.IssueNewGame();
            }
            if (Chessboard.IsCheckmateForProvidedColor(PieceColor.Black))
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
            Chessboard.SetChessBoardBoxesAsUnavailable();
            SetChessboardBoxesColors(ignoreIsAvailableFlag: true);
            RedrawChessboardBoxes();
            UpdateCapturedPiecesCounter();

            labelTurn.Text = Chessboard.CurrentTurn == PieceColor.White
                ? Strings.WhitesTurn
                : Strings.BlacksTurn;
        }

        private void BoxClick(object sender, EventArgs e)
        {
            if (Chessboard.RetakingIsActive)
            {
                return;
            }

            if (Chessboard.CurrentTurn != PlayerTurn)
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

                    Chessboard.SetChessBoardBoxesAsUnavailable();
                    clickedBox.Box.Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, boxPosition);
                    SetChessboardBoxesColors();

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
                    Chessboard.SetChessBoardBoxesAsUnavailable();
                    SetChessboardBoxesColors();
                    FirstClickedBox = null;
                }

                else if (clickedBox != FirstClickedBox && clickedBox.Available)
                {
                    MovePiece(FirstClickedBox.Box, clickedBox.Box);
                    FirstClickedBox = null;
                    Chessboard.SetChessBoardBoxesAsUnavailable();
                    SetChessboardBoxesColors();
                    RedrawChessboardBoxes();
                }
            }
            
        }

        private void CapturedPieceBoxClick(object sender, EventArgs e)
        {
            if (!Chessboard.RetakingIsActive)
            {
                return;
            }

            var clickedCapturedPieceBox = (CapturedPieceBoxUserControl)sender;
            var chessPieceToRetake = clickedCapturedPieceBox.ChessPiece;
            var count = Chessboard.CapturedPieceCollection.GetEntry(chessPieceToRetake);

            if (Chessboard.CurrentTurn == PlayerTurn && count > 0)
            {
                var retakingPosition = Chessboard.RetakingPosition;
                Chessboard.RetakePiece(retakingPosition, chessPieceToRetake.GetType(), chessPieceToRetake.Color);
                networkManager?.NotifyOfRetakeSelection(retakingPosition, Chessboard[retakingPosition].Piece);
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

        #region NetworkManager delegates

        private void NetworkManagerOnChangedColor(PieceColor opponentsTurn)
        {
            var opponentChangedColors = new MethodInvoker(() =>
            {
                PlayerTurn = opponentsTurn == PieceColor.White ? PieceColor.Black : PieceColor.White;
                OpponentsTurn = opponentsTurn;
            });

            Invoke(opponentChangedColors);
        }

        private void NetworkManagerOnChangedUsername(string username)
        {
            var changeOpponentUsername = new MethodInvoker(() => opponentUsername = username);
            Invoke(changeOpponentUsername);
        }

        private void NetworkManagerOnBegunRetakeSelection()
        {
            var beginSelection = new MethodInvoker(() =>
            {
                var message = string.Format(Strings.UserBeginsSelection, opponentUsername);
                OnNotification(message);
            });

            Invoke(beginSelection);
        }

        private void NetworkManagerOnMadeRetakeSelection(Position position, string type, string color)
        {
            var selection = new MethodInvoker(() =>
            {
                var pieceType = ChessPieceInfoProvider.GetChessPieceTypeFromString(type);
                var pieceColor = ChessPieceInfoProvider.GetPieceColorFromString(color);

                Chessboard.RetakePiece(position, pieceType, pieceColor);
                NextTurn();
            });

            Invoke(selection);
        }

        private void NetworkManagerOnMadeMove(Position origin, Position destination)
        {
            var move = new MethodInvoker(() => MovePiece(Chessboard[origin], Chessboard[destination]));

            Invoke(move);
        }

        private void NetworkManagerOnRequestedNewGame()
        {
            var request = new MethodInvoker(() =>
            {
                isNewGameRequested = true;
                NotifyNewGameIsRequested();
            });

            Invoke(request);
        }

        private void NetworkManagerOnIssuedNewGame()
        {
            var newGame = new MethodInvoker(() =>
            {
                var message = Strings.NewGameHasBegun;
                OnNotification(message);

                NewGame();
            });
            Invoke(newGame);
        }

        private void NetworkManagerOnChatMessage(string message)
        {
            var addChatMessage = new MethodInvoker(() => { OnReceivedChatMessage(opponentUsername, message); });
            Invoke(addChatMessage);
        }

        private void NetworkManagerOnNotification(string message)
        {
            var triggerNotification = new MethodInvoker(() => { OnNotification(message); });
            Invoke(triggerNotification);
        }

        #endregion
    }
}
