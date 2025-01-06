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
        int skor = 0; // Skoru tutmak için bir değişken
        int yerCekimi = 15; // Kuşun düşmesini sağlayan yer çekimi değişkeni
        int boruHizi = 25; // Boruların başlangıç hızını belirliyorum
        int gecenSure = 0; // Hız artışı için geçen süreyi izlemek için bir sayaç
        int hizArtisSuresi = 5000; // Boru hızının artması için gereken süre (ms cinsinden)

        public Form1()
        {
            InitializeComponent();
        }

        private void oyunSuresiEventi(object sender, EventArgs e)
        {
            // Yer çekimi etkisiyle kuşu aşağıya doğru hareket ettiriyorum
            flappyBird.Top += yerCekimi;

            // Boruları sola doğru hareket ettiriyorum
            altBoru.Left -= boruHizi;
            ustBoru.Left -= boruHizi;

            // Skor ve hız bilgilerini ekranda gösteriyorum
            lblSkor.Text = "Score: " + skor.ToString();
            lblHiz.Text = "Speed: " + boruHizi.ToString();

            // Her 5 saniyede bir boruların yaklaşma hızını 3 arttırıyorum
            gecenSure += oyunSuresi.Interval;
            if (gecenSure >= hizArtisSuresi)
            {
                boruHizi += 3; // Boru hızını artırıyoruz
                gecenSure = 0; // Süreyi sıfırlayarak yeniden başlatıyoruz
            }

            // Eğer kuş zemine veya borulara çarparsa oyunu bitiriyorum
            if (zemineCarptiMi() || ustBoruyaCarptiMi() || altBoruyaCarptiMi())
            {
                oyunBitti();
            }

            // Skorun artması için fonksiyonu tetikliyorum
            skorArtisi();

            // Boruların ekrandan çıkması durumunda yeni rastgele pozisyon atamalarını gerçekleştiriyorum.
            Random rastgele = new Random();
            int minDeger = 683;
            int maxDeger = 1200;
            int ustBoruRandomKoordinat = rastgele.Next(minDeger, maxDeger);
            int altBoruRandomKoordinat = rastgele.Next(minDeger, maxDeger);

            // Üst boru ekrandan çıktığında onu yeni bir yere taşıyorum
            if (ustBoru.Left < -100)
            {
                ustBoru.Left = ustBoruRandomKoordinat;
                ustBoruKontrolu = false;
            }

            // Alt boru ekrandan çıktığında onu yeni bir yere taşıyorum
            if (altBoru.Left < -100)
            {
                altBoru.Left = altBoruRandomKoordinat;
                altBoruKontrolu = false;
            }
        }

        private void ziplamaTusuBasili(object sender, KeyEventArgs e)
        {
            // Eğer Space tuşuna basılırsa kuşu yukarı hareket ettiriyoruz
            if (e.KeyCode == Keys.Space)
            {
                yerCekimi = -15;
            }
        }

        private void ziplamaTusuBosta(object sender, KeyEventArgs e)
        {
            // Eğer Space tuşunu bırakırsak kuş aşağı inmeye başlıyor
            if (e.KeyCode == Keys.Space)
            {
                yerCekimi = 15;
            }
        }

        private bool ustBoruyaCarptiMi()
        {
            // Kuş üst boruya çarptı mı kontrol ediyorum
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
            // Kuş alt boruya çarptı mı kontrol ediyorum
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
            // Kuş üst boruyu geçti mi kontrol ediyorum
            return flappyBird.Left > ustBoru.Right;
        }

        private bool altBoruGecildiMi()
        {
            // Kuş alt boruyu geçti mi kontrol ediyorum
            return flappyBird.Left > altBoru.Right;
        }

        //Kilit işlemleri için kullanacağım değişkenleri tanımlıyorum.(Her boru için skorun yalnızca bir kez artması için kullanıyorum)
        bool ustBoruKontrolu = false; // Üst borudan geçildi mi kontrolü
        bool altBoruKontrolu = false; // Alt borudan geçildi mi kontrolü

        private void skorArtisi()
        {
            // Eğer üst boruyu geçtiysek ve daha önce skor artırmadıysak skor artırıyoruz
            if (ustBoruGecildiMi() && !ustBoruKontrolu)
            {
                skor++;
                ustBoruKontrolu = true;  // Skoru bir kez artırıp geçişi kilitliyoruz
            }

            // Eğer alt boruyu geçtiysek ve daha önce skor artırmadıysak skor artırıyoruz
            if (altBoruGecildiMi() && !altBoruKontrolu)
            {
                skor++;
                altBoruKontrolu = true;  // Skoru bir kez artırıp geçişi kilitliyoruz
            }
        }

        private bool zemineCarptiMi()
        {
            // Kuş zemine çarptı mı kontrol ediyoruz
            return flappyBird.Bottom >= zemin.Top;
        }

        private void oyunBitti()
        {
            // Oyun durduğunda timer'ı durduruyorum
            oyunSuresi.Stop();

            // Skoru gösteriyorum ve devam etmek isteyip istemediğini soruyorum
            DialogResult sonuc = MessageBox.Show("Oyun Bitti! Skor: " + skor + "\nDevam etmek ister misiniz?",
                                                  "Oyun Bitti",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            // Eğer "Evet" seçilirse oyunu yeniden başlatıyorum
            if (sonuc == DialogResult.Yes)
            {
                oyunuYenidenBaslat(); // Oyunu sıfırlayıp yeniden başlatan bir metodu çağırıyoruz
            }
            else if (sonuc == DialogResult.No)
            {
                // "Hayır" seçilirse programı kapatıyorum
                Application.Exit();
            }
        }

        // Oyunu sıfırlayan ve yeniden başlatan metod
        private void oyunuYenidenBaslat()
        {
            skor = 0; // Skoru sıfırlıyoruz

            // Kuşun pozisyonunu başlangıç noktasına getiriyorum
            flappyBird.Top = this.ClientSize.Height / 2;

            // Boruların pozisyonlarını yeniden ayarlıyorum
            ustBoru.Left = this.ClientSize.Width + ustBoru.Width;
            altBoru.Left = this.ClientSize.Width + altBoru.Width;

            // Yer çekimi ve boru hızını sıfırlıyorum
            yerCekimi = 15;
            boruHizi = 25;

            // Timer'ı yeniden başlatıyorum
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
