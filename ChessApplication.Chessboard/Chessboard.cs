using System;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using ChessApplication.Common;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using ChessApplication.Network;

namespace ChessApplication.Chessboard
{
    public partial class Chessboard : UserControl
    {
        private NetworkManager networkManager;
        private const string CommandMarker = Network.Constants.CommandMarker;

        private Point positionWhiteKing;
        private Point positionBlackKing;

        private int clickCounter;
        private int retakeRow, retakeColumn; // Will hold the row and column of where retaken pieces will be placed

        private bool _BeginnersMode = true;
        public bool BeginnersMode
        {
            get => _BeginnersMode;
            set
            {
                _BeginnersMode = value;
                UpdateBeginnersModeForChessBoardBoxes();
            }
        }

        public bool SoundEnabled { get; set; } = true;

        private bool isNewGameRequested = false;
        private bool currentPlayerMustSelect = false;
        private bool opponentMustSelect = false;
        private bool isCurrentPlayersTurnToMove = true;

        private Turn CurrentPlayersTurn { get; set; } = Turn.White;
        private Turn OpponentsTurn { get; set; } = Turn.Black;

        private string username;
        private string usernameOpponent;

        private CapturedPieceBox capturedWhitePawns, capturedWhiteRooks, capturedWhiteKnights, capturedWhiteBishops, capturedWhiteQueen;
        private CapturedPieceBox capturedBlackPawns, capturedBlackRooks, capturedBlackKnights, capturedBlackBishops, capturedBlackQueen;

        private Box FirstClickedBox { get; set; }
        private Box[,] ChessBoard { get; set; }

        private Color BoxColorLight { get; } = Color.Silver;
        private Color BoxColorDark { get; } = Color.FromArgb(132, 107, 86);

        private SoundPlayer MoveSound1 { get; } = new SoundPlayer(Properties.Resources.MoveSound1);
        private SoundPlayer MoveSound2 { get; } = new SoundPlayer(Properties.Resources.MoveSound2);

        public delegate void MoveMade(Box origin, Box destination);
        public MoveMade OnMadeMove { get; set; }

        public delegate void Notification(string notificationMessage);
        public Notification OnNotification { get; set; }

        public Chessboard(UserType userType, string hostname = null)
        {
            InitializeComponent();
            InitializeNetworkManager(userType, hostname);
            InitializeUsernames(userType);

            NewGame();
        }

        private void InitializeNetworkManager(UserType userType, string hostname)
        {
            if (userType == UserType.Server)
            {
                networkManager = new NetworkManagerServer();
            }

            if (userType == UserType.Client)
            {
                networkManager = new NetworkManagerClient(hostname);
            }

            networkManager.OnChangedColors += (currentPlayersTurn, opponentsTurn) =>
            {
                var opponentChangedColors = new MethodInvoker(() =>
                {
                    CurrentPlayersTurn = currentPlayersTurn;
                    OpponentsTurn = opponentsTurn;

                    isCurrentPlayersTurnToMove = CurrentPlayersTurn == Turn.White;
                });

                Invoke(opponentChangedColors);
            };

            networkManager.OnChangedUsername += username =>
            {
                var changeOpponentUsername = new MethodInvoker(() => usernameOpponent = username);
                Invoke(changeOpponentUsername);
            };

            networkManager.OnBeginSelection += () =>
            {
                var beginSelection = new MethodInvoker(() => {
                    opponentMustSelect = true;

                    var message = string.Format(Strings.UserBeginsSelection, usernameOpponent);
                    OnNotification(message);
                });

                Invoke(beginSelection);
            };

            networkManager.OnSelection += (point, type, color) =>
            {
                var selection = new MethodInvoker(() => {
                    if (color == PieceColor.White)
                    {
                        if (type == typeof(Rook))
                        {
                            Utilities.RetakeCapturedPiece(capturedWhiteRooks, ChessBoard[point.X, point.Y]);
                        }

                        if (type == typeof(Knight))
                        {
                            Utilities.RetakeCapturedPiece(capturedWhiteKnights, ChessBoard[point.X, point.Y]);
                        }

                        if (type == typeof(Bishop))
                        {
                            Utilities.RetakeCapturedPiece(capturedWhiteBishops, ChessBoard[point.X, point.Y]);
                        }

                        if (type == typeof(Queen))
                        {
                            Utilities.RetakeCapturedPiece(capturedWhiteQueen, ChessBoard[point.X, point.Y]);
                        }
                    }

                    if (color == PieceColor.Black)
                    {
                        if (type == typeof(Rook))
                        {
                            Utilities.RetakeCapturedPiece(capturedBlackRooks, ChessBoard[point.X, point.Y]);
                        }

                        if (type == typeof(Knight))
                        {
                            Utilities.RetakeCapturedPiece(capturedBlackKnights, ChessBoard[point.X, point.Y]);
                        }

                        if (type == typeof(Bishop))
                        {
                            Utilities.RetakeCapturedPiece(capturedBlackBishops, ChessBoard[point.X, point.Y]);
                        }

                        if (type == typeof(Queen))
                        {
                            Utilities.RetakeCapturedPiece(capturedBlackQueen, ChessBoard[point.X, point.Y]);
                        }
                    }

                    opponentMustSelect = false;
                });

                Invoke(selection);
            };

            networkManager.OnMadeMove += (origin, destination) =>
            {
                var move = new MethodInvoker(
                    () => OpponentMovePiece(ChessBoard[origin.X, origin.Y], ChessBoard[destination.X, destination.Y])
                );

                Invoke(move);
            };

            networkManager.OnRequestNewGame += () =>
            {
                var request = new MethodInvoker(() => {
                    isNewGameRequested = true;
                    NotifyNewGameIsRequested();
                });

                Invoke(request);
            };

            networkManager.OnNewGame += () =>
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
                    var chatMessage = string.Format(Strings.ChatMessage, usernameOpponent, message);
                    chatBox.Text += chatMessage;
                });
                Invoke(addChatMessage);
            };
        }

        private void NotifyNewGameIsRequested()
        {
            var message = string.Format(Strings.UserRequestsNewGame, usernameOpponent);
            MessageBox.Show(message);
        }

        private void InitializeUsernames(UserType currentPlayerUserType)
        {
            if (currentPlayerUserType == UserType.Server)
            {
                username = Constants.DefaultUsernameServer;
                usernameOpponent = Constants.DefaultUsernameClient;
            }

            if (currentPlayerUserType == UserType.Client)
            {
                username = Constants.DefaultUsernameClient;
                usernameOpponent = Constants.DefaultUsernameServer;
            }
        }

        private void NewGame()
        {
            InitializeChessBoard();
            InitializeCapturedPiecesArea();
            ResetChessBoardBoxesColors();
            SetChessBoardBoxesAsUnavailable();
            AssignClickEventToBoxes();

            clickCounter = 0;

            if (OpponentsTurn == Turn.Black)
            {
                CurrentPlayersTurn = Turn.White;
                isCurrentPlayersTurnToMove = true;
            }
            else
            {
                CurrentPlayersTurn = Turn.Black;
                isCurrentPlayersTurnToMove = false;
            }

            positionWhiteKing.X = 1;
            positionWhiteKing.Y = 5;

            positionBlackKing.X = 8;
            positionBlackKing.Y = 4;
        }

        private void InitializeChessBoard()
        {
            ChessBoard = new Box[10, 10];

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    var boxName = GenerateBoxNameBasedOnRowAndColumn(row, column);
                    var boxLocation = GenerateBoxLocationBasedOnRowAndColumn(row, column);

                    ChessBoard[row, column] = new Box(boxName);
                    ChessBoard[row, column].Location = boxLocation;
                    ChessBoard[row, column].BeginnersMode = BeginnersMode;

                    panelChessBoard.Controls.Add(ChessBoard[row, column]);
                }
            }

            AddWhitePieces();
            AddBlackPieces();
        }

        private string GenerateBoxNameBasedOnRowAndColumn(int row, int column)
        {
            char rowLetter = (char)('A' + row - 1);
            return $"{rowLetter}{column}";
        }

        private Point GenerateBoxLocationBasedOnRowAndColumn(int row, int column)
        {
            return new Point
            {
                X = (column - 1) * 64,
                Y = (8 - row) * 64
            };
        }

        private void AddWhitePieces()
        {
            ChessBoard[1, 1].Piece = new Rook(PieceColor.White);
            ChessBoard[1, 2].Piece = new Knight(PieceColor.White);
            ChessBoard[1, 3].Piece = new Bishop(PieceColor.White);
            ChessBoard[1, 4].Piece = new Queen(PieceColor.White);
            ChessBoard[1, 5].Piece = new King(PieceColor.White);
            ChessBoard[1, 6].Piece = new Bishop(PieceColor.White);
            ChessBoard[1, 7].Piece = new Knight(PieceColor.White);
            ChessBoard[1, 8].Piece = new Rook(PieceColor.White);

            for (int column = 1; column < 9; column++)
            {
                ChessBoard[2, column].Piece = new Pawn(PieceColor.White);
            }
        }

        private void AddBlackPieces()
        {
            ChessBoard[8, 1].Piece = new Rook(PieceColor.Black);
            ChessBoard[8, 2].Piece = new Knight(PieceColor.Black);
            ChessBoard[8, 3].Piece = new Bishop(PieceColor.Black);
            ChessBoard[8, 4].Piece = new King(PieceColor.Black);
            ChessBoard[8, 5].Piece = new Queen(PieceColor.Black);
            ChessBoard[8, 6].Piece = new Bishop(PieceColor.Black);
            ChessBoard[8, 7].Piece = new Knight(PieceColor.Black);
            ChessBoard[8, 8].Piece = new Rook(PieceColor.Black);

            for (int column = 1; column < 9; column++)
            {
                ChessBoard[7, column].Piece = new Pawn(PieceColor.Black);
            }
        }

        private void InitializeCapturedPiecesArea()
        {
            panelCapturedWhitePieces.Controls.Clear();
            panelCapturedBlackPieces.Controls.Clear();

            capturedWhitePawns = new CapturedPieceBox(new Pawn(PieceColor.White));
            capturedWhiteRooks = new CapturedPieceBox(new Rook(PieceColor.White));
            capturedWhiteKnights = new CapturedPieceBox(new Knight(PieceColor.White));
            capturedWhiteBishops = new CapturedPieceBox(new Bishop(PieceColor.White));
            capturedWhiteQueen = new CapturedPieceBox(new Queen(PieceColor.White));

            capturedBlackPawns = new CapturedPieceBox(new Pawn(PieceColor.Black));
            capturedBlackRooks = new CapturedPieceBox(new Rook(PieceColor.Black));
            capturedBlackKnights = new CapturedPieceBox(new Knight(PieceColor.Black));
            capturedBlackBishops = new CapturedPieceBox(new Bishop(PieceColor.Black));
            capturedBlackQueen = new CapturedPieceBox(new Queen(PieceColor.Black));

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

        private void AssignClickEventToBoxes()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    ChessBoard[i, j].Click += BoxClick;
                }
            }
        }

        private void SendMessageAndCreateChatEntryIfItsNotCommand(string message)
        {
            // If the message to be sent isn't a command, create a new chat entry
            if (!message.StartsWith(CommandMarker))
            {
                var chatMessage = string.Format(Strings.ChatMessage, username, message);
                chatBox.AppendText(chatMessage);
            }

            networkManager.SendMessage(message);
        }

        private void TextBoxChatInputPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendChatMessage(sender, e);
            }
        }

        private void UpdateBeginnersModeForChessBoardBoxes()
        {
            for (int row = 1; row <= 8; row++)
            {
                for (int column = 1; column <= 8; column++)
                {
                    ChessBoard[row, column].BeginnersMode = BeginnersMode;
                }
            }
        }

        private void CurrentPlayerMovePiece(Box origin, Box destination)
        {
            if (destination.Piece != null)
            {
                UpdateCapturedPiecesCounter(destination);
            }

            var message = $"{CommandMarker}{CommandStrings.MoveMade}{origin.BoxName} {destination.BoxName}";
            SendMessageAndCreateChatEntryIfItsNotCommand(message);

            ResetChessBoardBoxesColors();
            PerformMove(origin, destination);

            if (destination.Piece is King)
            {
                UpdateKingPosition(destination);
            }

            BeginPieceRecapturingIfPawnReachedTheEnd(destination);

            NextTurn();
            SetChessBoardBoxesAsUnavailable();
            ResetChessBoardBoxesColors();

            isCurrentPlayersTurnToMove = false;
            CurrentPlayersTurn = OpponentsTurn;

            labelTurn.Text = CurrentPlayersTurn == Turn.White ? Strings.WhitesTurn : Strings.BlacksTurn;

            if (SoundEnabled)
            {
                MoveSound1.Play();
            }

            EndGameIfCheckMate();

            SetChessBoardBoxesAsUnavailable();
        }

        private void OpponentMovePiece(Box origin, Box destination)
        {
            // If the destination has a piece, it will be removed => increase the counter of the captured piece type
            if (destination.Piece != null)
            {
                UpdateCapturedPiecesCounter(destination);
            }

            ResetChessBoardBoxesColors();
            PerformMove(origin, destination);


            // If, the king was moved, update its coordinates
            if (destination.Piece is King)
            {
                UpdateKingPosition(destination);
            }

            isCurrentPlayersTurnToMove = true;

            if (OpponentsTurn == Turn.Black)
            {
                CurrentPlayersTurn = Turn.White;
                labelTurn.Text = Strings.WhitesTurn;
            }
            else
            {
                CurrentPlayersTurn = Turn.Black;
                labelTurn.Text = Strings.BlacksTurn;
            }

            if (SoundEnabled)
            {
                MoveSound2.Play();
            }

            EndGameIfCheckMate();

            SetChessBoardBoxesAsUnavailable();
        }

        private void PerformMove(Box origin, Box destination)
        {
            OnMadeMove(origin, destination);

            destination.Piece = origin.Piece;
            origin.Piece = null;
        }

        private void UpdateCapturedPiecesCounter(Box destination)
        {
            if (destination.Piece.Color == PieceColor.White)
            {
                if (destination.Piece is Pawn)
                {
                    capturedWhitePawns.Count++;
                }

                if (destination.Piece is Rook)
                {
                    capturedWhiteRooks.Count++;
                }

                if (destination.Piece is Knight)
                {
                    capturedWhiteKnights.Count++;
                }

                if (destination.Piece is Bishop)
                {
                    capturedWhiteBishops.Count++;
                }

                if (destination.Piece is Queen)
                {
                    capturedWhiteQueen.Count++;
                }
            }

            if (destination.Piece.Color == PieceColor.Black)
            {
                if (destination.Piece is Pawn)
                {
                    capturedBlackPawns.Count++;
                }

                if (destination.Piece is Rook)
                {
                    capturedBlackRooks.Count++;
                }

                if (destination.Piece is Knight)
                {
                    capturedBlackKnights.Count++;
                }

                if (destination.Piece is Bishop)
                {
                    capturedBlackBishops.Count++;
                }

                if (destination.Piece is Queen)
                {
                    capturedBlackQueen.Count++;
                }
            }
        }

        private void UpdateKingPosition(Box destination)
        {
            if (destination.Piece.Color == PieceColor.White)
            {
                positionWhiteKing.X = destination.BoxName[0] - 64;
                positionWhiteKing.Y = destination.BoxName[1] - 48;
            }
            if (destination.Piece.Color == PieceColor.Black)
            {
                positionBlackKing.X = destination.BoxName[0] - 64;
                positionBlackKing.Y = destination.BoxName[1] - 48;
            }
        }

        private void BeginPieceRecapturingIfPawnReachedTheEnd(Box destination)
        {
            // If a white pawn has reached the last line
            if (CurrentPlayersTurn == Turn.White)
            {
                if (destination.BoxName.Contains('H') && destination.Piece is Pawn)
                {
                    if (capturedWhiteRooks.Count + capturedWhiteKnights.Count + capturedWhiteRooks.Count + capturedWhiteQueen.Count > 0)
                    {
                        retakeRow = 8;
                        retakeColumn = destination.BoxName[1] - 48;
                        currentPlayerMustSelect = true;

                        SendMessageAndCreateChatEntryIfItsNotCommand($"{CommandMarker}{CommandStrings.BeginSelection}");

                        var message = string.Format(Strings.UserBeginsSelection, username);
                        OnNotification(message);
                    }
                }
            }

            // If a black pawn has reached the last line
            if (CurrentPlayersTurn == Turn.Black)
            {
                if (destination.BoxName.Contains('A') && destination.Piece is Pawn)
                {
                    if (capturedBlackRooks.Count + capturedBlackKnights.Count + capturedBlackBishops.Count + capturedBlackQueen.Count > 0)
                    {
                        retakeRow = 1;
                        retakeColumn = destination.BoxName[1] - 48;
                        currentPlayerMustSelect = true;

                        SendMessageAndCreateChatEntryIfItsNotCommand($"{CommandMarker}{CommandStrings.BeginSelection}");

                        var message = string.Format(Strings.UserBeginsSelection, username);
                        OnNotification(message);
                    }
                }
            }
        }

        private void EndGameIfCheckMate()
        {
            if (IsCheckmateForProvidedColor(PieceColor.White))
            {
                OnNotification(Strings.CheckmateWhite);

                Thread.Sleep(2000);
                var newGameInvoker = new MethodInvoker(NewGame);

                Invoke(newGameInvoker);
                SendMessageAndCreateChatEntryIfItsNotCommand($"{CommandMarker}{CommandStrings.NewGame}");
            }
            if (IsCheckmateForProvidedColor(PieceColor.Black))
            {
                OnNotification(Strings.CheckmateBlack);

                Thread.Sleep(2000);
                var newGameInvoker = new MethodInvoker(NewGame);

                Invoke(newGameInvoker);
                SendMessageAndCreateChatEntryIfItsNotCommand($"{CommandMarker}{CommandStrings.NewGame}");
            }
        }

        private void SendChatMessage(object sender, EventArgs e)
        {
            SendMessageAndCreateChatEntryIfItsNotCommand(textBoxChatInput.Text);
            textBoxChatInput.Clear();
        }

        private bool IsCheckmateForProvidedColor(PieceColor providedColor)
        {
            for (int row = 1; row <= 8; row++)
            {
                for (int column = 1; column <= 8; column++)
                {
                    if (ChessBoard[row, column].Piece != null && ChessBoard[row, column].Piece.Color == providedColor)
                    {
                        var location = new Point(row, column);
                        var kingPosition = providedColor == PieceColor.White ? positionWhiteKing : positionBlackKing;
                        ChessBoard[row, column].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, location, kingPosition);

                        if (ChessBoard[row, column].Piece.CanMove)
                        {
                            ResetChessBoardBoxesColors();
                            ChessBoard[row, column].Piece.CanMove = false;
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void ResetChessBoardBoxesColors()
        {
            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    if ((row % 2 == 0 && column % 2 == 0) || (row % 2 == 1 && column % 2 == 1))
                    {
                        ChessBoard[row, column].BoxBackgroundColor = BoxColorDark;
                    }
                    else
                    {
                        ChessBoard[row, column].BoxBackgroundColor = BoxColorLight;
                    }
                }
            }
        }

        private void NextTurn()
        {
            CurrentPlayersTurn++;

            if (CurrentPlayersTurn > Turn.Black)
            {
                CurrentPlayersTurn = Turn.White;
            }
        }

        private void SetChessBoardBoxesAsUnavailable()
        {
            for (int row = 1; row <= 8; row++)
            {
                for (int column = 1; column <= 8; column++)
                {
                    ChessBoard[row, column].Available = false;
                }
            }
        }

        private void BoxClick(object sender, EventArgs e)
        {
            var clickedBoxObject = (Box)sender;

            if (currentPlayerMustSelect || opponentMustSelect)
            {
                return;
            }

            // First click on a box with a chess piece
            if (clickCounter == 0 && clickedBoxObject.Piece != null && (int)CurrentPlayersTurn == (int)clickedBoxObject.Piece.Color && isCurrentPlayersTurnToMove)
            {
                var row = clickedBoxObject.Row;
                var column = clickedBoxObject.Column;
                var location = new Point(row, column);

                Point kingPosition;
                if (clickedBoxObject.Piece.Color == PieceColor.White)
                {
                    kingPosition = positionWhiteKing;
                }
                else
                {
                    kingPosition = positionBlackKing;
                }

                clickedBoxObject.Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, location, kingPosition);
                if (clickedBoxObject.Piece.CanMove)
                {
                    FirstClickedBox = clickedBoxObject;
                    clickCounter++;
                    return;
                }
            }

            // Second click on a box
            if (clickCounter == 1)
            {
                // Click on the same box => Cancel moving current chess piece
                if (clickedBoxObject == FirstClickedBox)
                {
                    SetChessBoardBoxesAsUnavailable();
                    ResetChessBoardBoxesColors();
                }

                // Click on a different box where the current piece can be moved
                if (clickedBoxObject != FirstClickedBox && clickedBoxObject.Available)
                {
                    CurrentPlayerMovePiece(FirstClickedBox, clickedBoxObject);
                }

                clickCounter = 0;
            }
        }

        private void CapturedPieceBoxClick(object sender, EventArgs e)
        {
            var clickedCapturedPieceBox = (CapturedPieceBox)sender;

            if (currentPlayerMustSelect && clickedCapturedPieceBox.Count > 0)
            {
                Utilities.RetakeCapturedPiece(clickedCapturedPieceBox, ChessBoard[retakeRow, retakeColumn]);
                currentPlayerMustSelect = false;

                var recapturedPiece = ChessBoard[retakeRow, retakeColumn].Piece;
                if (recapturedPiece != null)
                {
                    var recaptureMessage = $"{CommandMarker}{CommandStrings.Selection} {retakeRow} {retakeColumn} {recapturedPiece.Abbreviation}";
                    SendMessageAndCreateChatEntryIfItsNotCommand(recaptureMessage);
                }
            }
        }

        public void SetUsernameAndNotifyClient(string username)
        {
            this.username = username;
            var message = $"{CommandMarker}{CommandStrings.ChangedUsername}{username}";
            networkManager.SendMessage(message);
        }

        public void SetColorsAndNotifyClient(string colorsString)
        {
            var colors = colorsString.Split(' ');
            var currentPlayerColor = Convert.ToInt32(colors[0]);

            if (currentPlayerColor == (int)Turn.White)
            {
                CurrentPlayersTurn = Turn.White;
                OpponentsTurn = Turn.Black;
                isCurrentPlayersTurnToMove = true;
            }
            else
            {
                CurrentPlayersTurn = Turn.Black;
                OpponentsTurn = Turn.White;
                isCurrentPlayersTurnToMove = false;
            }

            var message = $"{CommandMarker}{CommandStrings.ChangedColors} {colors[1]} {colors[0]}";
            networkManager.SendMessage(message);
        }

        public void RequestNewGame()
        {
            if (!isNewGameRequested)
            {
                SendMessageAndCreateChatEntryIfItsNotCommand($"{CommandMarker}{CommandStrings.RequestNewGame}");
            }
            else
            {
                NewGame();
                isNewGameRequested = false;
                SendMessageAndCreateChatEntryIfItsNotCommand($"{CommandMarker}{CommandStrings.NewGame}");
            }
        }

        public void StopNetworkStuff()
        {
            if (networkManager != null)
            {
                networkManager.Stop();
            }
        }
    }
}
