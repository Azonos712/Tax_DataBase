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
    /// Логика взаимодействия для AddCompany.xaml
    /// </summary>
    public partial class AddCompany : Window
    {
        bool howform = true;
        public AddCompany(bool temp)
        {
            try
            {
                InitializeComponent();
                howform = temp;

                WorkSQL.sql_p = "select \"Форма собственности\" from show_owner_ship";
                cbx_owner.ItemsSource = WorkSQL.ConvertQueryToComboBox();

                if (howform)
                {
                    mainwin.Title = "Добавить предприятие";
                    btn_add.Content = "Добавить";
                }
                else
                {
                    mainwin.Title = "Изменить предприятие";
                    btn_add.Content = "Изменить";
                    txt_name.Text = WorkSQL.drv_p.Row.ItemArray[1].ToString();
                    cbx_owner.SelectedItem = WorkSQL.drv_p.Row.ItemArray[2];
                    txt_phone.Text = WorkSQL.drv_p.Row.ItemArray[3].ToString();
                    dp_date.SelectedDate = (DateTime)WorkSQL.drv_p.Row.ItemArray[4];
                    txt_number.Text = WorkSQL.drv_p.Row.ItemArray[5].ToString();
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
                if (txt_name.Text.Trim() != "" && cbx_owner.SelectedItem != null && txt_phone.Text.Trim() != "" && dp_date.SelectedDate != null && txt_number.Text.Trim() != "")
                {
                    if (howform)
                    {
                        WorkSQL.sql_p = "select add_company('" + txt_name.Text.Trim() + "','"
                            + cbx_owner.SelectedItem + "','" + txt_phone.Text.Trim() + "','"
                            + ((DateTime)dp_date.SelectedDate).ToString("dd-MM-yyyy") + "','"
                            + txt_number.Text.Trim() + "');";
                        WorkSQL.ExecuteSQL();
                    }
                    else
                    {
                        WorkSQL.sql_p = "select update_company('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + txt_name.Text.Trim() + "','"
                            + cbx_owner.SelectedItem + "','" + txt_phone.Text.Trim() + "','"
                            + ((DateTime)dp_date.SelectedDate).ToString("dd-MM-yyyy") + "','"
                            + txt_number.Text.Trim() + "');";
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
