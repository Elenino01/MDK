using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sale_App;

namespace RestoranWinForms
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Login = tbLogin.Text;
            string Password = tbPassword.Text;

            var Proverka = new Table_Class($"SELECT Otdel_ID, ID_Sotrudnika FROM dbo.Sotrudniki WHERE Sotrudnika_Login = '{Login}' AND Sotrudnika_Password = '{Password}'");
            try
            {
                if (Proverka.table.Rows[0][0] != DBNull.Value)
                {
                    Program.Dostup = Convert.ToInt32(Proverka.table.Rows[0][0].ToString());
                    Program.IDSotr = Convert.ToInt32(Proverka.table.Rows[0][1].ToString());
                    new MainPage().Show();
                    Visible = false;
                    ShowInTaskbar = false;
                }
            }
            catch
            {
                MessageBox.Show("Не правильно введен логин или пароль!", "Ресторан", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Register().Show();
            Visible = false;
            ShowInTaskbar = false;
        }
    }
}
