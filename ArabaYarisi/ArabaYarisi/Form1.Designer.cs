namespace ArabaYarisi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgLose = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.imgPatlama = new System.Windows.Forms.PictureBox();
            this.imgWinner = new System.Windows.Forms.PictureBox();
            this.Bot2 = new System.Windows.Forms.PictureBox();
            this.Bot1 = new System.Windows.Forms.PictureBox();
            this.YolCizgileri2 = new System.Windows.Forms.PictureBox();
            this.YolCizgileri1 = new System.Windows.Forms.PictureBox();
            this.btnBasla = new System.Windows.Forms.Button();
            this.lblSkor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPatlama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YolCizgileri2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YolCizgileri1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.imgLose);
            this.panel1.Controls.Add(this.player);
            this.panel1.Controls.Add(this.imgPatlama);
            this.panel1.Controls.Add(this.imgWinner);
            this.panel1.Controls.Add(this.Bot2);
            this.panel1.Controls.Add(this.Bot1);
            this.panel1.Controls.Add(this.YolCizgileri2);
            this.panel1.Controls.Add(this.YolCizgileri1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 520);
            this.panel1.TabIndex = 0;
            // 
            // imgLose
            // 
            this.imgLose.BackColor = System.Drawing.Color.Transparent;
            this.imgLose.Image = global::ArabaYarisi.Properties.Resources.loseimg;
            this.imgLose.Location = new System.Drawing.Point(106, 149);
            this.imgLose.Name = "imgLose";
            this.imgLose.Size = new System.Drawing.Size(275, 182);
            this.imgLose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLose.TabIndex = 7;
            this.imgLose.TabStop = false;
            this.imgLose.Visible = false;
            // 
            // player
            // 
            this.player.Image = global::ArabaYarisi.Properties.Resources.carOrange;
            this.player.Location = new System.Drawing.Point(217, 408);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(50, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 6;
            this.player.TabStop = false;
            // 
            // imgPatlama
            // 
            this.imgPatlama.Image = global::ArabaYarisi.Properties.Resources.explosion;
            this.imgPatlama.Location = new System.Drawing.Point(75, 368);
            this.imgPatlama.Name = "imgPatlama";
            this.imgPatlama.Size = new System.Drawing.Size(64, 64);
            this.imgPatlama.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgPatlama.TabIndex = 5;
            this.imgPatlama.TabStop = false;
            // 
            // imgWinner
            // 
            this.imgWinner.BackColor = System.Drawing.Color.Transparent;
            this.imgWinner.Image = global::ArabaYarisi.Properties.Resources.winnerimg;
            this.imgWinner.Location = new System.Drawing.Point(106, 149);
            this.imgWinner.Name = "imgWinner";
            this.imgWinner.Size = new System.Drawing.Size(275, 182);
            this.imgWinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgWinner.TabIndex = 4;
            this.imgWinner.TabStop = false;
            // 
            // Bot2
            // 
            this.Bot2.Image = global::ArabaYarisi.Properties.Resources.carYellow;
            this.Bot2.Location = new System.Drawing.Point(310, 125);
            this.Bot2.Name = "Bot2";
            this.Bot2.Size = new System.Drawing.Size(50, 99);
            this.Bot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Bot2.TabIndex = 3;
            this.Bot2.TabStop = false;
            this.Bot2.Tag = "sagdakiAraba";
            // 
            // Bot1
            // 
            this.Bot1.Image = global::ArabaYarisi.Properties.Resources.CarRed;
            this.Bot1.Location = new System.Drawing.Point(75, 125);
            this.Bot1.Name = "Bot1";
            this.Bot1.Size = new System.Drawing.Size(50, 100);
            this.Bot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Bot1.TabIndex = 2;
            this.Bot1.TabStop = false;
            this.Bot1.Tag = "soldakiAraba";
            this.Bot1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // YolCizgileri2
            // 
            this.YolCizgileri2.Image = global::ArabaYarisi.Properties.Resources.roadTrack;
            this.YolCizgileri2.Location = new System.Drawing.Point(0, 0);
            this.YolCizgileri2.Name = "YolCizgileri2";
            this.YolCizgileri2.Size = new System.Drawing.Size(475, 520);
            this.YolCizgileri2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.YolCizgileri2.TabIndex = 1;
            this.YolCizgileri2.TabStop = false;
            // 
            // YolCizgileri1
            // 
            this.YolCizgileri1.Image = global::ArabaYarisi.Properties.Resources.roadTrack;
            this.YolCizgileri1.Location = new System.Drawing.Point(0, -519);
            this.YolCizgileri1.Name = "YolCizgileri1";
            this.YolCizgileri1.Size = new System.Drawing.Size(475, 520);
            this.YolCizgileri1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.YolCizgileri1.TabIndex = 0;
            this.YolCizgileri1.TabStop = false;
            // 
            // btnBasla
            // 
            this.btnBasla.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBasla.Location = new System.Drawing.Point(168, 572);
            this.btnBasla.Name = "btnBasla";
            this.btnBasla.Size = new System.Drawing.Size(165, 53);
            this.btnBasla.TabIndex = 1;
            this.btnBasla.Text = "Tekrar Dene";
            this.btnBasla.UseVisualStyleBackColor = true;
            this.btnBasla.Click += new System.EventHandler(this.btnBasla_Click);
            // 
            // lblSkor
            // 
            this.lblSkor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSkor.Location = new System.Drawing.Point(12, 535);
            this.lblSkor.Name = "lblSkor";
            this.lblSkor.Size = new System.Drawing.Size(475, 34);
            this.lblSkor.TabIndex = 2;
            this.lblSkor.Text = "Skor: 0";
            this.lblSkor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(8, 628);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(478, 144);
            this.label3.TabIndex = 4;
            this.label3.Text = "Yön tuşlarıyla aracını sağa sola hareket ettir ve diğer araçlara çarpmamaya çalış" +
    ".\r\n\r\n1500 skor ve üstü yaparsan yarışı kazanırsın.\r\n\r\n(Hile için x ye z tuşların" +
    "a aynı anda bas.)\r\n\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 781);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSkor);
            this.Controls.Add(this.btnBasla);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Araba Yarışı Oyunu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPatlama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YolCizgileri2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YolCizgileri1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBasla;
        private System.Windows.Forms.Label lblSkor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox imgPatlama;
        private System.Windows.Forms.PictureBox imgWinner;
        private System.Windows.Forms.PictureBox Bot2;
        private System.Windows.Forms.PictureBox Bot1;
        private System.Windows.Forms.PictureBox YolCizgileri2;
        private System.Windows.Forms.PictureBox YolCizgileri1;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox imgLose;
    }
}

