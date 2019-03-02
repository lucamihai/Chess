using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Chess_Application_client.Classes;

namespace Chess_Application_client
{
    
    public partial class Form1 : Form
    {
        static bool rand=false;
        public static short randMutare = 2;
        static short randMutareServer = 1;
        short clickCounter = 0;
        public static string mesajDeTransmis;
        public static string mesajPrimit;
        public LocatieTabla[,] locatii;
        public static bool modInceptator = true;
        bool sunet = true;
        public static string usernameServer = "Server";
        bool incepeJocNou = false;
        bool trebuieSaSelectezi = false;
        bool adversarulSelecteaza = false;
        public int counterPioniAlbi, counterTureAlbe, counterCaiAlbi, counterNebuniAlbi, counterReginaAlba;
        public int counterPioniNegri, counterTureNegre, counterCaiNegri, counterNebuniNegri, counterReginaNeagra;
        public int tempI, tempJ;

        public static string username="Client";
        public static string _username
        {
            get { return username; }
            set { SetareUsername(value); }
        }

        public static string culoriUseri;
        public static string _culoriUseri
        {
            get { return culoriUseri; }
            set { SetareCulori(value); }
        }

        SoundPlayer sunetMutare1 = new SoundPlayer(Chess_Application_client.Properties.Resources.mutare1);
        SoundPlayer sunetMutare2 = new SoundPlayer(Chess_Application_client.Properties.Resources.mutare2);

        public static Point pozitieRegeAlb = new Point();
        public static Point pozitieRegeNegru = new Point();

        Pion pion1Alb, pion2Alb, pion3Alb, pion4Alb, pion5Alb, pion6Alb, pion7Alb, pion8Alb;
        Tura tura1Alb, tura2Alb;
        Nebun nebun1Alb, nebun2Alb;
        Cal cal1Alb, cal2Alb;
        Regina reginaAlb; Rege regeAlb;
        
        Pion pion1Negru, pion2Negru, pion3Negru, pion4Negru, pion5Negru, pion6Negru, pion7Negru, pion8Negru;
        Piesa tura1Negru, tura2Negru;
        Piesa nebun1Negru, nebun2Negru;
        Piesa cal1Negru, cal2Negru;
        Piesa reginaNegru, regeNegru;

        LocatieTabla orig, destinatie;

        LocatieTabla A1, A2, A3, A4, A5, A6, A7, A8, B1, B2, B3, B4, B5, B6, B7, B8;
        LocatieTabla H1, H2, H3, H4, H5, H6, H7, H8, G1, G2, G3, G4, G5, G6, G7, G8;

        LocatieTabla C1, C2, C3, C4, C5, C6, C7, C8, D1, D2, D3, D4, D5, D6, D7, D8;
        LocatieTabla E1, E2, E3, E4, E5, E6, E7, E8, F1, F2, F3, F4, F5, F6, F7, F8;

        LocatieTabla pioniAlbiLuati, tureAlbeLuate, caiAlbiLuati, nebuniAlbiLuati, reginaAlbaLuata;
        LocatieTabla pioniNegriLuati, tureNegreLuate, caiNegriLuati, nebuniNegriLuati, reginaNeagraLuata;
        //=============================================================================================================================================
        public TcpClient client;
        public static NetworkStream clientStream;
        public bool ascult;
        public static Form1 clientForm;
        public Thread t;
        //----------------------------------------------------------------------------------------------------------------------
        private void Asculta_client()
        {
            StreamReader citire = new StreamReader(clientStream);
            String dateClient;
            while (ascult)
            {
                {
                    dateClient = citire.ReadLine();
                    if (dateClient != null)
                    {
                        if (dateClient.StartsWith("#"))
                        {
                            if (dateClient.StartsWith("#") && dateClient.Length == 6)
                            {
                                string[] coordonate = new string[2];
                                coordonate = dateClient.Substring(1).Split();
                                int o1 = System.Convert.ToInt32(coordonate[0][0]) - 64;
                                int o2 = System.Convert.ToInt32(coordonate[0][1]) - 48;
                                int d1 = System.Convert.ToInt32(coordonate[1][0]) - 64;
                                int d2 = System.Convert.ToInt32(coordonate[1][1]) - 48;
                                MethodInvoker mutare = new MethodInvoker(() => Muta(locatii[o1, o2], locatii[d1, d2]));
                                clientForm.Invoke(mutare);
                            }
                            if (dateClient.StartsWith("#username"))
                            {
                                string u = dateClient.Substring(9);
                                usernameServer = u;
                            }
                            if (dateClient.StartsWith("#culori"))
                            {
                                string u = dateClient.Substring(8);
                                string[] w = u.Split(' ');
                                int r1 = Convert.ToInt32(w[0]);
                                int r2 = Convert.ToInt32(w[1]);
                                randMutare = (short)r2;
                                randMutareServer = (short)r1;
                                if (r2 == 1) rand = true;
                                else rand = false;
                            }
                            if (dateClient.StartsWith("#request new game"))
                            {
                                incepeJocNou = true;
                            }
                            if (dateClient.StartsWith("#new game"))
                            {
                                MethodInvoker m = new MethodInvoker(() => NewGame());
                                Invoke(m);
                            }
                            if (dateClient == "#selectie") { adversarulSelecteaza = true; MethodInvoker m = new MethodInvoker(() => textBox1.AppendText(usernameServer + " are de selectat o piesa din regiunea Spoils o' war" + Environment.NewLine)); Invoke(m); }
                            if (dateClient == "#final selectie") { adversarulSelecteaza = false; }
                            if (dateClient.StartsWith("#selectat"))
                            {
                                string[] detalii = dateClient.Substring(10).Split();
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
                            MethodInvoker m = new MethodInvoker(() => clientForm.textBox1.Text += (usernameServer + ": " + dateClient + Environment.NewLine));
                            clientForm.textBox1.Invoke(m);
                        }

                    }
                }
               

            }
        }
        public static void SetareUsername(string u)
        {
            username = u;
            StreamWriter scriere = new StreamWriter(clientStream);
            scriere.AutoFlush = true; // enable automatic flushing
            scriere.WriteLine("#username" + u);
            
        }

        public static void SetareCulori(string u)
        {
            StreamWriter scriere = new StreamWriter(clientStream);
            scriere.AutoFlush = true;
            string[] culori = u.Split(' ');
            int a = Convert.ToInt32(culori[0]);
            if (a == 1)
            {
                randMutare = 2;
                randMutareServer = 1;
                rand = false;
            }
            else
            {
                randMutare = 1;
                randMutareServer = 2;
                rand = true;
            }
            scriere.WriteLine("#culori " + u);
        }

        private void tbAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbServerDate.Text != "")
                btnSend_Click(this, new EventArgs());
        }

        void Transfera(LocatieTabla origine, LocatieTabla destinatie)
        {
            destinatie.piesa = origine.piesa;
            destinatie.imagineLocatie.BackgroundImage = origine.imagineLocatie.BackgroundImage;
            destinatie.tipPiesa = origine.tipPiesa;
            destinatie.culoare = origine.culoare;
            Console.WriteLine("s-a efectuat transferul");
            MethodInvoker m=new MethodInvoker(()=>textBox1.AppendText("O piesa a fost selectata" + Environment.NewLine));Invoke(m);
        }
        void Muta(LocatieTabla origine, LocatieTabla destinatie)
        {
            if (destinatie.piesa != null)
            {
                listaMiscari.Rows.Add(++LocatieTabla.count, origine.nume + " -> " + destinatie.nume, origine.piesa.imagineMicaPiesa.Image, destinatie.piesa.imagineMicaPiesa.Image);
                if (LocatieTabla.count == 7)
                {
                    listaMiscari.Width = listaMiscari.Width + 17;
                }
            }
            if (destinatie.piesa == null)
            {
                Bitmap img = new Bitmap(25, 25);
                listaMiscari.Rows.Add(++LocatieTabla.count, origine.nume + " -> " + destinatie.nume, origine.piesa.imagineMicaPiesa.Image, img);
                if (LocatieTabla.count == 7)
                {
                    listaMiscari.Width = listaMiscari.Width + 17;
                }
            }
            listaMiscari.FirstDisplayedScrollingRowIndex = listaMiscari.RowCount - 1;
            if (destinatie.tipPiesa != 0)
            {
                if (destinatie.culoare == 1)
                {
                    if (destinatie.tipPiesa == 1) labelCPA.Text = (++counterPioniAlbi).ToString();
                    if (destinatie.tipPiesa == 2) labelCTA.Text = (++counterTureAlbe).ToString();
                    if (destinatie.tipPiesa == 3) labelCountCA.Text = (++counterCaiAlbi).ToString();
                    if (destinatie.tipPiesa == 4) labelCNA.Text = (++counterNebuniAlbi).ToString();
                    if (destinatie.tipPiesa == 5) labelCRA.Text = (++counterReginaAlba).ToString();
                }
                if (destinatie.culoare == 2)
                {
                    if (destinatie.tipPiesa == 1) labelCPN.Text = (++counterPioniNegri).ToString();
                    if (destinatie.tipPiesa == 2) labelCTN.Text = (++counterTureNegre).ToString();
                    if (destinatie.tipPiesa == 3) labelCountCN.Text = (++counterCaiNegri).ToString();
                    if (destinatie.tipPiesa == 4) labelCNN.Text = (++counterNebuniNegri).ToString();
                    if (destinatie.tipPiesa == 5) labelCRN.Text = (++counterReginaNeagra).ToString();
                }
            }
            destinatie.piesa = origine.piesa;
            destinatie.imagineLocatie.BackgroundImage = origine.imagineLocatie.BackgroundImage;
            destinatie.tipPiesa = origine.tipPiesa;
            destinatie.culoare = origine.culoare;
            origine.culoare = 0;
            origine.tipPiesa = 0;
            origine.piesa = null;
            origine.StergeLocatie();
            if (destinatie.tipPiesa == 6)
            {
                if (destinatie.culoare == 1) { pozitieRegeAlb.X = destinatie.nume[0] - 64; pozitieRegeAlb.Y = destinatie.nume[1] - 48; Console.WriteLine(pozitieRegeAlb.X + " " + pozitieRegeAlb.Y); }
                if (destinatie.culoare == 2) { pozitieRegeNegru.X = destinatie.nume[0] - 64; pozitieRegeNegru.Y = destinatie.nume[1] - 48; Console.WriteLine(pozitieRegeNegru.X + " " + pozitieRegeNegru.Y); }
            }
            rand = true;
            if (randMutareServer == 1) randMutare = 2;
            else randMutare = 1;
            if (randMutare == 1) labelRand.Text = "randul pieselor albe";
            else labelRand.Text = "randul pieselor negre";
            if (sunet) sunetMutare2.Play();
            if (MatAlb())
            {
                textBox1.AppendText("a castigat negrul"); System.Threading.Thread.Sleep(2000);
                MethodInvoker m = new MethodInvoker(() => NewGame());
                this.Invoke(m);
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

        void Muta(LocatieTabla origine, LocatieTabla destinatie, string mesaj)
        {
            if (destinatie.piesa != null)
            {
                listaMiscari.Rows.Add(++LocatieTabla.count, origine.nume + " -> " + destinatie.nume, origine.piesa.imagineMicaPiesa.Image, destinatie.piesa.imagineMicaPiesa.Image);
                if (LocatieTabla.count == 7)
                {
                    listaMiscari.Width = listaMiscari.Width + 17;
                }
            }
            if (destinatie.piesa == null)
            {
                Bitmap img = new Bitmap(25, 25);
                listaMiscari.Rows.Add(++LocatieTabla.count, origine.nume + " -> " + destinatie.nume, origine.piesa.imagineMicaPiesa.Image, img);
                if (LocatieTabla.count == 7)
                {
                    listaMiscari.Width = listaMiscari.Width + 17;
                }
            }
            if (destinatie.tipPiesa != 0)
            {
                if (destinatie.culoare == 1)
                {
                    if (destinatie.tipPiesa == 1) { labelCPA.Text = (++counterPioniAlbi).ToString(); }
                    if (destinatie.tipPiesa == 2) { labelCTA.Text = (++counterTureAlbe).ToString(); }
                    if (destinatie.tipPiesa == 3) { labelCountCA.Text = (++counterCaiAlbi).ToString(); }
                    if (destinatie.tipPiesa == 4) { labelCNA.Text = (++counterNebuniAlbi).ToString(); }
                    if (destinatie.tipPiesa == 5) { labelCRA.Text = (++counterReginaAlba).ToString(); }
                }
                if (destinatie.culoare == 2)
                {
                    if (destinatie.tipPiesa == 1) { labelCPN.Text = (++counterPioniNegri).ToString(); }
                    if (destinatie.tipPiesa == 2) { labelCTN.Text = (++counterTureNegre).ToString(); }
                    if (destinatie.tipPiesa == 3) { labelCountCN.Text = (++counterCaiNegri).ToString(); }
                    if (destinatie.tipPiesa == 4) { labelCNN.Text = (++counterNebuniNegri).ToString(); }
                    if (destinatie.tipPiesa == 5) { labelCRN.Text = (++counterReginaNeagra).ToString(); }
                }
            }
            mesajDeTransmis = "#" + origine.nume + " " + destinatie.nume;
            listaMiscari.FirstDisplayedScrollingRowIndex = listaMiscari.RowCount - 1;
            destinatie.piesa = origine.piesa;
            destinatie.imagineLocatie.BackgroundImage = origine.imagineLocatie.BackgroundImage;
            destinatie.tipPiesa = origine.tipPiesa;
            destinatie.culoare = origine.culoare;
            origine.culoare = 0;
            origine.tipPiesa = 0;
            origine.piesa = null;
            if (destinatie.tipPiesa == 6)
            {
                if (destinatie.culoare == 1) { pozitieRegeAlb.X = destinatie.nume[0] - 64; pozitieRegeAlb.Y = destinatie.nume[1] - 48; Console.WriteLine(pozitieRegeAlb.X + " " + pozitieRegeAlb.Y); }
                if (destinatie.culoare == 2) { pozitieRegeNegru.X = destinatie.nume[0] - 64; pozitieRegeNegru.Y = destinatie.nume[1] - 48; Console.WriteLine(pozitieRegeNegru.X + " " + pozitieRegeNegru.Y); }
            }
            if (randMutare == 1)
            {
                if (destinatie.nume.Contains('H') && destinatie.tipPiesa == 1)
                {

                    Console.WriteLine("iaca-ta c-a ajuns pionu'-n ultima linie");
                    if (counterTureAlbe + counterCaiAlbi + counterNebuniAlbi + counterReginaAlba > 0)
                    {
                        tempI = 8;
                        tempJ = destinatie.nume[1] - 48;
                        trebuieSaSelectezi = true;
                        transmiteMesaj("#selectie");
                    }
                }
            }
            if (randMutare == 2)
            {
                if (destinatie.nume.Contains('A') && destinatie.tipPiesa == 1)
                {
                    Console.WriteLine("iaca-ta c-a ajuns pionu'-n ultima linie");
                    if (counterTureNegre + counterCaiNegri + counterNebuniNegri + counterReginaNeagra > 0)
                    {
                        tempI = 1;
                        tempJ = destinatie.nume[1] - 48;
                        trebuieSaSelectezi = true;
                        transmiteMesaj("#selectie");
                    }
                }
            }
            orig.StergeLocatie(); RandNou(locatii);
            clickCounter = 0; RestoreCulori(locatii); transmiteMesaj();
            rand = false;
            randMutare = randMutareServer;
            if (randMutare == 1) labelRand.Text = "randul pieselor albe";
            else labelRand.Text = "randul pieselor negre";
            if (sunet) sunetMutare1.Play();
            if (MatAlb())
            {
                textBox1.AppendText("a castigat negrul"); System.Threading.Thread.Sleep(2000);
                MethodInvoker m = new MethodInvoker(() => NewGame());
                this.Invoke(m);
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

        bool MatAlb()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Conecteaza-te")
            {
                if (tbAddress.Text.Length > 0)
                {
                    client = new TcpClient(tbAddress.Text, 3000);
                    ascult = true;
                    t = new Thread(new ThreadStart(Asculta_client));
                    t.Start();
                    clientStream = client.GetStream();
                    tbAddress.Visible = false;
                    btnConnect.Text = "Deconecteaza-te";
                }
                else
                {
                    MessageBox.Show("Specificati adresa de IP");
                }
            }
            else
            {
                ascult = false;
                t.Abort();
                StreamWriter scriere = new StreamWriter(clientStream);
                scriere.AutoFlush = true; // enable automatic flushing
                scriere.WriteLine("#Gata");
            }
        }

        void transmiteMesaj()
        {
            StreamWriter scriere = new StreamWriter(clientStream);
            scriere.AutoFlush = true; // enable automatic flushing
            if (!mesajDeTransmis.StartsWith("#"))
                textBox1.AppendText(username + ":    " + mesajDeTransmis + Environment.NewLine);
            scriere.WriteLine(mesajDeTransmis);
        }

        void transmiteMesaj(string a)
        {
            StreamWriter scriere = new StreamWriter(clientStream);
            scriere.AutoFlush = true; // enable automatic flushing
            if (!a.StartsWith("#"))
                textBox1.AppendText(username + ":    " + a + Environment.NewLine);
            scriere.WriteLine(a);
        }
        #region Selectare Piese
        private void pbTureAlbeLuate_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi && counterTureAlbe != 0 && randMutare == 2)
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
            if (trebuieSaSelectezi && counterCaiAlbi != 0 && randMutare == 2)
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
            if (trebuieSaSelectezi && counterNebuniAlbi != 0 && randMutare == 2)
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
            if (trebuieSaSelectezi && counterReginaAlba != 0 && randMutare == 2)
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
            if (trebuieSaSelectezi && counterTureNegre != 0 && randMutare == 1)
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
            if (trebuieSaSelectezi && counterCaiNegri != 0 && randMutare == 1)
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
            if (trebuieSaSelectezi && counterNebuniNegri != 0 && randMutare == 1)
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
            if (trebuieSaSelectezi && counterReginaNeagra != 0 && randMutare == 1)
            {
                Transfera(reginaNeagraLuata, locatii[tempI, tempJ]);
                trebuieSaSelectezi = false;
                labelCRN.Text = (--counterReginaNeagra).ToString();
                transmiteMesaj("#selectat " + tempI + " " + tempJ + " RN");
                transmiteMesaj("#final selectie");
            }
        }
#endregion


        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {               
                StreamWriter scriere = new StreamWriter(clientStream);
                scriere.AutoFlush = true; // enable automatic flushing
                scriere.WriteLine(tbServerDate.Text);
                textBox1.AppendText (username +": " + tbServerDate.Text + Environment.NewLine);
                tbServerDate.Clear();
                // s_text.Close();
            }
            finally
            {
                // code in finally block is guranteed 
                // to execute irrespective of 
                // whether any exception occurs or does 
                // not occur in the try block
                //  client.Close();
            }
        }

        private void btnConect_Click(object sender, EventArgs e)
        {

        }


        //----------------------------------------------------------------------------------------------------------------------
        #region Tooltip optiuni
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

        private void activeazalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sunet = true;
            dezactiveazalToolStripMenuItem.Available = true;
            activeazalToolStripMenuItem.Available = false;
        }

        private void dezactiveazalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sunet = false;
            activeazalToolStripMenuItem.Available = true;
            dezactiveazalToolStripMenuItem.Available = false;
        }
#endregion

        private void meniu1_Load(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();

        }

        private void quitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void quitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
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

        //---------------------------------------------------------------------------------------------------------------------------------------------

        public void NewGame()
        {
            A1 = new LocatieTabla(tura1Alb, _1A);   H1 = new LocatieTabla(tura1Negru, _1H);
            A2 = new LocatieTabla(cal1Alb, _2A);    H2 = new LocatieTabla(cal1Negru, _2H);
            A3 = new LocatieTabla(nebun1Alb, _3A);  H3 = new LocatieTabla(nebun1Negru, _3H);
            A4 = new LocatieTabla(reginaAlb, _4A);  H4 = new LocatieTabla(regeNegru, _4H);
            A5 = new LocatieTabla(regeAlb, _5A);    H5 = new LocatieTabla(reginaNegru, _5H);
            A6 = new LocatieTabla(nebun2Alb, _6A);  H6 = new LocatieTabla(nebun2Negru, _6H);
            A7 = new LocatieTabla(cal2Alb, _7A);    H7 = new LocatieTabla(cal2Negru, _7H);
            A8 = new LocatieTabla(tura2Alb, _8A);   H8 = new LocatieTabla(tura2Negru, _8H);
            B1 = new LocatieTabla(pion1Alb, _1B);   G1 = new LocatieTabla(pion1Negru, _1G);
            B2 = new LocatieTabla(pion2Alb, _2B);   G2 = new LocatieTabla(pion2Negru, _2G);
            B3 = new LocatieTabla(pion3Alb, _3B);   G3 = new LocatieTabla(pion3Negru, _3G);
            B4 = new LocatieTabla(pion4Alb, _4B);   G4 = new LocatieTabla(pion4Negru, _4G);
            B5 = new LocatieTabla(pion5Alb, _5B);   G5 = new LocatieTabla(pion5Negru, _5G);
            B6 = new LocatieTabla(pion6Alb, _6B);   G6 = new LocatieTabla(pion6Negru, _6G);
            B7 = new LocatieTabla(pion7Alb, _7B);   G7 = new LocatieTabla(pion7Negru, _7G);
            B8 = new LocatieTabla(pion8Alb, _8B);   G8 = new LocatieTabla(pion8Negru, _8G); 
            //=====
            C1 = new LocatieTabla(_1C); D1 = new LocatieTabla(_1D); E1 = new LocatieTabla(_1E); F1 = new LocatieTabla(_1F);
            C2 = new LocatieTabla(_2C); D2 = new LocatieTabla(_2D); E2 = new LocatieTabla(_2E); F2 = new LocatieTabla(_2F);
            C3 = new LocatieTabla(_3C); D3 = new LocatieTabla(_3D); E3 = new LocatieTabla(_3E); F3 = new LocatieTabla(_3F);
            C4 = new LocatieTabla(_4C); D4 = new LocatieTabla(_4D); E4 = new LocatieTabla(_4E); F4 = new LocatieTabla(_4F);
            C5 = new LocatieTabla(_5C); D5 = new LocatieTabla(_5D); E5 = new LocatieTabla(_5E); F5 = new LocatieTabla(_5F);
            C6 = new LocatieTabla(_6C); D6 = new LocatieTabla(_6D); E6 = new LocatieTabla(_6E); F6 = new LocatieTabla(_6F);
            C7 = new LocatieTabla(_7C); D7 = new LocatieTabla(_7D); E7 = new LocatieTabla(_7E); F7 = new LocatieTabla(_7F);
            C8 = new LocatieTabla(_8C); D8 = new LocatieTabla(_8D); E8 = new LocatieTabla(_8E); F8 = new LocatieTabla(_8F);
            //=====
            pioniAlbiLuati = new LocatieTabla(pion1Alb, pbPioniAlbiLuati);      pioniNegriLuati = new LocatieTabla(pion1Negru, pbPioniNegriLuati);
            tureAlbeLuate = new LocatieTabla(tura1Alb, pbTureAlbeLuate);        tureNegreLuate = new LocatieTabla(tura1Negru, pbTureNegreLuate);
            caiAlbiLuati = new LocatieTabla(cal1Alb, pbCaiAlbiLuati);           caiNegriLuati = new LocatieTabla(cal1Negru, pbCaiNegriLuati);
            nebuniAlbiLuati = new LocatieTabla(nebun1Alb, pbNebuniAlbiLuati);   nebuniNegriLuati = new LocatieTabla(nebun1Negru, pbNebuniNegriLuati);
            reginaAlbaLuata = new LocatieTabla(reginaAlb, pbReginaAlbaLuata);   reginaNeagraLuata = new LocatieTabla(reginaNegru, pbReginaNeagraLuata);
            //=====           
            locatii = new LocatieTabla[10, 10];
            locatii[1, 1] = A1; locatii[1, 2] = A2; locatii[1, 3] = A3; locatii[1, 4] = A4; locatii[1, 5] = A5; locatii[1, 6] = A6; locatii[1, 7] = A7; locatii[1, 8] = A8;
            locatii[2, 1] = B1; locatii[2, 2] = B2; locatii[2, 3] = B3; locatii[2, 4] = B4; locatii[2, 5] = B5; locatii[2, 6] = B6; locatii[2, 7] = B7; locatii[2, 8] = B8;
            locatii[3, 1] = C1; locatii[3, 2] = C2; locatii[3, 3] = C3; locatii[3, 4] = C4; locatii[3, 5] = C5; locatii[3, 6] = C6; locatii[3, 7] = C7; locatii[3, 8] = C8;
            locatii[4, 1] = D1; locatii[4, 2] = D2; locatii[4, 3] = D3; locatii[4, 4] = D4; locatii[4, 5] = D5; locatii[4, 6] = D6; locatii[4, 7] = D7; locatii[4, 8] = D8;
            locatii[5, 1] = E1; locatii[5, 2] = E2; locatii[5, 3] = E3; locatii[5, 4] = E4; locatii[5, 5] = E5; locatii[5, 6] = E6; locatii[5, 7] = E7; locatii[5, 8] = E8;
            locatii[6, 1] = F1; locatii[6, 2] = F2; locatii[6, 3] = F3; locatii[6, 4] = F4; locatii[6, 5] = F5; locatii[6, 6] = F6; locatii[6, 7] = F7; locatii[6, 8] = F8;
            locatii[7, 1] = G1; locatii[7, 2] = G2; locatii[7, 3] = G3; locatii[7, 4] = G4; locatii[7, 5] = G5; locatii[7, 6] = G6; locatii[7, 7] = G7; locatii[7, 8] = G8;
            locatii[8, 1] = H1; locatii[8, 2] = H2; locatii[8, 3] = H3; locatii[8, 4] = H4; locatii[8, 5] = H5; locatii[8, 6] = H6; locatii[8, 7] = H7; locatii[8, 8] = H8;
            //=====
            MethodInvoker golireIstoric = new MethodInvoker(() => listaMiscari.Rows.Clear());
            clientForm.Invoke(golireIstoric);
            RestoreCulori(locatii);            
            clickCounter = 0;
            if (randMutareServer == 1) { randMutare = 2; rand = false; }
            else { randMutare = 1; rand = true; }
            MethodInvoker text = new MethodInvoker(() => labelRand.Text = "Randul pieselor albe");
            clientForm.Invoke(text);
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
            counterPioniAlbi = 0; counterPioniNegri = 0;
            counterTureAlbe = 0; counterTureNegre = 0;
            counterCaiAlbi = 0; counterCaiNegri = 0;
            counterNebuniAlbi = 0; counterNebuniNegri = 0;
            counterReginaAlba = 0; counterReginaNeagra = 0;
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress addr in localIPs)
            {
                  if (addr.AddressFamily == AddressFamily.InterNetwork)
                  {
                    Console.WriteLine(addr);
                    tbAddress.Text = addr.ToString();
                    break;
                  }
            }
            R(locatii);
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            clientForm = this;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaMiscari.ScrollBars = ScrollBars.Vertical;
            tura1Alb = new Tura(1, pbTuraAlb, pbTuraAlbMic); tura2Alb = new Tura(1, pbTuraAlb, pbTuraAlbMic);
            cal1Alb = new Cal(1, pbCalAlb, pbCalAlbMic); cal2Alb = new Cal(1, pbCalAlb, pbCalAlbMic);
            nebun1Alb = new Nebun(1, pbNebunAlb,pbNebunAlbMic); nebun2Alb = new Nebun(1, pbNebunAlb, pbNebunAlbMic);
            reginaAlb = new Regina(1, pbReginaAlb,pbReginaAlbMic); regeAlb = new Rege(1, pbRegeAlb, pbRegeAlbMic);
            pion1Alb = new Pion(1, pbPionAlb,pbPionAlbMic); pion2Alb = new Pion(1, pbPionAlb, pbPionAlbMic);
            pion3Alb = new Pion(1, pbPionAlb,pbPionAlbMic); pion4Alb = new Pion(1, pbPionAlb, pbPionAlbMic);
            pion5Alb = new Pion(1, pbPionAlb,pbPionAlbMic); pion6Alb = new Pion(1, pbPionAlb, pbPionAlbMic);
            pion7Alb = new Pion(1, pbPionAlb,pbPionAlbMic); pion8Alb = new Pion(1, pbPionAlb, pbPionAlbMic);
            //=====
            tura1Negru = new Tura(2, pbTuraNegru,pbTuraNegruMic); tura2Negru = new Tura(2, pbTuraNegru, pbTuraNegruMic);
            cal1Negru = new Cal(2, pbCalNegru,pbCalNegruMic); cal2Negru = new Cal(2, pbCalNegru, pbCalNegruMic);
            nebun1Negru = new Nebun(2, pbNebunNegru, pbNebunNegruMic); nebun2Negru = new Nebun(2, pbNebunNegru, pbNebunNegruMic);
            reginaNegru = new Regina(2, pbReginaNegru,pbReginaNegruMic); regeNegru = new Rege(2, pbRegeNegru, pbRegeNegruMic);
            pion1Negru = new Pion(2, pbPionNegru,pbPionNegruMic); pion2Negru = new Pion(2, pbPionNegru, pbPionNegruMic);
            pion3Negru = new Pion(2, pbPionNegru,pbPionNegruMic); pion4Negru = new Pion(2, pbPionNegru, pbPionNegruMic);
            pion5Negru = new Pion(2, pbPionNegru,pbPionNegruMic); pion6Negru = new Pion(2, pbPionNegru, pbPionNegruMic);
            pion7Negru = new Pion(2, pbPionNegru,pbPionNegruMic); pion8Negru = new Pion(2, pbPionNegru, pbPionNegruMic);
            //=====
            NewGame();
            destinatie = new LocatieTabla();
            activeazaToolStripMenuItem.Available = false;
            activeazalToolStripMenuItem.Available = false;
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
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        public void Deselectare(LocatieTabla[,] loc)
        {
            Rearanjare(loc); clickCounter = 100; RestoreCulori(loc);
        }

        private void _1A_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && A1 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _1A.BackgroundImage != null && randMutare == A1.culoare && rand)
            {
                A1.piesa.VerificaPosibilitati(1, 1, locatii);
                if (A1.poateFaceMiscari == true)
                {
                    orig = A1;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && A1 != orig && A1.sePoate == true)
            {
                Muta(orig, A1, mesajDeTransmis);
            }
        }

        private void _2A_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && A2 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _2A.BackgroundImage != null && randMutare == A2.culoare && rand)
            {
                A2.piesa.VerificaPosibilitati(1, 2, locatii);
                if (A2.poateFaceMiscari == true)
                {
                    orig = A2;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && A2 != orig && A2.sePoate == true)
            {
                Muta(orig, A2, mesajDeTransmis);
            }
        }

        private void _3A_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && A3 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _3A.BackgroundImage != null && randMutare == A3.culoare && rand)
            {
                A3.piesa.VerificaPosibilitati(1, 3, locatii);
                if (A3.poateFaceMiscari == true)
                {
                    orig = A3;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && A3 != orig && A3.sePoate == true)
            {
                Muta(orig, A3, mesajDeTransmis);
            }
        }

        private void _4A_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && A4 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _4A.BackgroundImage != null && randMutare == A4.culoare && rand)
            {
                A4.piesa.VerificaPosibilitati(1, 4, locatii);
                if (A4.poateFaceMiscari == true)
                {
                    orig = A4;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && A4 != orig && A4.sePoate == true)
            {
                Muta(orig, A4, mesajDeTransmis);
            }
        }

        private void _5A_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && A5 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _5A.BackgroundImage != null && randMutare == A5.culoare && rand)
            {
                A5.piesa.VerificaPosibilitati(1, 5, locatii);
                if (A5.poateFaceMiscari == true)
                {
                    orig = A5;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && A5 != orig && A5.sePoate == true)
            {
                Muta(orig, A5, mesajDeTransmis);
            }
        }

        private void _6A_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && A6 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _6A.BackgroundImage != null && randMutare == A6.culoare && rand)
            {
                A6.piesa.VerificaPosibilitati(1, 6, locatii);
                if (A6.poateFaceMiscari == true)
                {
                    orig = A6;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && A6 != orig && A6.sePoate == true)
            {
                Muta(orig, A6, mesajDeTransmis);
            }
        }

        private void _7A_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && A7 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _7A.BackgroundImage != null && randMutare == A7.culoare && rand)
            {
                A7.piesa.VerificaPosibilitati(1, 7, locatii);
                if (A7.poateFaceMiscari == true)
                {
                    orig = A7;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && A7 != orig && A7.sePoate == true)
            {
                Muta(orig, A7, mesajDeTransmis);
            }
        }

        private void _8A_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && A8 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _8A.BackgroundImage != null && randMutare == A8.culoare && rand)
            {
                A8.piesa.VerificaPosibilitati(1, 8, locatii);
                if (A8.poateFaceMiscari == true)
                {
                    orig = A8;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && A8 != orig && A8.sePoate == true)
            {
                Muta(orig, A8, mesajDeTransmis);
            }
        }

        private void _1B_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && B1 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _1B.BackgroundImage != null && randMutare == B1.culoare && rand)
            {
                B1.piesa.VerificaPosibilitati(2, 1, locatii);
                if (B1.poateFaceMiscari == true)
                {
                    orig = B1;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && B1 != orig && B1.sePoate == true)
            {
                Muta(orig, B1, mesajDeTransmis);
            }
        }

        private void _2B_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && B2 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _2B.BackgroundImage != null && randMutare == B2.culoare && rand)
            {
                B2.piesa.VerificaPosibilitati(2, 2, locatii);
                if (B2.poateFaceMiscari == true)
                {
                    orig = B2;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && B2 != orig && B2.sePoate == true)
            {
                Muta(orig, B2, mesajDeTransmis);
            }
        }

        private void _3B_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && B3 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _3B.BackgroundImage != null && randMutare == B3.culoare && rand)
            {
                B3.piesa.VerificaPosibilitati(2, 3, locatii);
                if (B3.poateFaceMiscari == true)
                {
                    orig = B3;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && B3 != orig && B3.sePoate == true)
            {
                Muta(orig, B3, mesajDeTransmis);
            }
        }

        private void _4B_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && B4 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _4B.BackgroundImage != null && randMutare == B4.culoare && rand)
            {
                B4.piesa.VerificaPosibilitati(2, 4, locatii);
                if (B4.poateFaceMiscari == true)
                {
                    orig = B4;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && B4 != orig && B4.sePoate == true)
            {
                Muta(orig, B4, mesajDeTransmis);
            }
        }

        private void _5B_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && B5 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _5B.BackgroundImage != null && randMutare == B5.culoare && rand)
            {
                B5.piesa.VerificaPosibilitati(2, 5, locatii);
                if (B5.poateFaceMiscari == true)
                {
                    orig = B5;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && B5 != orig && B5.sePoate == true)
            {
                Muta(orig, B5, mesajDeTransmis);
            }
        }

        private void _6B_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && B6 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _6B.BackgroundImage != null && randMutare == B6.culoare && rand)
            {
                B6.piesa.VerificaPosibilitati(2, 6, locatii);
                if (B6.poateFaceMiscari == true)
                {
                    orig = B6;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && B6 != orig && B6.sePoate == true)
            {
                Muta(orig, B6, mesajDeTransmis);
            }
        }

        private void _7B_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && B7 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _7B.BackgroundImage != null && randMutare == B7.culoare && rand)
            {
                B7.piesa.VerificaPosibilitati(2, 7, locatii);
                if (B7.poateFaceMiscari == true)
                {
                    orig = B7;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && B7 != orig && B7.sePoate == true)
            {
                Muta(orig, B7, mesajDeTransmis);
            }
        }

        private void _8B_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && B8 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _8B.BackgroundImage != null && randMutare == B8.culoare && rand)
            {
                B8.piesa.VerificaPosibilitati(2, 8, locatii);
                if (B8.poateFaceMiscari == true)
                {
                    orig = B8;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && B8 != orig && B8.sePoate == true)
            {
                Muta(orig, B8, mesajDeTransmis);
            }
        }

        private void _1C_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && C1 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _1C.BackgroundImage != null && randMutare == C1.culoare && rand)
            {
                C1.piesa.VerificaPosibilitati(3, 1, locatii);
                if (C1.poateFaceMiscari == true)
                {
                    orig = C1;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && C1 != orig && C1.sePoate == true)
            {
                Muta(orig, C1, mesajDeTransmis);
            }
        }

        private void _2C_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && C2 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _2C.BackgroundImage != null && randMutare == C2.culoare && rand)
            {
                C2.piesa.VerificaPosibilitati(3, 2, locatii);
                if (C2.poateFaceMiscari == true)
                {
                    orig = C2;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && C2 != orig && C2.sePoate == true)
            {
                Muta(orig, C2, mesajDeTransmis);
            }
        }

        private void _3C_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && C3 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _3C.BackgroundImage != null && randMutare == C3.culoare && rand)
            {
                C3.piesa.VerificaPosibilitati(3, 3, locatii);
                if (C3.poateFaceMiscari == true)
                {
                    orig = C3;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && C3 != orig && C3.sePoate == true)
            {
                Muta(orig, C3, mesajDeTransmis);
            }
        }

        private void _4C_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && C4 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _4C.BackgroundImage != null && randMutare == C4.culoare && rand)
            {
                C4.piesa.VerificaPosibilitati(3, 4, locatii);
                if (C4.poateFaceMiscari == true)
                {
                    orig = C4;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && C4 != orig && C4.sePoate == true)
            {
                Muta(orig, C4, mesajDeTransmis);
            }
        }

        private void _5C_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && C5 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _5C.BackgroundImage != null && randMutare == C5.culoare && rand)
            {
                C5.piesa.VerificaPosibilitati(3, 5, locatii);
                if (C5.poateFaceMiscari == true)
                {
                    orig = C5;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && C5 != orig && C5.sePoate == true)
            {
                Muta(orig, C5, mesajDeTransmis);
            }
        }

        private void _6C_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && C6 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _6C.BackgroundImage != null && randMutare == C6.culoare && rand)
            {
                C6.piesa.VerificaPosibilitati(3, 6, locatii);
                if (C6.poateFaceMiscari == true)
                {
                    orig = C6;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && C6 != orig && C6.sePoate == true)
            {
                Muta(orig, C6, mesajDeTransmis);
            }
        }

        private void _7C_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && C7 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _7C.BackgroundImage != null && randMutare == C7.culoare && rand)
            {
                C7.piesa.VerificaPosibilitati(3, 7, locatii);
                if (C7.poateFaceMiscari == true)
                {
                    orig = C7;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && C7 != orig && C7.sePoate == true)
            {
                Muta(orig, C7, mesajDeTransmis);
            }
        }

        private void _8C_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && C8 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _8C.BackgroundImage != null && randMutare == C8.culoare && rand)
            {
                C8.piesa.VerificaPosibilitati(3, 8, locatii);
                if (C8.poateFaceMiscari == true)
                {
                    orig = C8;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && C8 != orig && C8.sePoate == true)
            {
                Muta(orig, C8, mesajDeTransmis);
            }
        }

        private void _1D_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && D1 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _1D.BackgroundImage != null && randMutare == D1.culoare && rand)
            {
                D1.piesa.VerificaPosibilitati(4, 1, locatii);
                if (D1.poateFaceMiscari == true)
                {
                    orig = D1;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && D1 != orig && D1.sePoate == true)
            {
                Muta(orig, D1, mesajDeTransmis);
            }
        }

        private void _2D_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && D2 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _2D.BackgroundImage != null && randMutare == D2.culoare && rand)
            {
                D2.piesa.VerificaPosibilitati(4, 2, locatii);
                if (D2.poateFaceMiscari == true)
                {
                    orig = D2;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && D2 != orig && D2.sePoate == true)
            {
                Muta(orig, D2, mesajDeTransmis);
            }
        }

        private void _3D_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && D3 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _3D.BackgroundImage != null && randMutare == D3.culoare && rand)
            {
                D3.piesa.VerificaPosibilitati(4, 3, locatii);
                if (D3.poateFaceMiscari == true)
                {
                    orig = D3;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && D3 != orig && D3.sePoate == true)
            {
                Muta(orig, D3, mesajDeTransmis);
            }
        }

        private void _4D_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && D4 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _4D.BackgroundImage != null && randMutare == D4.culoare && rand)
            {
                D4.piesa.VerificaPosibilitati(4, 4, locatii);
                if (D4.poateFaceMiscari == true)
                {
                    orig = D4;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && D4 != orig && D4.sePoate == true)
            {
                Muta(orig, D4, mesajDeTransmis);
            }
        }

        private void _5D_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && D5 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _5D.BackgroundImage != null && randMutare == D5.culoare && rand)
            {
                D5.piesa.VerificaPosibilitati(4, 5, locatii);
                if (D5.poateFaceMiscari == true)
                {
                    orig = D5;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && D5 != orig && D5.sePoate == true)
            {
                Muta(orig, D5, mesajDeTransmis);
            }
        }

        private void _6D_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && D6 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _6D.BackgroundImage != null && randMutare == D6.culoare && rand)
            {
                D6.piesa.VerificaPosibilitati(4, 6, locatii);
                if (D6.poateFaceMiscari == true)
                {
                    orig = D6;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && D6 != orig && D6.sePoate == true)
            {
                Muta(orig, D6, mesajDeTransmis);
            }
        }

        private void _7D_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && D7 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _7D.BackgroundImage != null && randMutare == D7.culoare && rand)
            {
                D7.piesa.VerificaPosibilitati(4, 7, locatii);
                if (D7.poateFaceMiscari == true)
                {
                    orig = D7;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && D7 != orig && D7.sePoate == true)
            {
                Muta(orig, D7, mesajDeTransmis);
            }
        }

        private void _8D_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && D8 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _8D.BackgroundImage != null && randMutare == D8.culoare && rand)
            {
                D8.piesa.VerificaPosibilitati(4, 8, locatii);
                if (D8.poateFaceMiscari == true)
                {
                    orig = D8;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && D8 != orig && D8.sePoate == true)
            {
                Muta(orig, D8, mesajDeTransmis);
            }
        }

        private void _1E_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && E1 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _1E.BackgroundImage != null && randMutare == E1.culoare && rand)
            {
                E1.piesa.VerificaPosibilitati(5, 1, locatii);
                if (E1.poateFaceMiscari == true)
                {
                    orig = E1;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && E1 != orig && E1.sePoate == true)
            {
                Muta(orig, E1, mesajDeTransmis);
            }
        }

        private void _2E_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && E2 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _2E.BackgroundImage != null && randMutare == E2.culoare && rand)
            {
                E2.piesa.VerificaPosibilitati(5, 2, locatii);
                if (E2.poateFaceMiscari == true)
                {
                    orig = E2;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && E2 != orig && E2.sePoate == true)
            {
                Muta(orig, E2, mesajDeTransmis);
            }
        }

        private void _3E_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && E3 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _3E.BackgroundImage != null && randMutare == E3.culoare && rand)
            {
                E3.piesa.VerificaPosibilitati(5, 3, locatii);
                if (E3.poateFaceMiscari == true)
                {
                    orig = E3;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && E3 != orig && E3.sePoate == true)
            {
                Muta(orig, E3, mesajDeTransmis);
            }
        }

        private void _4E_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && E4 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _4E.BackgroundImage != null && randMutare == E4.culoare && rand)
            {
                E4.piesa.VerificaPosibilitati(5, 4, locatii);
                if (E4.poateFaceMiscari == true)
                {
                    orig = E4;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && E4 != orig && E4.sePoate == true)
            {
                Muta(orig, E4, mesajDeTransmis);
            }
        }

        private void _5E_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && E5 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _5E.BackgroundImage != null && randMutare == E5.culoare && rand)
            {
                E5.piesa.VerificaPosibilitati(5, 5, locatii);
                if (E5.poateFaceMiscari == true)
                {
                    orig = E5;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && E5 != orig && E5.sePoate == true)
            {
                Muta(orig, E5, mesajDeTransmis);
            }
        }

        private void _6E_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && E6 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _6E.BackgroundImage != null && randMutare == E6.culoare && rand)
            {
                E6.piesa.VerificaPosibilitati(5, 6, locatii);
                if (E6.poateFaceMiscari == true)
                {
                    orig = E6;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && E6 != orig && E6.sePoate == true)
            {
                Muta(orig, E6, mesajDeTransmis);
            }
        }

        private void _7E_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && E7 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _7E.BackgroundImage != null && randMutare == E7.culoare && rand)
            {
                E7.piesa.VerificaPosibilitati(5, 7, locatii);
                if (E7.poateFaceMiscari == true)
                {
                    orig = E7;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && E7 != orig && E7.sePoate == true)
            {
                Muta(orig, E7, mesajDeTransmis);
            }
        }

        private void _8E_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && E8 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _8E.BackgroundImage != null && randMutare == E8.culoare && rand)
            {
                E8.piesa.VerificaPosibilitati(5, 8, locatii);
                if (E8.poateFaceMiscari == true)
                {
                    orig = E8;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && E8 != orig && E8.sePoate == true)
            {
                Muta(orig, E8, mesajDeTransmis);
            }
        }

        private void _1F_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && F1 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _1F.BackgroundImage != null && randMutare == F1.culoare && rand)
            {
                F1.piesa.VerificaPosibilitati(6, 1, locatii);
                if (F1.poateFaceMiscari == true)
                {
                    orig = F1;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && F1 != orig && F1.sePoate == true)
            {
                Muta(orig, F1, mesajDeTransmis);
            }
        }

        private void _2F_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && F2 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _2F.BackgroundImage != null && randMutare == F2.culoare && rand)
            {
                F2.piesa.VerificaPosibilitati(6, 2, locatii);
                if (F2.poateFaceMiscari == true)
                {
                    orig = F2;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && F2 != orig && F2.sePoate == true)
            {
                Muta(orig, F2, mesajDeTransmis);
            }
        }

        private void _3F_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && F3 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _3F.BackgroundImage != null && randMutare == F3.culoare && rand)
            {
                F3.piesa.VerificaPosibilitati(6, 3, locatii);
                if (F3.poateFaceMiscari == true)
                {
                    orig = F3;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && F3 != orig && F3.sePoate == true)
            {
                Muta(orig, F3, mesajDeTransmis);
            }
        }

        private void _4F_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && F4 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _4F.BackgroundImage != null && randMutare == F4.culoare && rand)
            {
                F4.piesa.VerificaPosibilitati(6, 4, locatii);
                if (F4.poateFaceMiscari == true)
                {
                    orig = F4;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && F4 != orig && F4.sePoate == true)
            {
                Muta(orig, F4, mesajDeTransmis);
            }
        }

        private void _5F_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && F5 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _5F.BackgroundImage != null && randMutare == F5.culoare && rand)
            {
                F5.piesa.VerificaPosibilitati(6, 5, locatii);
                if (F5.poateFaceMiscari == true)
                {
                    orig = F5;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && F5 != orig && F5.sePoate == true)
            {
                Muta(orig, F5, mesajDeTransmis);
            }
        }

        private void _6F_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && F6 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _6F.BackgroundImage != null && randMutare == F6.culoare && rand)
            {
                F6.piesa.VerificaPosibilitati(6, 6, locatii);
                if (F6.poateFaceMiscari == true)
                {
                    orig = F6;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && F6 != orig && F6.sePoate == true)
            {
                Muta(orig, F6, mesajDeTransmis);
            }
        }

        private void _7F_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && F7 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _7F.BackgroundImage != null && randMutare == F7.culoare && rand)
            {
                F7.piesa.VerificaPosibilitati(6, 7, locatii);
                if (F7.poateFaceMiscari == true)
                {
                    orig = F7;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && F7 != orig && F7.sePoate == true)
            {
                Muta(orig, F7, mesajDeTransmis);
            }
        }

        private void _8F_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && F8 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _8F.BackgroundImage != null && randMutare == F8.culoare && rand)
            {
                F8.piesa.VerificaPosibilitati(6, 8, locatii);
                if (F8.poateFaceMiscari == true)
                {
                    orig = F8;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && F8 != orig && F8.sePoate == true)
            {
                Muta(orig, F8, mesajDeTransmis);
            }
        }

        private void _1G_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && G1 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _1G.BackgroundImage != null && randMutare == G1.culoare && rand)
            {
                G1.piesa.VerificaPosibilitati(7, 1, locatii);
                if (G1.poateFaceMiscari == true)
                {
                    orig = G1;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && G1 != orig && G1.sePoate == true)
            {
                Muta(orig, G1, mesajDeTransmis);
            }
        }

        private void _2G_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && G2 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _2G.BackgroundImage != null && randMutare == G2.culoare && rand)
            {
                G2.piesa.VerificaPosibilitati(7, 2, locatii);
                if (G2.poateFaceMiscari == true)
                {
                    orig = G2;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && G2 != orig && G2.sePoate == true)
            {
                Muta(orig, G2, mesajDeTransmis);
            }
        }

        private void _3G_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && G3 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _3G.BackgroundImage != null && randMutare == G3.culoare && rand)
            {
                G3.piesa.VerificaPosibilitati(7, 3, locatii);
                if (G3.poateFaceMiscari == true)
                {
                    orig = G3;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && G3 != orig && G3.sePoate == true)
            {
                Muta(orig, G3, mesajDeTransmis);
            }
        }

        private void _4G_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && G4 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _4G.BackgroundImage != null && randMutare == G4.culoare && rand)
            {
                G4.piesa.VerificaPosibilitati(7, 4, locatii);
                if (G4.poateFaceMiscari == true)
                {
                    orig = G4;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && G4 != orig && G4.sePoate == true)
            {
                Muta(orig, G4, mesajDeTransmis);
            }
        }

        private void _5G_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && G5 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _5G.BackgroundImage != null && randMutare == G5.culoare && rand)
            {
                G5.piesa.VerificaPosibilitati(7, 5, locatii);
                if (G5.poateFaceMiscari == true)
                {
                    orig = G5;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && G5 != orig && G5.sePoate == true)
            {
                Muta(orig, G5, mesajDeTransmis);
            }
        }

        private void _6G_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && G6 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _6G.BackgroundImage != null && randMutare == G6.culoare && rand)
            {
                G6.piesa.VerificaPosibilitati(7, 6, locatii);
                if (G6.poateFaceMiscari == true)
                {
                    orig = G6;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && G6 != orig && G6.sePoate == true)
            {
                Muta(orig, G6, mesajDeTransmis);
            }
        }

        private void _7G_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && G7 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _7G.BackgroundImage != null && randMutare == G7.culoare && rand)
            {
                G7.piesa.VerificaPosibilitati(7, 7, locatii);
                if (G7.poateFaceMiscari == true)
                {
                    orig = G7;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && G7 != orig && G7.sePoate == true)
            {
                Muta(orig, G7, mesajDeTransmis);
            }
        }

        private void _8G_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && G8 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _8G.BackgroundImage != null && randMutare == G8.culoare && rand)
            {
                G8.piesa.VerificaPosibilitati(7, 8, locatii);
                if (G8.poateFaceMiscari == true)
                {
                    orig = G8;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && G8 != orig && G8.sePoate == true)
            {
                Muta(orig, G8, mesajDeTransmis);
            }
        }

        private void _1H_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && H1 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _1H.BackgroundImage != null && randMutare == H1.culoare && rand)
            {
                H1.piesa.VerificaPosibilitati(8, 1, locatii);
                if (H1.poateFaceMiscari == true)
                {
                    orig = H1;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && H1 != orig && H1.sePoate == true)
            {
                Muta(orig, H1, mesajDeTransmis);
            }
        }

        private void _2H_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && H2 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _2H.BackgroundImage != null && randMutare == H2.culoare && rand)
            {
                H2.piesa.VerificaPosibilitati(8, 2, locatii);
                if (H2.poateFaceMiscari == true)
                {
                    orig = H2;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && H2 != orig && H2.sePoate == true)
            {
                Muta(orig, H2, mesajDeTransmis);
            }
        }

        private void _3H_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && H3 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _3H.BackgroundImage != null && randMutare == H3.culoare && rand)
            {
                H3.piesa.VerificaPosibilitati(8, 3, locatii);
                if (H3.poateFaceMiscari == true)
                {
                    orig = H3;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && H3 != orig && H3.sePoate == true)
            {
                Muta(orig, H3, mesajDeTransmis);
            }
        }

        private void _4H_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && H4 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _4H.BackgroundImage != null && randMutare == H4.culoare && rand)
            {
                H4.piesa.VerificaPosibilitati(8, 4, locatii);
                if (H4.poateFaceMiscari == true)
                {
                    orig = H4;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && H4 != orig && H4.sePoate == true)
            {
                Muta(orig, H4, mesajDeTransmis);
            }
        }

        private void _5H_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && H5 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _5H.BackgroundImage != null && randMutare == H5.culoare && rand)
            {
                H5.piesa.VerificaPosibilitati(8, 5, locatii);
                if (H5.poateFaceMiscari == true)
                {
                    orig = H5;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && H5 != orig && H5.sePoate == true)
            {
                Muta(orig, H5, mesajDeTransmis);
            }
        }

        private void _6H_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && H6 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _6H.BackgroundImage != null && randMutare == H6.culoare && rand)
            {
                H6.piesa.VerificaPosibilitati(8, 6, locatii);
                if (H6.poateFaceMiscari == true)
                {
                    orig = H6;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && H6 != orig && H6.sePoate == true)
            {
                Muta(orig, H6, mesajDeTransmis);
            }
        }

        private void _7H_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && H7 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _7H.BackgroundImage != null && randMutare == H7.culoare && rand)
            {
                H7.piesa.VerificaPosibilitati(8, 7, locatii);
                if (H7.poateFaceMiscari == true)
                {
                    orig = H7;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && H7 != orig && H7.sePoate == true)
            {
                Muta(orig, H7, mesajDeTransmis);
            }
        }

        private void _8H_Click(object sender, EventArgs e)
        {
            if (trebuieSaSelectezi || adversarulSelecteaza) return;
            if (clickCounter == 1 && H8 == orig)
            {
                Rearanjare(locatii); clickCounter = 100; RestoreCulori(locatii);
            }
            if (clickCounter == 0 && _8H.BackgroundImage != null && randMutare == H8.culoare && rand)
            {
                H8.piesa.VerificaPosibilitati(8, 8, locatii);
                if (H8.poateFaceMiscari == true)
                {
                    orig = H8;
                    clickCounter++;
                }
            }
            if (clickCounter == 100) clickCounter = 0; if (clickCounter == 1 && H8 != orig && H8.sePoate == true)
            {
                Muta(orig, H8, mesajDeTransmis);
            }
        }
    }
}
