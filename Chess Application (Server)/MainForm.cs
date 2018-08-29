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

        short clickCounter = 0;

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

        static string mesajDeTransmis;

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

        public LocatieTabla orig, destinatie;
        
        LocatieTabla A1, A2, A3, A4, A5, A6, A7, A8, B1, B2, B3, B4, B5, B6, B7, B8;
        LocatieTabla H1, H2, H3, H4, H5, H6, H7, H8, G1, G2, G3, G4, G5, G6, G7, G8;

        LocatieTabla C1, C2, C3, C4, C5, C6, C7, C8, D1, D2, D3, D4, D5, D6, D7, D8;
        LocatieTabla E1, E2, E3, E4, E5, E6, E7, E8, F1, F2, F3, F4, F5, F6, F7, F8;

        LocatieTabla pioniAlbiLuati, tureAlbeLuate, caiAlbiLuati, nebuniAlbiLuati, reginaAlbaLuata;
        LocatieTabla pioniNegriLuati, tureNegreLuate, caiNegriLuati, nebuniNegriLuati, reginaNeagraLuata;

        public LocatieTabla[,] locatii;

        #region Network variables and objects

        public TcpListener server;
        public string dateServer;
        private static MainForm serverForm;
        Thread t;
        bool workThread;
        public static NetworkStream streamServer;
        public static string usernameClient = "Client";

        #endregion

        public MainForm()
        {
            InitializeComponent();

            server = new TcpListener(System.Net.IPAddress.Any, 3000);
            server.Start();
            t = new Thread(new ThreadStart(Asculta_Server));
            workThread = true;
            t.Start();
            serverForm = this;

            mainMenu = new MainMenu(this);  // link main menu to this form

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
                        locatii[i, j].imagineLocatie.Click += BoxClick;
                    }
                }

            #endregion

            destinatie = new LocatieTabla();
            activeazaToolStripMenuItem.Available = false;
            activeazalToolStripMenuItem.Available = false;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                workThread = false;
                streamServer.Close();
            }

            catch (Exception)
            {

            }
        }

        #region Network stuff

        public void Asculta_Server()
        {
            while (workThread)
            {
                Socket socketServer = server.AcceptSocket();
                try
                {                   
                    streamServer = new NetworkStream(socketServer);
                    StreamReader citireServer = new StreamReader(streamServer);
                    while (workThread)
                    {
                        string dateServer = citireServer.ReadLine();
                        if (dateServer == null) break;//primesc nimic - clientul a plecat
                        if (dateServer.StartsWith("#"))
                        {
                            if (dateServer == "#Gata") //ca sa pot sa inchid serverul
                                workThread = false;
                            if (dateServer.StartsWith("#") && dateServer.Length == 6)
                            {
                                string[] coordonate = new string[2];
                                coordonate = dateServer.Substring(1).Split();
                                int o1 = System.Convert.ToInt32(coordonate[0][0]) - 64;
                                int o2 = System.Convert.ToInt32(coordonate[0][1]) - 48;
                                int d1 = System.Convert.ToInt32(coordonate[1][0]) - 64;
                                int d2 = System.Convert.ToInt32(coordonate[1][1]) - 48;
                                MethodInvoker mutare = new MethodInvoker(() => OpponentMovePiece(locatii[o1, o2], locatii[d1, d2]));
                                serverForm.Invoke(mutare);
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
                                    if (detalii[2][0] == 'T') { Transfera(tureAlbeLuate, locatii[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCTA.Text = (--counterTureAlbe).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'C') { Transfera(caiAlbiLuati, locatii[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCountCA.Text = (--counterCaiAlbi).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'N') { Transfera(nebuniAlbiLuati, locatii[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCNA.Text = (--counterNebuniAlbi).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'R') { Transfera(reginaAlbaLuata, locatii[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCRA.Text = (--counterReginaAlba).ToString()); Invoke(m); }
                                }
                                if (detalii[2][1] == 'N')
                                {
                                    if (detalii[2][0] == 'T') { Transfera(tureNegreLuate, locatii[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCTN.Text = (--counterTureNegre).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'C') { Transfera(caiNegriLuati, locatii[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCountCN.Text = (--counterCaiNegri).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'N') { Transfera(nebuniNegriLuati, locatii[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCNN.Text = (--counterNebuniNegri).ToString()); Invoke(m); }
                                    if (detalii[2][0] == 'R') { Transfera(reginaNeagraLuata, locatii[tempI, tempJ]); MethodInvoker m = new MethodInvoker(() => labelCRN.Text = (--counterReginaNeagra).ToString()); Invoke(m); }
                                }
                            }
                        }
                        else
                        {
                            MethodInvoker m = new MethodInvoker(() => serverForm.textBox1.Text += (usernameClient + ": " + dateServer + Environment.NewLine));
                            serverForm.textBox1.Invoke(m);
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

        void transmiteMesaj()
        {
            StreamWriter scriere = new StreamWriter(streamServer);
            scriere.AutoFlush = true; // enable automatic flushing
            if (!mesajDeTransmis.StartsWith("#"))
                textBox1.AppendText(username + ":    " + mesajDeTransmis + Environment.NewLine);
            scriere.WriteLine(mesajDeTransmis);
        }

        void transmiteMesaj(string a)
        {
            StreamWriter scriere = new StreamWriter(streamServer);
            scriere.AutoFlush = true; // enable automatic flushing
            if (!a.StartsWith("#"))
                textBox1.AppendText(username + ":    " + a + Environment.NewLine);
            scriere.WriteLine(a);
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
                transmiteMesaj("#request new game");
                transmiteMesaj(" doreste sa-nceapa un joc nou. Daca esti de acord, File->New Game.");

            }
            else
            {
                NewGame();
                incepeJocNou = false;
                transmiteMesaj("#new game");
            }
        }

        #endregion

        /// <summary>
        /// Method used when retaking a captured chess piece.
        /// </summary>
        /// <param name="origin">Captured chess piece box</param>
        /// <param name="destination">Box where the captured piece will be placed</param>
        void Transfera(LocatieTabla origin, LocatieTabla destination)
        {
            destination.piesa = origin.piesa;
            destination.imagineLocatie.BackgroundImage = origin.imagineLocatie.BackgroundImage;
            destination.tipPiesa = origin.tipPiesa;
            destination.culoare = origin.culoare;

            textBox1.AppendText("O piesa a fost selectata" + Environment.NewLine);
        }

        #region Deplasare Piese

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
                    ++LocatieTabla.count, 
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
                    ++LocatieTabla.count, 
                    origin.nume + " -> " + destination.nume, 
                    origin.piesa.imagineMicaPiesa.Image, 
                    img
                );
            }

            // When the scroll bar appears, enlarge the width
            if (LocatieTabla.count == 7)
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
            origin.StergeLocatie();

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

            if (MatAlb())
            {
                textBox1.AppendText("Checkmate! Black has won"); System.Threading.Thread.Sleep(2000);
                MethodInvoker m = new MethodInvoker(() => NewGame());
                this.Invoke(m);
                transmiteMesaj("#new game");
            }
            if (MatNegru())
            {
                textBox1.AppendText("Checkmate! White has won"); System.Threading.Thread.Sleep(2000);
                MethodInvoker m = new MethodInvoker(() => NewGame());
                this.Invoke(m);
                transmiteMesaj("#new game");
            }

            R(locatii);
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
                    ++LocatieTabla.count,
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
                    ++LocatieTabla.count,
                    origin.nume + " -> " + destination.nume,
                    origin.piesa.imagineMicaPiesa.Image,
                    img
                );
            }

            // When the scroll bar appears, enlarge the width
            if (LocatieTabla.count == 7)
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

            mesajDeTransmis = "#" + origin.nume + " " + destination.nume;
            transmiteMesaj();

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

            if (randMutare == 1)
            {
                if (destination.nume.Contains('H') && destination.tipPiesa == 1)  
                {

                    Console.WriteLine("iaca-ta c-a ajuns pionu'-n ultima linie");
                    if (counterTureAlbe + counterCaiAlbi + counterNebuniAlbi + counterReginaAlba > 0)
                    {
                        tempI = 8;
                        tempJ = destinatie.nume[1] - 48;
                        trebuieSaSelectezi = true;
                        transmiteMesaj("#selectie");
                        textBox1.AppendText(username + " are de selectat o piesa din regiunea Spoils o' war"+Environment.NewLine);
                    }
                }
            }

            if (randMutare == 2)
            {
                if (destination.nume.Contains('A') && destination.tipPiesa == 1) 
                {
                    Console.WriteLine("iaca-ta c-a ajuns pionu'-n ultima linie");
                    if (counterTureNegre + counterCaiNegri + counterNebuniNegri + counterReginaNeagra > 0)
                    {
                        tempI = 1;
                        tempJ = destinatie.nume[1] - 48;
                        trebuieSaSelectezi = true;
                        transmiteMesaj("#selectie");
                        textBox1.AppendText(username + " are de selectat o piesa din regiunea Spoils o' war"+Environment.NewLine);
                    }
                }
            }

            orig.StergeLocatie();
            RandNou(locatii);
            clickCounter = 0;
            RestoreCulori(locatii);
            
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

            if (MatAlb())
            {
                textBox1.AppendText("a castigat negrul"); System.Threading.Thread.Sleep(2000);
                NewGame();
                transmiteMesaj("#new game");
            }
            if (MatNegru())
            {
                textBox1.AppendText("a castigat albul"); System.Threading.Thread.Sleep(2000);
                MethodInvoker m = new MethodInvoker(() => NewGame());
                this.Invoke(m);
                transmiteMesaj("#new game");
            }

            R(locatii);
        }

        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter scriere = new StreamWriter(streamServer);
                scriere.AutoFlush = true; // enable automatic flushing
                scriere.WriteLine(tbServerDate.Text);
                textBox1.AppendText(username + ": " + tbServerDate.Text + Environment.NewLine);
                tbServerDate.Clear();
            }
            catch
            {
                Console.WriteLine("Eroare la transmiterea mesajului");
            }
        }

        public void HideMainMenu()
        {
            menuContainer.Hide();
        }

        /// <summary>
        /// Method responsible for rearanging the chess board for a new game.
        /// </summary>
        public void NewGame()
        {

            #region Reset Boxes with pieces on them

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

            #region Reset empty boxes

            C1 = new LocatieTabla(_1C); D1 = new LocatieTabla(_1D); E1 = new LocatieTabla(_1E); F1 = new LocatieTabla(_1F);
            C2 = new LocatieTabla(_2C); D2 = new LocatieTabla(_2D); E2 = new LocatieTabla(_2E); F2 = new LocatieTabla(_2F);
            C3 = new LocatieTabla(_3C); D3 = new LocatieTabla(_3D); E3 = new LocatieTabla(_3E); F3 = new LocatieTabla(_3F);
            C4 = new LocatieTabla(_4C); D4 = new LocatieTabla(_4D); E4 = new LocatieTabla(_4E); F4 = new LocatieTabla(_4F);
            C5 = new LocatieTabla(_5C); D5 = new LocatieTabla(_5D); E5 = new LocatieTabla(_5E); F5 = new LocatieTabla(_5F);
            C6 = new LocatieTabla(_6C); D6 = new LocatieTabla(_6D); E6 = new LocatieTabla(_6E); F6 = new LocatieTabla(_6F);
            C7 = new LocatieTabla(_7C); D7 = new LocatieTabla(_7D); E7 = new LocatieTabla(_7E); F7 = new LocatieTabla(_7F);
            C8 = new LocatieTabla(_8C); D8 = new LocatieTabla(_8D); E8 = new LocatieTabla(_8E); F8 = new LocatieTabla(_8F);

            #endregion

            #region Reset Capture boxes

            pioniAlbiLuati = new LocatieTabla(pion1Alb, pbPioniAlbiLuati);      pioniNegriLuati = new LocatieTabla(pion1Negru, pbPioniNegriLuati);
            tureAlbeLuate = new LocatieTabla(tura1Alb, pbTureAlbeLuate);        tureNegreLuate = new LocatieTabla(tura1Negru, pbTureNegreLuate);
            caiAlbiLuati = new LocatieTabla(cal1Alb, pbCaiAlbiLuati);           caiNegriLuati = new LocatieTabla(cal1Negru, pbCaiNegriLuati);
            nebuniAlbiLuati = new LocatieTabla(nebun1Alb, pbNebuniAlbiLuati);   nebuniNegriLuati = new LocatieTabla(nebun1Negru, pbNebuniNegriLuati);
            reginaAlbaLuata = new LocatieTabla(reginaAlb, pbReginaAlbaLuata);   reginaNeagraLuata = new LocatieTabla(reginaNegru, pbReginaNeagraLuata);

            #endregion

            #region Prepare boxes matrix

            locatii = new LocatieTabla[10, 10];

            locatii[1, 1] = A1; locatii[1, 2] = A2; locatii[1, 3] = A3; locatii[1, 4] = A4; locatii[1, 5] = A5; locatii[1, 6] = A6; locatii[1, 7] = A7; locatii[1, 8] = A8;
            locatii[2, 1] = B1; locatii[2, 2] = B2; locatii[2, 3] = B3; locatii[2, 4] = B4; locatii[2, 5] = B5; locatii[2, 6] = B6; locatii[2, 7] = B7; locatii[2, 8] = B8;
            locatii[3, 1] = C1; locatii[3, 2] = C2; locatii[3, 3] = C3; locatii[3, 4] = C4; locatii[3, 5] = C5; locatii[3, 6] = C6; locatii[3, 7] = C7; locatii[3, 8] = C8;
            locatii[4, 1] = D1; locatii[4, 2] = D2; locatii[4, 3] = D3; locatii[4, 4] = D4; locatii[4, 5] = D5; locatii[4, 6] = D6; locatii[4, 7] = D7; locatii[4, 8] = D8;
            locatii[5, 1] = E1; locatii[5, 2] = E2; locatii[5, 3] = E3; locatii[5, 4] = E4; locatii[5, 5] = E5; locatii[5, 6] = E6; locatii[5, 7] = E7; locatii[5, 8] = E8;
            locatii[6, 1] = F1; locatii[6, 2] = F2; locatii[6, 3] = F3; locatii[6, 4] = F4; locatii[6, 5] = F5; locatii[6, 6] = F6; locatii[6, 7] = F7; locatii[6, 8] = F8;
            locatii[7, 1] = G1; locatii[7, 2] = G2; locatii[7, 3] = G3; locatii[7, 4] = G4; locatii[7, 5] = G5; locatii[7, 6] = G6; locatii[7, 7] = G7; locatii[7, 8] = G8;
            locatii[8, 1] = H1; locatii[8, 2] = H2; locatii[8, 3] = H3; locatii[8, 4] = H4; locatii[8, 5] = H5; locatii[8, 6] = H6; locatii[8, 7] = H7; locatii[8, 8] = H8;

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

            RestoreCulori(locatii);

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

            LocatieTabla.count = 0;
            pozitieRegeAlb.X = 1;
            pozitieRegeAlb.Y = 5;
            pozitieRegeNegru.X = 8;
            pozitieRegeNegru.Y = 4;
            labelCPA.Text = 0.ToString();       labelCPN.Text = 0.ToString();
            labelCTA.Text = 0.ToString();       labelCTN.Text = 0.ToString();
            labelCountCA.Text = 0.ToString();   labelCountCN.Text = 0.ToString();
            labelCNA.Text = 0.ToString();       labelCNN.Text = 0.ToString();
            labelCRA.Text = 0.ToString();       labelCRN.Text = 0.ToString();
            counterPioniAlbi = 0;   counterPioniNegri = 0;
            counterTureAlbe = 0;    counterTureNegre = 0;
            counterCaiAlbi = 0;     counterCaiNegri = 0;
            counterNebuniAlbi = 0;  counterNebuniNegri = 0;
            counterReginaAlba = 0;  counterReginaNeagra = 0;
            R(locatii);           
        }

        bool MatAlb()
        {
            for(int i=1; i<=8; i++)
            {
                for (int j=1; j<=8; j++)
                {
                    if (locatii[i, j].culoare == 1 && locatii[i, j].piesa != null)
                    {
                        locatii[i, j].piesa.VerificaPosibilitati(i, j, locatii);
                        if (locatii[i, j].poateFaceMiscari == true)
                        {
                            RestoreCulori(locatii);
                            locatii[i, j].poateFaceMiscari = false;                           
                            return false;
                        }
                    }
                }
            }

            textBox1.AppendText("Albu-i in mat..." + Environment.NewLine);

            return true;
        }

        bool MatNegru()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (locatii[i, j].culoare == 2 && locatii[i, j].piesa != null)
                    {
                        locatii[i, j].piesa.VerificaPosibilitati(i, j, locatii);
                        if (locatii[i, j].poateFaceMiscari == true)
                        {
                            RestoreCulori(locatii);
                            locatii[i, j].poateFaceMiscari = false;                           
                            return false;
                        }
                    }
                }
            }

            textBox1.AppendText("Negru-i in mat..." + Environment.NewLine);

            return true;
        }

        public void RestoreCulori(LocatieTabla[,] loc)
        {
            A1.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); A2.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            A3.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); A4.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            A5.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); A6.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            A7.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); A8.imagineLocatie.BackColor = System.Drawing.Color.Silver;

            B1.imagineLocatie.BackColor = System.Drawing.Color.Silver; B2.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            B3.imagineLocatie.BackColor = System.Drawing.Color.Silver; B4.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            B5.imagineLocatie.BackColor = System.Drawing.Color.Silver; B6.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            B7.imagineLocatie.BackColor = System.Drawing.Color.Silver; B8.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);

            C1.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); C2.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            C3.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); C4.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            C5.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); C6.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            C7.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); C8.imagineLocatie.BackColor = System.Drawing.Color.Silver;

            D1.imagineLocatie.BackColor = System.Drawing.Color.Silver; D2.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            D3.imagineLocatie.BackColor = System.Drawing.Color.Silver; D4.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            D5.imagineLocatie.BackColor = System.Drawing.Color.Silver; D6.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            D7.imagineLocatie.BackColor = System.Drawing.Color.Silver; D8.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);

            E1.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); E2.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            E3.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); E4.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            E5.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); E6.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            E7.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); E8.imagineLocatie.BackColor = System.Drawing.Color.Silver;

            F1.imagineLocatie.BackColor = System.Drawing.Color.Silver; F2.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            F3.imagineLocatie.BackColor = System.Drawing.Color.Silver; F4.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            F5.imagineLocatie.BackColor = System.Drawing.Color.Silver; F6.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            F7.imagineLocatie.BackColor = System.Drawing.Color.Silver; F8.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);

            G1.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); G2.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            G3.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); G4.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            G5.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); G6.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            G7.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); G8.imagineLocatie.BackColor = System.Drawing.Color.Silver;

            H1.imagineLocatie.BackColor = System.Drawing.Color.Silver; H2.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            H3.imagineLocatie.BackColor = System.Drawing.Color.Silver; H4.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            H5.imagineLocatie.BackColor = System.Drawing.Color.Silver; H6.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
            H7.imagineLocatie.BackColor = System.Drawing.Color.Silver; H8.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
        }

        public void RandNou(LocatieTabla[,] loc)
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    loc[i, j].sePoate = false;
                }
            }
            randMutare++;
            if (randMutare > 2) randMutare = 1;
        }

        public void R(LocatieTabla[,] loc)
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    loc[i, j].sePoate = false;
                }
            }           
        }

        public void Rearanjare(LocatieTabla[,] loc)
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    loc[i, j].sePoate = false;
                }
            }
            clickCounter = 0;
        }


        #region Recapturing chess pieces

        private void pbPioniAlbiLuati_Click(object sender, EventArgs e)
        {

        }

        private void pbTureAlbeLuate_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterTureAlbe != 0)
            {
                Transfera(tureAlbeLuate, locatii[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCTA.Text = (--counterTureAlbe).ToString();
                transmiteMesaj("#selectat " + tempI + " " + tempJ + " TA");
                transmiteMesaj("#final selectie");
            }
        }

        private void pbCaiAlbiLuati_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterCaiAlbi!=0)
            {
                Transfera(caiAlbiLuati, locatii[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCountCA.Text = (--counterCaiAlbi).ToString();
                transmiteMesaj("#selectat " + tempI + " " + tempJ + " CA");
                transmiteMesaj("#final selectie");
            }           
        }

        private void pbNebuniAlbiLuati_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterNebuniAlbi != 0)
            {
                Transfera(nebuniAlbiLuati, locatii[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCNA.Text = (--counterNebuniAlbi).ToString();
                transmiteMesaj("#selectat " + tempI + " " + tempJ + " NA");
                transmiteMesaj("#final selectie");
            }
        }

        private void pbReginaAlbaLuata_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterReginaAlba != 0)
            {
                Transfera(reginaAlbaLuata, locatii[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCRA.Text = (--counterReginaAlba).ToString();
                transmiteMesaj("#selectat " + tempI + " " + tempJ + " RA");
                transmiteMesaj("#final selectie");
            }
        }

        //=====

        private void pbTureNegreLuate_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterTureNegre != 0)
            {
                Transfera(tureNegreLuate, locatii[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCTN.Text = (--counterTureNegre).ToString();
                transmiteMesaj("#selectat " + tempI + " " + tempJ + " TN");
                transmiteMesaj("#final selectie");
            }
        }

        private void pbCaiNegriLuati_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterCaiNegri != 0)
            {
                Transfera(caiNegriLuati, locatii[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCountCN.Text = (--counterCaiNegri).ToString();
                transmiteMesaj("#selectat " + tempI + " " + tempJ + " CN");
                transmiteMesaj("#final selectie");
            }
        }

        private void pbNebuniNegriLuati_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterNebuniNegri != 0)
            {
                Transfera(nebuniNegriLuati, locatii[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCNN.Text = (--counterNebuniNegri).ToString();
                transmiteMesaj("#selectat " + tempI + " " + tempJ + " NN");
                transmiteMesaj("#final selectie");
            }
        }

        private void pbReginaNeagraLuata_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterReginaNeagra != 0)
            {
                Transfera(reginaNeagraLuata, locatii[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCRN.Text = (--counterReginaNeagra).ToString();
                transmiteMesaj("#selectat " + tempI + " " + tempJ + " RN");
                transmiteMesaj("#final selectie");
            }
        }

        #endregion

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
                short row = clickedBoxObject.GetRow();
                short column = clickedBoxObject.GetColumn();

                clickedBoxObject.piesa.VerificaPosibilitati(row, column, locatii);
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
                    Rearanjare(locatii);
                    clickCounter = 0;
                    RestoreCulori(locatii);
                }

                //Click on a different box where the current piece can be moved
                if (clickedBoxObject != orig && clickedBoxObject.sePoate == true)
                {
                    MovePiece(orig, clickedBoxObject);
                }
            }
        }

    }
}
