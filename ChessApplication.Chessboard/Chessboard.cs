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

        private Box A1, A2, A3, A4, A5, A6, A7, A8, B1, B2, B3, B4, B5, B6, B7, B8;
        private Box H1, H2, H3, H4, H5, H6, H7, H8, G1, G2, G3, G4, G5, G6, G7, G8;

        private Box C1, C2, C3, C4, C5, C6, C7, C8, D1, D2, D3, D4, D5, D6, D7, D8;
        private Box E1, E2, E3, E4, E5, E6, E7, E8, F1, F2, F3, F4, F5, F6, F7, F8;

        private CapturedPieceBox capturedWhitePawns, capturedWhiteRooks, capturedWhiteKnights, capturedWhiteBishops, capturedWhiteQueen;
        private CapturedPieceBox capturedBlackPawns, capturedBlackRooks, capturedBlackKnights, capturedBlackBishops, capturedBlackQueen;

        private Box FirstClickedBox { get; set; }
        private Box[,] ChessBoard { get; set; }

        private Color BoxColorLight { get; } = Color.Silver;
        private Color BoxColorDark { get; } = Color.FromArgb(132, 107, 86);

        private SoundPlayer MoveSound1 { get; } = new SoundPlayer(Properties.Resources.MoveSound1);
        private SoundPlayer MoveSound2 { get; } = new SoundPlayer(Properties.Resources.MoveSound2);

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
                    chatBox.AppendText(usernameOpponent + " must retake a piece from Spoils o' war\r\n");
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
                var newGame = new MethodInvoker(NewGame);
                Invoke(newGame);
            };

            networkManager.OnChatMessage += message =>
            {
                var chatMessage = new MethodInvoker(() => chatBox.Text += $"{usernameOpponent}: {message}\r\n");
                Invoke(chatMessage);
            };
        }

        private void NotifyNewGameIsRequested()
        {
            MessageBox.Show($"{usernameOpponent} wishes a new game. If you agree, go to File -> New game");
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
            InitializeBoxes();
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

        private void InitializeBoxes()
        {
            A1 = new Box("A1", new Rook(PieceColor.White));
            A2 = new Box("A2", new Knight(PieceColor.White));
            A3 = new Box("A3", new Bishop(PieceColor.White));
            A4 = new Box("A4", new Queen(PieceColor.White));
            A5 = new Box("A5", new King(PieceColor.White));
            A6 = new Box("A6", new Bishop(PieceColor.White));
            A7 = new Box("A7", new Knight(PieceColor.White));
            A8 = new Box("A8", new Rook(PieceColor.White));

            B1 = new Box("B1", new Pawn(PieceColor.White));
            B2 = new Box("B2", new Pawn(PieceColor.White));
            B3 = new Box("B3", new Pawn(PieceColor.White));
            B4 = new Box("B4", new Pawn(PieceColor.White));
            B5 = new Box("B5", new Pawn(PieceColor.White));
            B6 = new Box("B6", new Pawn(PieceColor.White));
            B7 = new Box("B7", new Pawn(PieceColor.White));
            B8 = new Box("B8", new Pawn(PieceColor.White));

            G1 = new Box("G1", new Pawn(PieceColor.Black));
            G2 = new Box("G2", new Pawn(PieceColor.Black));
            G3 = new Box("G3", new Pawn(PieceColor.Black));
            G4 = new Box("G4", new Pawn(PieceColor.Black));
            G5 = new Box("G5", new Pawn(PieceColor.Black));
            G6 = new Box("G6", new Pawn(PieceColor.Black));
            G7 = new Box("G7", new Pawn(PieceColor.Black));
            G8 = new Box("G8", new Pawn(PieceColor.Black));

            H1 = new Box("H1", new Rook(PieceColor.Black));
            H2 = new Box("H2", new Knight(PieceColor.Black));
            H3 = new Box("H3", new Bishop(PieceColor.Black));
            H4 = new Box("H4", new King(PieceColor.Black));
            H5 = new Box("H5", new Queen(PieceColor.Black));
            H6 = new Box("H6", new Bishop(PieceColor.Black));
            H7 = new Box("H7", new Knight(PieceColor.Black));
            H8 = new Box("H8", new Rook(PieceColor.Black));

            // ------

            C1 = new Box("C1");
            C2 = new Box("C2");
            C3 = new Box("C3");
            C4 = new Box("C4");
            C5 = new Box("C5");
            C6 = new Box("C6");
            C7 = new Box("C7");
            C8 = new Box("C8");

            D1 = new Box("D1");
            D2 = new Box("D2");
            D3 = new Box("D3");
            D4 = new Box("D4");
            D5 = new Box("D5");
            D6 = new Box("D6");
            D7 = new Box("D7");
            D8 = new Box("D8");

            E1 = new Box("E1");
            E2 = new Box("E2");
            E3 = new Box("E3");
            E4 = new Box("E4");
            E5 = new Box("E5");
            E6 = new Box("E6");
            E7 = new Box("E7");
            E8 = new Box("E8");

            F1 = new Box("F1");
            F2 = new Box("F2");
            F3 = new Box("F3");
            F4 = new Box("F4");
            F5 = new Box("F5");
            F6 = new Box("F6");
            F7 = new Box("F7");
            F8 = new Box("F8");

            // ------

            panelChessBoard.Controls.Clear();

            panelChessBoard.Controls.Add(A1);
            panelChessBoard.Controls.Add(A2);
            panelChessBoard.Controls.Add(A3);
            panelChessBoard.Controls.Add(A4);
            panelChessBoard.Controls.Add(A5);
            panelChessBoard.Controls.Add(A6);
            panelChessBoard.Controls.Add(A7);
            panelChessBoard.Controls.Add(A8);

            panelChessBoard.Controls.Add(B1);
            panelChessBoard.Controls.Add(B2);
            panelChessBoard.Controls.Add(B3);
            panelChessBoard.Controls.Add(B4);
            panelChessBoard.Controls.Add(B5);
            panelChessBoard.Controls.Add(B6);
            panelChessBoard.Controls.Add(B7);
            panelChessBoard.Controls.Add(B8);

            panelChessBoard.Controls.Add(C1);
            panelChessBoard.Controls.Add(C2);
            panelChessBoard.Controls.Add(C3);
            panelChessBoard.Controls.Add(C4);
            panelChessBoard.Controls.Add(C5);
            panelChessBoard.Controls.Add(C6);
            panelChessBoard.Controls.Add(C7);
            panelChessBoard.Controls.Add(C8);

            panelChessBoard.Controls.Add(D1);
            panelChessBoard.Controls.Add(D2);
            panelChessBoard.Controls.Add(D3);
            panelChessBoard.Controls.Add(D4);
            panelChessBoard.Controls.Add(D5);
            panelChessBoard.Controls.Add(D6);
            panelChessBoard.Controls.Add(D7);
            panelChessBoard.Controls.Add(D8);

            panelChessBoard.Controls.Add(E1);
            panelChessBoard.Controls.Add(E2);
            panelChessBoard.Controls.Add(E3);
            panelChessBoard.Controls.Add(E4);
            panelChessBoard.Controls.Add(E5);
            panelChessBoard.Controls.Add(E6);
            panelChessBoard.Controls.Add(E7);
            panelChessBoard.Controls.Add(E8);

            panelChessBoard.Controls.Add(F1);
            panelChessBoard.Controls.Add(F2);
            panelChessBoard.Controls.Add(F3);
            panelChessBoard.Controls.Add(F4);
            panelChessBoard.Controls.Add(F5);
            panelChessBoard.Controls.Add(F6);
            panelChessBoard.Controls.Add(F7);
            panelChessBoard.Controls.Add(F8);

            panelChessBoard.Controls.Add(G1);
            panelChessBoard.Controls.Add(G2);
            panelChessBoard.Controls.Add(G3);
            panelChessBoard.Controls.Add(G4);
            panelChessBoard.Controls.Add(G5);
            panelChessBoard.Controls.Add(G6);
            panelChessBoard.Controls.Add(G7);
            panelChessBoard.Controls.Add(G8);

            panelChessBoard.Controls.Add(H1);
            panelChessBoard.Controls.Add(H2);
            panelChessBoard.Controls.Add(H3);
            panelChessBoard.Controls.Add(H4);
            panelChessBoard.Controls.Add(H5);
            panelChessBoard.Controls.Add(H6);
            panelChessBoard.Controls.Add(H7);
            panelChessBoard.Controls.Add(H8);

            // ------

            H1.Location = new Point(0, 0);
            H2.Location = new Point(64, 0);
            H3.Location = new Point(128, 0);
            H4.Location = new Point(192, 0);
            H5.Location = new Point(256, 0);
            H6.Location = new Point(320, 0);
            H7.Location = new Point(384, 0);
            H8.Location = new Point(448, 0);

            G1.Location = new Point(0, 64);
            G2.Location = new Point(64, 64);
            G3.Location = new Point(128, 64);
            G4.Location = new Point(192, 64);
            G5.Location = new Point(256, 64);
            G6.Location = new Point(320, 64);
            G7.Location = new Point(384, 64);
            G8.Location = new Point(448, 64);

            F1.Location = new Point(0, 128);
            F2.Location = new Point(64, 128);
            F3.Location = new Point(128, 128);
            F4.Location = new Point(192, 128);
            F5.Location = new Point(256, 128);
            F6.Location = new Point(320, 128);
            F7.Location = new Point(384, 128);
            F8.Location = new Point(448, 128);

            E1.Location = new Point(0, 192);
            E2.Location = new Point(64, 192);
            E3.Location = new Point(128, 192);
            E4.Location = new Point(192, 192);
            E5.Location = new Point(256, 192);
            E6.Location = new Point(320, 192);
            E7.Location = new Point(384, 192);
            E8.Location = new Point(448, 192);

            D1.Location = new Point(0, 256);
            D2.Location = new Point(64, 256);
            D3.Location = new Point(128, 256);
            D4.Location = new Point(192, 256);
            D5.Location = new Point(256, 256);
            D6.Location = new Point(320, 256);
            D7.Location = new Point(384, 256);
            D8.Location = new Point(448, 256);

            C1.Location = new Point(0, 320);
            C2.Location = new Point(64, 320);
            C3.Location = new Point(128, 320);
            C4.Location = new Point(192, 320);
            C5.Location = new Point(256, 320);
            C6.Location = new Point(320, 320);
            C7.Location = new Point(384, 320);
            C8.Location = new Point(448, 320);

            B1.Location = new Point(0, 384);
            B2.Location = new Point(64, 384);
            B3.Location = new Point(128, 384);
            B4.Location = new Point(192, 384);
            B5.Location = new Point(256, 384);
            B6.Location = new Point(320, 384);
            B7.Location = new Point(384, 384);
            B8.Location = new Point(448, 384);

            A1.Location = new Point(0, 448);
            A2.Location = new Point(64, 448);
            A3.Location = new Point(128, 448);
            A4.Location = new Point(192, 448);
            A5.Location = new Point(256, 448);
            A6.Location = new Point(320, 448);
            A7.Location = new Point(384, 448);
            A8.Location = new Point(448, 448);
        }

        private void InitializeChessBoard()
        {
            ChessBoard = new Box[10, 10];

            ChessBoard[1, 1] = A1;
            ChessBoard[1, 2] = A2;
            ChessBoard[1, 3] = A3;
            ChessBoard[1, 4] = A4;
            ChessBoard[1, 5] = A5;
            ChessBoard[1, 6] = A6;
            ChessBoard[1, 7] = A7;
            ChessBoard[1, 8] = A8;

            ChessBoard[2, 1] = B1;
            ChessBoard[2, 2] = B2;
            ChessBoard[2, 3] = B3;
            ChessBoard[2, 4] = B4;
            ChessBoard[2, 5] = B5;
            ChessBoard[2, 6] = B6;
            ChessBoard[2, 7] = B7;
            ChessBoard[2, 8] = B8;

            ChessBoard[3, 1] = C1;
            ChessBoard[3, 2] = C2;
            ChessBoard[3, 3] = C3;
            ChessBoard[3, 4] = C4;
            ChessBoard[3, 5] = C5;
            ChessBoard[3, 6] = C6;
            ChessBoard[3, 7] = C7;
            ChessBoard[3, 8] = C8;

            ChessBoard[4, 1] = D1;
            ChessBoard[4, 2] = D2;
            ChessBoard[4, 3] = D3;
            ChessBoard[4, 4] = D4;
            ChessBoard[4, 5] = D5;
            ChessBoard[4, 6] = D6;
            ChessBoard[4, 7] = D7;
            ChessBoard[4, 8] = D8;

            ChessBoard[5, 1] = E1;
            ChessBoard[5, 2] = E2;
            ChessBoard[5, 3] = E3;
            ChessBoard[5, 4] = E4;
            ChessBoard[5, 5] = E5;
            ChessBoard[5, 6] = E6;
            ChessBoard[5, 7] = E7;
            ChessBoard[5, 8] = E8;

            ChessBoard[6, 1] = F1;
            ChessBoard[6, 2] = F2;
            ChessBoard[6, 3] = F3;
            ChessBoard[6, 4] = F4;
            ChessBoard[6, 5] = F5;
            ChessBoard[6, 6] = F6;
            ChessBoard[6, 7] = F7;
            ChessBoard[6, 8] = F8;

            ChessBoard[7, 1] = G1;
            ChessBoard[7, 2] = G2;
            ChessBoard[7, 3] = G3;
            ChessBoard[7, 4] = G4;
            ChessBoard[7, 5] = G5;
            ChessBoard[7, 6] = G6;
            ChessBoard[7, 7] = G7;
            ChessBoard[7, 8] = G8;

            ChessBoard[8, 1] = H1;
            ChessBoard[8, 2] = H2;
            ChessBoard[8, 3] = H3;
            ChessBoard[8, 4] = H4;
            ChessBoard[8, 5] = H5;
            ChessBoard[8, 6] = H6;
            ChessBoard[8, 7] = H7;
            ChessBoard[8, 8] = H8;

            for (int row = 1; row <= 8; row++)
            {
                for (int column = 1; row <= 8; row++)
                {
                    ChessBoard[row, column].BeginnersMode = BeginnersMode;
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

        private void SendMessageAndCreateChatEntryIfItsNotCommand(string message)
        {
            // If the message to be sent isn't a command, create a new chat entry
            if (!message.StartsWith(CommandMarker))
            {
                chatBox.AppendText(username + ": " + message + Environment.NewLine);
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

            labelTurn.Text = CurrentPlayersTurn == Turn.White ? "White's turn" : "Black's turn";

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
                labelTurn.Text = "White's turn";
            }
            else
            {
                CurrentPlayersTurn = Turn.Black;
                labelTurn.Text = "Black's turn";
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
            historyEntries.AddEntry(origin, destination);

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
                        chatBox.AppendText(username + " must select a chess piece from Spoils o' war" + Environment.NewLine);
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
                        chatBox.AppendText(username + " must select a chess piece from Spoils o' war" + Environment.NewLine);
                    }
                }
            }
        }

        private void EndGameIfCheckMate()
        {
            if (IsCheckmateForProvidedColor(PieceColor.White))
            {
                chatBox.AppendText("Checkmate! Black has won");
                Thread.Sleep(2000);
                var newGameInvoker = new MethodInvoker(NewGame);

                Invoke(newGameInvoker);
                SendMessageAndCreateChatEntryIfItsNotCommand($"{CommandMarker}{CommandStrings.NewGame}");
            }
            if (IsCheckmateForProvidedColor(PieceColor.Black))
            {
                chatBox.AppendText("Checkmate! White has won");
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
                    var recaptureMessage = $"{CommandMarker}{CommandStrings.Selection} {retakeRow} {retakeColumn} ";

                    if (recapturedPiece is Rook)
                    {
                        recaptureMessage += "T";
                    }

                    if (recapturedPiece is Knight)
                    {
                        recaptureMessage += "C";
                    }

                    if (recapturedPiece is Bishop)
                    {
                        recaptureMessage += "N";
                    }

                    if (recapturedPiece is Queen)
                    {
                        recaptureMessage += "R";
                    }

                    if (recapturedPiece.Color == PieceColor.White)
                    {
                        recaptureMessage += "A";
                    }

                    if (recapturedPiece.Color == PieceColor.Black)
                    {
                        recaptureMessage += "N";
                    }

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
