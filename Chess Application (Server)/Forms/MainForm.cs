using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Chess_Application.Classes;
using Chess_Application.Enums;
using Chess_Application.UserControls;
using System.Drawing.Imaging;

namespace Chess_Application
{

    public partial class MainForm : Form
    {
        Panel menuContainer;
        MainMenu mainMenu;

        public static Point pozitieRegeAlb = new Point();
        public static Point pozitieRegeNegru = new Point();

        int clickCounter;
        bool isCurrentPlayersTurnToMove = true;

        int retakeRow, retakeColumn; // Will hold the row and column of where retaken pieces will be placed

        public static bool markAvailableBoxesAsGreen = true; // Made static, because it's required elsewhere

        bool soundEnabled = true;
        bool incepeJocNou = false;
        bool currentPlayerMustSelect = false;
        bool opponentMustSelect = false;

        public static Turn currentPlayersTurn = Turn.White;
        public static Turn opponentsTurn = Turn.Black;

        string username = "Server";
        string usernameClient = "Client";

        ChessPiece whitePawn1, whitePawn2, whitePawn3, whitePawn4, whitePawn5, whitePawn6, whitePawn7, whitePawn8;
        ChessPiece whiteRook1, whiteRook2;
        ChessPiece whiteBishop1, whiteBishop2;
        ChessPiece whiteKnight1, whiteKnight2;
        ChessPiece whiteQueen, whiteKing;

        ChessPiece blackPawn1, blackPawn2, blackPawn3, blackPawn4, blackPawn5, blackPawn6, blackPawn7, blackPawn8;
        ChessPiece blackRook1, blackRook2;
        ChessPiece blackBishop1, blackBishop2;
        ChessPiece blackKnight1, blackKnight2;
        ChessPiece blackQueen, blackKing;

        Box orig;
        
        Box A1, A2, A3, A4, A5, A6, A7, A8, B1, B2, B3, B4, B5, B6, B7, B8;
        Box H1, H2, H3, H4, H5, H6, H7, H8, G1, G2, G3, G4, G5, G6, G7, G8;

        Box C1, C2, C3, C4, C5, C6, C7, C8, D1, D2, D3, D4, D5, D6, D7, D8;
        Box E1, E2, E3, E4, E5, E6, E7, E8, F1, F2, F3, F4, F5, F6, F7, F8;

        CapturedPieceBox capturedWhitePawns, capturedWhiteRooks, capturedWhiteKnights, capturedWhiteBishops, capturedWhiteQueen;
        CapturedPieceBox capturedBlackPawns, capturedBlackRooks, capturedBlackKnights, capturedBlackBishops, capturedBlackQueen;

        Box[,] ChessBoard;

        Color BoxColorLight = Color.Silver;
        Color BoxColorDark  = Color.FromArgb(132, 107, 86);

        SoundPlayer moveSound1 = new SoundPlayer(Properties.Resources.MoveSound1);
        SoundPlayer moveSound2 = new SoundPlayer(Properties.Resources.MoveSound2);

        TcpListener serverTcpListener;
        Thread networkThread;
        NetworkStream streamServer;
        bool isNetworkThreadRunning;

        public MainForm()
        {
            InitializeComponent();

            serverTcpListener = new TcpListener(System.Net.IPAddress.Any, 3000);
            serverTcpListener.Start();
            networkThread = new Thread( new ThreadStart(ServerListen) );
            isNetworkThreadRunning = true;
            networkThread.Start();

            mainMenu = new MainMenu(this);

            menuContainer = new Panel();
            menuContainer.MinimumSize = new Size(this.Width, this.Height);
            menuContainer.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            menuContainer.Controls.Add(mainMenu);

            mainMenu.MinimumSize = new Size(this.Width, this.Height);
            mainMenu.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            mainMenu.AutoSize = true;
            mainMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Controls.Add(menuContainer);

            menuContainer.BringToFront();

            InitializeChessPieces();

            PrepareCapturedPiecesArea();

            NewGame();

            activeazaToolStripMenuItem.Available = false;
            activeazalToolStripMenuItem.Available = false;
        }

        /// <summary>
        /// Method responsible for rearanging the chess board for a new game.
        /// </summary>
        public void NewGame()
        {
            ResetBoxes();

            InitializeChessBoard();

            #region Assign click event to chessboard pictureboxes

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    ChessBoard[i, j].Click += BoxClick;
                }
            }

            #endregion

            ResetBoxesColors(ChessBoard);

            clickCounter = 0;

            if (opponentsTurn == Turn.Black)
            {
                currentPlayersTurn = Turn.White;
                isCurrentPlayersTurnToMove = true;
            }
            else
            {
                currentPlayersTurn = Turn.Black;
                isCurrentPlayersTurnToMove = false;
            }

            pozitieRegeAlb.X = 1;
            pozitieRegeAlb.Y = 5;

            pozitieRegeNegru.X = 8;
            pozitieRegeNegru.Y = 4;

            SetAllBoxesAsUnavailable(ChessBoard);

            #region Reset captured pieces

            capturedWhitePawns.Count = 0;
            capturedWhiteRooks.Count = 0;
            capturedWhiteKnights.Count = 0;
            capturedWhiteBishops.Count = 0;
            capturedWhiteQueen.Count = 0;

            capturedBlackPawns.Count = 0;
            capturedBlackRooks.Count = 0;
            capturedBlackKnights.Count = 0;
            capturedBlackBishops.Count = 0;
            capturedBlackQueen.Count = 0;

            #endregion
        }

        void ResetBoxes()
        {
            A1 = new Box("A1", whiteRook1);
            A2 = new Box("A2", whiteKnight1);
            A3 = new Box("A3", whiteBishop1);
            A4 = new Box("A4", whiteQueen);
            A5 = new Box("A5", whiteKing);
            A6 = new Box("A6", whiteBishop2);
            A7 = new Box("A7", whiteKnight2);
            A8 = new Box("A8", whiteRook2);

            B1 = new Box("B1", whitePawn1);
            B2 = new Box("B2", whitePawn2);
            B3 = new Box("B3", whitePawn3);
            B4 = new Box("B4", whitePawn4);
            B5 = new Box("B5", whitePawn5);
            B6 = new Box("B6", whitePawn6);
            B7 = new Box("B7", whitePawn7);
            B8 = new Box("B8", whitePawn8);

            G1 = new Box("G1", blackPawn1);
            G2 = new Box("G2", blackPawn2);
            G3 = new Box("G3", blackPawn3);
            G4 = new Box("G4", blackPawn4);
            G5 = new Box("G5", blackPawn5);
            G6 = new Box("G6", blackPawn6);
            G7 = new Box("G7", blackPawn7);
            G8 = new Box("G8", blackPawn8);

            H1 = new Box("H1", blackRook1);
            H2 = new Box("H2", blackKnight1);
            H3 = new Box("H3", blackBishop1);
            H4 = new Box("H4", blackKing);
            H5 = new Box("H5", blackQueen);
            H6 = new Box("H6", blackBishop2);
            H7 = new Box("H7", blackKnight2);
            H8 = new Box("H8", blackRook2);

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

        void InitializeChessBoard()
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
        }

        void InitializeChessPieces()
        {
            whiteRook1 = new Rook(PieceColor.White);
            whiteRook2 = new Rook(PieceColor.White);
            whiteKnight1 = new Knight(PieceColor.White);
            whiteKnight2 = new Knight(PieceColor.White);
            whiteBishop1 = new Bishop(PieceColor.White);
            whiteBishop2 = new Bishop(PieceColor.White);
            whiteQueen = new Queen(PieceColor.White);
            whiteKing = new King(PieceColor.White);

            whitePawn1 = new Pawn(PieceColor.White);
            whitePawn2 = new Pawn(PieceColor.White);
            whitePawn3 = new Pawn(PieceColor.White);
            whitePawn4 = new Pawn(PieceColor.White);
            whitePawn5 = new Pawn(PieceColor.White);
            whitePawn6 = new Pawn(PieceColor.White);
            whitePawn7 = new Pawn(PieceColor.White);
            whitePawn8 = new Pawn(PieceColor.White);


            blackRook1 = new Rook(PieceColor.Black);
            blackRook2 = new Rook(PieceColor.Black);
            blackKnight1 = new Knight(PieceColor.Black);
            blackKnight2 = new Knight(PieceColor.Black);
            blackBishop1 = new Bishop(PieceColor.Black);
            blackBishop2 = new Bishop(PieceColor.Black);
            blackQueen = new Queen(PieceColor.Black);
            blackKing = new King(PieceColor.Black);

            blackPawn1 = new Pawn(PieceColor.Black);
            blackPawn2 = new Pawn(PieceColor.Black);
            blackPawn3 = new Pawn(PieceColor.Black);
            blackPawn4 = new Pawn(PieceColor.Black);
            blackPawn5 = new Pawn(PieceColor.Black);
            blackPawn6 = new Pawn(PieceColor.Black);
            blackPawn7 = new Pawn(PieceColor.Black);
            blackPawn8 = new Pawn(PieceColor.Black);

        }

        void PrepareCapturedPiecesArea()
        {
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

        #region Network stuff

        /// <summary>
        /// Listens for incoming data and makes decisions based on the received data.
        /// </summary>
        public void ServerListen()
        {
            while (isNetworkThreadRunning)
            {
                try
                {
                    Socket socketServer = serverTcpListener.AcceptSocket();
                    streamServer = new NetworkStream(socketServer);
                    StreamReader streamReader = new StreamReader(streamServer);

                    while (isNetworkThreadRunning)
                    {
                        string receivedData = streamReader.ReadLine();

                        if (receivedData == null)
                        {
                            break;
                        }
                        
                        // If a command was received
                        if (receivedData.StartsWith("#"))
                        {

                            // Client has disconnected
                            if (receivedData == "#Gata")
                            {
                                isNetworkThreadRunning = false;
                            }

                            // Client has made a move, receiving origin and destination coordinates, then proceeding to replicate the move
                            // e.g. "#B1 B2"
                            if (receivedData.Length == 6)
                            {
                                string[] coordinates = receivedData.Substring(1).Split();

                                int originRow         = Convert.ToInt32( coordinates[0][0] ) - 64;
                                int originColumn      = Convert.ToInt32( coordinates[0][1] ) - 48;
                                int destinationRow    = Convert.ToInt32( coordinates[1][0] ) - 64;
                                int destinationColumn = Convert.ToInt32( coordinates[1][1] ) - 48;

                                MethodInvoker move = new MethodInvoker(
                                    () => OpponentMovePiece( ChessBoard[originRow, originColumn], ChessBoard[destinationRow, destinationColumn] )
                                );

                                Invoke(move);
                            }

                            // Client changed the username, update this info
                            // e.g. "#usernameNewCoolUsername"
                            if (receivedData.StartsWith("#username"))
                            {
                                usernameClient = receivedData.Substring(9);
                            }

                            // Client chose a color, update this info
                            // e.g. "#culori 1 2"
                            if (receivedData.StartsWith("#culori"))
                            {
                                string colorsString = receivedData.Substring(8);
                                string[] colors = colorsString.Split(' ');

                                currentPlayersTurn       = (Turn)Convert.ToInt32(colors[0]);
                                opponentsTurn = (Turn)Convert.ToInt32(colors[1]);

                                isCurrentPlayersTurnToMove = (currentPlayersTurn == Turn.White) ? true : false;
                            }

                            // Client requested a new game
                            if (receivedData == "#request new game")
                            {
                                incepeJocNou = true;
                            }

                            // Client agreed to start a new game
                            if (receivedData == "#new game")
                            {
                                MethodInvoker newGame = new MethodInvoker(
                                    () => NewGame()
                                );

                                Invoke(newGame);
                            }

                            // Client must retake a captured piece
                            if (receivedData == "#selectie")
                            {
                                opponentMustSelect = true;
                                MethodInvoker notify = new MethodInvoker(
                                    () => { textBox1.AppendText(usernameClient + " must retake a piece from Spoils o' war\r\n"); }
                                );

                                Invoke(notify);
                            }

                            // Client has retaken a captured piece
                            if (receivedData == "#final selectie")
                            {
                                opponentMustSelect = false;
                            }

                            // Client has retaken a captured piece, update this info
                            // e.g. "#selectat 2 3 AC"
                            if (receivedData.StartsWith("#selectat"))
                            {
                                string[] retakeDetails = receivedData.Substring(10).Split();

                                int row    = Convert.ToInt32(retakeDetails[0]);
                                int column = Convert.ToInt32(retakeDetails[1]);

                                char retakenPieceColor = retakeDetails[2][1];
                                char retakenPieceType  = retakeDetails[2][0];

                                MethodInvoker updateLabelCapturedPiece = new MethodInvoker(() => { });

                                // White piece
                                if (retakenPieceColor == 'A')
                                {
                                    if (retakenPieceType == 'T')
                                    {
                                        RetakeCapturedPiece(capturedWhiteRooks, ChessBoard[row, column]);

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { capturedWhiteRooks.Count--; }
                                        );
                                    }

                                    if (retakenPieceType == 'C')
                                    {
                                        RetakeCapturedPiece(capturedWhiteKnights, ChessBoard[row, column]);

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { capturedWhiteKnights.Count--; }
                                        );
                                    }

                                    if (retakenPieceType == 'N')
                                    {
                                        RetakeCapturedPiece(capturedWhiteBishops, ChessBoard[row, column]);

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { capturedWhiteBishops.Count--; }
                                        );
                                    }

                                    if (retakenPieceType == 'R')
                                    {
                                        RetakeCapturedPiece(capturedWhiteQueen, ChessBoard[row, column]);

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { capturedWhiteQueen.Count--; }
                                        );
                                    }
                                }

                                // Black piece
                                if (retakenPieceColor == 'N')
                                {
                                    if (retakenPieceType == 'T')
                                    {
                                        RetakeCapturedPiece(capturedBlackRooks, ChessBoard[row, column]);

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { capturedBlackRooks.Count--; }
                                        );
                                    }

                                    if (retakenPieceType == 'C')
                                    {
                                        RetakeCapturedPiece(capturedBlackKnights, ChessBoard[row, column]);

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { capturedBlackKnights.Count--; }
                                        );
                                    }

                                    if (retakenPieceType == 'N')
                                    {
                                        RetakeCapturedPiece(capturedBlackBishops, ChessBoard[row, column]);

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { capturedBlackBishops.Count--; }
                                        );
                                    }

                                    if (retakenPieceType == 'R')
                                    {
                                        RetakeCapturedPiece(capturedBlackQueen, ChessBoard[row, column]);

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { capturedBlackQueen.Count--; }
                                        );
                                    }
                                }

                                Invoke(updateLabelCapturedPiece);
                            }
                        }

                        // If a normal message was received, create a new chat entry
                        else
                        {
                            MethodInvoker newChatMessage = new MethodInvoker(
                                () => { textBox1.Text += string.Format("{0}: {1}\r\n", usernameClient, receivedData); }
                            );

                            Invoke(newChatMessage);
                        }
                    }

                    streamServer.Close();
                }
                catch (Exception)
                {

                }
            }
        }

        #region Username and colors settings

        /// <summary>
        /// Set the server's username, and communicate to the client the new username
        /// </summary>
        /// <param name="username">The new username</param>
        public void SetUsername(string username)
        {
            this.username = username;

            // Communicate to partner the new username
            StreamWriter streamWriter = new StreamWriter(streamServer);
            streamWriter.AutoFlush = true;
            streamWriter.WriteLine("#username" + username);
        }

        /// <summary>
        /// Set the server's color, and communicate to the client the new color configuration
        /// </summary>
        /// <param name="colorsString">The string containing the color configuration (e.g. "1 2" will set server's color to white, and client's color to black)</param>
        public void SetColors(string colorsString)
        {
            string[] colors = colorsString.Split(' ');
            int a = Convert.ToInt32(colors[0]);

            // Player will be controlling white, will have first move
            if (a == 1)
            {
                currentPlayersTurn = Turn.White;
                opponentsTurn = Turn.Black;
                isCurrentPlayersTurnToMove = true;
            }

            // Player will be controlling black, will have second move
            else
            {
                currentPlayersTurn = Turn.Black;
                opponentsTurn = Turn.White;
                isCurrentPlayersTurnToMove = false;
            }

            // Communicate to partner the colors
            StreamWriter streamWriter = new StreamWriter(streamServer);
            streamWriter.AutoFlush = true;
            streamWriter.WriteLine("#culori " + colorsString);
        }

        #endregion

        /// <summary>
        /// Send a message on the stream, and if the message isn't a command, also create a new chat entry.
        /// </summary>
        /// <param name="message">Message to be sent</param>
        void SendMessage(string message)
        {
            StreamWriter writer = new StreamWriter(streamServer);
            writer.AutoFlush = true;

            // If the message to be sent isn't a command, create a new chat entry
            if (!message.StartsWith("#"))
            {
                textBox1.AppendText(username + ": " + message + Environment.NewLine);
            }
                
            writer.WriteLine(message);
        }

        private void tbServerDate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbServerDate.Text != "")
            {
                SendChatMessage(this, new EventArgs());
            }     
        }

        #endregion

        #region ToolStripMenu Items

        #region Options

        /// <summary>
        /// Enables sound, hides the "enable sound" option and displays the "hide sound" option.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableSound(object sender, EventArgs e)
        {
            soundEnabled = true;
            activeazalToolStripMenuItem.Visible = false;
            dezactiveazalToolStripMenuItem.Visible = true;
        }

        /// <summary>
        /// Disables sound, hides the "disable sound" option and displays the "enable sound" option.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisableSound(object sender, EventArgs e)
        {
            soundEnabled = false;
            activeazalToolStripMenuItem.Visible = true;
            dezactiveazalToolStripMenuItem.Visible = false;
        }

        /// <summary>
        /// Enables beginner's mode, hides the enable option and displays the disable option.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableBeginnerMode(object sender, EventArgs e)
        {
            markAvailableBoxesAsGreen = true;
            activeazaToolStripMenuItem.Available = false;
            dezactiveazaToolStripMenuItem.Available = true;
        }

        /// <summary>
        /// Disables beginner's mode, hides the disable option and displays the enable option.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisableBeginnerMode(object sender, EventArgs e)
        {
            markAvailableBoxesAsGreen = false;
            activeazaToolStripMenuItem.Available = true;
            dezactiveazaToolStripMenuItem.Available = false;
        }

        #endregion

        /// <summary>
        /// Requests a new game, or begins a new game if the client has made a new game request. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripNewGame(object sender, EventArgs e)
        {
            // If a new game isn't already requested, proceed to request
            if (!incepeJocNou)
            {
                SendMessage("#request new game");
                SendMessage(" doreste sa-nceapa un joc nou. Daca esti de acord, File->New Game.");

            }

            // If a new game was already requested, fulfill that request
            else
            {
                NewGame();
                incepeJocNou = false;
                SendMessage("#new game");
            }
        }

        private void ToolStripQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Chess pieces movement

        /// <summary>
        /// Method called when the current player moves a chess piece.
        /// </summary>
        /// <param name="origine"></param>
        /// <param name="destinatie"></param>
        void MovePiece(Box origin, Box destination)
        {
            if (destination.Piece != null)
            {
                UpdateCapturedPiecesCounter(destination);
            }

            string message = string.Format("#{0} {1}", origin.BoxName, destination.BoxName);
            SendMessage(message);

            ResetBoxesColors(ChessBoard);
            PerformMove(origin, destination);

            if (destination.Piece is King)
            {
                UpdateKingPosition(destination);
            }

            BeginPieceRecapturingIfPawnReachedTheEnd(destination);

            NextTurn();
            SetAllBoxesAsUnavailable(ChessBoard);
            ResetBoxesColors(ChessBoard);

            isCurrentPlayersTurnToMove = false;
            currentPlayersTurn = opponentsTurn;

            if (currentPlayersTurn == Turn.White)
            {
                labelRand.Text = "White's turn";
            }
            else
            {
                labelRand.Text = "Black's turn";
            }

            if (soundEnabled)
            {
                moveSound1.Play();
            }

            EndGameIfCheckMate();

            SetAllBoxesAsUnavailable(ChessBoard);
        }

        /// <summary>
        /// Method called when the opponent moves a chess piece.
        /// </summary>
        /// <param name="origin">The box whose piece will be moved.</param>
        /// <param name="destination">The box where the selected piece will be moved</param>
        void OpponentMovePiece(Box origin, Box destination)
        {
            // If the destionation has a piece, it will be removed => increase the counter of the captured piece type
            if (destination.Piece != null)
            {
                UpdateCapturedPiecesCounter(destination);
            }

            ResetBoxesColors(ChessBoard);
            PerformMove(origin, destination);
            

            // If, the king was moved, update its coordinates
            if (destination.Piece is King)
            {
                UpdateKingPosition(destination);
            }

            isCurrentPlayersTurnToMove = true;

            if (opponentsTurn == Turn.Black)
            {
                currentPlayersTurn = Turn.White;
                labelRand.Text = "White's turn";
            }
            else
            {
                currentPlayersTurn = Turn.Black;
                labelRand.Text = "Black's turn";
            }

            if (soundEnabled)
            {
                moveSound2.Play();
            }

            EndGameIfCheckMate();

            SetAllBoxesAsUnavailable(ChessBoard);
        }

        void PerformMove(Box origin, Box destination)
        {
            historyEntries.AddEntry(origin, destination);

            destination.Piece = origin.Piece;

            origin.Piece = null;
        }

        #endregion

        void UpdateCapturedPiecesCounter(Box destination)
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

        void UpdateKingPosition(Box destination)
        {
            if (destination.Piece.Color == PieceColor.White)
            {
                pozitieRegeAlb.X = destination.BoxName[0] - 64;
                pozitieRegeAlb.Y = destination.BoxName[1] - 48;
            }
            if (destination.Piece.Color == PieceColor.Black)
            {
                pozitieRegeNegru.X = destination.BoxName[0] - 64;
                pozitieRegeNegru.Y = destination.BoxName[1] - 48;
            }
        }

        void BeginPieceRecapturingIfPawnReachedTheEnd(Box destination)
        {
            // If a white pawn has reached the last line
            if (currentPlayersTurn == Turn.White)
            {
                if (destination.BoxName.Contains('H') && destination.Piece is Pawn)
                {
                    if (capturedWhiteRooks.Count + capturedWhiteKnights.Count + capturedWhiteRooks.Count + capturedWhiteQueen.Count > 0)
                    {
                        retakeRow = 8;
                        retakeColumn = destination.BoxName[1] - 48;
                        currentPlayerMustSelect = true;

                        SendMessage("#selectie");
                        textBox1.AppendText(username + " must select a chess piece from Spoils o' war" + Environment.NewLine);
                    }
                }
            }

            // If a black pawn has reached the last line
            if (currentPlayersTurn == Turn.Black)
            {
                if (destination.BoxName.Contains('A') && destination.Piece is Pawn)
                {
                    if (capturedBlackRooks.Count + capturedBlackKnights.Count + capturedBlackBishops.Count + capturedBlackQueen.Count > 0)
                    {
                        retakeRow = 1;
                        retakeColumn = destination.BoxName[1] - 48;
                        currentPlayerMustSelect = true;

                        SendMessage("#selectie");
                        textBox1.AppendText(username + " must select a chess piece from Spoils o' war" + Environment.NewLine);
                    }
                }
            }
        }

        void EndGameIfCheckMate()
        {
            if ( CheckmateWhite() )
            {
                textBox1.AppendText("Checkmate! Black has won");
                Thread.Sleep(2000);
                MethodInvoker NewGameInvoker = new MethodInvoker(
                    () => NewGame()
                );

                Invoke(NewGameInvoker);
                SendMessage("#new game");
            }
            if ( CheckmateBlack() )
            {
                textBox1.AppendText("Checkmate! White has won");
                Thread.Sleep(2000);
                MethodInvoker NewGameInvoker = new MethodInvoker(
                    () => NewGame()
                );

                Invoke(NewGameInvoker);
                SendMessage("#new game");
            }
        }

        void RetakeCapturedPiece(CapturedPieceBox capturedPieceBox, Box destination)
        {
            PieceColor capturedPieceColor = capturedPieceBox.ChessPiece.Color;

            if (capturedPieceBox.ChessPiece is Rook)
            {
                destination.Piece = new Rook(capturedPieceColor);

                capturedPieceBox.Count--;
            }

            if (capturedPieceBox.ChessPiece is Knight)
            {
                destination.Piece = new Knight(capturedPieceColor);

                capturedPieceBox.Count--;
            }

            if (capturedPieceBox.ChessPiece is Bishop)
            {
                destination.Piece = new Bishop(capturedPieceColor);

                capturedPieceBox.Count--;
            }

            if (capturedPieceBox.ChessPiece is Queen)
            {
                destination.Piece = new Queen(capturedPieceColor);

                capturedPieceBox.Count--;
            }
        }

        private void SendChatMessage(object sender, EventArgs e)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(streamServer);

                streamWriter.AutoFlush = true;
                streamWriter.WriteLine(tbServerDate.Text);
                textBox1.AppendText(username + ": " + tbServerDate.Text + Environment.NewLine);
                tbServerDate.Clear();
            }
            catch
            {
                MessageBox.Show("There was an error sending the message"); 
            }
        }

        public void HideMainMenu()
        {
            menuContainer.Hide();
        }

        bool CheckmateWhite()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (ChessBoard[i, j].Piece != null && ChessBoard[i, j].Piece.Color == PieceColor.White)
                    {
                        ChessBoard[i, j].Piece.CheckPossibilities(i, j, ChessBoard);

                        if (ChessBoard[i, j].Piece.CanMove == true)
                        {
                            ResetBoxesColors(ChessBoard);
                            ChessBoard[i, j].Piece.CanMove = false;                           
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        bool CheckmateBlack()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (ChessBoard[i, j].Piece != null && ChessBoard[i, j].Piece.Color == PieceColor.Black)
                    {
                        ChessBoard[i, j].Piece.CheckPossibilities(i, j, ChessBoard);

                        if (ChessBoard[i, j].Piece.CanMove == true)
                        {
                            ResetBoxesColors(ChessBoard);
                            ChessBoard[i, j].Piece.CanMove = false;                           
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public void ResetBoxesColors(Box[,] ChessBoard)
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if ( (i % 2 == 0 && j % 2 == 0) || (i % 2 == 1 && j % 2 == 1) )
                    {
                        ChessBoard[i, j].BoxBackgroundColor = BoxColorDark;
                    }
                    else
                    {
                        ChessBoard[i, j].BoxBackgroundColor = BoxColorLight;
                    }
                }
            }
        }

        public void NextTurn()
        {
            currentPlayersTurn++;

            if (currentPlayersTurn > Turn.Black)
            {
                currentPlayersTurn = Turn.White;
            }
        }

        /// <summary>
        /// Sets every box as unavailable for chess pieces to move upon.
        /// </summary>
        /// <param name="ChessBoard">The boxes matrix.</param>
        public void SetAllBoxesAsUnavailable(Box[,] ChessBoard)
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    ChessBoard[i, j].Available = false;
                }
            }           
        }

        /// <summary>
        /// Event called whenever a box is clicked.
        /// Responsible for making player moves possible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BoxClick(object sender, EventArgs e)
        {
            Box clickedBoxObject = (Box)sender;

            if (currentPlayerMustSelect || opponentMustSelect)
            {
                return;
            }

            // First click on a box with a chess piece
            if (clickCounter == 0 && clickedBoxObject.Piece != null && (int)currentPlayersTurn == (int)clickedBoxObject.Piece.Color && isCurrentPlayersTurnToMove)
            {
                short row = clickedBoxObject.Row;
                short column = clickedBoxObject.Column;

                clickedBoxObject.Piece.CheckPossibilities(row, column, ChessBoard);
                if (clickedBoxObject.Piece.CanMove)
                {
                    orig = clickedBoxObject;
                    clickCounter++;
                    return;
                }
            }

            // Second click on a box
            if (clickCounter == 1)
            {
                // Click on the same box => Cancel moving current chess piece
                if (clickedBoxObject == orig)
                {
                    SetAllBoxesAsUnavailable(ChessBoard);
                    ResetBoxesColors(ChessBoard);
                }

                // Click on a different box where the current piece can be moved
                if (clickedBoxObject != orig && clickedBoxObject.Available)
                {
                    MovePiece(orig, clickedBoxObject);
                }

                clickCounter = 0;
            }
        }

        void CapturedPieceBoxClick(object sender, EventArgs e)
        {
            CapturedPieceBox clickedCapturedPieceBox = (CapturedPieceBox)sender;

            if (currentPlayerMustSelect && clickedCapturedPieceBox.Count > 0)
            {
                RetakeCapturedPiece(clickedCapturedPieceBox, ChessBoard[retakeRow, retakeColumn]);
                currentPlayerMustSelect = false;

                ChessPiece recapturedPiece = ChessBoard[retakeRow, retakeColumn].Piece;
                if (recapturedPiece != null)
                {
                    string recaptureMessage = "#selectat " + retakeRow + " " + retakeColumn + " ";

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

                    SendMessage(recaptureMessage);
                    SendMessage("#final selectie");
                }
                
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                isNetworkThreadRunning = false;
                streamServer.Close();
            }

            catch (Exception)
            {

            }

            serverTcpListener.Stop();
        }
    }
}
