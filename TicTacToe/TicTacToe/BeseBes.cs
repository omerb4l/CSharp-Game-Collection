using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class BeseBes : Form
    {
        // 5x5 boyutlu oyun alanı için buton matrisi
        private Button[,] butonlar;

        // Oyun alanı boyutunu (5x5) belirten değişken
        private int boyut = 5;

        // Kazanmak için gerekli ardışık simge sayısı (4)
        private int kazanmaSayisi = 4;

        // Oyuncu sırasını tutan değişken, başlangıçta "X" başlıyor
        private string oyuncu = "X";

        // Formun kurucu metodu
        public BeseBes()
        {
            InitializeComponent();

            // Form yeniden boyutlandırıldığında butonları yeniden hizalamak için bir olay bağlanıyor
            this.Resize += Form_Resize;

            // Oyun alanını oluşturuyor
            OyunAlaniOlustur();

            // Butonları formun ortasına hizalıyor
            OrtalaOyunAlani();
        }

        // Oyun alanını oluşturur ve butonları ekrana ekler
        private void OyunAlaniOlustur()
        {
            // 2 boyutlu buton dizisi oluşturuluyor
            butonlar = new Button[boyut, boyut];

            // Tüm satır ve sütunlarda butonlar oluşturuluyor
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    // Yeni bir buton oluşturuluyor ve özellikleri atanıyor
                    Button btn = new Button
                    {
                        Font = new Font("Arial", 18, FontStyle.Bold), // Yazı tipi ve boyutu
                        Tag = $"{i},{j}" // Hangi satır ve sütun olduğunu belirlemek için 'Tag' özelliği
                    };

                    // Tıklama olayı bağlanıyor
                    btn.Click += ButonTiklama;

                    // Buton formun kontrol listesine ekleniyor
                    this.Controls.Add(btn);

                    // Buton, butonlar matrisine kaydediliyor
                    butonlar[i, j] = btn;
                }
            }

            // Oluşturulan butonlar ortalanıyor
            OrtalaOyunAlani();
        }

        // Oyun alanını formun boyutuna göre hizalar ve buton boyutlarını ayarlar
        private void OrtalaOyunAlani()
        {
            if (butonlar == null) return;

            // Formun genişlik ve yükseklik değerlerini alır
            int formGenislik = this.ClientSize.Width;
            int formYukseklik = this.ClientSize.Height;

            // Butonların boyutu, formun en küçük kenarına göre belirlenir
            int butonBoyutu = Math.Min(formGenislik, formYukseklik) / (boyut + 1);

            // Oyun alanının toplam genişlik ve yüksekliği hesaplanır
            int toplamGenislik = boyut * butonBoyutu;
            int toplamYukseklik = boyut * butonBoyutu;

            // Oyun alanını formun ortasına hizalamak için başlangıç noktaları belirlenir
            int baslangicX = (formGenislik - toplamGenislik) / 2;
            int baslangicY = (formYukseklik - toplamYukseklik) / 2;

            // Her butonun konumu ve boyutu ayarlanır
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

        // Form yeniden boyutlandırıldığında çağrılan metot
        private void Form_Resize(object sender, EventArgs e)
        {
            OrtalaOyunAlani(); // Butonları yeniden hizalar
        }

        // Bir butona tıklandığında gerçekleşen olay
        private void ButonTiklama(object sender, EventArgs e)
        {
            Button tiklananButon = sender as Button;

            // Eğer buton zaten doluysa işlem yapma
            if (!string.IsNullOrEmpty(tiklananButon.Text))
                return;

            // Oyuncunun işareti tıklanan butona atanır
            tiklananButon.Text = oyuncu;

            // Kazanan olup olmadığını kontrol eder
            string kazanan = OyunuKimKazandi();
            if (!string.IsNullOrEmpty(kazanan))
            {
                MessageBox.Show($"{kazanan} kazandı!", "Oyun Sonu");
                OyunSifirla(); // Oyun alanını sıfırlar
                return;
            }

            // Beraberlik kontrolü yapılır
            if (BeraberlikKontrol())
            {
                MessageBox.Show("Oyun berabere bitti!", "Oyun Sonu");
                OyunSifirla();
                return;
            }

            // Oyuncu sırasını değiştirir
            oyuncu = (oyuncu == "X") ? "O" : "X";
        }

        // Oyunun kazanılıp kazanılmadığını kontrol eder
        // Oyunun kazanılıp kazanılmadığını kontrol eder
        private string OyunuKimKazandi()
        {
            // Satır kontrolü
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j <= boyut - kazanmaSayisi; j++)
                {
                    bool kazandi = true;
                    for (int k = 0; k < kazanmaSayisi; k++)
                    {
                        if (butonlar[i, j + k].Text != butonlar[i, j].Text || string.IsNullOrEmpty(butonlar[i, j].Text))
                        {
                            kazandi = false;
                            break;
                        }
                    }
                    if (kazandi) return butonlar[i, j].Text;
                }
            }

            // Sütun kontrolü
            for (int i = 0; i <= boyut - kazanmaSayisi; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    bool kazandi = true;
                    for (int k = 0; k < kazanmaSayisi; k++)
                    {
                        if (butonlar[i + k, j].Text != butonlar[i, j].Text || string.IsNullOrEmpty(butonlar[i, j].Text))
                        {
                            kazandi = false;
                            break;
                        }
                    }
                    if (kazandi) return butonlar[i, j].Text;
                }
            }

            // Çapraz kontrol (sol üst -> sağ alt)
            for (int i = 0; i <= boyut - kazanmaSayisi; i++)
            {
                for (int j = 0; j <= boyut - kazanmaSayisi; j++)
                {
                    bool kazandi = true;
                    for (int k = 0; k < kazanmaSayisi; k++)
                    {
                        if (butonlar[i + k, j + k].Text != butonlar[i, j].Text || string.IsNullOrEmpty(butonlar[i, j].Text))
                        {
                            kazandi = false;
                            break;
                        }
                    }
                    if (kazandi) return butonlar[i, j].Text;
                }
            }

            // Çapraz kontrol (sağ üst -> sol alt)
            for (int i = 0; i <= boyut - kazanmaSayisi; i++)
            {
                for (int j = kazanmaSayisi - 1; j < boyut; j++)
                {
                    bool kazandi = true;
                    for (int k = 0; k < kazanmaSayisi; k++)
                    {
                        if (butonlar[i + k, j - k].Text != butonlar[i, j].Text || string.IsNullOrEmpty(butonlar[i, j].Text))
                        {
                            kazandi = false;
                            break;
                        }
                    }
                    if (kazandi) return butonlar[i, j].Text;
                }
            }

            return null; // Kazanan yoksa null döner
        }


        // Oyun alanındaki tüm butonların dolu olup olmadığını kontrol eder
        private bool BeraberlikKontrol()
        {
            foreach (var buton in butonlar)
            {
                if (string.IsNullOrEmpty(buton.Text))
                    return false;
            }
            return true;
        }

        // Oyun alanını sıfırlar ve oyuncu sırasını "X" olarak başlatır
        private void OyunSifirla()
        {
            foreach (var buton in butonlar)
            {
                buton.Text = string.Empty;
            }
            oyuncu = "X";
        }

        // Ana sayfaya dönmek için kullanılan buton tıklama olayı
        private void btnGeri_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show(); // Ana sayfa formunu gösterir
            this.Hide(); // Mevcut formu gizler
        }

        private void BeseBes_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde çalışacak işlemleri buraya yazabiliriz.
        }

    }
}
