using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sale_App;

namespace RestoranWinForms
{
    static class Program
    {
        public static string intID = "";
        public static Int32 IDSotr, GotovZakaz;
        public static string FIOSotr = "";
        public static Int32 intDropStatis = 0;
        public static string strStatus = "Null";
        public static bool connect = false;
        private static Mutex _instanse;
        private const string _app_name = "Ресторан";
        public static Int32 Dostup;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool Create_app;
            _instanse = new Mutex(true, _app_name, out Create_app);
            if (Create_app)
            {
                try
                {
                    Configuration_class configuration = new Configuration_class();
                    configuration.SQL_Server_Configuration_Get();
                    Configuration_class.connection.Open();
                    connect = true;
                }
                catch
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    ConnectionForm conection = new ConnectionForm();
                    conection.ShowDialog();
                }
                finally
                {
                    Configuration_class.connection.Close();
                    switch (connect)
                    {
                        case false:
                            MessageBox.Show("Ошибка подключения", "Ресторан", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Environment.Exit(0);
                            break;
                        case true:
                            try
                            {
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);
                                Application.Run(new Auth());
                            }
                            catch { }
                            break;
                    }
                }
            }
        }
    }
}
