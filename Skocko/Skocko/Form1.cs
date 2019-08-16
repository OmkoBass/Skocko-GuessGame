using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Skocko
{
    public partial class Form1 : Form
    {

        PictureBox[] boje = new PictureBox[24]; //Generise da znamo crvena i zuta pogadjanja //hit or near miss
        PictureBox[] pogadjaj = new PictureBox[24]; //Generise nas input //our input
        int[] dobitna = new int[24];
        string s = null; //String Combination //String kombinacija
        int br = 0; //Timer seconds

        private static void generisiRandomZnakove(int[] n) // <== Generise random kombianciju // Creates a random combination
        {
            Random r = new Random();
            for (int i = 0; i < 4; i++)  //1 tref -- 2 pik -- 3 herc -- 4 karo //1 clover -- 2 fuck it -- 3 heats -- 4 diamounds
            {
                n[i] = r.Next(1, 5);
            }

            int br = 0;

            for (int i = 4; i < 24; i++)
            {
                if (br == 4) { br = 0; n[i] = n[br]; br++; }
                else { n[i] = n[br]; br++; }
            }
        }

        public string getDobitna()
        {
            string s = "";
            for (int i = 0; i < 4; i++)
            { 
                switch (dobitna[i])
                {
                    case 1:
                        s += "tref ";
                        break;
                    case 2:
                        s += "pik ";
                        break;
                    case 3:
                        s += "herc ";
                        break;
                    case 4:
                        s += "karo ";
                        break;
                }
            }
            return s;
        }

        public Form1()
        {

            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000; // interval = 1 sec
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Enabled = true;

            InitializeComponent();
            generisiRandomZnakove(dobitna);
            s = getDobitna();
            int horizontalb = 280;
            int verticalb = 15;
            int horizontalp = 15;
            int verticalp = 15;
            for(int i = 0; i < 24; i++)
            {
                boje[i] = new PictureBox();
                boje[i].Size = new Size(60, 53);
                boje[i].Location = new Point(horizontalb, verticalb);
                boje[i].Name = $"b{i}";
                boje[i].BorderStyle = BorderStyle.FixedSingle;
                boje[i].BackColor = Color.White;
                if(i == 3 || i == 7 || i == 11 || i == 15 || i == 19 || i == 23) { verticalb += 75; horizontalb = 280; }
                else { horizontalb += 63; }
                this.Controls.Add(boje[i]);
            }
            for(int i = 0; i < 24; i++)
            {
                pogadjaj[i] = new PictureBox();
                pogadjaj[i].Size = new Size(60, 53);
                pogadjaj[i].Location = new Point(horizontalp, verticalp);
                pogadjaj[i].Name = $"p{i}";
                boje[i].BorderStyle = BorderStyle.FixedSingle;
                pogadjaj[i].BackColor = Color.White;
                pogadjaj[i].SizeMode = PictureBoxSizeMode.Zoom;
                if(i == 3 || i == 7 || i == 11 || i == 15 || i == 19 || i == 23) { verticalp += 75; horizontalp = 15; }
                else { horizontalp += 63; }
                this.Controls.Add(pogadjaj[i]);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (br == 60) { timer1.Enabled = false; MessageBox.Show($"Nestalo je vremena\n{s}"); this.Close(); }
            else { progress.Value = br; br += 1; }
        }

        private int logika(int pocni, int zavrsi)
        {
            int br = pocni;
            for(int i = pocni; i < zavrsi; i++)
            {
                if(tvoja[i] == dobitna[i])
                {
                    boje[br].BackColor = Color.Red;
                    tvoja[i] = -1; dobitna[i] = -1;
                    br++;
                }
            }

            int temp = br;

            for(int i = pocni; i < zavrsi; i++)
            {
                for(int j = pocni; j < zavrsi; j++)
                {
                    if (tvoja[i] == dobitna[j] && tvoja[i] != -1 && dobitna[j] != -1)
                    {
                        boje[temp].BackColor = Color.Yellow;
                        tvoja[i] = -1; dobitna[j] = -1;
                        temp++;
                    }
                }
            }

            return br;
        }

        void proveri(int brojac)
        {
            switch (brojac)
            {
                case 3:
                    if(logika(0, 4) == 4) { timer1.Enabled = false; MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 7:
                    if (logika(4, 8) == 8) { timer1.Enabled = false; MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 11:
                    if (logika(8, 12) == 12) { timer1.Enabled = false; MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 15:
                    if (logika(12, 16) == 16) { timer1.Enabled = false; MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 19:
                    if (logika(16, 20) == 20) { timer1.Enabled = false; MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 23:
                    if (logika(20, 24) == 24) { timer1.Enabled = false; MessageBox.Show("Tacno!"); this.Close(); }
                    break;
            }
        }

        int brojac = 0;
        int[] tvoja = new int[24];


        //U ovim ovde funkcijama je problem
        //brojac == 3 || brojac == 7 || brojac == 11 || brojac == 15 || brojac == 19 || brojac == 23 <- ne radi, ne okida uopste
        private void Tref_Click(object sender, EventArgs e)
        {
            try
            {
                if (brojac == 3 || brojac == 7 || brojac == 11 || brojac == 15 || brojac == 19 || brojac == 23)
                {
                    
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/clubs_24px.png");
                    tvoja[brojac] = 1;
                    proveri(brojac);
                    brojac++;
                }
                else if(brojac == 23) { MessageBox.Show(s); this.Close(); }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/clubs_24px.png");
                    tvoja[brojac] = 1;
                    brojac++;
                }
            }
            catch { MessageBox.Show(s); this.Close(); }
        }

        private void Pik_Click(object sender, EventArgs e)
        {
            try
            {
                if (brojac == 3 || brojac == 7 || brojac == 11 || brojac == 15 || brojac == 19 || brojac == 23)
                {
              
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/spades_26px.png");
                    tvoja[brojac] = 2;
                    proveri(brojac);
                    brojac++;
                }
                else if (brojac == 23) { MessageBox.Show(s); this.Close(); }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/spades_26px.png");
                    tvoja[brojac] = 2;
                    brojac++;
                }
            }
            catch { MessageBox.Show(s); this.Close(); }
        }

        private void Herc_Click(object sender, EventArgs e)
        {
            try
            {
                if (brojac == 3 || brojac == 7 || brojac == 11 || brojac == 15 || brojac == 19 || brojac == 23)
                {
                  
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/hearts_48px.png");
                    tvoja[brojac] = 3;
                    proveri(brojac);
                    brojac++;
                }
                else if (brojac == 23) { MessageBox.Show(s); this.Close(); }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/hearts_48px.png");
                    tvoja[brojac] = 3;
                    brojac++;
                }
            }
            catch { MessageBox.Show(s); this.Close(); }
        }

        private void Karo_Click(object sender, EventArgs e)
        {
            try
            {
                if (brojac == 3 || brojac == 7 || brojac == 11 || brojac == 15 || brojac == 19 || brojac == 23)
                {
                
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/diamonds_48px.png");
                    tvoja[brojac] = 4;
                    proveri(brojac);
                    brojac++;
                }
                else if (brojac == 23) { MessageBox.Show(s); this.Close(); }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/diamonds_48px.png");
                    tvoja[brojac] = 4;
                    brojac++;
                }
            }
            catch { MessageBox.Show(s); this.Close(); }
        }
    }
}