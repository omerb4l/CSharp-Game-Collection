using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void lblHosgeldiniz_Click(object sender, EventArgs e)
        {

        }

        //Üçe üç olan oyun formuna yönlendirmeye yarayan buton.
        private void btnUc_Click(object sender, EventArgs e)
        {
            UceUc ucxuc = new UceUc();
            ucxuc.Show();
            this.Hide();
        }

        //Beşe beş olan oyun formuna yönlendirmeye yarayan buton.
        private void btnBes_Click(object sender, EventArgs e)
        {
            BeseBes besxbes = new BeseBes();
            besxbes.Show();
            this.Hide();
        }

        //Yediye yedi olan oyun formuna yönlendirmeye yarayan buton.
        private void btnYedi_Click(object sender, EventArgs e)
        {
            YediyeYedi yedixyedi = new YediyeYedi();
            yedixyedi.Show();
            this.Hide();
        }

        //Programı sonlandırmaya yarayan buton.
        private void btnGeri_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
