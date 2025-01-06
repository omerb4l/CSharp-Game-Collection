using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class UceUc : Form
    {
        // Oyun alanı için 2 boyutlu bir buton matrisi tanımlıyoruz.
        private Button[,] butonlar;

        // Oyun alanının boyutunu (3x3) belirtmek için bir sabit değer oluşturuyoruz.
        private int boyut = 3;

        // Oyuncu sırasını takip etmek için bir değişken. İlk oyuncu "X" ile başlar.
        private string oyuncu = "X";

        // Formun başlangıç ayarlarını yapan yapılandırıcı metod.
        public UceUc()
        {
            InitializeComponent(); // Form bileşenlerini başlatır.

            // Form yeniden boyutlandırıldığında oyun alanını güncellemek için Resize olayına metod bağlanır.
            this.Resize += Form_Resize;

            OyunAlaniOlustur(); // Oyun alanını oluşturur.
            OrtalaOyunAlani(); // Oyun alanını merkeze hizalar.
        }

        // Oyun alanını oluşturan metod.
        private void OyunAlaniOlustur()
        {
            // Buton matrisini, belirlenen boyuta göre oluşturuyoruz.
            butonlar = new Button[boyut, boyut];

            // Matris boyutları kadar döngü oluşturuyoruz.
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    // Her bir hücre için yeni bir buton oluşturuyoruz.
                    Button btn = new Button();

                    // Butonun font ayarlarını düzenliyoruz.
                    btn.Font = new Font("Arial", 18, FontStyle.Bold);

                    // Butonun tıklanma olayını ButonTiklama metoduna bağlıyoruz.
                    btn.Click += ButonTiklama;

                    // Butonu formun kontrollerine ekliyoruz.
                    this.Controls.Add(btn);

                    // Oluşturulan butonu matrise ekliyoruz.
                    butonlar[i, j] = btn;
                }
            }

            // Oyun alanını başlangıçta merkeze hizalıyoruz.
            OrtalaOyunAlani();
        }

        // Oyun alanını form içinde merkeze hizalayan metod.
        private void OrtalaOyunAlani()
        {
            // Eğer butonlar henüz oluşturulmadıysa metoddan çıkıyoruz.
            if (butonlar == null) return;

            // Formun genişlik ve yükseklik değerlerini alıyoruz.
            int formGenislik = this.ClientSize.Width;
            int formYukseklik = this.ClientSize.Height;

            // Form boyutuna uygun şekilde bir buton boyutu hesaplıyoruz.
            int butonBoyutu = Math.Min(formGenislik, formYukseklik) / (boyut + 1);

            // Oyun alanının toplam genişlik ve yüksekliğini belirliyoruz.
            int toplamGenislik = boyut * butonBoyutu;
            int toplamYukseklik = boyut * butonBoyutu;

            // Oyun alanının başlangıç konumunu merkeze göre hesaplıyoruz.
            int baslangicX = (formGenislik - toplamGenislik) / 2;
            int baslangicY = (formYukseklik - toplamYukseklik) / 2;

            // Her bir butonun boyut ve konumunu belirliyoruz.
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    butonlar[i, j].Size = new Size(butonBoyutu, butonBoyutu);
                    butonlar[i, j].Location = new Point(
                        baslangicX + j * butonBoyutu,
                        baslangicY + i * butonBoyutu
                    );
                }
            }
        }

        // Form yeniden boyutlandırıldığında çalışan olay metodu.
        private void Form_Resize(object sender, EventArgs e)
        {
            OrtalaOyunAlani(); // Butonları yeniden hizalar.
        }

        // Butona tıklandığında çalışan olay metodu.
        private void ButonTiklama(object sender, EventArgs e)
        {
            // Tıklanan butonu alıyoruz.
            Button tiklananButon = sender as Button;

            // Eğer buton zaten doluysa hiçbir işlem yapmadan çıkıyoruz.
            if (!string.IsNullOrEmpty(tiklananButon.Text))
                return;

            // Tıklanan butonun metnini sıradaki oyuncunun sembolüyle dolduruyoruz.
            tiklananButon.Text = oyuncu;

            // Kazanan oyuncuyu kontrol ediyoruz.
            string kazanan = OyunuKimKazandi();
            if (!string.IsNullOrEmpty(kazanan))
            {
                MessageBox.Show($"{kazanan} kazandı!", "Oyun Sonu");
                OyunSifirla(); // Oyun bitince sıfırlıyoruz.
                return;
            }

            // Beraberlik durumunu kontrol ediyoruz.
            if (BeraberlikKontrol())
            {
                MessageBox.Show("Oyun berabere bitti!", "Oyun Sonu");
                OyunSifirla(); // Oyun sıfırlanıyor.
                return;
            }

            // Sıradaki oyuncuyu değiştiriyoruz.
            oyuncu = (oyuncu == "X") ? "O" : "X";
        }

        // Kazananı kontrol eden metod.
        private string OyunuKimKazandi()
        {
            // Satırları kontrol ediyoruz.
            for (int i = 0; i < boyut; i++)
            {
                if (!string.IsNullOrEmpty(butonlar[i, 0].Text) &&
                    butonlar[i, 0].Text == butonlar[i, 1].Text &&
                    butonlar[i, 0].Text == butonlar[i, 2].Text)
                {
                    return butonlar[i, 0].Text;
                }
            }

            // Sütunları kontrol ediyoruz.
            for (int j = 0; j < boyut; j++)
            {
                if (!string.IsNullOrEmpty(butonlar[0, j].Text) &&
                    butonlar[0, j].Text == butonlar[1, j].Text &&
                    butonlar[0, j].Text == butonlar[2, j].Text)
                {
                    return butonlar[0, j].Text;
                }
            }

            // Çaprazları kontrol ediyoruz.
            if (!string.IsNullOrEmpty(butonlar[0, 0].Text) &&
                butonlar[0, 0].Text == butonlar[1, 1].Text &&
                butonlar[0, 0].Text == butonlar[2, 2].Text)
            {
                return butonlar[0, 0].Text;
            }

            if (!string.IsNullOrEmpty(butonlar[0, 2].Text) &&
                butonlar[0, 2].Text == butonlar[1, 1].Text &&
                butonlar[0, 2].Text == butonlar[2, 0].Text)
            {
                return butonlar[0, 2].Text;
            }

            return null; // Eğer kazanan yoksa null döndürülür.
        }

        // Beraberlik durumunu kontrol eden metod.
        private bool BeraberlikKontrol()
        {
            // Eğer boş bir buton varsa, oyun devam ediyor demektir.
            foreach (var buton in butonlar)
            {
                if (string.IsNullOrEmpty(buton.Text))
                    return false;
            }
            return true; // Hiçbir boş buton yoksa oyun beraberedir.
        }

        // Oyunu sıfırlayan metod.
        private void OyunSifirla()
        {
            // Tüm butonları temizliyoruz.
            foreach (var buton in butonlar)
            {
                buton.Text = string.Empty;
            }

            // Oyuncuyu "X" ile başlatıyoruz.
            oyuncu = "X";
        }

        // Ana sayfaya dönmeyi sağlayan buton olayı.
        private void btnGeri_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage(); // Yeni bir ana sayfa oluşturuyoruz.
            hp.Show(); // Ana sayfayı gösteriyoruz.
            this.Hide(); // Mevcut formu gizliyoruz.
        }

        private void UceUc_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde çalışacak işlemleri buraya yazabiliriz.
        }
    }
}
