using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace Chess_Application
{

    public partial class MainForm : Form
    {
        Panel menuContainer;
        MainMenu mainMenu;

        Dictionary <PictureBox, LocatieTabla> Boxes; 

        public static Point pozitieRegeAlb = new Point();
        public static Point pozitieRegeNegru = new Point();
        int tempI, tempJ;

        short clickCounter;
        short moveNumber;

        static bool rand = true;
        public static bool modInceptator = true;
        bool soundEnabled = true;
        bool incepeJocNou = false;
        bool trebuieSaSelectezi = false;
        bool adversarulSelecteaza = false;

        public static short randMutare = 1;
        public static short randMutareClient = 2;

        int counterPioniAlbi, counterTureAlbe, counterCaiAlbi, counterNebuniAlbi, counterReginaAlba;
        int counterPioniNegri, counterTureNegre, counterCaiNegri, counterNebuniNegri, counterReginaNeagra;

        string username = "Server";

        SoundPlayer sunetMutare1 = new SoundPlayer(Properties.Resources.mutare1);
        SoundPlayer sunetMutare2 = new SoundPlayer(Properties.Resources.mutare2);

        Piesa pion1Alb, pion2Alb, pion3Alb, pion4Alb, pion5Alb, pion6Alb, pion7Alb, pion8Alb;
        Piesa tura1Alb, tura2Alb;
        Piesa nebun1Alb, nebun2Alb;
        Piesa cal1Alb, cal2Alb;
        Piesa reginaAlb, regeAlb;

        Piesa pion1Negru, pion2Negru, pion3Negru, pion4Negru, pion5Negru, pion6Negru, pion7Negru, pion8Negru;
        Piesa tura1Negru, tura2Negru;
        Piesa nebun1Negru, nebun2Negru;
        Piesa cal1Negru, cal2Negru;
        Piesa reginaNegru, regeNegru;

        LocatieTabla orig;
        
        LocatieTabla A1, A2, A3, A4, A5, A6, A7, A8, B1, B2, B3, B4, B5, B6, B7, B8;
        LocatieTabla H1, H2, H3, H4, H5, H6, H7, H8, G1, G2, G3, G4, G5, G6, G7, G8;

        LocatieTabla C1, C2, C3, C4, C5, C6, C7, C8, D1, D2, D3, D4, D5, D6, D7, D8;
        LocatieTabla E1, E2, E3, E4, E5, E6, E7, E8, F1, F2, F3, F4, F5, F6, F7, F8;

        LocatieTabla pioniAlbiLuati, tureAlbeLuate, caiAlbiLuati, nebuniAlbiLuati, reginaAlbaLuata;
        LocatieTabla pioniNegriLuati, tureNegreLuate, caiNegriLuati, nebuniNegriLuati, reginaNeagraLuata;

        LocatieTabla[,] ChessBoard;

        Color BoxColorLight = System.Drawing.Color.Silver;
        Color BoxColorDark = Color.FromArgb(132, 107, 86);

        #region Network variables and objects

        TcpListener serverTcpListener;

        Thread networkThread;
        bool isNetworkThreadRunning;

        NetworkStream streamServer;

        //string mesajDeTransmis;

        string usernameClient = "Client";

        #endregion

        public MainForm()
        {
            InitializeComponent();

            serverTcpListener = new TcpListener(System.Net.IPAddress.Any, 3000);
            serverTcpListener.Start();
            networkThread = new Thread(new ThreadStart(Asculta_Server));
            isNetworkThreadRunning = true;
            networkThread.Start();

            mainMenu = new MainMenu(this);

            menuContainer = new Panel();
            menuContainer.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            menuContainer.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            menuContainer.Controls.Add(mainMenu);

            mainMenu.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            mainMenu.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            mainMenu.AutoSize = true;
            mainMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Controls.Add(menuContainer);

            menuContainer.BringToFront();

            listaMiscari.ScrollBars = ScrollBars.Vertical;

            #region Chess pieces

            tura1Alb = new Tura(1, pbTuraAlb, pbTuraAlbMic); tura2Alb = new Tura(1, pbTuraAlb, pbTuraAlbMic);
            cal1Alb = new Cal(1, pbCalAlb, pbCalAlbMic); cal2Alb = new Cal(1, pbCalAlb, pbCalAlbMic);
            nebun1Alb = new Nebun(1, pbNebunAlb, pbNebunAlbMic); nebun2Alb = new Nebun(1, pbNebunAlb, pbNebunAlbMic);
            reginaAlb = new Regina(1, pbReginaAlb, pbReginaAlbMic); regeAlb = new Rege(1, pbRegeAlb, pbRegeAlbMic);
            pion1Alb = new Pion(1, pbPionAlb, pbPionAlbMic); pion2Alb = new Pion(1, pbPionAlb, pbPionAlbMic);
            pion3Alb = new Pion(1, pbPionAlb, pbPionAlbMic); pion4Alb = new Pion(1, pbPionAlb, pbPionAlbMic);
            pion5Alb = new Pion(1, pbPionAlb, pbPionAlbMic); pion6Alb = new Pion(1, pbPionAlb, pbPionAlbMic);
            pion7Alb = new Pion(1, pbPionAlb, pbPionAlbMic); pion8Alb = new Pion(1, pbPionAlb, pbPionAlbMic);
            //=====
            tura1Negru = new Tura(2, pbTuraNegru, pbTuraNegruMic); tura2Negru = new Tura(2, pbTuraNegru, pbTuraNegruMic);
            cal1Negru = new Cal(2, pbCalNegru, pbCalNegruMic); cal2Negru = new Cal(2, pbCalNegru, pbCalNegruMic);
            nebun1Negru = new Nebun(2, pbNebunNegru, pbNebunNegruMic); nebun2Negru = new Nebun(2, pbNebunNegru, pbNebunNegruMic);
            reginaNegru = new Regina(2, pbReginaNegru, pbReginaNegruMic); regeNegru = new Rege(2, pbRegeNegru, pbRegeNegruMic);
            pion1Negru = new Pion(2, pbPionNegru, pbPionNegruMic); pion2Negru = new Pion(2, pbPionNegru, pbPionNegruMic);
            pion3Negru = new Pion(2, pbPionNegru, pbPionNegruMic); pion4Negru = new Pion(2, pbPionNegru, pbPionNegruMic);
            pion5Negru = new Pion(2, pbPionNegru, pbPionNegruMic); pion6Negru = new Pion(2, pbPionNegru, pbPionNegruMic);
            pion7Negru = new Pion(2, pbPionNegru, pbPionNegruMic); pion8Negru = new Pion(2, pbPionNegru, pbPionNegruMic);

            #endregion

            NewGame();

            #region Event Assignment

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
            moveNumber = 1;

            #region Reset boxes with chess pieces on them

            A1 = new LocatieTabla(tura1Alb, _1A); H1 = new LocatieTabla(tura1Negru, _1H);
            A2 = new LocatieTabla(cal1Alb, _2A); H2 = new LocatieTabla(cal1Negru, _2H);
            A3 = new LocatieTabla(nebun1Alb, _3A); H3 = new LocatieTabla(nebun1Negru, _3H);
            A4 = new LocatieTabla(reginaAlb, _4A); H4 = new LocatieTabla(regeNegru, _4H);
            A5 = new LocatieTabla(regeAlb, _5A); H5 = new LocatieTabla(reginaNegru, _5H);
            A6 = new LocatieTabla(nebun2Alb, _6A); H6 = new LocatieTabla(nebun2Negru, _6H);
            A7 = new LocatieTabla(cal2Alb, _7A); H7 = new LocatieTabla(cal2Negru, _7H);
            A8 = new LocatieTabla(tura2Alb, _8A); H8 = new LocatieTabla(tura2Negru, _8H);
            B1 = new LocatieTabla(pion1Alb, _1B); G1 = new LocatieTabla(pion1Negru, _1G);
            B2 = new LocatieTabla(pion2Alb, _2B); G2 = new LocatieTabla(pion2Negru, _2G);
            B3 = new LocatieTabla(pion3Alb, _3B); G3 = new LocatieTabla(pion3Negru, _3G);
            B4 = new LocatieTabla(pion4Alb, _4B); G4 = new LocatieTabla(pion4Negru, _4G);
            B5 = new LocatieTabla(pion5Alb, _5B); G5 = new LocatieTabla(pion5Negru, _5G);
            B6 = new LocatieTabla(pion6Alb, _6B); G6 = new LocatieTabla(pion6Negru, _6G);
            B7 = new LocatieTabla(pion7Alb, _7B); G7 = new LocatieTabla(pion7Negru, _7G);
            B8 = new LocatieTabla(pion8Alb, _8B); G8 = new LocatieTabla(pion8Negru, _8G);

            #endregion

            #region Reset boxes without chess pieces on them

            C1 = new LocatieTabla(_1C); D1 = new LocatieTabla(_1D); E1 = new LocatieTabla(_1E); F1 = new LocatieTabla(_1F);
            C2 = new LocatieTabla(_2C); D2 = new LocatieTabla(_2D); E2 = new LocatieTabla(_2E); F2 = new LocatieTabla(_2F);
            C3 = new LocatieTabla(_3C); D3 = new LocatieTabla(_3D); E3 = new LocatieTabla(_3E); F3 = new LocatieTabla(_3F);
            C4 = new LocatieTabla(_4C); D4 = new LocatieTabla(_4D); E4 = new LocatieTabla(_4E); F4 = new LocatieTabla(_4F);
            C5 = new LocatieTabla(_5C); D5 = new LocatieTabla(_5D); E5 = new LocatieTabla(_5E); F5 = new LocatieTabla(_5F);
            C6 = new LocatieTabla(_6C); D6 = new LocatieTabla(_6D); E6 = new LocatieTabla(_6E); F6 = new LocatieTabla(_6F);
            C7 = new LocatieTabla(_7C); D7 = new LocatieTabla(_7D); E7 = new LocatieTabla(_7E); F7 = new LocatieTabla(_7F);
            C8 = new LocatieTabla(_8C); D8 = new LocatieTabla(_8D); E8 = new LocatieTabla(_8E); F8 = new LocatieTabla(_8F);

            #endregion

            #region Reset capture boxes

            pioniAlbiLuati = new LocatieTabla(pion1Alb, pbPioniAlbiLuati); pioniNegriLuati = new LocatieTabla(pion1Negru, pbPioniNegriLuati);
            tureAlbeLuate = new LocatieTabla(tura1Alb, pbTureAlbeLuate); tureNegreLuate = new LocatieTabla(tura1Negru, pbTureNegreLuate);
            caiAlbiLuati = new LocatieTabla(cal1Alb, pbCaiAlbiLuati); caiNegriLuati = new LocatieTabla(cal1Negru, pbCaiNegriLuati);
            nebuniAlbiLuati = new LocatieTabla(nebun1Alb, pbNebuniAlbiLuati); nebuniNegriLuati = new LocatieTabla(nebun1Negru, pbNebuniNegriLuati);
            reginaAlbaLuata = new LocatieTabla(reginaAlb, pbReginaAlbaLuata); reginaNeagraLuata = new LocatieTabla(reginaNegru, pbReginaNeagraLuata);

            #endregion

            #region Prepare boxes matrix

            ChessBoard = new LocatieTabla[10, 10];

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

            Boxes = new Dictionary<PictureBox, LocatieTabla>();

            Boxes[_1A] = A1; Boxes[_2A] = A2; Boxes[_3A] = A3; Boxes[_4A] = A4; Boxes[_5A] = A5; Boxes[_6A] = A6; Boxes[_7A] = A7; Boxes[_8A] = A8;
            Boxes[_1B] = B1; Boxes[_2B] = B2; Boxes[_3B] = B3; Boxes[_4B] = B4; Boxes[_5B] = B5; Boxes[_6B] = B6; Boxes[_7B] = B7; Boxes[_8B] = B8;
            Boxes[_1C] = C1; Boxes[_2C] = C2; Boxes[_3C] = C3; Boxes[_4C] = C4; Boxes[_5C] = C5; Boxes[_6C] = C6; Boxes[_7C] = C7; Boxes[_8C] = C8;
            Boxes[_1D] = D1; Boxes[_2D] = D2; Boxes[_3D] = D3; Boxes[_4D] = D4; Boxes[_5D] = D5; Boxes[_6D] = D6; Boxes[_7D] = D7; Boxes[_8D] = D8;
            Boxes[_1E] = E1; Boxes[_2E] = E2; Boxes[_3E] = E3; Boxes[_4E] = E4; Boxes[_5E] = E5; Boxes[_6E] = E6; Boxes[_7E] = E7; Boxes[_8E] = E8;
            Boxes[_1F] = F1; Boxes[_2F] = F2; Boxes[_3F] = F3; Boxes[_4F] = F4; Boxes[_5F] = F5; Boxes[_6F] = F6; Boxes[_7F] = F7; Boxes[_8F] = F8;
            Boxes[_1G] = G1; Boxes[_2G] = G2; Boxes[_3G] = G3; Boxes[_4G] = G4; Boxes[_5G] = G5; Boxes[_6G] = G6; Boxes[_7G] = G7; Boxes[_8G] = G8;
            Boxes[_1H] = H1; Boxes[_2H] = H2; Boxes[_3H] = H3; Boxes[_4H] = H4; Boxes[_5H] = H5; Boxes[_6H] = H6; Boxes[_7H] = H7; Boxes[_8H] = H8;

            #endregion

            listaMiscari.Rows.Clear();

            RestoreColors(ChessBoard);

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

            ResetBoxes(ChessBoard);

            #region Reset captured pieces count and labels

            counterPioniAlbi = 0; counterPioniNegri = 0;
            counterTureAlbe = 0; counterTureNegre = 0;
            counterCaiAlbi = 0; counterCaiNegri = 0;
            counterNebuniAlbi = 0; counterNebuniNegri = 0;
            counterReginaAlba = 0; counterReginaNeagra = 0;

            labelCPA.Text = 0.ToString(); labelCPN.Text = 0.ToString();
            labelCTA.Text = 0.ToString(); labelCTN.Text = 0.ToString();
            labelCountCA.Text = 0.ToString(); labelCountCN.Text = 0.ToString();
            labelCNA.Text = 0.ToString(); labelCNN.Text = 0.ToString();
            labelCRA.Text = 0.ToString(); labelCRN.Text = 0.ToString();

            #endregion

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
        }

        #region Network stuff

        public void Asculta_Server()
        {
            while (isNetworkThreadRunning)
            {
                Socket socketServer = serverTcpListener.AcceptSocket();
                try
                {                   
                    streamServer = new NetworkStream(socketServer);
                    StreamReader citireServer = new StreamReader(streamServer);
                    while (isNetworkThreadRunning)
                    {
                        string dateServer = citireServer.ReadLine();
                        if (dateServer == null)
                        {
                            break;
                        }
                        
                        if (dateServer.StartsWith("#"))
                        {
                            if (dateServer == "#Gata") 
                                isNetworkThreadRunning = false;
                            if (dateServer.StartsWith("#") && dateServer.Length == 6)
                            {
                                string[] coordonate = new string[2];
                                coordonate = dateServer.Substring(1).Split();
                                int o1 = System.Convert.ToInt32(coordonate[0][0]) - 64;
                                int o2 = System.Convert.ToInt32(coordonate[0][1]) - 48;
                                int d1 = System.Convert.ToInt32(coordonate[1][0]) - 64;
                                int d2 = System.Convert.ToInt32(coordonate[1][1]) - 48;
                                MethodInvoker mutare = new MethodInvoker(() => OpponentMovePiece(ChessBoard[o1, o2], ChessBoard[d1, d2]));
                                Invoke(mutare);
                            }
                            if (dateServer.StartsWith("#username"))
                            {
                                usernameClient = dateServer.Substring(9);
                            }
                            if (dateServer.StartsWith("#culori"))
                            {
                                string u = dateServer.Substring(8);
                                string[] w = u.Split(' ');
                                int r1 = Convert.ToInt32(w[0]);
                                int r2 = Convert.ToInt32(w[1]);
                                randMutare = (short)r1;
                                randMutareClient = (short)r2;
                                if (r1 == 1) rand = true;
                                else rand = false;
                            }
                            if (dateServer.StartsWith("#request new game"))
                            {
                                incepeJocNou = true;
                            }
                            if (dateServer.StartsWith("#new game"))
                            {
                                MethodInvoker m = new MethodInvoker(() => NewGame());
                                this.Invoke(m);
                            }
                            if (dateServer == "#selectie") { adversarulSelecteaza = true; MethodInvoker m = new MethodInvoker(() => textBox1.AppendText(usernameClient + " are de selectat o piesa din regiunea Spoils o' war"+Environment.NewLine)); Invoke(m); }
                            if (dateServer == "#final selectie") { adversarulSelecteaza = false; }
                            if (dateServer.StartsWith("#selectat"))
                            {
                                string[] detalii = dateServer.Substring(10).Split();
                                foreach (string a in detalii) Console.WriteLine(a);
                                tempI = Convert.ToInt32(detalii[0]);
                                tempJ = Convert.ToInt32(detalii[1]);
                                if (detalii[2][1] == 'A')
                                {
                                    if (detalii[2][0] == 'T') { RetakePiece(tureAlbeLuate, ChessBoard[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCTA.Text = (--counterTureAlbe).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'C') { RetakePiece(caiAlbiLuati, ChessBoard[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCountCA.Text = (--counterCaiAlbi).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'N') { RetakePiece(nebuniAlbiLuati, ChessBoard[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCNA.Text = (--counterNebuniAlbi).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'R') { RetakePiece(reginaAlbaLuata, ChessBoard[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCRA.Text = (--counterReginaAlba).ToString()); Invoke(m); }
                                }
                                if (detalii[2][1] == 'N')
                                {
                                    if (detalii[2][0] == 'T') { RetakePiece(tureNegreLuate, ChessBoard[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCTN.Text = (--counterTureNegre).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'C') { RetakePiece(caiNegriLuati, ChessBoard[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCountCN.Text = (--counterCaiNegri).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'N') { RetakePiece(nebuniNegriLuati, ChessBoard[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCNN.Text = (--counterNebuniNegri).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'R') { RetakePiece(reginaNeagraLuata, ChessBoard[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCRN.Text = (--counterReginaNeagra).ToString()); Invoke(m); }
                                }
                            }
                        }
                        else
                        {
                            MethodInvoker m = new MethodInvoker(() => textBox1.Text += (usernameClient + ": " + dateServer + Environment.NewLine));
                            textBox1.Invoke(m);
                        }
                    }
                    streamServer.Close();
                }
                catch (Exception)
                {
#if LOG
                    Console.WriteLine(e.Message);
#endif
                }
                socketServer.Close();
            }
        }

        #region Username and colors settings

        public void SetUsername(string username)
        {
            this.username = username;

            // Communicate to partner the new username
            StreamWriter streamWriter = new StreamWriter(streamServer);
            streamWriter.AutoFlush = true;
            streamWriter.WriteLine("#username" + username);
        }

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

        void SendMessage(string message)
        {
            StreamWriter scriere = new StreamWriter(streamServer);
            scriere.AutoFlush = true; // enable automatic flushing
            if (!message.StartsWith("#"))
                textBox1.AppendText(username + ":    " + message + Environment.NewLine);
            scriere.WriteLine(message);
        }

        private void tbServerDate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbServerDate.Text != "")
            {
                btnSend_Click(this, new EventArgs());
            }     
        }

        #endregion

        #region OptionsToolStripMenu

        private void activeazalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundEnabled = true;
            activeazalToolStripMenuItem.Visible = false;
            dezactiveazalToolStripMenuItem.Visible = true;
        }

        private void dezactiveazalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundEnabled = false;
            activeazalToolStripMenuItem.Visible = true;
            dezactiveazalToolStripMenuItem.Visible = false;
        }

        private void activeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modInceptator = true;
            activeazaToolStripMenuItem.Available = false;
            dezactiveazaToolStripMenuItem.Available = true;
        }

        private void dezactiveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modInceptator = false;
            activeazaToolStripMenuItem.Available = true;
            dezactiveazaToolStripMenuItem.Available = false;
        }

        private void quitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void quitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!incepeJocNou)
            {
                SendMessage("#request new game");
                SendMessage(" doreste sa-nceapa un joc nou. Daca esti de acord, File->New Game.");

            }
            else
            {
                NewGame();
                incepeJocNou = false;
                SendMessage("#new game");
            }
        }

        #endregion

        #region Chess pieces movement

        /// <summary>
        /// Method called when the opponent moves a chess piece.
        /// </summary>
        /// <param name="origin">The box whose piece will be moved.</param>
        /// <param name="destination">The box where the selected piece will be moved</param>
        void OpponentMovePiece(LocatieTabla origin, LocatieTabla destination)
        {
            #region Add history entry

            // If the destination has a piece, add its image to the entry
            if (destination.piesa != null)
            {
                listaMiscari.Rows.Add(
                    moveNumber++, 
                    origin.nume + " -> " + destination.nume, 
                    origin.piesa.imagineMicaPiesa.Image, 
                    destination.piesa.imagineMicaPiesa.Image
                );
            }

            // If the destination doesn't have a piece, add an empty image
            if (destination.piesa == null)
            {
                Bitmap img = new Bitmap(25, 25);

                listaMiscari.Rows.Add(
                    moveNumber++, 
                    origin.nume + " -> " + destination.nume, 
                    origin.piesa.imagineMicaPiesa.Image, 
                    img
                );
            }

            // When the scroll bar appears, enlarge the width
            if (moveNumber == 7)
            {
                listaMiscari.Width = listaMiscari.Width + 17;
            }

            listaMiscari.FirstDisplayedScrollingRowIndex = listaMiscari.RowCount - 1;

            #endregion

            // If the destionation has a piece, it will be removed => increase the counter of the captured piece type
            if (destination.tipPiesa != 0)
            {
                if (destination.culoare == 1)
                {
                    switch (destination.tipPiesa)
                    {
                        case 1:
                            labelCPA.Text = (++counterPioniAlbi).ToString();
                            break;
                        case 2:
                            labelCTA.Text = (++counterTureAlbe).ToString();
                            break;
                        case 3:
                            labelCountCA.Text = (++counterCaiAlbi).ToString();
                            break;
                        case 4:
                            labelCNA.Text = (++counterNebuniAlbi).ToString();
                            break;
                        case 5:
                            labelCRA.Text = (++counterReginaAlba).ToString();
                            break;
                    }
                }

                if (destination.culoare == 2)
                {
                    switch (destination.tipPiesa)
                    {
                        case 1:
                            labelCPN.Text = (++counterPioniNegri).ToString();
                            break;
                        case 2:
                            labelCTN.Text = (++counterTureNegre).ToString();
                            break;
                        case 3:
                            labelCountCN.Text = (++counterCaiNegri).ToString();
                            break;
                        case 4:
                            labelCNN.Text = (++counterNebuniNegri).ToString();
                            break;
                        case 5:
                            labelCRN.Text = (++counterReginaNeagra).ToString();
                            break;
                    }
                }
            }

            destination.piesa = origin.piesa;
            destination.imagineLocatie.BackgroundImage = origin.imagineLocatie.BackgroundImage;
            destination.tipPiesa = origin.tipPiesa;
            destination.culoare = origin.culoare;

            origin.culoare = 0;
            origin.tipPiesa = 0;
            origin.piesa = null;
            origin.RemovePieceImage();

            // If, the king was moved, update its coordinates
            if (destination.tipPiesa == 6)
            {
                if (destination.culoare == 1)
                {
                    pozitieRegeAlb.X = destination.nume[0]-64;
                    pozitieRegeAlb.Y = destination.nume[1]-48;
                }
                if (destination.culoare == 2)
                {
                    pozitieRegeNegru.X = destination.nume[0]-64;
                    pozitieRegeNegru.Y = destination.nume[1]-48;
                }
            }

            rand = true;

            if (randMutareClient == 2)
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
                sunetMutare2.Play();
            }

            System.Threading.Thread.Sleep(1);

            if (CheckmateWhite())
            {
                textBox1.AppendText("Checkmate! Black has won"); System.Threading.Thread.Sleep(2000);
                MethodInvoker m = new MethodInvoker(() => NewGame());
                this.Invoke(m);
                SendMessage("#new game");
            }
            if (CheckmateBlack())
            {
                textBox1.AppendText("Checkmate! White has won"); System.Threading.Thread.Sleep(2000);
                MethodInvoker m = new MethodInvoker(() => NewGame());
                this.Invoke(m);
                SendMessage("#new game");
            }

            ResetBoxes(ChessBoard);
        }

        /// <summary>
        /// Method called when the current player moves a chess piece.
        /// </summary>
        /// <param name="origine"></param>
        /// <param name="destinatie"></param>
        void MovePiece(LocatieTabla origin, LocatieTabla destination)
        {
            #region Add history entry

            // If the destination has a piece, add its image to the entry
            if (destination.piesa != null)
            {
                listaMiscari.Rows.Add(
                    moveNumber++,
                    origin.nume + " -> " + destination.nume,
                    origin.piesa.imagineMicaPiesa.Image,
                    destination.piesa.imagineMicaPiesa.Image
                );
            }

            // If the destination doesn't have a piece, add an empty image
            if (destination.piesa == null)
            {
                Bitmap img = new Bitmap(25, 25);

                listaMiscari.Rows.Add(
                    moveNumber++,
                    origin.nume + " -> " + destination.nume,
                    origin.piesa.imagineMicaPiesa.Image,
                    img
                );
            }

            // When the scroll bar appears, enlarge the width
            if (moveNumber == 7)
            {
                listaMiscari.Width = listaMiscari.Width + 17;
            }

            listaMiscari.FirstDisplayedScrollingRowIndex = listaMiscari.RowCount - 1;

            #endregion

            // If the destionation has a piece, it will be removed => increase the counter of the captured piece type
            if (destination.tipPiesa != 0)
            {
                if (destination.culoare == 1)
                {
                    switch (destination.tipPiesa)
                    {
                        case 1:
                            labelCPA.Text = (++counterPioniAlbi).ToString();
                            break;
                        case 2:
                            labelCTA.Text = (++counterTureAlbe).ToString();
                            break;
                        case 3:
                            labelCountCA.Text = (++counterCaiAlbi).ToString();
                            break;
                        case 4:
                            labelCNA.Text = (++counterNebuniAlbi).ToString();
                            break;
                        case 5:
                            labelCRA.Text = (++counterReginaAlba).ToString();
                            break;
                    }
                }

                if (destination.culoare == 2)
                {
                    switch (destination.tipPiesa)
                    {
                        case 1:
                            labelCPN.Text = (++counterPioniNegri).ToString();
                            break;
                        case 2:
                            labelCTN.Text = (++counterTureNegre).ToString();
                            break;
                        case 3:
                            labelCountCN.Text = (++counterCaiNegri).ToString();
                            break;
                        case 4:
                            labelCNN.Text = (++counterNebuniNegri).ToString();
                            break;
                        case 5:
                            labelCRN.Text = (++counterReginaNeagra).ToString();
                            break;
                    }
                }
            }

            string message = "#" + origin.nume + " " + destination.nume;
            SendMessage(message);

            destination.piesa = origin.piesa;
            destination.imagineLocatie.BackgroundImage = origin.imagineLocatie.BackgroundImage;
            destination.tipPiesa = origin.tipPiesa;
            destination.culoare = origin.culoare;

            origin.culoare = 0;
            origin.tipPiesa = 0;
            origin.piesa = null;

            // If, the king was moved, update its coordinates
            if (destination.tipPiesa == 6)
            {
                if (destination.culoare == 1)
                {
                    pozitieRegeAlb.X = destination.nume[0] - 64;
                    pozitieRegeAlb.Y = destination.nume[1] - 48;
                }
                if (destination.culoare == 2)
                {
                    pozitieRegeNegru.X = destination.nume[0] - 64;
                    pozitieRegeNegru.Y = destination.nume[1] - 48;
                }
            }

            // If a white pawn has reached the last line
            if (randMutare == 1)
            {
                if (destination.nume.Contains('H') && destination.tipPiesa == 1)  
                {
                    if (counterTureAlbe + counterCaiAlbi + counterNebuniAlbi + counterReginaAlba > 0)
                    {
                        tempI = 8;
                        tempJ = destination.nume[1] - 48;
                        trebuieSaSelectezi = true;
                        SendMessage("#selectie");
                        textBox1.AppendText(username + " must select a chess piece from Spoils o' war" + Environment.NewLine);
                    }
                }
            }

            // If a black pawn has reached the last line
            if (randMutare == 2)
            {
                if (destination.nume.Contains('A') && destination.tipPiesa == 1) 
                {
                    if (counterTureNegre + counterCaiNegri + counterNebuniNegri + counterReginaNeagra > 0)
                    {
                        tempI = 1;
                        tempJ = destination.nume[1] - 48;
                        trebuieSaSelectezi = true;
                        SendMessage("#selectie");
                        textBox1.AppendText(username + " must select a chess piece from Spoils o' war" + Environment.NewLine);
                    }
                }
            }

            origin.RemovePieceImage();

            NewTurn();
            ResetBoxes(ChessBoard);

            clickCounter = 0;
            RestoreColors(ChessBoard);
            
            rand = false;
            randMutare = randMutareClient;

            if (randMutare == 1)
            {
                labelRand.Text = "randul pieselor albe";
            }
            else
            {
                labelRand.Text = "randul pieselor negre";
            }

            if (soundEnabled)
            {
                sunetMutare1.Play();
            }

            System.Threading.Thread.Sleep(1);

            if (CheckmateWhite())
            {
                textBox1.AppendText("a castigat negrul"); System.Threading.Thread.Sleep(2000);
                NewGame();
                SendMessage("#new game");
            }
            if (CheckmateBlack())
            {
                textBox1.AppendText("a castigat albul"); System.Threading.Thread.Sleep(2000);
                MethodInvoker m = new MethodInvoker(() => NewGame());
                this.Invoke(m);
                SendMessage("#new game");
            }

            ResetBoxes(ChessBoard);
        }

        #endregion

        #region Events for recapturing chess pieces

        private void pbPioniAlbiLuati_Click(object sender, EventArgs e)
        {

        }

        private void pbTureAlbeLuate_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterTureAlbe != 0)
            {
                RetakePiece(tureAlbeLuate, ChessBoard[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCTA.Text = (--counterTureAlbe).ToString();
                SendMessage("#selectat " + tempI + " " + tempJ + " TA");
                SendMessage("#final selectie");
            }
        }

        private void pbCaiAlbiLuati_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterCaiAlbi != 0)
            {
                RetakePiece(caiAlbiLuati, ChessBoard[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCountCA.Text = (--counterCaiAlbi).ToString();
                SendMessage("#selectat " + tempI + " " + tempJ + " CA");
                SendMessage("#final selectie");
            }
        }

        private void pbNebuniAlbiLuati_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterNebuniAlbi != 0)
            {
                RetakePiece(nebuniAlbiLuati, ChessBoard[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCNA.Text = (--counterNebuniAlbi).ToString();
                SendMessage("#selectat " + tempI + " " + tempJ + " NA");
                SendMessage("#final selectie");
            }
        }

        private void pbReginaAlbaLuata_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterReginaAlba != 0)
            {
                RetakePiece(reginaAlbaLuata, ChessBoard[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCRA.Text = (--counterReginaAlba).ToString();
                SendMessage("#selectat " + tempI + " " + tempJ + " RA");
                SendMessage("#final selectie");
            }
        }

        //=====

        private void pbTureNegreLuate_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterTureNegre != 0)
            {
                RetakePiece(tureNegreLuate, ChessBoard[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCTN.Text = (--counterTureNegre).ToString();
                SendMessage("#selectat " + tempI + " " + tempJ + " TN");
                SendMessage("#final selectie");
            }
        }

        private void pbCaiNegriLuati_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterCaiNegri != 0)
            {
                RetakePiece(caiNegriLuati, ChessBoard[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCountCN.Text = (--counterCaiNegri).ToString();
                SendMessage("#selectat " + tempI + " " + tempJ + " CN");
                SendMessage("#final selectie");
            }
        }

        private void pbNebuniNegriLuati_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterNebuniNegri != 0)
            {
                RetakePiece(nebuniNegriLuati, ChessBoard[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCNN.Text = (--counterNebuniNegri).ToString();
                SendMessage("#selectat " + tempI + " " + tempJ + " NN");
                SendMessage("#final selectie");
            }
        }

        private void pbReginaNeagraLuata_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterReginaNeagra != 0)
            {
                RetakePiece(reginaNeagraLuata, ChessBoard[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCRN.Text = (--counterReginaNeagra).ToString();
                SendMessage("#selectat " + tempI + " " + tempJ + " RN");
                SendMessage("#final selectie");
            }
        }

        #endregion

        /// <summary>
        /// Used to retake a captured chess piece.
        /// </summary>
        /// <param name="origin">Captured chess piece box</param>
        /// <param name="destination">Box where the captured piece will be placed</param>
        void RetakePiece(LocatieTabla origin, LocatieTabla destination)
        {
            destination.piesa = origin.piesa;
            destination.imagineLocatie.BackgroundImage = origin.imagineLocatie.BackgroundImage;
            destination.tipPiesa = origin.tipPiesa;
            destination.culoare = origin.culoare;

            textBox1.AppendText("O piesa a fost selectata" + Environment.NewLine);
        }

        private void btnSend_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Determines wether White is in checkmate or not.
        /// </summary>
        /// <returns>true if White is in checkmate, false if White isn't in checkmate</returns>
        bool CheckmateWhite()
        {
            for(int i=1; i<=8; i++)
            {
                for (int j=1; j<=8; j++)
                {
                    if (ChessBoard[i, j].culoare == 1 && ChessBoard[i, j].piesa != null)
                    {
                        ChessBoard[i, j].piesa.VerificaPosibilitati(i, j, ChessBoard);
                        if (ChessBoard[i, j].poateFaceMiscari == true)
                        {
                            RestoreColors(ChessBoard);
                            ChessBoard[i, j].poateFaceMiscari = false;                           
                            return false;
                        }
                    }
                }
            }

            textBox1.AppendText("Albu-i in mat..." + Environment.NewLine);

            return true;
        }

        /// <summary>
        /// Determines wether Black is in checkmate or not.
        /// </summary>
        /// <returns>true if Black is in checkmate, false if Black isn't in checkmate</returns>
        bool CheckmateBlack()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (ChessBoard[i, j].culoare == 2 && ChessBoard[i, j].piesa != null)
                    {
                        ChessBoard[i, j].piesa.VerificaPosibilitati(i, j, ChessBoard);
                        if (ChessBoard[i, j].poateFaceMiscari == true)
                        {
                            RestoreColors(ChessBoard);
                            ChessBoard[i, j].poateFaceMiscari = false;                           
                            return false;
                        }
                    }
                }
            }

            textBox1.AppendText("Negru-i in mat..." + Environment.NewLine);

            return true;
        }

        /// <summary>
        /// Reset the colors of the boxes.
        /// </summary>
        /// <param name="ChessBoard">The boxes matrix.</param>
        public void RestoreColors(LocatieTabla[,] ChessBoard)
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

        public void NewTurn()
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
        /// <param name="boxes">The matrix of boxes to be set as unavailable.</param>
        public void ResetBoxes(LocatieTabla[,] boxes)
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    boxes[i, j].MarkAsUnavailable();
                }
            }           
        }

        public void Rearanjare(LocatieTabla[,] loc)
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    loc[i, j].MarkAsUnavailable();
                }
            }
            clickCounter = 0;
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
            LocatieTabla clickedBoxObject = Boxes[clickedBox];

            if (trebuieSaSelectezi || adversarulSelecteaza)
            {
                return;
            }

            // First click on a box with a chess piece
            if (clickCounter == 0 && clickedBox.BackgroundImage != null && randMutare == clickedBoxObject.culoare && rand)
            {
                short row = clickedBoxObject.Row;
                short column = clickedBoxObject.Column;

                clickedBoxObject.piesa.VerificaPosibilitati(row, column, ChessBoard);
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
                    Rearanjare(ChessBoard);
                    clickCounter = 0;
                    RestoreColors(ChessBoard);
                }

                //Click on a different box where the current piece can be moved
                if (clickedBoxObject != orig && clickedBoxObject.Available)
                {
                    MovePiece(orig, clickedBoxObject);
                }
            }
        }

    }
}
