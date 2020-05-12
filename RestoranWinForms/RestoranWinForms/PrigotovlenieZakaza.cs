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
    public partial class PrigotovlenieZakaza : Form
    {
        public PrigotovlenieZakaza()
        {
            InitializeComponent();
        }

        private void PrigotovlenieZakaza_Load(object sender, EventArgs e)
        {
            dgTovary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgFill();
            CbFill();
        }

        private void DgFill()
        {
            var table_class = new Table_Class("SELECT [ID_Tovara],[Name_of_Tovar] as \"ИмяТовара\",[Number_of_Tovar] as \"НомерТовара\"" +
                                              ",[Date_Postavka] as \"ДатаПоставкиТовара\",[Srok_Godnosti] as \"СрокГодности\", " +
                                              "[Nazv_Kachestvo] as \"НазваниеКачества\", [ID_Kachestvo] FROM [Restoran].[dbo].[Spisok_Tovarov] inner join" +
                                              " [Restoran].[dbo].[Kachestvo] on [Restoran].[dbo].[Spisok_Tovarov].[Kachestvo_ID] = [Restoran].[dbo].[Kachestvo].[ID_Kachestvo]");
            dgTovary.DataSource = table_class.table.DefaultView;
            dgTovary.Columns[0].Visible = false;
            dgTovary.Columns[6].Visible = false;
        }

        private void CbFill()
        {
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
            arrayList.Add(Program.IDSotr);
            new Procedure_Class().procedure_Execution("Zakaz_insert", arrayList);
            DgFill();
            MessageBox.Show("Заказ успешно добавлен!", "Ресторан", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MainPage().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgTovary.RowCount; i++)
            {
                dgTovary.Rows[i].Selected = false;
                for (int j = 0; j < dgTovary.ColumnCount; j++)
                    if (dgTovary.Rows[i].Cells[j].Value != null)
                        if (dgTovary.Rows[i].Cells[j].Value.ToString().Contains(tbSearch.Text))
                        {
                            dgTovary.Rows[i].Selected = true;
                            break;
                        }
            }
        }
    }
}
