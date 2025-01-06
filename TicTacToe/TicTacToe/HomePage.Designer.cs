namespace TicTacToe
{
    partial class HomePage
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
            this.lblHosgeldiniz = new System.Windows.Forms.Label();
            this.lblModSecimi = new System.Windows.Forms.Label();
            this.btnUc = new System.Windows.Forms.Button();
            this.btnYedi = new System.Windows.Forms.Button();
            this.btnBes = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHosgeldiniz
            // 
            this.lblHosgeldiniz.AutoSize = true;
            this.lblHosgeldiniz.BackColor = System.Drawing.Color.Transparent;
            this.lblHosgeldiniz.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHosgeldiniz.ForeColor = System.Drawing.Color.Snow;
            this.lblHosgeldiniz.Location = new System.Drawing.Point(37, 59);
            this.lblHosgeldiniz.Name = "lblHosgeldiniz";
            this.lblHosgeldiniz.Size = new System.Drawing.Size(665, 59);
            this.lblHosgeldiniz.TabIndex = 0;
            this.lblHosgeldiniz.Text = "TicTacToe oyununa hoş geldiniz!\r\n";
            this.lblHosgeldiniz.Click += new System.EventHandler(this.lblHosgeldiniz_Click);
            // 
            // lblModSecimi
            // 
            this.lblModSecimi.AutoSize = true;
            this.lblModSecimi.BackColor = System.Drawing.Color.Transparent;
            this.lblModSecimi.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblModSecimi.ForeColor = System.Drawing.Color.Snow;
            this.lblModSecimi.Location = new System.Drawing.Point(9, 145);
            this.lblModSecimi.Name = "lblModSecimi";
            this.lblModSecimi.Size = new System.Drawing.Size(711, 59);
            this.lblModSecimi.TabIndex = 1;
            this.lblModSecimi.Text = "Oynamak istediğiniz modu seçiniz:";
            // 
            // btnUc
            // 
            this.btnUc.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUc.Location = new System.Drawing.Point(269, 279);
            this.btnUc.Name = "btnUc";
            this.btnUc.Size = new System.Drawing.Size(169, 59);
            this.btnUc.TabIndex = 2;
            this.btnUc.Text = "3x3";
            this.btnUc.UseVisualStyleBackColor = true;
            this.btnUc.Click += new System.EventHandler(this.btnUc_Click);
            // 
            // btnYedi
            // 
            this.btnYedi.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYedi.Location = new System.Drawing.Point(269, 481);
            this.btnYedi.Name = "btnYedi";
            this.btnYedi.Size = new System.Drawing.Size(169, 59);
            this.btnYedi.TabIndex = 3;
            this.btnYedi.Text = "7x7";
            this.btnYedi.UseVisualStyleBackColor = true;
            this.btnYedi.Click += new System.EventHandler(this.btnYedi_Click);
            // 
            // btnBes
            // 
            this.btnBes.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBes.Location = new System.Drawing.Point(269, 383);
            this.btnBes.Name = "btnBes";
            this.btnBes.Size = new System.Drawing.Size(169, 59);
            this.btnBes.TabIndex = 4;
            this.btnBes.Text = "5x5";
            this.btnBes.UseVisualStyleBackColor = true;
            this.btnBes.Click += new System.EventHandler(this.btnBes_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Location = new System.Drawing.Point(269, 610);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(169, 52);
            this.btnCikis.TabIndex = 5;
            this.btnCikis.Text = "Cikis";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TicTacToe.Properties.Resources.aaaaaaaa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(732, 694);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnBes);
            this.Controls.Add(this.btnYedi);
            this.Controls.Add(this.btnUc);
            this.Controls.Add(this.lblModSecimi);
            this.Controls.Add(this.lblHosgeldiniz);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TicTacToe";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHosgeldiniz;
        private System.Windows.Forms.Label lblModSecimi;
        private System.Windows.Forms.Button btnUc;
        private System.Windows.Forms.Button btnYedi;
        private System.Windows.Forms.Button btnBes;
        private System.Windows.Forms.Button btnCikis;
    }
}

