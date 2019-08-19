namespace Skocko
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tref = new System.Windows.Forms.PictureBox();
            this.pik = new System.Windows.Forms.PictureBox();
            this.herc = new System.Windows.Forms.PictureBox();
            this.karo = new System.Windows.Forms.PictureBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.klik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tref)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.herc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.karo)).BeginInit();
            this.SuspendLayout();
            // 
            // tref
            // 
            this.tref.Image = global::Skocko.Properties.Resources.clubs_24px;
            this.tref.Location = new System.Drawing.Point(565, 12);
            this.tref.Name = "tref";
            this.tref.Size = new System.Drawing.Size(44, 53);
            this.tref.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tref.TabIndex = 3;
            this.tref.TabStop = false;
            this.tref.Click += new System.EventHandler(this.Tref_Click);
            // 
            // pik
            // 
            this.pik.Image = global::Skocko.Properties.Resources.spades_26px;
            this.pik.Location = new System.Drawing.Point(615, 12);
            this.pik.Name = "pik";
            this.pik.Size = new System.Drawing.Size(44, 53);
            this.pik.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pik.TabIndex = 2;
            this.pik.TabStop = false;
            this.pik.Click += new System.EventHandler(this.Pik_Click);
            // 
            // herc
            // 
            this.herc.Image = global::Skocko.Properties.Resources.hearts_48px;
            this.herc.Location = new System.Drawing.Point(665, 12);
            this.herc.Name = "herc";
            this.herc.Size = new System.Drawing.Size(44, 53);
            this.herc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.herc.TabIndex = 1;
            this.herc.TabStop = false;
            this.herc.Click += new System.EventHandler(this.Herc_Click);
            // 
            // karo
            // 
            this.karo.Image = global::Skocko.Properties.Resources.diamonds_48px;
            this.karo.Location = new System.Drawing.Point(715, 12);
            this.karo.Name = "karo";
            this.karo.Size = new System.Drawing.Size(44, 53);
            this.karo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.karo.TabIndex = 0;
            this.karo.TabStop = false;
            this.karo.Click += new System.EventHandler(this.Karo_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 466);
            this.progress.Maximum = 60;
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(747, 23);
            this.progress.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // klik
            // 
            this.klik.AutoSize = true;
            this.klik.Font = new System.Drawing.Font("Fira Code", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klik.Location = new System.Drawing.Point(562, 68);
            this.klik.Name = "klik";
            this.klik.Size = new System.Drawing.Size(197, 33);
            this.klik.TabIndex = 5;
            this.klik.Text = "Klikni znakove";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(771, 501);
            this.Controls.Add(this.klik);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.tref);
            this.Controls.Add(this.pik);
            this.Controls.Add(this.herc);
            this.Controls.Add(this.karo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(787, 540);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Skocko";
            ((System.ComponentModel.ISupportInitialize)(this.tref)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.herc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.karo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox karo;
        private System.Windows.Forms.PictureBox herc;
        private System.Windows.Forms.PictureBox pik;
        private System.Windows.Forms.PictureBox tref;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label klik;
    }
}

