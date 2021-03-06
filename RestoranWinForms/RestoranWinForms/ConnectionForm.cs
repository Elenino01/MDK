﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sale_App;

namespace RestoranWinForms
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            Configuration_class configuration = new Configuration_class();
            configuration.Server_Collection += Configuration_server_Collection;
            Thread threadServers = new Thread(configuration.SQL_Server_Enumurator);
            threadServers.Start();
        }

        private void Configuration_server_Collection(DataTable obj)
        {
            Action action = () =>
            {
                foreach (DataRow r in obj.Rows)
                {
                    cbServers.Items.Add(string.Format(@"{0}\{1}", r[0], r[1]));
                }
                cbServers.Enabled = true;
                btChecked.Enabled = true;
            };
            Invoke(action);
        }

        private void Configuration_Data_Base_Collection(DataTable obj)
        {
            Action action = () =>
            {
                foreach (DataRow r in obj.Rows)
                {
                    cbDatabases.Items.Add(r[0]);
                }
                cbDatabases.Enabled = true;
                btChecked.Enabled = true;
            };
            Invoke(action);
        }

        private void btChecked_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection sql = new System.Data.SqlClient.SqlConnection(string.Format("Data Source = {0}; Initial Catalog = {1}; Integrated Security = true;", cbServers.Text, cbDatabases.Text));
            try
            {
                sql.Open();
                btConnect.Enabled = true;
            }
            catch
            {

            }
            finally
            {
                sql.Close();
            }
        }

        private void Configuration_connection_checked(bool obj)
        {
            switch (obj)
            {
                case true:
                    MessageBox.Show("Проверка выполнена!");
                    Action action = () =>
                    {
                        Configuration_class configuration1 = new Configuration_class();
                        configuration1.Data_Base_Collection += Configuration_Data_Base_Collection;
                        Thread threadBases = new Thread(configuration1.SQL_Data_Base_Collection);
                        threadBases.Start();
                    };
                    Invoke(action);
                    break;
                case false:
                    Configuration_class configuration = new Configuration_class();
                    configuration.Server_Collection += Configuration_server_Collection;
                    Thread threadServers = new Thread(configuration.SQL_Server_Enumurator);
                    threadServers.Start();
                    break;
            }
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            switch (cbDatabases.Text == "")
            {
                case true:
                    MessageBox.Show("Не выбрана нужная БД", "Ресторан", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbDatabases.Focus();
                    break;
                case false:
                    Configuration_class configuration_Class = new Configuration_class();
                    configuration_Class.SQL_Server_Configuration_Set(cbServers.Text, cbDatabases.Text);
                    Program.connect = true;
                    Application.Restart();
                    break;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configuration_class configuration = new Configuration_class();
            configuration.ds = cbServers.SelectedItem.ToString();
            configuration.Conection_Checked += Configuration_connection_checked;
            Thread threadBases = new Thread(configuration.SQL_Data_Base_Checking);
            threadBases.Start();
        }
    }
}
