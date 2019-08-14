using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skocko
{
    public partial class Form1 : Form
    {

        PictureBox[] boje = new PictureBox[24]; //Generise da znamo crvena i zuta pogadjanja //hit or near miss
        PictureBox[] pogadjaj = new PictureBox[24]; //Generise nas input //our input
        int[] dobitna = new int[24];

        private void generisiRandomZnakove(int[] n) // <== Generise random kombianciju // Creates a random combination
        {
            int br = 0;
            Random r = new Random();
            for(int i = 0; i < 4; i++)  //1 tref -- 2 pik -- 3 herc -- 4 karo //1 clover -- 2 fuck it -- 3 heats -- 4 diamounds
            {
                n[i] = r.Next(1, 5);
                MessageBox.Show($"{n[i]}");
            }

            for(int i = 4; i < 24; i++) //So i don't go out of bounds, it copies the combiantion
            {                           //from 0-3 indekes to all others till 23
                if(br % 4 == 0)         //da uhvatim exception, uzima dobitnu kombinaciju i baca je za svaki "red"
                {
                    br = 0;
                }
                else
                {
                    n[i] = n[br];
                    br++;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            generisiRandomZnakove(dobitna);
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

        private int logika(int pocni, int zavrsi)
        {
            int br = pocni;
            for (int i = pocni; i < zavrsi; i++)
            {
                if (tvoja[i] == dobitna[i])//same index == same position == good
                {//Ako su po istom indeksu onda su ista pozicija i stavi crveno
                    boje[br].BackColor = Color.Red;
                    dobitna[i] = 0; 
                    tvoja[i] = 0;
                    br++;
                }
                for (int j = pocni; j < zavrsi; j++)//same but no in good positions
                {//ako su isti al' ne na dobrim pozicijama
                    if ((tvoja[i] == dobitna[j]) && (tvoja[i] != 0))
                    {
                        if (i == j) { continue; }
                        boje[br].BackColor = Color.Yellow;
                        dobitna[j] = 0;
                    }
                }
            }
            return br;
        }

        void proveri(int brojac)
        {
            switch (brojac)
            {
                case 4:
                    if(logika(0, 4) == 4) { MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 8:
                    if (logika(4, 8) == 8) { MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 12:
                    if (logika(8, 12) == 12) { MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 16:
                    if (logika(12, 16) == 16) { MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 20:
                    if (logika(16, 20) == 20) { MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 24:
                    if (logika(20, 24) == 24) { MessageBox.Show("Tacno!"); this.Close(); }
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
                if (brojac % 4 == 0)
                {
                    proveri(brojac);
                    pogadjaj[brojac].Image = Image.FromFile(@"D:/Code/C#/Skocko/Skocko/Resources/clubs_24px.png");
                    tvoja[brojac] = 1;
                    brojac++;
                }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"D:/Code/C#/Skocko/Skocko/Resources/clubs_24px.png");
                    tvoja[brojac] = 1;
                    brojac++;
                }
            }
            catch { MessageBox.Show("Neuspesno!"); this.Close(); }
        }

        private void Pik_Click(object sender, EventArgs e)
        {
            try
            {
                if (brojac % 4 == 0)
                {
                    proveri(brojac);
                    pogadjaj[brojac].Image = Image.FromFile(@"D:/Code/C#/Skocko/Skocko/Resources/spades_26px.png");
                    tvoja[brojac] = 2;
                    brojac++;
                }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"D:/Code/C#/Skocko/Skocko/Resources/spades_26px.png");
                    tvoja[brojac] = 2;
                    brojac++;
                }
            }
            catch { MessageBox.Show("Neuspesno!"); this.Close(); }
        }

        private void Herc_Click(object sender, EventArgs e)
        {
            try
            {
                if (brojac % 4 == 0)
                {
                    proveri(brojac);
                    pogadjaj[brojac].Image = Image.FromFile(@"D:/Code/C#/Skocko/Skocko/Resources/hearts_48px.png");
                    tvoja[brojac] = 3;
                    brojac++;
                }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"D:/Code/C#/Skocko/Skocko/Resources/hearts_48px.png");
                    tvoja[brojac] = 3;
                    brojac++;
                }
            }
            catch { MessageBox.Show("Neuspesno!"); this.Close(); }
        }

        private void Karo_Click(object sender, EventArgs e)
        {
            try
            {
                if (brojac % 4 == 0)
                {
                    proveri(brojac);
                    pogadjaj[brojac].Image = Image.FromFile(@"D:/Code/C#/Skocko/Skocko/Resources/diamonds_48px.png");
                    tvoja[brojac] = 4;
                    brojac++;
                }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"D:/Code/C#/Skocko/Skocko/Resources/diamonds_48px.png");
                    tvoja[brojac] = 4;
                    brojac++;
                }
            }
            catch { MessageBox.Show("Neuspesno!"); this.Close(); }
        }
    }
}
