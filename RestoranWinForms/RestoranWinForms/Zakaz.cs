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
    public partial class Zakaz : Form
    {
        private Int32 ID_Zakaza;

        public Zakaz()
        {
            InitializeComponent();
        }

        private void Zakaz_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgFill();
            CbFill();
        }

        private void DgFill()
        {
            var table_class = new Table_Class("SELECT [ID_Zakaza],[Summa_Zakaza] as \"СуммаЗаказа\",[Number_of_Stol] as \"НомерСтола\"," +
                                              " [Name_Sotrudnika] as \"ФамилияСотрудника\", [Name_of_Tovar] as \"ИмяТовара\", [ID_Tovara], [ID_Sotrudnika]" +
                                              " FROM [Restoran].[dbo].[Zakaz] inner join [Restoran].[dbo].[Sotrudniki] on" +
                                              " [Restoran].[dbo].[Zakaz].[Sotrudnika_ID] = [Restoran].[dbo].[Sotrudniki].[ID_Sotrudnika] " +
                                              "inner join [Restoran].[dbo].[Spisok_Tovarov] on [Restoran].[dbo].[Zakaz].[Tovar_ID] = [Restoran].[dbo].[Spisok_Tovarov].[ID_Tovara]");
            dataGridView1.DataSource = table_class.table.DefaultView;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void CbFill()
        {
            Table_Class tableClass = new Table_Class("SELECT ID_Sotrudnika, Midlle_Name_Sotrudnika FROM dbo.Sotrudniki");
            comboBox1.DataSource = tableClass.table.DefaultView;
            comboBox1.ValueMember = "ID_Sotrudnika";
            comboBox1.DisplayMember = "Midlle_Name_Sotrudnika";
            Table_Class tableClass2 = new Table_Class("SELECT ID_Tovara, Name_of_Tovar FROM dbo.Spisok_Tovarov");
            comboBox2.DataSource = tableClass2.table.DefaultView;
            comboBox2.ValueMember = "ID_Tovara";
            comboBox2.DisplayMember = "Name_of_Tovar";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(textBox1.Text);
            arrayList.Add(textBox2.Text);
            arrayList.Add(comboBox2.SelectedValue);
            arrayList.Add(comboBox1.SelectedValue);
            new Procedure_Class().procedure_Execution("Zakaz_insert", arrayList);
            DgFill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(ID_Zakaza);
            arrayList.Add(textBox1.Text);
            arrayList.Add(textBox2.Text);
            arrayList.Add(comboBox2.SelectedValue);
            arrayList.Add(comboBox1.SelectedValue);
            new Procedure_Class().procedure_Execution("Zakaz_update", arrayList);
            DgFill();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(ID_Zakaza);
            new Procedure_Class().procedure_Execution("Zakaz_delete", arrayList);
            DgFill();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            if (row != null)
            {
                ID_Zakaza = Convert.ToInt32(row.Cells[0].Value.ToString());
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                comboBox1.Text = row.Cells[3].Value.ToString();
                comboBox2.Text = row.Cells[4].Value.ToString();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            new MainPage().Show();
            Visible = false;
            ShowInTaskbar = false;
        }
    }
}
