﻿using System;
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

namespace ChessApplication.Main
{
    public partial class Main : UserControl
    {
        public bool NetworkManagerIsInitialized => networkManager != null;

        private NetworkManager networkManager;
        private const string CommandMarker = Network.Constants.CommandMarker;

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

        public string PlayerUsername { get; private set; }
        private string usernameOpponent;

        private CapturedPieceBox capturedWhitePawns, capturedWhiteRooks, capturedWhiteKnights, capturedWhiteBishops, capturedWhiteQueen;
        private CapturedPieceBox capturedBlackPawns, capturedBlackRooks, capturedBlackKnights, capturedBlackBishops, capturedBlackQueen;

        private Box FirstClickedBox { get; set; }
        private Chessboard ChessBoard { get; set; }

        private SoundPlayer MoveSound1 { get; } = new SoundPlayer(Properties.Resources.movesound1);
        private SoundPlayer MoveSound2 { get; } = new SoundPlayer(Properties.Resources.movesound2);

        public delegate void MoveMade(Box origin, Box destination);
        public MoveMade OnMadeMove { get; set; }

        public delegate void ReceivedChatMessage(string username, string message);
        public ReceivedChatMessage OnReceivedChatMessage { get; set; }

        public delegate void Notification(string notificationMessage);
        public Notification OnNotification { get; set; }

        public Main(UserType userType, string hostname = null)
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

        private void NotifyNewGameIsRequested()
        {
            var message = string.Format(Strings.UserRequestsNewGame, usernameOpponent);
            MessageBox.Show(message);
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
        }

        private void InitializeChessBoard()
        {
            ChessBoard = new Chessboard();

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    panelChessBoard.Controls.Add(ChessBoard[row, column]);
                }
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

        private void SendCommand(string command)
        {
            if (command.StartsWith(CommandMarker))
            {
                networkManager.SendMessage(command);
            }
        }

        public void SendMessageToOpponent(string message)
        {
            if (!message.StartsWith(CommandMarker))
            {
                networkManager.SendMessage(message);
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

            var command = $"{CommandMarker}{CommandStrings.MoveMade}{origin.BoxName} {destination.BoxName}";
            SendCommand(command);

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
                ChessBoard.PositionWhiteKing = new Point
                {
                    X = destination.BoxName[0] - 64,
                    Y = destination.BoxName[1] - 48
                };
            }
            if (destination.Piece.Color == PieceColor.Black)
            {
                ChessBoard.PositionBlackKing = new Point
                {
                    X = destination.BoxName[0] - 64,
                    Y = destination.BoxName[1] - 48
                };
            }
        }

        private void BeginPieceRecapturingIfPawnReachedTheEnd(Box destination)
        {
            // If a white pawn has reached the last line
            if (CurrentPlayersTurn == Turn.White)
            {
                if (Enumerable.Contains(destination.BoxName, 'H') && destination.Piece is Pawn)
                {
                    if (capturedWhiteRooks.Count + capturedWhiteKnights.Count + capturedWhiteRooks.Count + capturedWhiteQueen.Count > 0)
                    {
                        retakeRow = 8;
                        retakeColumn = destination.BoxName[1] - 48;
                        currentPlayerMustSelect = true;

                        SendCommand($"{CommandMarker}{CommandStrings.BeginSelection}");

                        var message = string.Format(Strings.UserBeginsSelection, PlayerUsername);
                        OnNotification(message);
                    }
                }
            }

            // If a black pawn has reached the last line
            if (CurrentPlayersTurn == Turn.Black)
            {
                if (Enumerable.Contains(destination.BoxName, 'A') && destination.Piece is Pawn)
                {
                    if (capturedBlackRooks.Count + capturedBlackKnights.Count + capturedBlackBishops.Count + capturedBlackQueen.Count > 0)
                    {
                        retakeRow = 1;
                        retakeColumn = destination.BoxName[1] - 48;
                        currentPlayerMustSelect = true;

                        SendCommand($"{CommandMarker}{CommandStrings.BeginSelection}");

                        var message = string.Format(Strings.UserBeginsSelection, PlayerUsername);
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
                SendCommand($"{CommandMarker}{CommandStrings.NewGame}");
            }
            if (IsCheckmateForProvidedColor(PieceColor.Black))
            {
                OnNotification(Strings.CheckmateBlack);

                Thread.Sleep(2000);
                var newGameInvoker = new MethodInvoker(NewGame);

                Invoke(newGameInvoker);
                SendCommand($"{CommandMarker}{CommandStrings.NewGame}");
            }
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
                        var kingPosition = providedColor == PieceColor.White ? ChessBoard.PositionWhiteKing : ChessBoard.PositionBlackKing;
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
                        ChessBoard[row, column].BoxBackgroundColor = Constants.BoxColorDark;
                    }
                    else
                    {
                        ChessBoard[row, column].BoxBackgroundColor = Constants.BoxColorLight;
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
                    kingPosition = ChessBoard.PositionWhiteKing;
                }
                else
                {
                    kingPosition = ChessBoard.PositionBlackKing;
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
                    var command = $"{CommandMarker}{CommandStrings.Selection} {retakeRow} {retakeColumn} {recapturedPiece.Abbreviation}";
                    SendCommand(command);
                }
            }
        }

        public void SetUsernameAndNotifyClient(string username)
        {
            PlayerUsername = username;
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
                SendCommand($"{CommandMarker}{CommandStrings.RequestNewGame}");
            }
            else
            {
                NewGame();
                isNewGameRequested = false;
                SendCommand($"{CommandMarker}{CommandStrings.NewGame}");
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