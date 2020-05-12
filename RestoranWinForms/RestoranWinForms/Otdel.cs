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
    public partial class Otdel : Form
    {
        private Int32 ID_Otdela;

        public Otdel()
        {
            InitializeComponent();
        }

        private void Otdel_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgFill();
        }

        private void DgFill()
        {
            var table_class = new Table_Class("SELECT [ID_Otdela] ,[Nazvanie_Otdela] as \"НазваниеОтдела\"," +
                                              "[Number_Otdela] as \"НомерОтдела\" FROM [Restoran].[dbo].[Otdel]");
            dataGridView1.DataSource = table_class.table.DefaultView;
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(textBox1.Text);
            arrayList.Add(textBox2.Text);
            new Procedure_Class().procedure_Execution("Otdel_insert", arrayList);
            DgFill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(ID_Otdela);
            arrayList.Add(textBox1.Text);
            arrayList.Add(textBox2.Text);
            new Procedure_Class().procedure_Execution("Otdel_update", arrayList);
            DgFill();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(ID_Otdela);
            new Procedure_Class().procedure_Execution("Otdel_delete", arrayList);
            DgFill();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            if (row != null)
            {
                ID_Otdela = Convert.ToInt32(row.Cells[0].Value.ToString());
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
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
