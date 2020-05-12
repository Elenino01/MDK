using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoranWinForms
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();

            if (Program.Dostup != 1)
            {
                if (Program.Dostup == 2)
                    button6.Enabled = true;
                if (Program.Dostup == 3)
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button5.Enabled = true;
                    button10.Enabled = true;
                    button9.Enabled = true;
                    button8.Enabled = true;
                }
                if (Program.Dostup == 4)
                {
                    button3.Enabled = true;
                    button5.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    button6.Enabled = true;
                }

                if (Program.Dostup == 5)
                    button8.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Sotrs().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Otdel().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new SpisokTovarov().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Kachestvo().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Zakaz().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new PrigotovlenieZakaza().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new PeredachaTovaraKuxnu().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new ZavozTovaraSklad().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new ZakazTovara().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Oplata().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Auth().Show();
            Visible = false;
            ShowInTaskbar = false;
        }
    }
}
