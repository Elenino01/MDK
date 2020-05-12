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
    public partial class Oplata : Form
    {
        private Table_Class table_class1;

        public Oplata()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MainPage().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void Oplata_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgFill();
        }

        private void DgFill()
        {
            table_class1 = new Table_Class("SELECT [ID_Zakaza] as \"Код заказа\",[Summa_Zakaza] as \"СуммаЗаказа\",[Number_of_Stol] as \"НомерСтола\"," +
                                               " [Name_Sotrudnika] as \"ФамилияСотрудника\", [Name_of_Tovar] as \"ИмяТовара\", [ID_Tovara], [ID_Sotrudnika]" +
                                               " FROM [Restoran].[dbo].[Zakaz] inner join [Restoran].[dbo].[Sotrudniki] on" +
                                               " [Restoran].[dbo].[Zakaz].[Sotrudnika_ID] = [Restoran].[dbo].[Sotrudniki].[ID_Sotrudnika] " +
                                               "inner join [Restoran].[dbo].[Spisok_Tovarov] on [Restoran].[dbo].[Zakaz].[Tovar_ID] = [Restoran].[dbo].[Spisok_Tovarov].[ID_Tovara]" +
                                               $" WHERE [ID_Zakaza] = {Program.GotovZakaz}");
            dataGridView1.DataSource = table_class1.table.DefaultView;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document_Class documentClass = new Document_Class();
            documentClass.Document_Create(Document_Class.Document_Type.Report, Document_Class.Document_Format.Word, "Заказ на оплату", table_class1.table);
            documentClass.Document_Create(Document_Class.Document_Type.Report, Document_Class.Document_Format.Excel, "Заказ на оплату", table_class1.table);
            documentClass.Document_Create(Document_Class.Document_Type.Report, Document_Class.Document_Format.PDF, "Заказ на оплату", table_class1.table);
        }
    }
}
