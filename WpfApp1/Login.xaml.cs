using MaterialDesignThemes.Wpf;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            log_prog.Visibility = Visibility.Hidden;
        }

        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private string msgrole;
        private string password;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (loginT.Text.Trim() == "" | passwordT.Password.Trim() == "")
                {
                    MessageBox.Show("Вы заполнили не все поля!");
                }
                else
                {
                    log_prog.Visibility = Visibility.Visible;
                    WorkSQL.login_p = loginT.Text.Trim().ToLower();
                    password = passwordT.Password.Trim();
                    autorization.IsEnabled = false;
                    loginT.IsEnabled = false;
                    passwordT.IsEnabled = false;
                    await Task.Run(() => ConDB());
                    //Thread t = new Thread(ConDB);
                    //t.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ConDB()
        {
            try
            {
                string connectionString = "Server=127.0.0.1;Port=5432;User Id=" + WorkSQL.login_p
                    + ";Password=" + password + ";Database=Tax_Service;";

                WorkSQL.npgSqlCon_p = new NpgsqlConnection(connectionString);
                WorkSQL.npgSqlCon_p.Open();

                WorkSQL.sql_p = "select show_role('" + WorkSQL.login_p + "');";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(WorkSQL.sql_p, WorkSQL.npgSqlCon_p);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                WorkSQL.role_p = (string)dt.Rows[0].ItemArray[0];

                switch (WorkSQL.role_p)
                {
                    case "Tax_Admin":
                        msgrole = "Администратор";
                        break;
                    case "Tax_Employee":
                        msgrole = "Сотрудник";
                        break;
                    case "Tax_SuperVisor":
                        msgrole = "Обозреватель";
                        break;
                }
                Dispatcher.Invoke((Action)(() =>
                {
                    log_prog.Visibility = Visibility.Hidden;
                    MessageBox.Show("Вы вошли в систему!(" + msgrole + ")");
                    MainWindow m = new MainWindow();
                    m.Show();
                    this.Close();
                }));
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    log_prog.Visibility = Visibility.Hidden;
                    autorization.IsEnabled = true;
                    loginT.IsEnabled = true;
                    passwordT.IsEnabled = true;
                    MessageBox.Show("Ошибка входа!");//ex.Message
                }));
            }
        }
    }
}
