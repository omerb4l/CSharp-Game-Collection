using System;
using System.Drawing;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        const int BOYUT = 30; // Oyun alanı boyutu (30x30 hücre)
        const int MAYIN_SAYISI = 100; // Oyundaki toplam mayın sayısı
        const int BUTON_BOYUTU = 25; // Her bir hücrenin piksel cinsinden boyutu
        Button[,] butonlar = new Button[BOYUT, BOYUT]; // Butonlar için 2 boyutlu bir dizi
        bool[,] mayinlar = new bool[BOYUT, BOYUT]; // Mayın bilgisi için 2 boyutlu bir dizi
        bool oyunBitti = false; // Oyun durumu takibi için bayrak

        public Form1()
        {
            InitializeComponent();
            OyunAlaniOlustur(); // Butonları ve oyun alanını oluştur
            MayinlariYerlestir(); // Mayınları rastgele yerlere dağıt
            FormuMerkezeAyarla(); // Formun boyutunu ve konumunu ayarla
        }

        private void FormuMerkezeAyarla()
        {
            // Formun boyutunu butonlara göre ayarlıyorum
            this.Size = new Size(BOYUT * BUTON_BOYUTU + 20, BOYUT * BUTON_BOYUTU + 40);
            this.StartPosition = FormStartPosition.CenterScreen; // Ekranın ortasında başlasın
        }

        private void OyunAlaniOlustur()
        {
            // Tüm butonları sırayla oluşturuyorum
            for (int i = 0; i < BOYUT; i++)
            {
                for (int j = 0; j < BOYUT; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(BUTON_BOYUTU, BUTON_BOYUTU); // Butonun boyutunu belirle
                    btn.Location = new Point(j * BUTON_BOYUTU, i * BUTON_BOYUTU); // Butonun ekrandaki konumu
                    btn.Tag = new Point(i, j); // Satır ve sütun bilgisini butona etiket olarak kaydediyorum
                    btn.Click += ButonTikla; // Butona tıklama olayı ekleniyor
                    Controls.Add(btn); // Butonu forma ekle
                    butonlar[i, j] = btn; // Butonu diziye kaydet
                }
            }
        }

        private void MayinlariYerlestir()
        {
            // Rastgele bir şekilde mayınları oluşturuyorum
            Random rastgele = new Random();
            int sayac = 0;

            // İstenilen sayıda mayını rastgele yerlere koyana kadar döngü devam eder
            while (sayac < MAYIN_SAYISI)
            {
                int x = rastgele.Next(BOYUT); // Satır koordinatı
                int y = rastgele.Next(BOYUT); // Sütun koordinatı

                // Eğer bu hücrede daha önce mayın yoksa yeni bir mayın koyuyorum
                if (!mayinlar[x, y])
                {
                    mayinlar[x, y] = true;
                    sayac++;
                }
            }
        }

        private void ButonTikla(object sender, EventArgs e)
        {
            // Oyun bitmişse tıklama işlemi yapılmasın
            if (oyunBitti) return;

            // Tıklanan butonu al ve konum bilgilerini çöz
            Button tiklananButon = sender as Button;
            Point pozisyon = (Point)tiklananButon.Tag;
            int satir = pozisyon.X;
            int sutun = pozisyon.Y;

            // Eğer tıklanan hücrede mayın varsa
            if (mayinlar[satir, sutun])
            {
                // Mayına basıldığı için oyunu sonlandırıyorum
                tiklananButon.Text = "*";
                tiklananButon.BackColor = Color.Red;
                MessageBox.Show("Mayına bastınız! Oyun bitti.");
                OyunBitir();

                // Oyuncuya tekrar oynamak isteyip istemediğini soruyorum
                DialogResult result = MessageBox.Show("Tekrar başlamak ister misiniz?", "Oyun Bitti", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Restart(); // Uygulamayı yeniden başlat
                }
                else
                {
                    Application.Exit(); // Çıkış yap
                }
            }
            else
            {
                // Mayın yoksa komşu mayın sayısını hesaplıyorum
                int komsuMayinSayisi = MayinSayisiHesapla(satir, sutun);
                tiklananButon.Text = komsuMayinSayisi > 0 ? komsuMayinSayisi.ToString() : "";
                tiklananButon.Enabled = false; // Butonu devre dışı bırak

                // Eğer komşu mayın yoksa çevresindeki hücreleri de aç
                if (komsuMayinSayisi == 0)
                {
                    CevreyiAc(satir, sutun);
                }
            }
        }

        private int MayinSayisiHesapla(int x, int y)
        {
            int sayac = 0;

            // Çevredeki 8 hücreyi kontrol ediyorum
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int yeniX = x + i;
                    int yeniY = y + j;

                    // Hücre sınırları dışına çıkmamak şartıyla mayın kontrolü yapıyorum
                    if (yeniX >= 0 && yeniX < BOYUT && yeniY >= 0 && yeniY < BOYUT && mayinlar[yeniX, yeniY])
                    {
                        sayac++; // Mayın varsa sayaç artır
                    }
                }
            }
            return sayac; // Komşu mayın sayısını döndür
        }

        private void CevreyiAc(int x, int y)
        {
            // Çevredeki tüm hücreleri kontrol ediyorum
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int yeniX = x + i;
                    int yeniY = y + j;

                    // Hücre sınırları dışına çıkmayan ve daha önce açılmamış hücreleri açıyorum
                    if (yeniX >= 0 && yeniX < BOYUT && yeniY >= 0 && yeniY < BOYUT && butonlar[yeniX, yeniY].Enabled)
                    {
                        butonlar[yeniX, yeniY].PerformClick(); // Tıklama olayını tetikle
                    }
                }
            }
        }

        private void OyunBitir()
        {
            oyunBitti = true; // Oyun durumunu bitmiş olarak işaretle

            // Tüm mayınları görünür hale getiriyorum
            for (int i = 0; i < BOYUT; i++)
            {
                for (int j = 0; j < BOYUT; j++)
                {
                    if (mayinlar[i, j])
                    {
                        butonlar[i, j].Text = "*";
                        butonlar[i, j].BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
