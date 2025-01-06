using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaYarisi
{
    public partial class Form1 : Form
    {

        int yolunHizi;
        int trafiginHizi = 15;
        int oyuncuHizi = 12;
        int skor;
        int arabaImage;

        Random rand = new Random();
        Random arabaPozisyonu = new Random();

        bool solagit, sagagit;

        bool xBasildiMi = false;
        bool zBasildiMi = false;
        int hileSayac = 0;
        bool hileAktifMi = false;
        

        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                solagit = true;
            }

            if(e.KeyCode == Keys.Right)
            {
                sagagit = true;
            }

            if (e.KeyCode == Keys.X)
            {
                xBasildiMi = true;
            }

            if (e.KeyCode == Keys.Z)
            {
                zBasildiMi = true;
            }
            
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                solagit = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                sagagit = false;
            }

            if (e.KeyCode == Keys.X)
            {
                xBasildiMi = false;
            }

            if (e.KeyCode == Keys.Z)
            {
                zBasildiMi = false;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            
            lblSkor.Text = "Skor: " + skor;
            skor++;

            if(solagit == true && player.Left > 5)
            {
                player.Left -= oyuncuHizi;
            }
            if(sagagit == true && player.Left < 415)
            {
                player.Left += oyuncuHizi;
            }

            YolCizgileri1.Top += yolunHizi;
            YolCizgileri2.Top += yolunHizi;

            if(YolCizgileri2.Top > 519)
            {
                YolCizgileri2.Top = -519;
            }

            if(YolCizgileri1.Top > 519)
            {
                YolCizgileri1.Top = -519;
            }

            Bot1.Top += trafiginHizi;
            Bot2.Top += trafiginHizi;

            if(Bot1.Top > 530)
            {
                botlarinArabaDegistir(Bot1);
            }

            if(Bot2.Top > 530)
            {
                botlarinArabaDegistir(Bot2);
            }

            if (zBasildiMi && xBasildiMi)
            {
                hileSayac++;
                if (!(hileSayac % 2 == 0))
                {
                    hileAktifMi = true;
                    player.BackColor = Color.Green;
                }
                else
                {
                    player.BackColor = Color.Transparent;
                    hileAktifMi = false;
                }

            }


            if (hileAktifMi == true)
            {
                return;
            }
            else if (player.Bounds.IntersectsWith(Bot1.Bounds) || player.Bounds.IntersectsWith(Bot2.Bounds))
            {
                oyunBitti();
            }

            


            if (skor > 500)
            {
                yolunHizi = 20;
                trafiginHizi = 22;
            }

            if(skor > 1250)
            {
                yolunHizi = 25;
                trafiginHizi = 26;
            }

            if(skor >= 1500)
            {
                trafiginHizi = 22;
                yolunHizi = 20;
            }


        }

        private void botlarinArabaDegistir(PictureBox tempAraba)
        {
            arabaImage = rand.Next(1,9);

            switch(arabaImage)
            {
                case 1:
                    tempAraba.Image = Properties.Resources.ambulance;
                    break;
                case 2:
                    tempAraba.Image = Properties.Resources.carGreen;
                    break;
                case 3:
                    tempAraba.Image = Properties.Resources.carGrey;
                    break;
                case 4:
                    tempAraba.Image = Properties.Resources.carOrange;
                    break;
                case 5:
                    tempAraba.Image = Properties.Resources.carPink;
                    break;
                case 6:
                    tempAraba.Image = Properties.Resources.CarRed;
                    break;
                case 7:
                    tempAraba.Image = Properties.Resources.carYellow;
                    break;
                case 8:
                    tempAraba.Image = Properties.Resources.TruckBlue;
                    break;
                case 9:
                    tempAraba.Image = Properties.Resources.TruckWhite;
                    break;
            }

            tempAraba.Top = arabaPozisyonu.Next(100,400)*-1;


            if((string)tempAraba.Tag == "soldakiAraba")
            {
                tempAraba.Left = arabaPozisyonu.Next(5, 200);
            }

            if((string)tempAraba.Tag == "sagdakiAraba")
            {
                tempAraba.Left = arabaPozisyonu.Next(245, 422);
            }


        }

        private void oyunBitti()
        {
            carpmaSesCal();
            gameTimer.Stop();
            imgPatlama.Visible = true;
            player.Controls.Add(imgPatlama);
            imgPatlama.Location = new Point(-8,5);
            imgPatlama.BackColor = Color.Transparent;

            if(skor >= 1500)
            {
                imgWinner.Visible = true;
                imgWinner.BackColor = Color.Transparent;
            }
            else
            {
                imgLose.Visible = true;
                imgLose.BackColor = Color.Transparent;
            }

            

            btnBasla.Enabled = true;
        }

        private void ResetGame()
        {
            btnBasla.Enabled = false;
            imgPatlama.Visible = false;
            imgWinner.Visible = false;
            imgLose.Visible = false;
            solagit = false;
            sagagit = false;
            skor = 0;

            yolunHizi = 12;
            trafiginHizi = 15;

            Bot1.Top = arabaPozisyonu.Next(200,500)*-1;
            Bot1.Left = arabaPozisyonu.Next(5, 200);

            Bot2.Top = arabaPozisyonu.Next(200,500)*-1;
            Bot2.Left = arabaPozisyonu.Next(245, 422);

            gameTimer.Start();  


        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void carpmaSesCal()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.hit);
            player.Play();
        }


    }
}
