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
    public partial class SpisokTovarov : Form
    {
        private Int32 ID_Tovara;

        public SpisokTovarov()
        {
            InitializeComponent();
        }

        private void SpisokTovarov_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgFill();
            CbFill();
        }

        private void DgFill()
        {
            var table_class = new Table_Class("SELECT [ID_Tovara],[Name_of_Tovar] as \"Имя Товара\",[Number_of_Tovar] as \"Номер Товара\"" +
                                              ",[Date_Postavka] as \"Дата Поставки Товара\",[Srok_Godnosti] as \"Срок Годности\", " +
                                              "[Nazv_Kachestvo] as \"Название Качества\", [ID_Kachestvo] FROM [Restoran].[dbo].[Spisok_Tovarov] inner join" +
                                              " [Restoran].[dbo].[Kachestvo] on [Restoran].[dbo].[Spisok_Tovarov].[Kachestvo_ID] = [Restoran].[dbo].[Kachestvo].[ID_Kachestvo]");
            dataGridView1.DataSource = table_class.table.DefaultView;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void CbFill()
        {
            Table_Class tableClass = new Table_Class("SELECT [ID_Kachestvo],[Nazv_Kachestvo] FROM [Restoran].[dbo].[Kachestvo]");
            comboBox1.DataSource = tableClass.table.DefaultView;
            comboBox1.ValueMember = "ID_Kachestvo";
            comboBox1.DisplayMember = "Nazv_Kachestvo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(textBox1.Text);
            arrayList.Add(textBox2.Text);
            arrayList.Add(textBox3.Text);
            arrayList.Add(textBox4.Text);
            arrayList.Add(comboBox1.SelectedValue);
            new Procedure_Class().procedure_Execution("Spisok_Tovarov_insert", arrayList);
            DgFill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(ID_Tovara);
            arrayList.Add(textBox1.Text);
            arrayList.Add(textBox2.Text);
            arrayList.Add(textBox3.Text);
            arrayList.Add(textBox4.Text);
            arrayList.Add(comboBox1.SelectedValue);
            new Procedure_Class().procedure_Execution("Spisok_Tovarov_update", arrayList);
            DgFill();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(ID_Tovara);
            new Procedure_Class().procedure_Execution("Spisok_Tovarov_delete", arrayList);
            DgFill();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            if (row != null)
            {
                ID_Tovara = Convert.ToInt32(row.Cells[0].Value.ToString());
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                comboBox1.Text = row.Cells[5].Value.ToString();
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
