using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Şehirler adında bir liste oluşturdum.
        List<string> sehirler = new List<string>
        {
            "ADANA", "ADIYAMAN", "AFYONKARAHİSAR", "AĞRI", "AKSARAY", "AMASYA", "ANKARA", "ANTALYA",
            "ARDAHAN", "ARTVİN", "AYDIN", "BALIKESİR", "BARTIN", "BATMAN", "BAYBURT", "BİLECİK",
            "BİNGÖL", "BİTLİS", "BOLU", "BURDUR", "BURSA", "ÇANAKKALE", "ÇANKIRI", "ÇORUM",
            "DENİZLİ", "DİYARBAKIR", "DÜZCE", "EDİRNE", "ELAZIĞ", "ERZİNCAN", "ERZURUM",
            "ESKİŞEHİR", "GAZİANTEP", "GİRESUN", "GÜMÜŞHANE", "HAKKARİ", "HATAY", "IĞDIR",
            "ISPARTA", "İSTANBUL", "İZMİR", "KAHRAMANMARAŞ", "KARABÜK", "KARAMAN", "KARS",
            "KASTAMONU", "KAYSERİ", "KIRIKKALE", "KIRKLARELİ", "KIRŞEHİR", "KİLİS", "KOCAELİ",
            "KONYA", "KÜTAHYA", "MALATYA", "MANİSA", "MARDİN", "MERSİN", "MUĞLA", "MUŞ",
            "NEVŞEHİR", "NİĞDE", "ORDU", "OSMANİYE", "RİZE", "SAKARYA", "SAMSUN", "SİİRT",
            "SİNOP", "SİVAS", "ŞANLIURFA", "ŞIRNAK", "TEKİRDAĞ", "TOKAT", "TRABZON",
            "TUNCELİ", "UŞAK", "VAN", "YALOVA", "YOZGAT", "ZONGULDAK"
        };
        // Sonradan gerekli olacak değişkenleri burada tanımladım.
        int yanlisTahminSayisi;
        Random random;
        string secilmisSehir;
        char[] ekrandakiSehir;
        
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // Önceden tanımladığım değişkenlere değer ataması yaptım.
            yanlisTahminSayisi = 0;
            random = new Random();
            // Şehirler listesinden rastgele bir şehir seçilip o şehrin secilmisSehir değişkenine atadım.
            secilmisSehir = sehirler[random.Next(sehirler.Count)];
            ekrandakiSehir = new string('_', secilmisSehir.Length).ToCharArray();
            string formattedDisplayWord = string.Join(" ", ekrandakiSehir);
            lblEkrandakiSehir.Text = formattedDisplayWord;
        }

        private void HarfButonunaTikla(object sender, EventArgs e)
        {
            // Tıklanan butonu al
            Button harfButonu = sender as Button;
            // Butonun üstündeki harfi secilenHarf değişkenine atadım.
            char secilenHarf = harfButonu.Text.ToUpper()[0];
            harfButonu.Enabled = false; // Bir kez tıklanan butona bir daha tıklanamayacak şekilde ayarladım
            // Yukarıda aldığımız harfi bu fonksiyona gönderdim.
            HarfKontrolEt(secilenHarf);
        }

        private void HarfKontrolEt(char secilenHarf)
        {
            // Seçilen harf şehirde varsa, ekrandaki harfleri güncelle.
            bool harfDogruMu = false;
            for (int i = 0; i < secilmisSehir.Length; i++)
            {
                if (secilmisSehir[i] == secilenHarf)
                {
                    ekrandakiSehir[i] = secilenHarf;
                    harfDogruMu = true;
                }
            }

            // Label'ı güncelledım.
            lblEkrandakiSehir.Text = string.Join(" ", ekrandakiSehir);

            // Eğer harf yanlışsa, yanlisTahminSayisi'ni artır.
            if (!harfDogruMu)
            {
                yanlisTahminSayisi++;
                // Yanlış tahminlere göre PictureBox'ı güncelle
                GorselGuncelle();
            }

            // Eğer şehir tamamen doğru tahmin edildiyse, oyunu kazanan kullanıcı olarak bitir
            if (!ekrandakiSehir.Contains('_'))
            {
                OyunBitirWin();
            }
        }

        private void OyunBitirWin()
        {
            var result = MessageBox.Show("Tebrikler! Oyunu kazandın. Devam etmek ister misin?",
                                           "Oyun Bitti",
                                           MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Açılan pencerede kullanıcı oyuna devam etmek istediğini belirtmişse OyunYenidenBaslat fonksiyonu çalışsın.
                OyunYenidenBaslat();
            }
            else
            {
                Application.Exit(); // İstemiyorsa da pencere kapansın.
            }
        }

        private void OyunBitirLose()
        {
            var result = MessageBox.Show($"Maalesef oyunu kaybettin. Bulamadığın şehir: {secilmisSehir}. Devam etmek ister misin?",
                                           "Oyun Bitti",
                                           MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Açılan pencerede kullanıcı oyuna devam etmek istediğini belirtmişse OyunYenidenBaslat fonksiyonu çalışsın.
                OyunYenidenBaslat();
            }
            else
            {
                Application.Exit(); // İstemiyorsa da pencere kapansın.
            }
        }

        private void OyunYenidenBaslat()
        {
            // Oyunun yeniden başlayabilmesi için tüm değiştirdiğimiz değişkenleri sıfırladık.
            yanlisTahminSayisi = 0;
            secilmisSehir = sehirler[random.Next(sehirler.Count)];
            ekrandakiSehir = new string('_', secilmisSehir.Length).ToCharArray();
            string formattedDisplayWord = string.Join(" ", ekrandakiSehir);
            lblEkrandakiSehir.Text = formattedDisplayWord;

            // Tüm butonları yeniden etkinleştir.
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = true;
                }
            }

            // Görseli sıfırla
            pictureBox1.Image = Properties.Resources.adam1; 
        }


        private void GorselGuncelle()
        {
            //Görselleri de paint'den kendim çizdim :)
            // Hata sayısına göre değiştiren ve son görsele gelindiğinde yani hata hakkı kalmadığında oyunun bitmesini sağlayan fonksiyonum.
            if (yanlisTahminSayisi == 1) pictureBox1.Image = Properties.Resources.adam2;
            if (yanlisTahminSayisi == 2) pictureBox1.Image = Properties.Resources.adam3;
            if (yanlisTahminSayisi == 3) pictureBox1.Image = Properties.Resources.adam4;
            if (yanlisTahminSayisi == 4) pictureBox1.Image = Properties.Resources.adam5;
            if (yanlisTahminSayisi == 5) pictureBox1.Image = Properties.Resources.adam6;
            if (yanlisTahminSayisi == 6) pictureBox1.Image = Properties.Resources.adam7;
            if (yanlisTahminSayisi == 7) pictureBox1.Image = Properties.Resources.adam8;
            if (yanlisTahminSayisi == 8) pictureBox1.Image = Properties.Resources.adam9;
            if (yanlisTahminSayisi == 9)
            {
                pictureBox1.Image = Properties.Resources.adam10;
                OyunBitirLose();
            }

        }

        // Tüm butonlara kontrol yapmamızı sağlayan fonksiyonu ekledim.
        #region Harf Butonları
        private void btnA_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnCnoktali_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnD_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnF_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnYumusakG_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnH_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnI_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnInoktali_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnK_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnL_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnM_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnN_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnO_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnOnoktali_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnP_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }
        private void btnR_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnS_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnSnoktali_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnT_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnU_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnUnoktali_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnV_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnY_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);

        }

        private void btnG_Click_1(object sender, EventArgs e)
        {
            HarfButonunaTikla(sender, e);
        }

        #endregion
    }
}