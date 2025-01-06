namespace FlappyBirdGame
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
            this.lblSkor = new System.Windows.Forms.Label();
            this.oyunSuresi = new System.Windows.Forms.Timer(this.components);
            this.flappyBird = new System.Windows.Forms.PictureBox();
            this.zemin = new System.Windows.Forms.PictureBox();
            this.altBoru = new System.Windows.Forms.PictureBox();
            this.ustBoru = new System.Windows.Forms.PictureBox();
            this.lblHiz = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flappyBird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zemin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.altBoru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ustBoru)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSkor
            // 
            this.lblSkor.AutoSize = true;
            this.lblSkor.BackColor = System.Drawing.Color.Bisque;
            this.lblSkor.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkor.Location = new System.Drawing.Point(0, 705);
            this.lblSkor.Name = "lblSkor";
            this.lblSkor.Size = new System.Drawing.Size(174, 42);
            this.lblSkor.TabIndex = 4;
            this.lblSkor.Text = "Score : 0";
            this.lblSkor.Click += new System.EventHandler(this.lblSkor_Click);
            // 
            // oyunSuresi
            // 
            this.oyunSuresi.Enabled = true;
            this.oyunSuresi.Interval = 20;
            this.oyunSuresi.Tick += new System.EventHandler(this.oyunSuresiEventi);
            // 
            // flappyBird
            // 
            this.flappyBird.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.flappyBird.Image = global::FlappyBirdGame.Properties.Resources.flappyBird;
            this.flappyBird.Location = new System.Drawing.Point(79, 280);
            this.flappyBird.Name = "flappyBird";
            this.flappyBird.Size = new System.Drawing.Size(85, 72);
            this.flappyBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flappyBird.TabIndex = 5;
            this.flappyBird.TabStop = false;
            // 
            // zemin
            // 
            this.zemin.BackColor = System.Drawing.Color.Bisque;
            this.zemin.Image = global::FlappyBirdGame.Properties.Resources.zemin;
            this.zemin.Location = new System.Drawing.Point(-3, 697);
            this.zemin.Name = "zemin";
            this.zemin.Size = new System.Drawing.Size(670, 50);
            this.zemin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.zemin.TabIndex = 3;
            this.zemin.TabStop = false;
            // 
            // altBoru
            // 
            this.altBoru.Image = global::FlappyBirdGame.Properties.Resources.yukari_boru;
            this.altBoru.Location = new System.Drawing.Point(496, 440);
            this.altBoru.Name = "altBoru";
            this.altBoru.Size = new System.Drawing.Size(112, 264);
            this.altBoru.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.altBoru.TabIndex = 2;
            this.altBoru.TabStop = false;
            // 
            // ustBoru
            // 
            this.ustBoru.Image = global::FlappyBirdGame.Properties.Resources.asagi_boru;
            this.ustBoru.Location = new System.Drawing.Point(496, -4);
            this.ustBoru.Name = "ustBoru";
            this.ustBoru.Size = new System.Drawing.Size(112, 264);
            this.ustBoru.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ustBoru.TabIndex = 0;
            this.ustBoru.TabStop = false;
            this.ustBoru.Click += new System.EventHandler(this.ustBoru_Click);
            // 
            // lblHiz
            // 
            this.lblHiz.AutoSize = true;
            this.lblHiz.BackColor = System.Drawing.Color.Bisque;
            this.lblHiz.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiz.Location = new System.Drawing.Point(485, 705);
            this.lblHiz.Name = "lblHiz";
            this.lblHiz.Size = new System.Drawing.Size(182, 42);
            this.lblHiz.TabIndex = 6;
            this.lblHiz.Text = "Speed : 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(666, 745);
            this.Controls.Add(this.lblHiz);
            this.Controls.Add(this.flappyBird);
            this.Controls.Add(this.lblSkor);
            this.Controls.Add(this.zemin);
            this.Controls.Add(this.altBoru);
            this.Controls.Add(this.ustBoru);
            this.Name = "Form1";
            this.Text = "Flappy Bird Game";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ziplamaTusuBasili);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ziplamaTusuBosta);
            ((System.ComponentModel.ISupportInitialize)(this.flappyBird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zemin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.altBoru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ustBoru)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ustBoru;
        private System.Windows.Forms.PictureBox altBoru;
        private System.Windows.Forms.PictureBox zemin;
        private System.Windows.Forms.Label lblSkor;
        private System.Windows.Forms.PictureBox flappyBird;
        private System.Windows.Forms.Timer oyunSuresi;
        private System.Windows.Forms.Label lblHiz;
    }
}

