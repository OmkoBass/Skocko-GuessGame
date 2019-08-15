﻿using System;
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

        private static void generisiRandomZnakove(int[] n) // <== Generise random kombianciju // Creates a random combination
        {
            Random r = new Random();
            for (int i = 0; i < 4; i++)  //1 tref -- 2 pik -- 3 herc -- 4 karo //1 clover -- 2 fuck it -- 3 heats -- 4 diamounds
            {
                n[i] = r.Next(1, 5);
                MessageBox.Show(n[i].ToString());
            }
            int br = 0;

            for (int i = 4; i < 24; i++)
            {
                if (br == 4) { br = 0; n[i] = n[br]; br++; }
                else { n[i] = n[br]; br++; }
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
                Debug.Print($"dobitna{dobitna[i]} --- tvoja{tvoja[i]}");
               if (tvoja[i] == dobitna[i])//same index == same position == good
                {//Ako su po istom indeksu onda su ista pozicija i stavi crveno
                    boje[br].BackColor = Color.Red;
                    dobitna[i] = 0; 
                    tvoja[i] = 0;
                    br++;
                }
                for (int j = pocni; j <= zavrsi; j++)//same but not in good positions
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
                case 3:
                    if(logika(0, 4) == 3) { MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 7:
                    if (logika(4, 8) == 7) { MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 11:
                    if (logika(8, 12) == 11) { MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 15:
                    if (logika(12, 16) == 15) { MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 19:
                    if (logika(16, 20) == 19) { MessageBox.Show("Tacno!"); this.Close(); }
                    break;
                case 23:
                    if (logika(20, 24) == 23) { MessageBox.Show("Tacno!"); this.Close(); }
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
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/clubs_24px.png");
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
                if (brojac == 3 || brojac == 7 || brojac == 11 || brojac == 15 || brojac == 19 || brojac == 23)
                {
              
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/spades_26px.png");
                    tvoja[brojac] = 2;
                    proveri(brojac);
                    brojac++;
                }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/spades_26px.png");
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
                if (brojac == 3 || brojac == 7 || brojac == 11 || brojac == 15 || brojac == 19 || brojac == 23)
                {
                  
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/hearts_48px.png");
                    tvoja[brojac] = 3;
                    proveri(brojac);
                    brojac++;
                }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/hearts_48px.png");
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
                if (brojac == 3 || brojac == 7 || brojac == 11 || brojac == 15 || brojac == 19 || brojac == 23)
                {
                
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/diamonds_48px.png");
                    tvoja[brojac] = 4;
                    proveri(brojac);
                    brojac++;
                }
                else
                {
                    pogadjaj[brojac].Image = Image.FromFile(@"Resources/diamonds_48px.png");
                    tvoja[brojac] = 4;
                    brojac++;
                }
            }
            catch { MessageBox.Show("Neuspesno!"); this.Close(); }
        }
    }
}
