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
    public partial class Sotrs : Form
    {
        private Int32 sotrID;

        public Sotrs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MainPage().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void Sotrs_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgFill();
            CbFill();
        }

        private void DgFill()
        {
            var table_class = new Table_Class("SELECT ID_Sotrudnika, [Name_Sotrudnika]  as \"Фамилия\" ," +
                                              "[Midlle_Name_Sotrudnika] as \"Имя\",[Last_Name_Sotrudnika] as \"Отчество\",[Birhady_Date_Sotrudnika] as \"Дата Рождения\"" +
                                              ",[Document_Series] as \"Серия Паспорта\" " +
                                              ",[Document_Number] as \"Номер Паспорта\",[Sotrudnika_Login] as \"Логин\",[Sotrudnika_Password] as \"Пароль\", " +
                                              "[Nazvanie_Otdela] as \"Название Отдела\", Otdel_ID FROM [Restoran].[dbo].[Sotrudniki] INNER JOIN [Restoran].[dbo].[Otdel] ON " +
                                              "[Restoran].[dbo].[Sotrudniki].[Otdel_ID] = [Restoran].[dbo].[Otdel].[ID_Otdela]");
            dataGridView1.DataSource = table_class.table.DefaultView;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[10].Visible = false;
        }

        private void CbFill()
        {
            Table_Class tableClass = new Table_Class("SELECT ID_Otdela, Nazvanie_Otdela FROM dbo.Otdel");
            comboBox1.DataSource = tableClass.table.DefaultView;
            comboBox1.ValueMember = "ID_Otdela";
            comboBox1.DisplayMember = "Nazvanie_Otdela";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
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
            arrayList.Add(comboBox1.SelectedValue);
            new Procedure_Class().procedure_Execution("Sotrudniki_insert", arrayList);
            DgFill();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            if (row != null)
            {
                sotrID = Convert.ToInt32(row.Cells[0].Value.ToString());
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
                textBox7.Text = row.Cells[7].Value.ToString();
                textBox8.Text = row.Cells[8].Value.ToString();
                comboBox1.Text = row.Cells[9].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(sotrID);
            arrayList.Add(textBox1.Text);
            arrayList.Add(textBox2.Text);
            arrayList.Add(textBox3.Text);
            arrayList.Add(textBox4.Text);
            arrayList.Add(textBox5.Text);
            arrayList.Add(textBox6.Text);
            arrayList.Add(textBox7.Text);
            arrayList.Add(textBox8.Text);
            arrayList.Add(comboBox1.SelectedValue);
            new Procedure_Class().procedure_Execution("Sotrudniki_update", arrayList);
            DgFill();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(sotrID);
            new Procedure_Class().procedure_Execution("Sotrudniki_delete", arrayList);
            DgFill();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(tbSearch.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            button6_Click(sender, e);
                            break;
                        }
            }
        }
    }
}
