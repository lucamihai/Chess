using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using ChessApplication.Common;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Helpers;
using ChessApplication.Common.Interfaces;
using ChessApplication.GUI.Helpers;
using ChessApplication.Network;

namespace ChessApplication.GUI.UserControls.Chessboard
{
    [ExcludeFromCodeCoverage]
    public partial class ChessboardUserControl : UserControl
    {
        private NetworkManager networkManager;
        private IChessboard chessboard;
        private BoxUserControl firstClickedBox;
        private BoxUserControl[,] boxUserControls;

        private PieceColor playerTurn = PieceColor.White;
        private PieceColor opponentTurn = PieceColor.Black;

        private CapturedPieceBoxUserControl capturedWhitePawns, capturedWhiteRooks, capturedWhiteKnights, capturedWhiteBishops, capturedWhiteQueen;
        private CapturedPieceBoxUserControl capturedBlackPawns, capturedBlackRooks, capturedBlackKnights, capturedBlackBishops, capturedBlackQueen;

        private bool isNewGameRequested;

        // TODO: Extract sound logic in a separate class
        private readonly SoundPlayer moveSound1;
        private readonly SoundPlayer moveSound2;

        public bool SoundEnabled { get; set; } = true;
        public bool HighlightAvailableMoves { get; set; } = true;

        public string PlayerUsername { get; private set; }
        private string opponentUsername;

        public delegate void MoveMade(BoxUserControl origin, BoxUserControl destination);
        public delegate void ReceivedChatMessage(string username, string message);
        public delegate void Notification(string notificationMessage);

        public MoveMade OnMadeMove { get; set; }
        public ReceivedChatMessage OnReceivedChatMessage { get; set; }
        public Notification OnNotification { get; set; }

        public ChessboardUserControl(ChessboardType chessboardType, UserType userType, string hostname = null)
        {
            moveSound1 = new SoundPlayer(Properties.Resources.movesound1);
            moveSound2 = new SoundPlayer(Properties.Resources.movesound2);

            InitializeComponent();
            InitializeChessboard(chessboardType);
            InitializeNetworkManager(userType, hostname);
            InitializeUsernames(userType);
            InitializeTurns(userType);
            InitializeChessboardBoxesArea();
            InitializeCapturedPiecesArea();

            NewGame();
        }

        public void SetPlayerUsername(string username)
        {
            PlayerUsername = username;
            networkManager?.ChangeUsername(username);
        }

        public void SetPlayerColor(PieceColor chosenColor)
        {
            playerTurn = chosenColor;
            opponentTurn = chosenColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            networkManager?.ChangeColor(chosenColor);
        }
        
        private void InitializeChessboard(ChessboardType chessboardType)
        {
            chessboard = ChessboardProvider.GetChessboard(chessboardType);
        }

        private void InitializeNetworkManager(UserType userType, string hostname)
        {
            networkManager = NetworkManagerProvider.GetNetworkManager(userType, hostname);

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
                playerTurn = PieceColor.Black;
                opponentTurn = PieceColor.White;
            }
            else
            {
                playerTurn = PieceColor.White;
                opponentTurn = PieceColor.Black;
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

        public void Disconnect()
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
            chessboard.NewGame();

            SetChessboardBoxesColors();
            RedrawChessboardBoxes();
            UpdateCapturedPiecesCounter();

            playerTurn = opponentTurn == PieceColor.Black
                ? PieceColor.White
                : PieceColor.Black;
        }

        private void InitializeChessboardBoxesArea()
        {
            panelChessBoard.Controls.Clear();
            boxUserControls = new BoxUserControl[9, 9];

            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    boxUserControls[row, column] = new BoxUserControl(chessboard[row, column]);
                    boxUserControls[row, column].Click += BoxClick;
                    boxUserControls[row, column].Location = new Point
                    {
                        X = (column - 1) * 64,
                        Y = (8 - row) * 64
                    };
                    panelChessBoard.Controls.Add(boxUserControls[row, column]);
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
                    var currentBox = boxUserControls[row, column];

                    if ((row + column) % 2 == 0)
                    {
                        boxUserControls[row, column].BoxBackgroundColor = !ignoreIsAvailableFlag && ShouldHighlightBoxAsAvailable(currentBox)
                            ? Constants.BoxColorAvailable
                            : Constants.BoxColorDark;
                    }
                    else
                    {
                        boxUserControls[row, column].BoxBackgroundColor = !ignoreIsAvailableFlag && ShouldHighlightBoxAsAvailable(currentBox)
                            ? Constants.BoxColorAvailable
                            : Constants.BoxColorLight;
                    }
                }
            }
        }

        private bool ShouldHighlightBoxAsAvailable(BoxUserControl boxUserControl)
        {
            return boxUserControl.Box.Available && HighlightAvailableMoves;
        }

        private void MovePiece(Box origin, Box destination)
        {
            // TODO: Check if move is valid

            if (chessboard.CurrentTurn == playerTurn)
            {
                networkManager?.NotifyOfMove(origin.Position, destination.Position);
            }

            SetChessboardBoxesColors(ignoreIsAvailableFlag: true);
            TriggerOnMadeMove(origin, destination);
            chessboard.Move(origin.Position, destination.Position);

            if (!chessboard.RetakingIsActive)
            {
                NextTurn();
            }

            if (SoundEnabled)
            {
                var soundToPlay = chessboard.CurrentTurn == playerTurn ? moveSound1 : moveSound2;
                soundToPlay.Play();
            }

            EndGameIfCheckMate();
        }

        private void TriggerOnMadeMove(Box origin, Box destination)
        {
            var originBoxUserControl = boxUserControls[origin.Position.Row, origin.Position.Column];
            var destinationBoxUserControl = boxUserControls[destination.Position.Row, destination.Position.Column];

            OnMadeMove(originBoxUserControl, destinationBoxUserControl);
        }

        private void UpdateCapturedPiecesCounter()
        {
            capturedWhitePawns.Count = chessboard.CapturedPieceCollection.GetEntry<Pawn>(PieceColor.White);
            capturedWhiteRooks.Count = chessboard.CapturedPieceCollection.GetEntry<Rook>(PieceColor.White);
            capturedWhiteKnights.Count = chessboard.CapturedPieceCollection.GetEntry<Knight>(PieceColor.White);
            capturedWhiteBishops.Count = chessboard.CapturedPieceCollection.GetEntry<Bishop>(PieceColor.White);
            capturedWhiteQueen.Count = chessboard.CapturedPieceCollection.GetEntry<Queen>(PieceColor.White);

            capturedBlackPawns.Count = chessboard.CapturedPieceCollection.GetEntry<Pawn>(PieceColor.Black);
            capturedBlackRooks.Count = chessboard.CapturedPieceCollection.GetEntry<Rook>(PieceColor.Black);
            capturedBlackKnights.Count = chessboard.CapturedPieceCollection.GetEntry<Knight>(PieceColor.Black);
            capturedBlackBishops.Count = chessboard.CapturedPieceCollection.GetEntry<Bishop>(PieceColor.Black);
            capturedBlackQueen.Count = chessboard.CapturedPieceCollection.GetEntry<Queen>(PieceColor.Black);
        }

        private void EndGameIfCheckMate()
        {
            if (chessboard.IsCheckmateForProvidedColor(PieceColor.White))
            {
                OnNotification(Strings.CheckmateWhite);

                Thread.Sleep(2000);
                var newGameInvoker = new MethodInvoker(NewGame);

                Invoke(newGameInvoker);
                networkManager?.IssueNewGame();
            }
            if (chessboard.IsCheckmateForProvidedColor(PieceColor.Black))
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
            chessboard.SetChessboardBoxesAsUnavailable();
            SetChessboardBoxesColors(ignoreIsAvailableFlag: true);
            RedrawChessboardBoxes();
            UpdateCapturedPiecesCounter();

            labelTurn.Text = chessboard.CurrentTurn == PieceColor.White
                ? Strings.WhitesTurn
                : Strings.BlacksTurn;
        }

        private void BoxClick(object sender, EventArgs e)
        {
            if (chessboard.RetakingIsActive)
            {
                return;
            }

            if (chessboard.CurrentTurn != playerTurn)
            {
                return;
            }

            var clickedBox = (BoxUserControl)sender;
            
            if (firstClickedBox == null && clickedBox.Piece != null)
            {
                if (playerTurn == clickedBox.Piece.Color)
                {
                    var boxPosition = clickedBox.Position;
                    
                    clickedBox.Box.Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, boxPosition);
                    SetChessboardBoxesColors();

                    if (clickedBox.Box.Piece.CanMove)
                    {
                        firstClickedBox = clickedBox;
                    }
                }
            }
            else if (firstClickedBox != null)
            {
                if (clickedBox == firstClickedBox)
                {
                    chessboard.SetChessboardBoxesAsUnavailable();
                    SetChessboardBoxesColors();
                    firstClickedBox = null;
                }

                else if (clickedBox != firstClickedBox && clickedBox.Available)
                {
                    MovePiece(firstClickedBox.Box, clickedBox.Box);
                    firstClickedBox = null;
                    RedrawChessboardBoxes();
                }
            }
            
        }

        private void CapturedPieceBoxClick(object sender, EventArgs e)
        {
            if (!chessboard.RetakingIsActive)
            {
                return;
            }

            var clickedCapturedPieceBox = (CapturedPieceBoxUserControl)sender;
            var chessPieceToRetake = clickedCapturedPieceBox.ChessPiece;
            var count = chessboard.CapturedPieceCollection.GetEntry(chessPieceToRetake);

            if (chessboard.CurrentTurn == playerTurn && count > 0)
            {
                var retakingPosition = chessboard.RetakingPosition;
                chessboard.RetakePiece(retakingPosition, chessPieceToRetake.GetType(), chessPieceToRetake.Color);
                networkManager?.NotifyOfRetakeSelection(retakingPosition, chessboard[retakingPosition].Piece);
                NextTurn();
            }
        }

        private void RedrawChessboardBoxes()
        {
            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    boxUserControls[row, column].Draw();
                }
            }
        }

        #region NetworkManager delegates

        private void NetworkManagerOnChangedColor(PieceColor opponentsTurn)
        {
            var opponentChangedColors = new MethodInvoker(() =>
            {
                playerTurn = opponentsTurn == PieceColor.White ? PieceColor.Black : PieceColor.White;
                this.opponentTurn = opponentsTurn;
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

                chessboard.RetakePiece(position, pieceType, pieceColor);
                NextTurn();
            });

            Invoke(selection);
        }

        private void NetworkManagerOnMadeMove(Position origin, Position destination)
        {
            var move = new MethodInvoker(() => MovePiece(chessboard[origin], chessboard[destination]));

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
