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
    /// Логика взаимодействия для AddEducation.xaml
    /// </summary>
    public partial class AddHelper : Window
    {
        bool howform = true;
        int howhelper = 0;
        public AddHelper(bool temp, int i)
        {
            try
            {
                InitializeComponent();
                howform = temp;
                howhelper = i;
                if (howform)
                {
                    btn_add.Content = "Добавить";
                    switch (howhelper)
                    {
                        case 1:
                            mainwin.Title = "Добавить образование";
                            lbl_name.Content = "Образование";
                            break;
                        case 2:
                            mainwin.Title = "Добавить тип";
                            lbl_name.Content = "Тип";
                            break;
                        case 3:
                            mainwin.Title = "Добавить заголовок";
                            lbl_name.Content = "Заголовок";
                            break;
                        case 4:
                            mainwin.Title = "Добавить вид";
                            lbl_name.Content = "Вид";
                            break;
                        case 5:
                            mainwin.Title = "Добавить владельца";
                            lbl_name.Content = "Владелец";
                            break;
                    }
                }
                else
                {
                    btn_add.Content = "Изменить";

                    txt_name.Text = WorkSQL.drv_p.Row.ItemArray[1].ToString();

                    switch (howhelper)
                    {
                        case 1:
                            mainwin.Title = "Изменить образование";
                            lbl_name.Content = "Образование";
                            break;
                        case 2:
                            mainwin.Title = "Изменить тип";
                            lbl_name.Content = "Тип";
                            break;
                        case 3:
                            mainwin.Title = "Изменить заголовок";
                            lbl_name.Content = "Заголовок";
                            break;
                        case 4:
                            mainwin.Title = "Изменить вид";
                            lbl_name.Content = "Вид";
                            break;
                        case 5:
                            mainwin.Title = "Изменить владельца";
                            lbl_name.Content = "Владелец";
                            break;
                    }
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
                if (txt_name.Text.Trim() != "")
                {
                    if (howform)
                    {
                        switch (howhelper)
                        {
                            case 1:
                                WorkSQL.sql_p = "select add_education('" + txt_name.Text.Trim() + "');";
                                break;
                            case 2:
                                WorkSQL.sql_p = "select add_type('" + txt_name.Text.Trim() + "');";
                                break;
                            case 3:
                                WorkSQL.sql_p = "select add_title('" + txt_name.Text.Trim() + "');";
                                break;
                            case 4:
                                WorkSQL.sql_p = "select add_kind('" + txt_name.Text.Trim() + "');";
                                break;
                            case 5:
                                WorkSQL.sql_p = "select add_owner_ship('" + txt_name.Text.Trim() + "');";
                                break;
                        }
                        WorkSQL.ExecuteSQL();
                    }
                    else
                    {
                        switch (howhelper)
                        {
                            case 1:
                                WorkSQL.sql_p = "select update_education('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + txt_name.Text.Trim() + "');";
                                break;
                            case 2:
                                WorkSQL.sql_p = "select update_type('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + txt_name.Text.Trim() + "');";
                                break;
                            case 3:
                                WorkSQL.sql_p = "select update_title('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + txt_name.Text.Trim() + "');";
                                break;
                            case 4:
                                WorkSQL.sql_p = "select update_kind('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + txt_name.Text.Trim() + "');";
                                break;
                            case 5:
                                WorkSQL.sql_p = "select update_owner_ship('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + txt_name.Text.Trim() + "');";
                                break;
                        }
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
