using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window
    {
        bool howform = true;
        public AddDepartment(bool temp)
        {
            try
            {
                InitializeComponent();
                howform = temp;

                WorkSQL.sql_p = "select Название from show_title";
                cbx_title.ItemsSource = WorkSQL.ConvertQueryToComboBox();

                WorkSQL.sql_p = "select Тип from show_type";
                cbx_type.ItemsSource = WorkSQL.ConvertQueryToComboBox();

                if (howform)
                {
                    mainwin.Title = "Добавить отделение";
                    btn_add.Content = "Добавить";
                }
                else
                {
                    mainwin.Title = "Изменить отделение";
                    btn_add.Content = "Изменить";
                    cbx_title.SelectedItem = WorkSQL.drv_p.Row.ItemArray[1];
                    cbx_type.SelectedItem = WorkSQL.drv_p.Row.ItemArray[2];
                    dp_date.SelectedDate = (DateTime)WorkSQL.drv_p.Row.ItemArray[3];
                    txt_phone.Text = WorkSQL.drv_p.Row.ItemArray[4].ToString();
                    txt_address.Text = WorkSQL.drv_p.Row.ItemArray[5].ToString();
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
                if (cbx_title.SelectedItem != null && cbx_type.SelectedItem != null && dp_date.SelectedDate != null && txt_phone.Text.Trim() != "" && txt_address.Text.Trim() != "")
                {
                    if (howform)
                    {
                        WorkSQL.sql_p = "select add_department('" + cbx_title.SelectedItem + "','"
                            + cbx_type.SelectedItem + "','" + ((DateTime)dp_date.SelectedDate).ToString("dd-MM-yyyy")
                            + "','" + txt_phone.Text.Trim() + "','" + txt_address.Text.Trim() + "');";
                        WorkSQL.ExecuteSQL();
                    }
                    else
                    {
                        WorkSQL.sql_p = "select update_department('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + cbx_title.SelectedItem + "','"
                            + cbx_type.SelectedItem + "','" + ((DateTime)dp_date.SelectedDate).ToString("dd-MM-yyyy")
                            + "','" + txt_phone.Text.Trim() + "','" + txt_address.Text.Trim() + "');"; ;
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
