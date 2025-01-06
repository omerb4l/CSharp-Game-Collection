using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class YediyeYedi : Form
    {
        private Button[,] butonlar; // Oyun alanındaki butonları tutan 2D dizi.
        private int boyut = 7; // Oyun alanının boyutu 7x7 olacak şekilde ayarlanıyor.
        private int kazanmaSayisi = 4; // Oyunu kazanmak için gereken ardışık sembol sayısı.
        private string oyuncu = "X"; // Oyuncu değişkeni. Başlangıçta "X" atanıyor.

        public YediyeYedi()
        {
            InitializeComponent(); // Formdaki bileşenleri başlatıyor.
            this.Resize += Form_Resize; // Form yeniden boyutlandığında çağrılacak olay tanımlanıyor.
            OyunAlaniOlustur(); // Oyun alanını oluşturuyor.
            OrtalaOyunAlani(); // Butonları formun ortasına hizalıyor.
        }

        private void OyunAlaniOlustur()
        {
            butonlar = new Button[boyut, boyut]; // 7x7 boyutunda bir buton matrisi oluşturuluyor.

            for (int i = 0; i < boyut; i++) // Satırları döngüyle dolaşıyoruz.
            {
                for (int j = 0; j < boyut; j++) // Her satırın sütunlarını dolaşıyoruz.
                {
                    Button btn = new Button(); // Yeni bir buton oluşturuluyor.
                    btn.Font = new Font("Arial", 18, FontStyle.Bold); // Butonun yazı tipi ayarlanıyor.
                    btn.Tag = $"{i},{j}"; // Butonun koordinatları Tag özelliğine atanıyor.
                    btn.Click += ButonTiklama; // Butona tıklanıldığında çağrılacak olay bağlanıyor.
                    this.Controls.Add(btn); // Buton form üzerine ekleniyor.
                    butonlar[i, j] = btn; // Buton matrise kaydediliyor.
                }
            }
            OrtalaOyunAlani(); // İlk oluşturma sırasında butonlar hizalanıyor.
        }

        private void OrtalaOyunAlani()
        {
            if (butonlar == null) return; // Butonlar oluşturulmamışsa işlem yapılmıyor.

            int formGenislik = this.ClientSize.Width; // Formun genişliği alınıyor.
            int formYukseklik = this.ClientSize.Height; // Formun yüksekliği alınıyor.

            int butonBoyutu = Math.Min(formGenislik, formYukseklik) / (boyut + 1); // Buton boyutları hesaplanıyor.

            int toplamGenislik = boyut * butonBoyutu; // Tüm butonların toplam genişliği hesaplanıyor.
            int toplamYukseklik = boyut * butonBoyutu; // Tüm butonların toplam yüksekliği hesaplanıyor.

            int baslangicX = (formGenislik - toplamGenislik) / 2; // Butonlar için yatay başlangıç konumu hesaplanıyor.
            int baslangicY = (formYukseklik - toplamYukseklik) / 2; // Butonlar için dikey başlangıç konumu hesaplanıyor.

            for (int i = 0; i < boyut; i++) // Satırları dolaşıyoruz.
            {
                for (int j = 0; j < boyut; j++) // Her satırın sütunlarını dolaşıyoruz.
                {
                    butonlar[i, j].Size = new Size(butonBoyutu, butonBoyutu); // Her butonun boyutları ayarlanıyor.
                    butonlar[i, j].Location = new Point(
                        baslangicX + j * butonBoyutu,
                        baslangicY + i * butonBoyutu
                    ); // Her butonun konumu hesaplanıyor ve atanıyor.
                }
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            OrtalaOyunAlani(); // Form boyutlandığında butonlar yeniden hizalanıyor.
        }

        private void ButonTiklama(object sender, EventArgs e)
        {
            Button tiklananButon = sender as Button; // Tıklanan buton alınıyor.

            if (!string.IsNullOrEmpty(tiklananButon.Text)) // Eğer butona daha önce tıklanmışsa işlem yapılmıyor.
                return;

            tiklananButon.Text = oyuncu; // Tıklanan butona sıradaki oyuncunun sembolü yazılıyor.

            string kazanan = OyunuKimKazandi(); // Kazanan oyuncu kontrol ediliyor.
            if (!string.IsNullOrEmpty(kazanan)) // Eğer bir kazanan varsa oyun bitiyor.
            {
                MessageBox.Show($"{kazanan} kazandı!", "Oyun Sonu");
                OyunSifirla(); // Oyun sıfırlanıyor.
                return;
            }

            if (BeraberlikKontrol()) // Eğer oyun alanında boş yer kalmadıysa ve kazanan yoksa oyun berabere bitiyor.
            {
                MessageBox.Show("Oyun berabere bitti!", "Oyun Sonu");
                OyunSifirla();
                return;
            }

            oyuncu = (oyuncu == "X") ? "O" : "X"; // Sıradaki oyuncu değiştiriliyor.
        }

        private string OyunuKimKazandi()
        {
            // Yatay kontrol
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

            // Dikey kontrol
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

            // Sol üstten sağ alta çapraz kontrol
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

            // Sağ üstten sol alta çapraz kontrol
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

            return null; // Eğer kazanan yoksa null döndürülür.
        }


        private bool BeraberlikKontrol()
        {
            foreach (var buton in butonlar) // Tüm butonları kontrol ediyoruz.
            {
                if (string.IsNullOrEmpty(buton.Text)) // Eğer boş bir buton varsa oyun devam ediyor.
                    return false;
            }
            return true; // Eğer tüm butonlar doluysa oyun berabere bitiyor.
        }

        private void OyunSifirla()
        {
            foreach (var buton in butonlar) // Tüm butonları sıfırlıyoruz.
            {
                buton.Text = string.Empty; // Butonların metni temizleniyor.
            }
            oyuncu = "X"; // Oyuncu "X" olarak sıfırlanıyor.
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage(); // Ana menü sayfası oluşturuluyor.
            hp.Show(); // Ana menü gösteriliyor.
            this.Hide(); // Mevcut form gizleniyor.
        }
    }
}
