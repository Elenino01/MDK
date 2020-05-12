using System;
using System.Collections;
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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(textBox1.Text);
            arrayList.Add(textBox2.Text);
            arrayList.Add(textBox3.Text);
            arrayList.Add(textBox4.Text);
            arrayList.Add(textBox5.Text);
            arrayList.Add(textBox6.Text);
            arrayList.Add(textBox7.Text);
            arrayList.Add(textBox8.Text);
            arrayList.Add(2);
            new Procedure_Class().procedure_Execution("Sotrudniki_insert", arrayList);
            MessageBox.Show("Вы успешно зарегистрированны!", "Ресторан", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            new Auth().Show();
            Visible = false;
            ShowInTaskbar = false;
        }
    }
}
