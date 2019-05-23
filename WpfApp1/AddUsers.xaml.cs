using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        bool temp;
        bool who;
        public AddUsers(bool t1, bool t2)
        {
            temp = t1;
            who = t2;
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MyWindow_Closing);
        }
        void MyWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (temp)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_login.Text.Trim() != "" && txt_password.Text.Trim() != "")
                {

                    if (temp)
                    {
                        if (who)
                        {
                            WorkSQL.sql_p = "select create_user('" + txt_login.Text.Trim().ToLower() +
                                    "','" + txt_password.Text.Trim() + "','Tax_Employee');";
                            WorkSQL.ExecuteSQL();

                            WorkSQL.sql_p = "select add_users_employee('" + txt_login.Text.Trim().ToLower() + "');";
                            WorkSQL.ExecuteSQL();
                        }
                        else
                        {
                            WorkSQL.sql_p = "select create_user('" + txt_login.Text.Trim().ToLower() +
                                "','" + txt_password.Text.Trim() + "','Tax_SuperVisor');";
                            WorkSQL.ExecuteSQL();
                        }
                    }
                    else
                    {

                    }
                    temp = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
