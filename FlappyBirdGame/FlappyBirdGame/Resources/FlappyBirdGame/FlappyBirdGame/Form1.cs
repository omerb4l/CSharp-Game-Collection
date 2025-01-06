using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdGame
{
    public partial class Form1 : Form
    {

        int skor = 0;
        int yerCekimi = 15;
        int boruHizi = 25;
        int gecenSure = 0;
        int hizArtisSuresi = 5000;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void oyunSuresiEventi(object sender, EventArgs e)
        {
            flappyBird.Top += yerCekimi;
            altBoru.Left -= boruHizi;
            ustBoru.Left -= boruHizi;
            lblSkor.Text = "Skor: " + skor.ToString();
            

            gecenSure = oyunSuresi.Interval;
            if (gecenSure >= hizArtisSuresi)
            {
                boruHizi = boruHizi + 3;
                gecenSure = 0;
            }

            if (zemineCarptiMi() || ustBoruyaCarptiMi() || altBoruyaCarptiMi())
            {
                oyunBitti();
            }

            skorArtisi();

            Random rastgele = new Random();
            int minDeger = 683; 
            int maxDeger = 1200; 
            int ustBoruRandomKoordinat = rastgele.Next(minDeger, maxDeger);
            int altBoruRandomKoordinat = rastgele.Next(minDeger, maxDeger);

            if (ustBoru.Left < -100)
            {
                ustBoru.Left = ustBoruRandomKoordinat;
                ustBoruKontrolu = false;
            }

            if (altBoru.Left < -100)
            {
                altBoru.Left = altBoruRandomKoordinat;
                altBoruKontrolu = false;
            }

        }

        private void ziplamaTusuBasili(object sender, KeyEventArgs e)
        {

            //kendıme not buraya bır sey ekle kı ekran dısına cıktıgında hala daha zıplamasını engellesın
            if (e.KeyCode == Keys.Space) 
            {
                yerCekimi = -15;
            }


        }

        private void ziplamaTusuBosta(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                yerCekimi = 15;
            }

        }


        private bool ustBoruyaCarptiMi()
        {
            // Flappy Bird'ün üst boruya çarpıp çarpmadığını kontrol ediyoruz
            if (flappyBird.Right >= ustBoru.Left && flappyBird.Left <= ustBoru.Right)
            {
                if (flappyBird.Top <= ustBoru.Bottom)
                {
                    return true; // Çarpışma var
                }
            }
            return false; // Çarpışma yok
        }

        private bool altBoruyaCarptiMi()
        {
            // Flappy Bird'ün alt boruya çarpıp çarpmadığını kontrol ediyoruz
            if (flappyBird.Right >= altBoru.Left && flappyBird.Left <= altBoru.Right)
            {
                if (flappyBird.Bottom >= altBoru.Top)
                {
                    return true; // Çarpışma var
                }
            }
            return false; // Çarpışma yok
        }

        private bool ustBoruGecildiMi()
        {
            if(flappyBird.Left > ustBoru.Right)
            {
                return true;
            }
            return false;
        }

        private bool altBoruGecildiMi()
        {
            if(flappyBird.Left > altBoru.Right)
            {
                return true;
            }
            return false;
        }

        bool ustBoruKontrolu= false;
        bool altBoruKontrolu = false;
        private void skorArtisi()
        {
            // Flappy Bird üst boruyu geçtiyse ve daha önce skoru artırmadıysak
            if (ustBoruGecildiMi() && !ustBoruKontrolu)
            {
                skor++;
                ustBoruKontrolu = true;  // Skoru bir kez artırıp geçişi kilitliyoruz
            }

            // Flappy Bird alt boruyu geçtiyse ve daha önce skoru artırmadıysak
            if (altBoruGecildiMi() && !altBoruKontrolu)
            {
                skor++;
                altBoruKontrolu = true;  // Skoru bir kez artırıp geçişi kilitliyoruz
            }
        }



        private bool zemineCarptiMi()
        {
            if (flappyBird.Bottom >= zemin.Top)
            {
                return true;
            }
            else return false;
        }


        private void oyunBitti()
        {
            // Oyun durduğunda timer'ı durduruyoruz
            oyunSuresi.Stop();

            // Skoru gösteriyoruz ve kullanıcıya devam etmek isteyip istemediğini soruyoruz
            DialogResult sonuc = MessageBox.Show("Oyun Bitti! Skor: " + skor + "\nDevam etmek ister misiniz?",
                                                  "Oyun Bitti",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            // Eğer "Evet" seçilirse oyunu yeniden başlatıyoruz
            if (sonuc == DialogResult.Yes)
            {
                oyunuYenidenBaslat(); // Oyunu sıfırlayıp yeniden başlatan bir metod oluşturuyoruz
            }
            else if (sonuc == DialogResult.No)
            {
                // "Hayır" seçilirse formu kapatıyoruz
                Application.Exit();
            }
        }

        // Oyunu sıfırlayan ve yeniden başlatan metod
        private void oyunuYenidenBaslat()
        {
            // Skoru sıfırla
            skor = 0;

            // Flappy Bird'ün pozisyonunu başlangıç noktasına getir
            flappyBird.Top = this.ClientSize.Height / 2;

            // Boruların pozisyonlarını yeniden ayarla
            ustBoru.Left = this.ClientSize.Width + ustBoru.Width;
            altBoru.Left = this.ClientSize.Width + altBoru.Width;

            // Zemin hareketi ve diğer ayarları sıfırla
            yerCekimi = 15;
            boruHizi = 25;

            // Timer'ı yeniden başlat
            oyunSuresi.Start();
        }


        private void lblSkor_Click(object sender, EventArgs e)
        {
        }

        private void ustBoru_Click(object sender, EventArgs e)
        {

        }
    }
}
