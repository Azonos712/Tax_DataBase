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
    /// Логика взаимодействия для DeleteUsers.xaml
    /// </summary>
    public partial class DeleteUsers : Window
    {
        public DeleteUsers()
        {
            InitializeComponent();
            WorkSQL.sql_p = "select select_all_users_from_group('Tax_SuperVisor')";
            cbx_login.ItemsSource = WorkSQL.ConvertQueryToComboBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbx_login.SelectedItem != null)
            {
                WorkSQL.sql_p = "select drop_user('" + cbx_login.SelectedItem + "')";
                WorkSQL.ExecuteSQL();
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
