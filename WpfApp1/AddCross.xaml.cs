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
    /// Логика взаимодействия для AddCross.xaml
    /// </summary>
    public partial class AddCross : Window
    {
        bool howform = true;
        public AddCross(bool temp)
        {
            try
            {
                InitializeComponent();
                howform = temp;

                WorkSQL.sql_p = "select Номер from show_department";
                cbx_department.ItemsSource = WorkSQL.ConvertQueryToComboBox();

                WorkSQL.sql_p = "select Номер from show_employee";
                cbx_employee.ItemsSource = WorkSQL.ConvertQueryToComboBox();

                if (howform)
                {
                    mainwin.Title = "Добавить распределение";
                    btn_add.Content = "Добавить";
                }
                else
                {
                    mainwin.Title = "Изменить распределение";
                    btn_add.Content = "Изменить";
                    cbx_department.Text = WorkSQL.drv_p.Row.ItemArray[1].ToString();
                    cbx_employee.Text = WorkSQL.drv_p.Row.ItemArray[3].ToString();
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
                if (cbx_employee.SelectedItem != null && cbx_department.SelectedItem != null)
                {
                    if (howform)
                    {
                        WorkSQL.sql_p = "select add_cross('" + cbx_department.SelectedItem + "','"
                            + cbx_employee.SelectedItem + "');";
                        WorkSQL.ExecuteSQL();
                    }
                    else
                    {
                        WorkSQL.sql_p = "select update_cross('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + cbx_department.SelectedItem + "','"
                            + cbx_employee.SelectedItem + "');";
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
