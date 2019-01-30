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
        bool rand = true;

        int retakeRow, retakeColumn; // Will hold the row and column of where retaken pieces will be placed

        public static bool modInceptator = true; // Made static, because it's required elsewhere

        bool soundEnabled = true;
        bool incepeJocNou = false;
        bool currentPlayerMustSelect = false;
        bool opponentMustSelect = false;

        public static int randMutare = 1;
        public static int randMutareClient = 2;

        int counterCapturedPawnsWhite, counterCapturedRooksWhite, counterCapturedKnightsWhite, counterCapturedBishopsWhite, counterCapturedQueenWhite;
        int counterCapturedPawnsBlack, counterCapturedRooksBlack, counterCapturedKnightsBlack, counterCapturedBishopsBlack, counterCapturedQueenBlack;

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

        Box capturedPawnsWhite, capturedRooksWhite, capturedKnightsWhite, capturedBishopsWhite, capturedQueenWhite;
        Box capturedPawnsBlack, capturedRooksBlack, capturedKnightsBlack, capturedBishopsBlack, capturedQueenBlack;

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

            whiteRook1 = new Rook(1, pbTuraAlb, pbTuraAlbMic);
            whiteRook2 = new Rook(1, pbTuraAlb, pbTuraAlbMic);
            whiteKnight1 = new Knight(1, pbCalAlb, pbCalAlbMic);
            whiteKnight2 = new Knight(1, pbCalAlb, pbCalAlbMic);
            whiteBishop1 = new Bishop(1, pbNebunAlb, pbNebunAlbMic);
            whiteBishop2 = new Bishop(1, pbNebunAlb, pbNebunAlbMic);
            whiteQueen = new Queen(1, pbReginaAlb, pbReginaAlbMic);
            whiteKing = new King(1, pbRegeAlb, pbRegeAlbMic);

            whitePawn1 = new Pawn(1, pbPionAlb, pbPionAlbMic);
            whitePawn2 = new Pawn(1, pbPionAlb, pbPionAlbMic);
            whitePawn3 = new Pawn(1, pbPionAlb, pbPionAlbMic);
            whitePawn4 = new Pawn(1, pbPionAlb, pbPionAlbMic);
            whitePawn5 = new Pawn(1, pbPionAlb, pbPionAlbMic);
            whitePawn6 = new Pawn(1, pbPionAlb, pbPionAlbMic);
            whitePawn7 = new Pawn(1, pbPionAlb, pbPionAlbMic);
            whitePawn8 = new Pawn(1, pbPionAlb, pbPionAlbMic);

            
            blackRook1 = new Rook(2, pbTuraNegru, pbTuraNegruMic);
            blackRook2 = new Rook(2, pbTuraNegru, pbTuraNegruMic);
            blackKnight1 = new Knight(2, pbCalNegru, pbCalNegruMic);
            blackKnight2 = new Knight(2, pbCalNegru, pbCalNegruMic);
            blackBishop1 = new Bishop(2, pbNebunNegru, pbNebunNegruMic);
            blackBishop2 = new Bishop(2, pbNebunNegru, pbNebunNegruMic);
            blackQueen = new Queen(2, pbReginaNegru, pbReginaNegruMic);
            blackKing = new King(2, pbRegeNegru, pbRegeNegruMic);

            blackPawn1 = new Pawn(2, pbPionNegru, pbPionNegruMic);
            blackPawn2 = new Pawn(2, pbPionNegru, pbPionNegruMic);
            blackPawn3 = new Pawn(2, pbPionNegru, pbPionNegruMic);
            blackPawn4 = new Pawn(2, pbPionNegru, pbPionNegruMic);
            blackPawn5 = new Pawn(2, pbPionNegru, pbPionNegruMic);
            blackPawn6 = new Pawn(2, pbPionNegru, pbPionNegruMic);
            blackPawn7 = new Pawn(2, pbPionNegru, pbPionNegruMic);
            blackPawn8 = new Pawn(2, pbPionNegru, pbPionNegruMic);

            #endregion

            NewGame();

            #region Assign click event to chessboard pictureboxes

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    ChessBoard[i, j].imagineLocatie.Click += BoxClick;
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

            A1 = new Box(whiteRook1, _1A); H1 = new Box(blackRook1, _1H);
            A2 = new Box(whiteKnight1, _2A); H2 = new Box(blackKnight1, _2H);
            A3 = new Box(whiteBishop1, _3A); H3 = new Box(blackBishop1, _3H);
            A4 = new Box(whiteQueen, _4A); H4 = new Box(blackKing, _4H);
            A5 = new Box(whiteKing, _5A); H5 = new Box(blackQueen, _5H);
            A6 = new Box(whiteBishop2, _6A); H6 = new Box(blackBishop2, _6H);
            A7 = new Box(whiteKnight2, _7A); H7 = new Box(blackKnight2, _7H);
            A8 = new Box(whiteRook2, _8A); H8 = new Box(blackRook2, _8H);
            B1 = new Box(whitePawn1, _1B); G1 = new Box(blackPawn1, _1G);
            B2 = new Box(whitePawn2, _2B); G2 = new Box(blackPawn2, _2G);
            B3 = new Box(whitePawn3, _3B); G3 = new Box(blackPawn3, _3G);
            B4 = new Box(whitePawn4, _4B); G4 = new Box(blackPawn4, _4G);
            B5 = new Box(whitePawn5, _5B); G5 = new Box(blackPawn5, _5G);
            B6 = new Box(whitePawn6, _6B); G6 = new Box(blackPawn6, _6G);
            B7 = new Box(whitePawn7, _7B); G7 = new Box(blackPawn7, _7G);
            B8 = new Box(whitePawn8, _8B); G8 = new Box(blackPawn8, _8G);

            #endregion

            #region Reset boxes without chess pieces on them

            C1 = new Box(_1C); D1 = new Box(_1D); E1 = new Box(_1E); F1 = new Box(_1F);
            C2 = new Box(_2C); D2 = new Box(_2D); E2 = new Box(_2E); F2 = new Box(_2F);
            C3 = new Box(_3C); D3 = new Box(_3D); E3 = new Box(_3E); F3 = new Box(_3F);
            C4 = new Box(_4C); D4 = new Box(_4D); E4 = new Box(_4E); F4 = new Box(_4F);
            C5 = new Box(_5C); D5 = new Box(_5D); E5 = new Box(_5E); F5 = new Box(_5F);
            C6 = new Box(_6C); D6 = new Box(_6D); E6 = new Box(_6E); F6 = new Box(_6F);
            C7 = new Box(_7C); D7 = new Box(_7D); E7 = new Box(_7E); F7 = new Box(_7F);
            C8 = new Box(_8C); D8 = new Box(_8D); E8 = new Box(_8E); F8 = new Box(_8F);

            #endregion

            #region Reset capture boxes

            capturedPawnsWhite = new Box(whitePawn1, pbPioniAlbiLuati);
            capturedRooksWhite = new Box(whiteRook1, pbTureAlbeLuate);
            capturedKnightsWhite = new Box(whiteKnight1, pbCaiAlbiLuati);
            capturedBishopsWhite = new Box(whiteBishop1, pbNebuniAlbiLuati);
            capturedQueenWhite = new Box(whiteQueen, pbReginaAlbaLuata);

            capturedPawnsBlack = new Box(blackPawn1, pbPioniNegriLuati);
            capturedRooksBlack = new Box(blackRook1, pbTureNegreLuate);
            capturedKnightsBlack = new Box(blackKnight1, pbCaiNegriLuati);
            capturedBishopsBlack = new Box(blackBishop1, pbNebuniNegriLuati);
            capturedQueenBlack = new Box(blackQueen, pbReginaNeagraLuata);

            #endregion

            #region Prepare the ChessBoard boxes matrix

            ChessBoard = new Box[10, 10];

            ChessBoard[1, 1] = A1; ChessBoard[1, 2] = A2; ChessBoard[1, 3] = A3; ChessBoard[1, 4] = A4; ChessBoard[1, 5] = A5; ChessBoard[1, 6] = A6; ChessBoard[1, 7] = A7; ChessBoard[1, 8] = A8;
            ChessBoard[2, 1] = B1; ChessBoard[2, 2] = B2; ChessBoard[2, 3] = B3; ChessBoard[2, 4] = B4; ChessBoard[2, 5] = B5; ChessBoard[2, 6] = B6; ChessBoard[2, 7] = B7; ChessBoard[2, 8] = B8;
            ChessBoard[3, 1] = C1; ChessBoard[3, 2] = C2; ChessBoard[3, 3] = C3; ChessBoard[3, 4] = C4; ChessBoard[3, 5] = C5; ChessBoard[3, 6] = C6; ChessBoard[3, 7] = C7; ChessBoard[3, 8] = C8;
            ChessBoard[4, 1] = D1; ChessBoard[4, 2] = D2; ChessBoard[4, 3] = D3; ChessBoard[4, 4] = D4; ChessBoard[4, 5] = D5; ChessBoard[4, 6] = D6; ChessBoard[4, 7] = D7; ChessBoard[4, 8] = D8;
            ChessBoard[5, 1] = E1; ChessBoard[5, 2] = E2; ChessBoard[5, 3] = E3; ChessBoard[5, 4] = E4; ChessBoard[5, 5] = E5; ChessBoard[5, 6] = E6; ChessBoard[5, 7] = E7; ChessBoard[5, 8] = E8;
            ChessBoard[6, 1] = F1; ChessBoard[6, 2] = F2; ChessBoard[6, 3] = F3; ChessBoard[6, 4] = F4; ChessBoard[6, 5] = F5; ChessBoard[6, 6] = F6; ChessBoard[6, 7] = F7; ChessBoard[6, 8] = F8;
            ChessBoard[7, 1] = G1; ChessBoard[7, 2] = G2; ChessBoard[7, 3] = G3; ChessBoard[7, 4] = G4; ChessBoard[7, 5] = G5; ChessBoard[7, 6] = G6; ChessBoard[7, 7] = G7; ChessBoard[7, 8] = G8;
            ChessBoard[8, 1] = H1; ChessBoard[8, 2] = H2; ChessBoard[8, 3] = H3; ChessBoard[8, 4] = H4; ChessBoard[8, 5] = H5; ChessBoard[8, 6] = H6; ChessBoard[8, 7] = H7; ChessBoard[8, 8] = H8;

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

            if (randMutareClient == 2)
            {
                randMutare = 1;
                rand = true;
            }
            else
            {
                randMutare = 2;
                rand = false;
            }

            pozitieRegeAlb.X = 1;
            pozitieRegeAlb.Y = 5;

            pozitieRegeNegru.X = 8;
            pozitieRegeNegru.Y = 4;

            SetAllBoxesAsUnavailable(ChessBoard);

            #region Reset captured pieces count and labels

            counterCapturedPawnsWhite  = 0;
            counterCapturedRooksWhite   = 0;
            counterCapturedKnightsWhite    = 0;
            counterCapturedBishopsWhite = 0;
            counterCapturedQueenWhite = 0;

            labelCPA.Text = "0";
            labelCounterCapturedRooksWhite.Text = "0";
            labelCounterCapturedKnightsWhite.Text = "0";
            labelCounterCapturedBishopsWhite.Text = "0";
            labelCounterCapturedQueenWhite.Text = "0";


            counterCapturedPawnsBlack = 0;
            counterCapturedRooksBlack = 0;
            counterCapturedKnightsBlack = 0;
            counterCapturedBishopsBlack = 0;
            counterCapturedQueenBlack = 0;

            labelCPN.Text = "0";
            labelCounterCapturedRooksBlack.Text = "0";
            labelCounterCapturedKnightsBlack.Text = "0";
            labelCounterCapturedBishopsBlack.Text = "0";
            labelCounterCapturedQueenBlack.Text = "0";

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

                                randMutare       = Convert.ToInt32(colors[0]);
                                randMutareClient = Convert.ToInt32(colors[1]);

                                rand = (randMutare == 1) ? true : false;
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
                                        RetakePiece(capturedRooksWhite, ChessBoard[row, column]);
                                        counterCapturedRooksWhite--;

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { labelCounterCapturedRooksWhite.Text = counterCapturedRooksWhite.ToString(); }
                                        );
                                    }

                                    if (retakenPieceType == 'C')
                                    {
                                        RetakePiece(capturedKnightsWhite, ChessBoard[row, column]);
                                        counterCapturedKnightsWhite--;

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { labelCounterCapturedKnightsWhite.Text = counterCapturedKnightsWhite.ToString(); }
                                        );
                                    }

                                    if (retakenPieceType == 'N')
                                    {
                                        RetakePiece(capturedBishopsWhite, ChessBoard[row, column]);
                                        counterCapturedBishopsWhite--;

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { labelCounterCapturedBishopsWhite.Text = counterCapturedBishopsWhite.ToString(); }
                                        );
                                    }

                                    if (retakenPieceType == 'R')
                                    {
                                        RetakePiece(capturedQueenWhite, ChessBoard[row, column]);
                                        counterCapturedQueenWhite--;

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { labelCounterCapturedQueenWhite.Text = counterCapturedQueenWhite.ToString(); }
                                        );
                                    }
                                }

                                // Black piece
                                if (retakenPieceColor == 'N')
                                {
                                    if (retakenPieceType == 'T')
                                    {
                                        RetakePiece(capturedRooksBlack, ChessBoard[row, column]);
                                        counterCapturedRooksBlack--;

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { labelCounterCapturedRooksBlack.Text = counterCapturedRooksBlack.ToString(); }
                                        );
                                    }

                                    if (retakenPieceType == 'C')
                                    {
                                        RetakePiece(capturedKnightsBlack, ChessBoard[row, column]);
                                        counterCapturedKnightsBlack--;

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { labelCounterCapturedKnightsBlack.Text = counterCapturedKnightsBlack.ToString(); }
                                        );
                                    }

                                    if (retakenPieceType == 'N')
                                    {
                                        RetakePiece(capturedBishopsBlack, ChessBoard[row, column]);
                                        counterCapturedBishopsBlack--;

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { labelCounterCapturedBishopsBlack.Text = counterCapturedBishopsBlack.ToString(); }
                                        );
                                    }

                                    if (retakenPieceType == 'R')
                                    {
                                        RetakePiece(capturedQueenBlack, ChessBoard[row, column]);
                                        counterCapturedQueenBlack--;

                                        updateLabelCapturedPiece = new MethodInvoker(
                                            () => { labelCounterCapturedQueenBlack.Text = counterCapturedQueenBlack.ToString(); }
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
                randMutare = 1;
                randMutareClient = 2;
                rand = true;
            }

            // Player will be controlling black, will have second move
            else
            {
                randMutare = 2;
                randMutareClient = 1;
                rand = false;
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
            modInceptator = true;
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
            modInceptator = false;
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

            string message = string.Format("#{0} {1}", origin.nume, destination.nume);
            SendMessage(message);

            PerformMove(origin, destination);

            if (destination.Piece.tipPiesa == 6)
            {
                UpdateKingPosition(destination);
            }

            BeginPieceRecapturingIfPawnReachedTheEnd(destination);

            NextTurn();
            SetAllBoxesAsUnavailable(ChessBoard);

            clickCounter = 0;
            ResetBoxesColors(ChessBoard);

            rand = false;
            randMutare = randMutareClient;

            if (randMutare == Constants.TURN_WHITE)
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
            if (destination.Piece.tipPiesa == 6)
            {
                UpdateKingPosition(destination);
            }

            rand = true;

            if (randMutareClient == Constants.TURN_BLACK)
            {
                randMutare = 1;
                labelRand.Text = "White's turn";
            }
            else
            {
                randMutare = 2;
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
            destination.imagineLocatie.BackgroundImage = origin.imagineLocatie.BackgroundImage;

            origin.Piece = null;
            origin.RemovePieceImage();
        }

        #endregion

        void AddMoveHistoryEntry(Box origin, Box destination)
        {
            // If the destination has a piece, add its image to the entry
            if (destination.Piece != null)
            {
                listaMiscari.Rows.Add(
                    moveNumber++,
                    origin.nume + " -> " + destination.nume,
                    origin.Piece.imagineMicaPiesa.Image,
                    destination.Piece.imagineMicaPiesa.Image
                );
            }

            // If the destination doesn't have a piece, add an empty image
            if (destination.Piece == null)
            {
                Bitmap emptyImage = new Bitmap(25, 25);

                listaMiscari.Rows.Add(
                    moveNumber++,
                    origin.nume + " -> " + destination.nume,
                    origin.Piece.imagineMicaPiesa.Image,
                    emptyImage
                );
            }

            // When the scroll bar appears, enlarge the width
            if (moveNumber == 7)
            {
                listaMiscari.Width = listaMiscari.Width + 17;
            }

            listaMiscari.FirstDisplayedScrollingRowIndex = listaMiscari.RowCount - 1;
        }

        void UpdateCapturedPiecesCounter(Box destination)
        {
            if (destination.Piece.culoare == Constants.PIECE_COLOR_WHITE)
            {
                switch (destination.Piece.tipPiesa)
                {
                    case Constants.PIECE_TYPE_PAWN:
                        labelCPA.Text = (++counterCapturedPawnsWhite).ToString();
                        break;
                    case Constants.PIECE_TYPE_ROOK:
                        labelCounterCapturedRooksWhite.Text = (++counterCapturedRooksWhite).ToString();
                        break;
                    case Constants.PIECE_TYPE_KNIGHT:
                        labelCounterCapturedKnightsWhite.Text = (++counterCapturedKnightsWhite).ToString();
                        break;
                    case Constants.PIECE_TYPE_BISHOP:
                        labelCounterCapturedBishopsWhite.Text = (++counterCapturedBishopsWhite).ToString();
                        break;
                    case Constants.PIECE_TYPE_QUEEN:
                        labelCounterCapturedQueenWhite.Text = (++counterCapturedQueenWhite).ToString();
                        break;
                }
            }

            if (destination.Piece.culoare == Constants.PIECE_COLOR_BLACK)
            {
                switch (destination.Piece.tipPiesa)
                {
                    case Constants.PIECE_TYPE_PAWN:
                        labelCPN.Text = (++counterCapturedPawnsBlack).ToString();
                        break;
                    case Constants.PIECE_TYPE_ROOK:
                        labelCounterCapturedRooksBlack.Text = (++counterCapturedRooksBlack).ToString();
                        break;
                    case Constants.PIECE_TYPE_KNIGHT:
                        labelCounterCapturedKnightsBlack.Text = (++counterCapturedKnightsBlack).ToString();
                        break;
                    case Constants.PIECE_TYPE_BISHOP:
                        labelCounterCapturedBishopsBlack.Text = (++counterCapturedBishopsBlack).ToString();
                        break;
                    case Constants.PIECE_TYPE_QUEEN:
                        labelCounterCapturedQueenBlack.Text = (++counterCapturedQueenBlack).ToString();
                        break;
                }
            }
        }

        void UpdateKingPosition(Box destination)
        {
            if (destination.Piece.culoare == Constants.PIECE_COLOR_WHITE)
            {
                pozitieRegeAlb.X = destination.nume[0] - 64;
                pozitieRegeAlb.Y = destination.nume[1] - 48;
            }
            if (destination.Piece.culoare == Constants.PIECE_COLOR_BLACK)
            {
                pozitieRegeNegru.X = destination.nume[0] - 64;
                pozitieRegeNegru.Y = destination.nume[1] - 48;
            }
        }

        void BeginPieceRecapturingIfPawnReachedTheEnd(Box destination)
        {
            // If a white pawn has reached the last line
            if (randMutare == Constants.TURN_WHITE)
            {
                if (destination.nume.Contains('H') && destination.Piece.tipPiesa == Constants.PIECE_TYPE_PAWN)
                {
                    if (counterCapturedRooksWhite + counterCapturedKnightsWhite + counterCapturedBishopsWhite + counterCapturedQueenWhite > 0)
                    {
                        retakeRow = 8;
                        retakeColumn = destination.nume[1] - 48;
                        currentPlayerMustSelect = true;

                        SendMessage("#selectie");
                        textBox1.AppendText(username + " must select a chess piece from Spoils o' war" + Environment.NewLine);
                    }
                }
            }

            // If a black pawn has reached the last line
            if (randMutare == Constants.TURN_BLACK)
            {
                if (destination.nume.Contains('A') && destination.Piece.tipPiesa == Constants.PIECE_TYPE_PAWN)
                {
                    if (counterCapturedRooksBlack + counterCapturedKnightsBlack + counterCapturedBishopsBlack + counterCapturedQueenBlack > 0)
                    {
                        retakeRow = 1;
                        retakeColumn = destination.nume[1] - 48;
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

        /// <summary>
        /// Used to retake a captured chess piece.
        /// </summary>
        /// <param name="origin">Captured chess piece box</param>
        /// <param name="destination">Box where the captured piece will be placed</param>
        void RetakePiece(Box origin, Box destination)
        {
            destination.Piece = origin.Piece;
            destination.imagineLocatie.BackgroundImage = origin.imagineLocatie.BackgroundImage;
            destination.Piece.tipPiesa = origin.Piece.tipPiesa;
            destination.Piece.culoare = origin.Piece.culoare;

            textBox1.AppendText("O piesa a fost selectata" + Environment.NewLine);
        }

        #region White pieces recapturing

        private void pbPioniAlbiLuati_Click(object sender, EventArgs e)
        {

        }

        private void pbTureAlbeLuate_Click(object sender, EventArgs e)
        {
            if (currentPlayerMustSelect && counterCapturedRooksWhite != 0)
            {
                RetakePiece(capturedRooksWhite, ChessBoard[retakeRow, retakeColumn]);
                currentPlayerMustSelect = false;
                labelCounterCapturedRooksWhite.Text = (--counterCapturedRooksWhite).ToString();

                SendMessage("#selectat " + retakeRow + " " + retakeColumn + " TA");
                SendMessage("#final selectie");
            }
        }

        private void pbCaiAlbiLuati_Click(object sender, EventArgs e)
        {
            if (currentPlayerMustSelect && counterCapturedKnightsWhite != 0)
            {
                RetakePiece(capturedKnightsWhite, ChessBoard[retakeRow, retakeColumn]);
                currentPlayerMustSelect = false;
                labelCounterCapturedKnightsWhite.Text = (--counterCapturedKnightsWhite).ToString();

                SendMessage("#selectat " + retakeRow + " " + retakeColumn + " CA");
                SendMessage("#final selectie");
            }
        }

        private void pbNebuniAlbiLuati_Click(object sender, EventArgs e)
        {
            if (currentPlayerMustSelect && counterCapturedBishopsWhite != 0)
            {
                RetakePiece(capturedBishopsWhite, ChessBoard[retakeRow, retakeColumn]);
                currentPlayerMustSelect = false;
                labelCounterCapturedBishopsWhite.Text = (--counterCapturedBishopsWhite).ToString();

                SendMessage("#selectat " + retakeRow + " " + retakeColumn + " NA");
                SendMessage("#final selectie");
            }
        }

        private void pbReginaAlbaLuata_Click(object sender, EventArgs e)
        {
            if (currentPlayerMustSelect && counterCapturedQueenWhite != 0)
            {
                RetakePiece(capturedQueenWhite, ChessBoard[retakeRow, retakeColumn]);
                currentPlayerMustSelect = false;
                labelCounterCapturedQueenWhite.Text = (--counterCapturedQueenWhite).ToString();

                SendMessage("#selectat " + retakeRow + " " + retakeColumn + " RA");
                SendMessage("#final selectie");
            }
        }

        #endregion

        #region Black pieces recapturing

        private void pbTureNegreLuate_Click(object sender, EventArgs e)
        {
            if (currentPlayerMustSelect && counterCapturedRooksBlack != 0)
            {
                RetakePiece(capturedRooksBlack, ChessBoard[retakeRow, retakeColumn]);
                currentPlayerMustSelect = false;
                labelCounterCapturedRooksBlack.Text = (--counterCapturedRooksBlack).ToString();

                SendMessage("#selectat " + retakeRow + " " + retakeColumn + " TN");
                SendMessage("#final selectie");
            }
        }

        private void pbCaiNegriLuati_Click(object sender, EventArgs e)
        {
            if (currentPlayerMustSelect && counterCapturedKnightsBlack != 0)
            {
                RetakePiece(capturedKnightsBlack, ChessBoard[retakeRow, retakeColumn]);
                currentPlayerMustSelect = false;
                labelCounterCapturedKnightsBlack.Text = (--counterCapturedKnightsBlack).ToString();

                SendMessage("#selectat " + retakeRow + " " + retakeColumn + " CN");
                SendMessage("#final selectie");
            }
        }

        private void pbNebuniNegriLuati_Click(object sender, EventArgs e)
        {
            if (currentPlayerMustSelect && counterCapturedBishopsBlack != 0)
            {
                RetakePiece(capturedBishopsBlack, ChessBoard[retakeRow, retakeColumn]);
                currentPlayerMustSelect = false;
                labelCounterCapturedBishopsBlack.Text = (--counterCapturedBishopsBlack).ToString();

                SendMessage("#selectat " + retakeRow + " " + retakeColumn + " NN");
                SendMessage("#final selectie");
            }
        }

        private void pbReginaNeagraLuata_Click(object sender, EventArgs e)
        {
            if (currentPlayerMustSelect && counterCapturedQueenBlack != 0)
            {
                RetakePiece(capturedQueenBlack, ChessBoard[retakeRow, retakeColumn]);
                currentPlayerMustSelect = false;
                labelCounterCapturedQueenBlack.Text = (--counterCapturedQueenBlack).ToString();

                SendMessage("#selectat " + retakeRow + " " + retakeColumn + " RN");
                SendMessage("#final selectie");
            }
        }

        #endregion

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
                    if (ChessBoard[i, j].Piece != null && ChessBoard[i, j].Piece.culoare == 1)
                    {
                        ChessBoard[i, j].Piece.CheckPossibilities(i, j, ChessBoard);

                        if (ChessBoard[i, j].poateFaceMiscari == true)
                        {
                            ResetBoxesColors(ChessBoard);
                            ChessBoard[i, j].poateFaceMiscari = false;                           
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
                    if (ChessBoard[i, j].Piece != null && ChessBoard[i, j].Piece.culoare == 2)
                    {
                        ChessBoard[i, j].Piece.CheckPossibilities(i, j, ChessBoard);

                        if (ChessBoard[i, j].poateFaceMiscari == true)
                        {
                            ResetBoxesColors(ChessBoard);
                            ChessBoard[i, j].poateFaceMiscari = false;                           
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
                        ChessBoard[i, j].imagineLocatie.BackColor = BoxColorDark;
                    }
                    else
                    {
                        ChessBoard[i, j].imagineLocatie.BackColor = BoxColorLight;
                    }
                }
            }
        }

        public void NextTurn()
        {
            randMutare++;

            if (randMutare > 2)
            {
                randMutare = 1;
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
                    ChessBoard[i, j].MarkAsUnavailable();
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
            if (clickCounter == 0 && clickedBox.BackgroundImage != null && randMutare == clickedBoxObject.Piece.culoare && rand)
            {
                short row = clickedBoxObject.Row;
                short column = clickedBoxObject.Column;

                clickedBoxObject.Piece.CheckPossibilities(row, column, ChessBoard);
                if (clickedBoxObject.poateFaceMiscari == true)
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
                    clickCounter = 0;
                    ResetBoxesColors(ChessBoard);
                }

                // Click on a different box where the current piece can be moved
                if (clickedBoxObject != orig && clickedBoxObject.Available)
                {
                    MovePiece(orig, clickedBoxObject);
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
