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
    public partial class ZakazTovara : Form
    {
        public ZakazTovara()
        {
            InitializeComponent();
        }

        private void ZakazTovara_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgFill();
        }

        private void DgFill()
        {
            var table_class1 = new Table_Class("SELECT [ID_Zakaza] as \"Код заказа\",[Summa_Zakaza] as \"СуммаЗаказа\",[Number_of_Stol] as \"НомерСтола\"," +
                                              " [Name_Sotrudnika] as \"ФамилияСотрудника\", [Name_of_Tovar] as \"ИмяТовара\", [ID_Tovara], [ID_Sotrudnika]" +
                                              " FROM [Restoran].[dbo].[Zakaz] inner join [Restoran].[dbo].[Sotrudniki] on" +
                                              " [Restoran].[dbo].[Zakaz].[Sotrudnika_ID] = [Restoran].[dbo].[Sotrudniki].[ID_Sotrudnika] " +
                                              "inner join [Restoran].[dbo].[Spisok_Tovarov] on [Restoran].[dbo].[Zakaz].[Tovar_ID] = [Restoran].[dbo].[Spisok_Tovarov].[ID_Tovara]");
            dataGridView1.DataSource = table_class1.table.DefaultView;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            var table_class = new Table_Class("SELECT [ID_Tovara],[Name_of_Tovar] as \"Имя Товара\",[Number_of_Tovar] as \"Номер Товара\"" +
                                              ",[Date_Postavka] as \"Дата Поставки Товара\",[Srok_Godnosti] as \"Срок Годности\", " +
                                              "[Nazv_Kachestvo] as \"Название Качества\", [ID_Kachestvo] FROM [Restoran].[dbo].[Spisok_Tovarov] inner join" +
                                              " [Restoran].[dbo].[Kachestvo] on [Restoran].[dbo].[Spisok_Tovarov].[Kachestvo_ID] = [Restoran].[dbo].[Kachestvo].[ID_Kachestvo]");
            dataGridView2.DataSource = table_class.table.DefaultView;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[6].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MainPage().Show();
            Visible = false;
            ShowInTaskbar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.GotovZakaz = Convert.ToInt32(numericUpDown1.Value);
            new Oplata().Show();
            Visible = false;
            ShowInTaskbar = false;
        }
    }
}
