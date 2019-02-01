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

        Dictionary <PictureBox, Box> Boxes; 

        public static Point pozitieRegeAlb = new Point();
        public static Point pozitieRegeNegru = new Point();

        int clickCounter;
        int moveNumber;
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

            listaMiscari.ScrollBars = ScrollBars.Vertical;

            #region Initialize chess pieces

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

            #endregion

            #region Prepare captured pieces panel (Spoils o' war)

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

            #endregion

            NewGame();

            #region Assign click event to chessboard pictureboxes

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    ChessBoard[i, j].pictureBox.Click += BoxClick;
                }
            }

            #endregion

            activeazaToolStripMenuItem.Available = false;
            activeazalToolStripMenuItem.Available = false;
        }

        /// <summary>
        /// Method responsible for rearanging the chess board for a new game.
        /// </summary>
        public void NewGame()
        {
            moveNumber = 1; // Used in history entries

            #region Reset boxes with chess pieces on them

            A1 = new Box(_1A, whiteRook1);
            A2 = new Box(_2A, whiteKnight1);
            A3 = new Box(_3A, whiteBishop1);
            A4 = new Box(_4A, whiteQueen);
            A5 = new Box(_5A, whiteKing);
            A6 = new Box(_6A, whiteBishop2);
            A7 = new Box(_7A, whiteKnight2);
            A8 = new Box(_8A, whiteRook2);
            
            B1 = new Box(_1B, whitePawn1);
            B2 = new Box(_2B, whitePawn2);
            B3 = new Box(_3B, whitePawn3);
            B4 = new Box(_4B, whitePawn4);
            B5 = new Box(_5B, whitePawn5);
            B6 = new Box(_6B, whitePawn6);
            B7 = new Box(_7B, whitePawn7);
            B8 = new Box(_8B, whitePawn8);
            

            G1 = new Box(_1G, blackPawn1);
            G2 = new Box(_2G, blackPawn2);
            G3 = new Box(_3G, blackPawn3);
            G4 = new Box(_4G, blackPawn4);
            G5 = new Box(_5G, blackPawn5);
            G6 = new Box(_6G, blackPawn6);
            G7 = new Box(_7G, blackPawn7);
            G8 = new Box(_8G, blackPawn8);

            H1 = new Box(_1H, blackRook1);
            H2 = new Box(_2H, blackKnight1);
            H3 = new Box(_3H, blackBishop1);
            H4 = new Box(_4H, blackKing);
            H5 = new Box(_5H, blackQueen);
            H6 = new Box(_6H, blackBishop2);
            H7 = new Box(_7H, blackKnight2);
            H8 = new Box(_8H, blackRook2);

            #endregion

            #region Reset boxes without chess pieces on them

            C1 = new Box(_1C);
            C2 = new Box(_2C);
            C3 = new Box(_3C);
            C4 = new Box(_4C);
            C5 = new Box(_5C);
            C6 = new Box(_6C);
            C7 = new Box(_7C);
            C8 = new Box(_8C);

            D1 = new Box(_1D);
            D2 = new Box(_2D);
            D3 = new Box(_3D);
            D4 = new Box(_4D);
            D5 = new Box(_5D);
            D6 = new Box(_6D);
            D7 = new Box(_7D);
            D8 = new Box(_8D);

            E1 = new Box(_1E);
            E2 = new Box(_2E);
            E3 = new Box(_3E);
            E4 = new Box(_4E);
            E5 = new Box(_5E);
            E6 = new Box(_6E);
            E7 = new Box(_7E);
            E8 = new Box(_8E);

            F1 = new Box(_1F);
            F2 = new Box(_2F);
            F3 = new Box(_3F);
            F4 = new Box(_4F);
            F5 = new Box(_5F);
            F6 = new Box(_6F);
            F7 = new Box(_7F);
            F8 = new Box(_8F);

            #endregion

            #region Prepare the ChessBoard boxes matrix

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

            #endregion

            #region Boxes dictionary

            Boxes = new Dictionary<PictureBox, Box>();

            Boxes[_1A] = A1;
            Boxes[_2A] = A2;
            Boxes[_3A] = A3;
            Boxes[_4A] = A4;
            Boxes[_5A] = A5;
            Boxes[_6A] = A6;
            Boxes[_7A] = A7;
            Boxes[_8A] = A8;

            Boxes[_1B] = B1;
            Boxes[_2B] = B2;
            Boxes[_3B] = B3;
            Boxes[_4B] = B4;
            Boxes[_5B] = B5;
            Boxes[_6B] = B6;
            Boxes[_7B] = B7;
            Boxes[_8B] = B8;

            Boxes[_1C] = C1;
            Boxes[_2C] = C2;
            Boxes[_3C] = C3;
            Boxes[_4C] = C4;
            Boxes[_5C] = C5;
            Boxes[_6C] = C6;
            Boxes[_7C] = C7;
            Boxes[_8C] = C8;

            Boxes[_1D] = D1;
            Boxes[_2D] = D2;
            Boxes[_3D] = D3;
            Boxes[_4D] = D4;
            Boxes[_5D] = D5;
            Boxes[_6D] = D6;
            Boxes[_7D] = D7;
            Boxes[_8D] = D8;

            Boxes[_1E] = E1;
            Boxes[_2E] = E2;
            Boxes[_3E] = E3;
            Boxes[_4E] = E4;
            Boxes[_5E] = E5;
            Boxes[_6E] = E6;
            Boxes[_7E] = E7;
            Boxes[_8E] = E8;

            Boxes[_1F] = F1;
            Boxes[_2F] = F2;
            Boxes[_3F] = F3;
            Boxes[_4F] = F4;
            Boxes[_5F] = F5;
            Boxes[_6F] = F6;
            Boxes[_7F] = F7;
            Boxes[_8F] = F8;

            Boxes[_1G] = G1;
            Boxes[_2G] = G2;
            Boxes[_3G] = G3;
            Boxes[_4G] = G4;
            Boxes[_5G] = G5;
            Boxes[_6G] = G6;
            Boxes[_7G] = G7;
            Boxes[_8G] = G8;

            Boxes[_1H] = H1;
            Boxes[_2H] = H2;
            Boxes[_3H] = H3;
            Boxes[_4H] = H4;
            Boxes[_5H] = H5;
            Boxes[_6H] = H6;
            Boxes[_7H] = H7;
            Boxes[_8H] = H8;

            #endregion

            listaMiscari.Rows.Clear();

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
            AddMoveHistoryEntry(origin, destination);

            if (destination.Piece != null)
            {
                UpdateCapturedPiecesCounter(destination);
            }

            string message = string.Format("#{0} {1}", origin.Name, destination.Name);
            SendMessage(message);

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
            AddMoveHistoryEntry(origin, destination);

            // If the destionation has a piece, it will be removed => increase the counter of the captured piece type
            if (destination.Piece != null)
            {
                UpdateCapturedPiecesCounter(destination);
            }

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
            destination.Piece = origin.Piece;
            destination.pictureBox.BackgroundImage = origin.pictureBox.BackgroundImage;

            origin.Piece = null;
            origin.RemovePieceImage();
        }

        #endregion

        void AddMoveHistoryEntry(Box origin, Box destination)
        {
            Image destinationImage = (destination.Piece != null) ? destination.Piece.ImageSmall : new Bitmap(25, 25);

            listaMiscari.Rows.Add(
                moveNumber++,
                origin.Name + " -> " + destination.Name,
                origin.Piece.ImageSmall,
                destinationImage
            );

            // When the scroll bar appears, enlarge the width
            if (moveNumber == 7)
            {
                listaMiscari.Width = listaMiscari.Width + 17;
            }

            listaMiscari.FirstDisplayedScrollingRowIndex = listaMiscari.RowCount - 1;
        }

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
                pozitieRegeAlb.X = destination.Name[0] - 64;
                pozitieRegeAlb.Y = destination.Name[1] - 48;
            }
            if (destination.Piece.Color == PieceColor.Black)
            {
                pozitieRegeNegru.X = destination.Name[0] - 64;
                pozitieRegeNegru.Y = destination.Name[1] - 48;
            }
        }

        void BeginPieceRecapturingIfPawnReachedTheEnd(Box destination)
        {
            // If a white pawn has reached the last line
            if (currentPlayersTurn == Turn.White)
            {
                if (destination.Name.Contains('H') && destination.Piece is Pawn)
                {
                    if (capturedWhiteRooks.Count + capturedWhiteKnights.Count + capturedWhiteRooks.Count + capturedWhiteQueen.Count > 0)
                    {
                        retakeRow = 8;
                        retakeColumn = destination.Name[1] - 48;
                        currentPlayerMustSelect = true;

                        SendMessage("#selectie");
                        textBox1.AppendText(username + " must select a chess piece from Spoils o' war" + Environment.NewLine);
                    }
                }
            }

            // If a black pawn has reached the last line
            if (currentPlayersTurn == Turn.Black)
            {
                if (destination.Name.Contains('A') && destination.Piece is Pawn)
                {
                    if (capturedBlackRooks.Count + capturedBlackKnights.Count + capturedBlackBishops.Count + capturedBlackQueen.Count > 0)
                    {
                        retakeRow = 1;
                        retakeColumn = destination.Name[1] - 48;
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

        #region Recapturing chess pieces

        void RetakeCapturedPiece(CapturedPieceBox capturedPieceBox, Box destination)
        {
            PieceColor capturedPieceColor = capturedPieceBox.ChessPiece.Color;

            if (capturedPieceBox.ChessPiece is Rook)
            {
                destination.Piece = new Rook(capturedPieceColor);
                destination.pictureBox.BackgroundImage = capturedPieceBox.ChessPiece.Image;

                capturedPieceBox.Count--;
            }

            if (capturedPieceBox.ChessPiece is Knight)
            {
                destination.Piece = new Knight(capturedPieceColor);
                destination.pictureBox.BackgroundImage = capturedPieceBox.ChessPiece.Image;

                capturedPieceBox.Count--;
            }

            if (capturedPieceBox.ChessPiece is Bishop)
            {
                destination.Piece = new Bishop(capturedPieceColor);
                destination.pictureBox.BackgroundImage = capturedPieceBox.ChessPiece.Image;

                capturedPieceBox.Count--;
            }

            if (capturedPieceBox.ChessPiece is Queen)
            {
                destination.Piece = new Queen(capturedPieceColor);
                destination.pictureBox.BackgroundImage = capturedPieceBox.ChessPiece.Image;

                capturedPieceBox.Count--;
            }
        }

        #endregion

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
                        ChessBoard[i, j].pictureBox.BackColor = BoxColorDark;
                    }
                    else
                    {
                        ChessBoard[i, j].pictureBox.BackColor = BoxColorLight;
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
            PictureBox clickedBox = (PictureBox)sender;
            Box clickedBoxObject = Boxes[clickedBox];

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
