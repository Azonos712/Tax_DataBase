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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        bool howform = true;
        public AddEmployee(bool temp)
        {
            try
            {
                InitializeComponent();
                howform = temp;

                WorkSQL.sql_p = "select Образование from show_education";
                cbx_education.ItemsSource = WorkSQL.ConvertQueryToComboBox();

                if (howform)
                {
                    mainwin.Title = "Добавить сотрудника";
                    btn_add.Content = "Добавить";
                }
                else
                {
                    mainwin.Title = "Изменить сотрудника";
                    btn_add.Content = "Изменить";
                    txt_first.Text = WorkSQL.drv_p.Row.ItemArray[1].ToString();
                    txt_second.Text = WorkSQL.drv_p.Row.ItemArray[2].ToString();
                    txt_middle.Text = WorkSQL.drv_p.Row.ItemArray[3].ToString();
                    dp_date.SelectedDate = (DateTime)WorkSQL.drv_p.Row.ItemArray[4];
                    txt_position.Text = WorkSQL.drv_p.Row.ItemArray[5].ToString();
                    txt_salary.Text = WorkSQL.drv_p.Row.ItemArray[6].ToString();
                    cbx_education.SelectedItem = WorkSQL.drv_p.Row.ItemArray[7];
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
                if (txt_first.Text.Trim() != "" && txt_second.Text.Trim() != "" && txt_middle.Text.Trim() != "" && dp_date.SelectedDate != null && txt_position.Text.Trim() != "" && txt_salary.Text.Trim() != "" && cbx_education.SelectedItem != null)
                {
                    if (howform)
                    {
                        WorkSQL.sql_p = "select add_employee('" + txt_first.Text.Trim() + "','"
                            + txt_second.Text.Trim() + "','" + txt_middle.Text.Trim() + "','"
                            + ((DateTime)dp_date.SelectedDate).ToString("dd-MM-yyyy") + "','"
                            + txt_position.Text.Trim() + "','" + txt_salary.Text.Trim() + "','"
                            + cbx_education.SelectedItem + "');";
                        WorkSQL.ExecuteSQL();

                        AddUsers au = new AddUsers(true,true);
                        au.ShowDialog();
                    }
                    else
                    {
                        WorkSQL.sql_p = "select update_employee('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + txt_first.Text.Trim() + "','"
                            + txt_second.Text.Trim() + "','" + txt_middle.Text.Trim() + "','"
                            + ((DateTime)dp_date.SelectedDate).ToString("dd-MM-yyyy") + "','"
                            + txt_position.Text.Trim() + "','" + txt_salary.Text.Trim() + "','"
                            + cbx_education.SelectedItem + "');";
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
