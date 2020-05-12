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
    public partial class PeredachaTovaraKuxnu : Form
    {
        private Table_Class tableClass;

        public PeredachaTovaraKuxnu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MainPage().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void PeredachaTovaraKuxnu_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgFill();
        }

        private void DgFill()
        {
            tableClass = new Table_Class("SELECT Name_of_Tovar as \"Имя Товара\", Number_of_Tovar as \"Номер Товара\", Srok_Godnosti as \"Срок Годности\" " +
                                         $"FROM dbo.Spisok_Tovarov WHERE Spisok_Tovarov.Date_Postavka = '{DateTime.Now.ToShortDateString()}'");
            dataGridView1.DataSource = tableClass.table.DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document_Class documentClass = new Document_Class();
            documentClass.Document_Create(Document_Class.Document_Type.Statistic, Document_Class.Document_Format.Word, "Товары на передачу на кухню", tableClass.table);
            documentClass.Document_Create(Document_Class.Document_Type.Statistic, Document_Class.Document_Format.Excel, "Товары на передачу на кухню", tableClass.table);
            documentClass.Document_Create(Document_Class.Document_Type.Statistic, Document_Class.Document_Format.PDF, "Товары на передачу на кухню", tableClass.table);
        }
    }
}
