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
    /// Логика взаимодействия для AddPayment.xaml
    /// </summary>
    public partial class AddPayment : Window
    {
        bool howform = true;
        public AddPayment(bool temp)
        {
            try
            {
                InitializeComponent();
                howform = temp;

                WorkSQL.sql_p = "select Вид from show_kind";
                cbx_kind.ItemsSource = WorkSQL.ConvertQueryToComboBox();

                WorkSQL.sql_p = "select Номер from show_company";
                cbx_company.ItemsSource = WorkSQL.ConvertQueryToComboBox();

                WorkSQL.sql_p = "select department_code from show_available('" + WorkSQL.login_p + "');";
                cbx_department.ItemsSource = WorkSQL.ConvertQueryToComboBox();

                if (howform)
                {
                    mainwin.Title = "Добавить платёж";
                    btn_add.Content = "Добавить";
                }
                else
                {
                    mainwin.Title = "Изменить платёж";
                    btn_add.Content = "Изменить";
                    cbx_kind.SelectedItem = WorkSQL.drv_p.Row.ItemArray[1];
                    dp_date.SelectedDate = (DateTime)WorkSQL.drv_p.Row.ItemArray[2];
                    txt_amount.Text = WorkSQL.drv_p.Row.ItemArray[3].ToString();
                    cbx_company.SelectedItem = WorkSQL.drv_p.Row.ItemArray[6].ToString();
                    cbx_department.SelectedItem = WorkSQL.drv_p.Row.ItemArray[5].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbx_kind.SelectedItem != null && dp_date.SelectedDate != null && txt_amount.Text.Trim() != "" && cbx_company.SelectedItem != null && cbx_department.SelectedItem != null)
                {
                    if (howform)
                    {
                        WorkSQL.sql_p = "select add_payment('" + cbx_kind.SelectedItem + "','"
                            + ((DateTime)dp_date.SelectedDate).ToString("dd-MM-yyyy") + "','"
                            + txt_amount.Text.Trim() + "','" + cbx_company.SelectedItem + "','" + cbx_department.SelectedItem + "','" + WorkSQL.login_p + "');";
                        WorkSQL.ExecuteSQL();
                    }
                    else
                    {
                        WorkSQL.sql_p = "select update_payment('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + cbx_kind.SelectedItem + "','"
                            + ((DateTime)dp_date.SelectedDate).ToString("dd-MM-yyyy") + "','"
                            + txt_amount.Text.Trim() + "','" + cbx_company.SelectedItem + "','" + cbx_department.SelectedItem + "');";
                        WorkSQL.ExecuteSQL();
                    }
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
