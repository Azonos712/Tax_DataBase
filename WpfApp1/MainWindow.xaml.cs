using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
using NpgsqlTypes;
using WinForms = System.Windows.Forms;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                log_prog.Visibility = Visibility.Hidden;

                switch (WorkSQL.role_p)
                {
                    case "Tax_Admin":
                        mainTabControl.SelectedIndex = 0;
                        TabPayment.Visibility = Visibility.Collapsed;
                        MIQuary.Visibility = Visibility.Collapsed;
                        MIExport.Visibility = Visibility.Collapsed;
                        MIDiagramm.Visibility = Visibility.Collapsed;
                        break;
                    case "Tax_Employee":
                        MIAdmin.Visibility = Visibility.Collapsed;
                        MIGen.Visibility = Visibility.Collapsed;
                        MIQuary.Visibility = Visibility.Collapsed;
                        MIExport.Visibility = Visibility.Collapsed;
                        MIDiagramm.Visibility = Visibility.Collapsed;
                        mainTabControl.SelectedIndex = 3;
                        TabCompany.Visibility = Visibility.Collapsed;
                        TabDepartament.Visibility = Visibility.Collapsed;
                        TabEmployee.Visibility = Visibility.Collapsed;
                        TabEducation.Visibility = Visibility.Collapsed;
                        TabKind.Visibility = Visibility.Collapsed;
                        TabOwnerShip.Visibility = Visibility.Collapsed;
                        TabTitle.Visibility = Visibility.Collapsed;
                        TabType.Visibility = Visibility.Collapsed;
                        TabCross.Visibility = Visibility.Collapsed;
                        break;
                    case "Tax_SuperVisor":
                        btn_add.IsEnabled = false;
                        btn_update.IsEnabled = false;
                        btn_delete.IsEnabled = false;
                        MIAdmin.Visibility = Visibility.Collapsed;
                        MIGen.Visibility = Visibility.Collapsed;
                        TabCross.Visibility = Visibility.Collapsed;
                        TabCompany.Visibility = Visibility.Collapsed;
                        TabEducation.Visibility = Visibility.Collapsed;
                        TabKind.Visibility = Visibility.Collapsed;
                        TabOwnerShip.Visibility = Visibility.Collapsed;
                        TabTitle.Visibility = Visibility.Collapsed;
                        TabType.Visibility = Visibility.Collapsed;
                        mainTabControl.SelectedIndex = 0;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataView ShowCross()
        {
            WorkSQL.sql_p = "select * from show_cross";
            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView10.DataContext = temp;
            //}));
        }
        private DataView ShowOwnerShip()
        {
            WorkSQL.sql_p = "select * from show_owner_ship";
            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView9.DataContext = temp;
            //}));
        }

        private DataView ShowKind()
        {
            WorkSQL.sql_p = "select * from show_kind";
            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView8.DataContext = temp;
            //}));
        }

        private DataView ShowTitle()
        {
            WorkSQL.sql_p = "select * from show_title";
            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView7.DataContext = temp;
            //}));
        }

        private DataView ShowType()
        {
            WorkSQL.sql_p = "select * from show_type";
            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView6.DataContext = temp;
            //}));
        }

        private DataView ShowEducation()
        {
            WorkSQL.sql_p = "select * from show_education";
            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView5.DataContext = temp;
            //}));
        }

        static private DataView ShowPayment()
        {
            WorkSQL.sql_p = "select * from show_payment";
            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView4.DataContext = temp;
            //}));
        }
        static private DataView ShowPaymentFor()
        {
            WorkSQL.sql_p = "select * from show_payment_for('" + WorkSQL.login_p + "')";
            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView4.DataContext = temp;
            //}));
        }

        private DataView ShowCompany()
        {
            WorkSQL.sql_p = "select * from show_company";
            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView3.DataContext = temp;
            //}));
        }

        private DataView ShowEmployee()
        {
            WorkSQL.sql_p = "select * from show_employee";

            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView2.DataContext = temp;
            //}));
        }

        private DataView ShowDepartment()
        {
            WorkSQL.sql_p = "select * from show_department;";

            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    dataGridView1.DataContext = temp;
            //}));
        }

        //---------------------------------------------ADD-----------------------------------------------------------
        #region ADD
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (mainTabControl.SelectedIndex)
                {
                    case 0:
                        AddDepartment ad = new AddDepartment(true);
                        ad.ShowDialog();
                        controll_false();
                        dataGridView1.DataContext = await Task.Run(() => ShowDepartment());
                        break;
                    case 1:
                        AddEmployee ae = new AddEmployee(true);
                        ae.ShowDialog();
                        controll_false();
                        dataGridView2.DataContext = await Task.Run(() => ShowEmployee());
                        break;
                    case 2:
                        AddCompany ac = new AddCompany(true);
                        ac.ShowDialog();
                        controll_false();
                        dataGridView3.DataContext = await Task.Run(() => ShowCompany());
                        break;
                    case 3:
                        AddPayment ap = new AddPayment(true);
                        ap.ShowDialog();
                        controll_false();
                        dataGridView4.DataContext = await Task.Run(() => ShowPaymentFor());
                        //dataGridView4.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 4:
                        AddHelper aed = new AddHelper(true, 1);
                        aed.ShowDialog();
                        controll_false();
                        dataGridView5.DataContext = await Task.Run(() => ShowEducation());
                        //dataGridView5.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 5:
                        AddHelper at = new AddHelper(true, 2);
                        at.ShowDialog();
                        controll_false();
                        dataGridView6.DataContext = await Task.Run(() => ShowType());
                        //dataGridView6.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 6:
                        AddHelper ati = new AddHelper(true, 3);
                        ati.ShowDialog();
                        controll_false();
                        dataGridView7.DataContext = await Task.Run(() => ShowTitle());
                        //dataGridView7.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 7:
                        AddHelper ak = new AddHelper(true, 4);
                        ak.ShowDialog();
                        controll_false();
                        dataGridView8.DataContext = await Task.Run(() => ShowKind());
                        //dataGridView8.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 8:
                        AddHelper ao = new AddHelper(true, 5);
                        ao.ShowDialog();
                        controll_false();
                        dataGridView9.DataContext = await Task.Run(() => ShowOwnerShip());
                        //dataGridView9.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 9:
                        AddCross acr = new AddCross(true);
                        acr.ShowDialog();
                        controll_false();
                        dataGridView10.DataContext = await Task.Run(() => ShowCross());
                        //dataGridView10.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                }
                controll_true();
            }
            catch (Exception ex)
            {
                controll_true();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        //---------------------------------------------UPDATE-----------------------------------------------------------
        #region UPDATE
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (mainTabControl.SelectedIndex)
                {
                    case 0:
                        WorkSQL.drv_p = (DataRowView)dataGridView1.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");
                        AddDepartment ad = new AddDepartment(false);
                        ad.ShowDialog();
                        controll_false();
                        dataGridView1.DataContext = await Task.Run(() => ShowDepartment());
                        break;
                    case 1:
                        WorkSQL.drv_p = (DataRowView)dataGridView2.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");
                        AddEmployee ae = new AddEmployee(false);
                        ae.ShowDialog();
                        controll_false();
                        dataGridView2.DataContext = await Task.Run(() => ShowEmployee());
                        //dataGridView2.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 2:
                        WorkSQL.drv_p = (DataRowView)dataGridView3.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");
                        AddCompany ac = new AddCompany(false);
                        ac.ShowDialog();
                        controll_false();
                        dataGridView3.DataContext = await Task.Run(() => ShowCompany());
                        //dataGridView3.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 3:
                        WorkSQL.drv_p = (DataRowView)dataGridView4.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");
                        AddPayment ap = new AddPayment(false);
                        ap.ShowDialog();
                        controll_false();
                        dataGridView4.DataContext = await Task.Run(() => ShowPaymentFor());
                        //dataGridView4.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 4:
                        WorkSQL.drv_p = (DataRowView)dataGridView5.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");
                        AddHelper aed = new AddHelper(false, 1);
                        aed.ShowDialog();
                        controll_false();
                        dataGridView5.DataContext = await Task.Run(() => ShowEducation());
                        //dataGridView5.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 5:
                        WorkSQL.drv_p = (DataRowView)dataGridView6.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");
                        AddHelper at = new AddHelper(false, 2);
                        at.ShowDialog();
                        controll_false();
                        dataGridView6.DataContext = await Task.Run(() => ShowType());
                        //dataGridView6.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 6:
                        WorkSQL.drv_p = (DataRowView)dataGridView7.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");
                        AddHelper ati = new AddHelper(false, 3);
                        ati.ShowDialog();
                        controll_false();
                        dataGridView7.DataContext = await Task.Run(() => ShowTitle());
                        //dataGridView7.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 7:
                        WorkSQL.drv_p = (DataRowView)dataGridView8.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");
                        AddHelper ak = new AddHelper(false, 4);
                        ak.ShowDialog();
                        controll_false();
                        dataGridView8.DataContext = await Task.Run(() => ShowKind());
                        //dataGridView8.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 8:
                        WorkSQL.drv_p = (DataRowView)dataGridView9.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");
                        AddHelper ao = new AddHelper(false, 5);
                        ao.ShowDialog();
                        controll_false();
                        dataGridView9.DataContext = await Task.Run(() => ShowOwnerShip());
                        //dataGridView9.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 9:
                        WorkSQL.drv_p = (DataRowView)dataGridView10.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");
                        AddCross acr = new AddCross(false);
                        acr.ShowDialog();
                        controll_false();
                        dataGridView10.DataContext = await Task.Run(() => ShowCross());
                        //dataGridView10.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                }
                controll_true();
            }
            catch (Exception ex)
            {
                controll_true();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void OnAutoGeneratinngColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }
        }

        //---------------------------------------------DELETE-----------------------------------------------------------
        #region DELETE
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<string> temp = new List<string>();
            try
            {
                var firstresult = MessageBox.Show("Вы точно хотите удалить данный элемент?", "Удаление", MessageBoxButton.YesNo);
                if (firstresult == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                controll_false();
                switch (mainTabControl.SelectedIndex)
                {
                    case 0:
                        WorkSQL.drv_p = (DataRowView)dataGridView1.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");

                        WorkSQL.sql_p = "select * from select_dep_emp_by_department_code('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                        temp = WorkSQL.ConvertQueryToComboBox();
                        if (temp.Count != 0)
                        {
                            log_prog.Visibility = Visibility.Hidden;
                            var result = MessageBox.Show("Таблица распределения содержит информацию об удаляемом отделении. Вы точно хотите удалить это отделение?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                            log_prog.Visibility = Visibility.Visible;
                        }

                        WorkSQL.sql_p = "select * from select_payment_by_department_code('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                        temp = WorkSQL.ConvertQueryToComboBox();
                        if (temp.Count != 0)
                        {
                            log_prog.Visibility = Visibility.Hidden;
                            var result = MessageBox.Show("Таблица платежи содержит информацию об удаляемом отделении. Вы точно хотите удалить это отделение?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                            log_prog.Visibility = Visibility.Visible;
                        }

                        WorkSQL.sql_p = "select delete_department('" + WorkSQL.drv_p.Row.ItemArray[0] + "');";
                        WorkSQL.ExecuteSQL();

                        dataGridView1.DataContext = await Task.Run(() => ShowDepartment());
                        break;
                    case 1:
                        WorkSQL.drv_p = (DataRowView)dataGridView2.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");

                        WorkSQL.sql_p = "select * from select_dep_emp_by_employee_code('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                        temp = WorkSQL.ConvertQueryToComboBox();
                        if (temp.Count != 0)
                        {
                            log_prog.Visibility = Visibility.Hidden;
                            var result = MessageBox.Show("Таблица распределения содержит информацию об удаляемом сотруднике. Вы точно хотите удалить этого сотрудника?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                            log_prog.Visibility = Visibility.Visible;
                        }

                        WorkSQL.sql_p = "select * from select_payment_by_employee_code('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                        temp = WorkSQL.ConvertQueryToComboBox();
                        if (temp.Count != 0)
                        {
                            log_prog.Visibility = Visibility.Hidden;
                            var result = MessageBox.Show("Таблица платежи содержит информацию об удаляемом сотруднике. Вы точно хотите удалить этого сотрудника?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                            log_prog.Visibility = Visibility.Visible;
                        }

                        WorkSQL.sql_p = "select delete_employee('" + WorkSQL.drv_p.Row.ItemArray[0] + "');";
                        WorkSQL.ExecuteSQL();

                        dataGridView2.DataContext = await Task.Run(() => ShowEmployee());
                        //dataGridView2.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 2:
                        WorkSQL.drv_p = (DataRowView)dataGridView3.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");

                        WorkSQL.sql_p = "select * from select_payment_by_company_code('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                        temp = WorkSQL.ConvertQueryToComboBox();
                        if (temp.Count != 0)
                        {
                            log_prog.Visibility = Visibility.Hidden;
                            var result = MessageBox.Show("Таблица платежи содержит информацию об удаляемой предприятии. Вы точно хотите удалить это предприятие?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                            log_prog.Visibility = Visibility.Visible;
                        }

                        WorkSQL.sql_p = "select delete_company('" + WorkSQL.drv_p.Row.ItemArray[0] + "');";
                        WorkSQL.ExecuteSQL();

                        dataGridView3.DataContext = await Task.Run(() => ShowCompany());
                        //dataGridView3.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 3:
                        WorkSQL.drv_p = (DataRowView)dataGridView4.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");

                        WorkSQL.sql_p = "select delete_payment('" + WorkSQL.drv_p.Row.ItemArray[0] + "');";
                        WorkSQL.ExecuteSQL();

                        dataGridView4.DataContext = await Task.Run(() => ShowPaymentFor());
                        //dataGridView4.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 4:
                        WorkSQL.drv_p = (DataRowView)dataGridView5.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");

                        WorkSQL.sql_p = "select * from select_employee_by_education_code('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                        temp = WorkSQL.ConvertQueryToComboBox();
                        if (temp.Count != 0)
                        {
                            log_prog.Visibility = Visibility.Hidden;
                            var result = MessageBox.Show("Таблица сотрудники содержит информацию об удаляемом типе образования. Вы точно хотите удалить этот тип образования?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                            log_prog.Visibility = Visibility.Visible;
                        }

                        WorkSQL.sql_p = "select delete_education('" + WorkSQL.drv_p.Row.ItemArray[0] + "');";
                        WorkSQL.ExecuteSQL();

                        dataGridView5.DataContext = await Task.Run(() => ShowEducation());
                        //dataGridView5.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 5:
                        WorkSQL.drv_p = (DataRowView)dataGridView6.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");

                        WorkSQL.sql_p = "select * from select_department_by_type_code('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                        temp = WorkSQL.ConvertQueryToComboBox();
                        if (temp.Count != 0)
                        {
                            log_prog.Visibility = Visibility.Hidden;
                            var result = MessageBox.Show("Таблица отделения содержит информацию об удаляемом типе. Вы точно хотите удалить этот тип?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                            log_prog.Visibility = Visibility.Visible;
                        }

                        WorkSQL.sql_p = "select delete_type('" + WorkSQL.drv_p.Row.ItemArray[0] + "');";
                        WorkSQL.ExecuteSQL();

                        dataGridView6.DataContext = await Task.Run(() => ShowType());
                        //dataGridView6.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 6:
                        WorkSQL.drv_p = (DataRowView)dataGridView7.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");

                        WorkSQL.sql_p = "select * from select_department_by_title_code('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                        temp = WorkSQL.ConvertQueryToComboBox();
                        if (temp.Count != 0)
                        {
                            log_prog.Visibility = Visibility.Hidden;
                            var result = MessageBox.Show("Таблица отделения содержит информацию об удаляемом типе заголовка. Вы точно хотите удалить этот тип заголовка?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                            log_prog.Visibility = Visibility.Visible;
                        }

                        WorkSQL.sql_p = "select delete_title('" + WorkSQL.drv_p.Row.ItemArray[0] + "');";
                        WorkSQL.ExecuteSQL();

                        dataGridView7.DataContext = await Task.Run(() => ShowTitle());
                        //dataGridView7.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 7:
                        WorkSQL.drv_p = (DataRowView)dataGridView8.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");

                        WorkSQL.sql_p = "select * from select_payment_by_kind_code('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                        temp = WorkSQL.ConvertQueryToComboBox();
                        if (temp.Count != 0)
                        {
                            log_prog.Visibility = Visibility.Hidden;
                            var result = MessageBox.Show("Таблица платежи содержит информацию об удаляемой виде. Вы точно хотите удалить этот вид?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                            log_prog.Visibility = Visibility.Visible;
                        }

                        WorkSQL.sql_p = "select delete_kind('" + WorkSQL.drv_p.Row.ItemArray[0] + "');";
                        WorkSQL.ExecuteSQL();

                        dataGridView8.DataContext = await Task.Run(() => ShowKind());
                        //dataGridView8.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 8:
                        WorkSQL.drv_p = (DataRowView)dataGridView9.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");

                        WorkSQL.sql_p = "select * from select_company_by_owner_ship_code('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                        temp = WorkSQL.ConvertQueryToComboBox();
                        if (temp.Count != 0)
                        {
                            log_prog.Visibility = Visibility.Hidden;
                            var result = MessageBox.Show("Таблица предприятия содержит информацию об удаляемой виде владельца. Вы точно хотите удалить этот вид владельца?", "Удаление", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No) throw new Exception("Отмена удаления!");
                            log_prog.Visibility = Visibility.Visible;
                        }

                        WorkSQL.sql_p = "select delete_owner_ship('" + WorkSQL.drv_p.Row.ItemArray[0] + "');";
                        WorkSQL.ExecuteSQL();

                        dataGridView9.DataContext = await Task.Run(() => ShowOwnerShip());
                        //dataGridView9.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                    case 9:
                        WorkSQL.drv_p = (DataRowView)dataGridView10.SelectedItem;
                        if (WorkSQL.drv_p == null) throw new Exception("Ничего не выбрано!");

                        WorkSQL.sql_p = "select delete_cross('" + WorkSQL.drv_p.Row.ItemArray[0] + "');";
                        WorkSQL.ExecuteSQL();

                        dataGridView10.DataContext = await Task.Run(() => ShowCross());
                        //dataGridView10.Columns[0].Visibility = Visibility.Collapsed;
                        break;
                }
                controll_true();
            }
            catch (Exception ex)
            {
                controll_true();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public void PaymentGenerator()
        {
            Random rnd = new Random();
            //формируем данные
            WorkSQL.sql_p = "select Номер from show_kind";
            List<string> kind_code = WorkSQL.ConvertQueryToComboBox();

            List<DateTime> payment_date = new List<DateTime>();
            for (int i = 0; i < 10; i++)
            {
                int day = rnd.Next(1, 28);
                int month = rnd.Next(1, 12);
                int year = rnd.Next(1900, 2019);
                DateTime dt = new DateTime(year, month, day);
                payment_date.Add(dt);
            }

            List<string> amount = new List<string>();
            for (int j = 0; j < 10; j++)
            {
                int salary = rnd.Next(1000, 5000);
                amount.Add(salary.ToString());
            }

            WorkSQL.sql_p = "select Номер from show_employee";
            List<string> employee_code = WorkSQL.ConvertQueryToComboBox();

            WorkSQL.sql_p = "select Номер from show_department";
            List<string> department_code = WorkSQL.ConvertQueryToComboBox();

            WorkSQL.sql_p = "select Номер from show_company";
            List<string> company_code = WorkSQL.ConvertQueryToComboBox();

            //понеслась
            for (int k = 0; k < 10000; k++)
            {
                string kd = kind_code.ElementAt(rnd.Next(0, kind_code.Count));

                DateTime pd = payment_date.ElementAt(rnd.Next(0, payment_date.Count));

                string at = amount.ElementAt(rnd.Next(0, amount.Count));

                string ec = employee_code.ElementAt(rnd.Next(0, employee_code.Count));

                string dc = department_code.ElementAt(rnd.Next(0, department_code.Count));

                string cc = company_code.ElementAt(rnd.Next(0, company_code.Count));

                WorkSQL.sql_p = "INSERT INTO payment (kind_code,payment_date,amount,employee_code,department_code,company_code) " +
                    "VALUES ('" + kd + "','" + pd.ToString("dd-MM-yyyy") + "','" + at + "','" + ec + "','" + dc + "','" + cc + "');";
                WorkSQL.ExecuteSQL();
            }
        }
        private async void MIGen_Click(object sender, RoutedEventArgs e)
        {
            var firstresult = MessageBox.Show("Вы точно хотите сгенерировать записи?", "Генерация", MessageBoxButton.YesNo);
            if (firstresult == MessageBoxResult.No) { return; }
            controll_false();
            await Task.Run(() => PaymentGenerator());
            controll_true();
            MessageBox.Show("Генерация завершена!");
        }
        private async void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                controll_false();

                if (TabDepartament.IsSelected)
                {
                    txt_look_for.Visibility = Visibility.Visible;
                    dataGridView1.DataContext = await Task.Run(() => ShowDepartment());
                }

                if (TabEmployee.IsSelected)
                {
                    txt_look_for.Visibility = Visibility.Visible;
                    dataGridView2.DataContext = await Task.Run(() => ShowEmployee());
                    //dataGridView2.Columns[0].Visibility = Visibility.Collapsed;
                }

                if (TabCompany.IsSelected)
                {
                    txt_look_for.Visibility = Visibility.Visible;
                    dataGridView3.DataContext = await Task.Run(() => ShowCompany());
                    //dataGridView3.Columns[0].Visibility = Visibility.Collapsed;
                }

                if (TabPayment.IsSelected)
                {
                    switch (WorkSQL.role_p)
                    {
                        case "Tax_Admin":
                            break;
                        case "Tax_Employee":
                            dataGridView4.DataContext = await Task.Run(() => ShowPaymentFor());
                            break;
                        case "Tax_SuperVisor":
                            dataGridView4.DataContext = await Task.Run(() => ShowPayment());
                            break;
                    }
                    txt_look_for.Visibility = Visibility.Visible;
                }

                if (TabEducation.IsSelected)
                {
                    txt_look_for.Visibility = Visibility.Hidden;
                    dataGridView5.DataContext = await Task.Run(() => ShowEducation());
                    //dataGridView5.Columns[0].Visibility = Visibility.Collapsed;
                }

                if (TabType.IsSelected)
                {
                    txt_look_for.Visibility = Visibility.Hidden;
                    dataGridView6.DataContext = await Task.Run(() => ShowType());
                    //dataGridView6.Columns[0].Visibility = Visibility.Collapsed;
                }

                if (TabTitle.IsSelected)
                {
                    txt_look_for.Visibility = Visibility.Hidden;
                    dataGridView7.DataContext = await Task.Run(() => ShowTitle());
                    //dataGridView7.Columns[0].Visibility = Visibility.Collapsed;
                }

                if (TabKind.IsSelected)
                {
                    txt_look_for.Visibility = Visibility.Hidden;
                    dataGridView8.DataContext = await Task.Run(() => ShowKind());
                    //dataGridView8.Columns[0].Visibility = Visibility.Collapsed;
                }

                if (TabOwnerShip.IsSelected)
                {
                    txt_look_for.Visibility = Visibility.Hidden;
                    dataGridView9.DataContext = await Task.Run(() => ShowOwnerShip());
                    //dataGridView9.Columns[0].Visibility = Visibility.Collapsed;
                }

                if (TabCross.IsSelected)
                {
                    txt_look_for.Visibility = Visibility.Visible;
                    dataGridView10.DataContext = await Task.Run(() => ShowCross());
                    //dataGridView10.Columns[0].Visibility = Visibility.Collapsed;
                }

                txt_look_for.Text = "";
                controll_true();
                if (WorkSQL.role_p == "Tax_SuperVisor")
                {
                    btn_add.IsEnabled = false;
                    btn_delete.IsEnabled = false;
                    btn_update.IsEnabled = false;
                }
            }
        }

        public void controll_true()
        {
            log_prog.Visibility = Visibility.Hidden;
            btn_add.IsEnabled = true;
            btn_delete.IsEnabled = true;
            btn_update.IsEnabled = true;
            mainTabControl.IsEnabled = true;
            AllMenu.IsEnabled = true;
            dataGridView1.IsEnabled = true;
            dataGridView2.IsEnabled = true;
            dataGridView3.IsEnabled = true;
            dataGridView4.IsEnabled = true;
            dataGridView5.IsEnabled = true;
            dataGridView6.IsEnabled = true;
            dataGridView7.IsEnabled = true;
            dataGridView8.IsEnabled = true;
            dataGridView9.IsEnabled = true;
            dataGridView10.IsEnabled = true;
            txt_look_for.IsEnabled = true;
        }

        public void controll_false()
        {
            log_prog.Visibility = Visibility.Visible;
            btn_add.IsEnabled = false;
            btn_delete.IsEnabled = false;
            btn_update.IsEnabled = false;
            mainTabControl.IsEnabled = false;
            AllMenu.IsEnabled = false;
            dataGridView1.IsEnabled = false;
            dataGridView2.IsEnabled = false;
            dataGridView3.IsEnabled = false;
            dataGridView4.IsEnabled = false;
            dataGridView5.IsEnabled = false;
            dataGridView6.IsEnabled = false;
            dataGridView7.IsEnabled = false;
            dataGridView8.IsEnabled = false;
            dataGridView9.IsEnabled = false;
            dataGridView10.IsEnabled = false;
            txt_look_for.IsEnabled = false;
        }

        #region QUARY

        ///////
        //симметричное внутреннее соединение с условием (выводит отделения и работника,который работает в нём)
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //////
            //симметричное внутреннее соединение с условием (выводит все платежи выбранного сотрудника)
            try
            {
                WorkSQL.drv_p = (DataRowView)dataGridView2.SelectedItem;
                if (WorkSQL.drv_p == null) throw new Exception("Вы не выбрали сотрудника!");

                WorkSQL.sql_p = "select * from in_join_1('" + WorkSQL.drv_p.Row.ItemArray[0] + "')";
                //WorkSQL.sql_p = "select * from show_payment";
                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            /////////////
            //симметричное внутреннее соединение с условием (выводит все платежи выбранного сотрудника, 
            //которые он совершил в заданном промежутке времени)
            try
            {
                WorkSQL.drv_p = (DataRowView)dataGridView2.SelectedItem;
                if (WorkSQL.drv_p == null) throw new Exception("Вы не выбрали сотрудника!");

                BetweenDate bd = new BetweenDate();
                bd.ShowDialog();

                WorkSQL.sql_p = "select * from in_join_2('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + WorkSQL.first_date_p + "','" + WorkSQL.second_date_p + "')";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            ///////////////
            //симметричное внутреннее соединение с условием (выводит все платежи выбранного отделения, 
            //которые были совершены в заданном промежутке времени)
            try
            {
                WorkSQL.drv_p = (DataRowView)dataGridView1.SelectedItem;
                if (WorkSQL.drv_p == null) throw new Exception("Вы не выбрали отделение!");

                BetweenDate bd = new BetweenDate();
                bd.ShowDialog();

                WorkSQL.sql_p = "select * from in_join_3('" + WorkSQL.drv_p.Row.ItemArray[0] + "','" + WorkSQL.first_date_p + "','" + WorkSQL.second_date_p + "')";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            ////////////////////
            //симметричное внутреннее соединение без условия (выводит ФИО работников и их место работы)
            try
            {
                WorkSQL.sql_p = "select * from in_join_with_out_1()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            ////////////////////////////
            //симметричное внутреннее соединение без условия (номера и названия предприятий и их тип собственности)
            try
            {
                WorkSQL.sql_p = "select * from in_join_with_out_2()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            //////////////////
            //симметричное внутреннее соединение без условия (выводит номер и наименование отдела)
            try
            {
                WorkSQL.sql_p = "select * from in_join_with_out_3()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            /////////////////
            //левое внешнее соединение(выводит номер и фио всех работников и их места работы)
            try
            {
                WorkSQL.sql_p = "select * from out_left_join_1()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            /////////////
            //правое внешнее соединение(выводит номер и образование и фио всех работников)
            try
            {
                WorkSQL.sql_p = "select * from out_right_join_1()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //????????????????????запрос на запросе по принципу левого соединения(это вывод доступных предприятий для сотрудника, когда он пытается добавить платеж)

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            /////////////////////////////
            //итоговый запрос без условия(выводит номер сотрудника и количество оформленных платежей)
            try
            {
                WorkSQL.sql_p = "select * from final_with_out_1()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            //////////////////
            //итоговый запрос без условия с итоговыми данными вида всего, в том числе(Всего платежей, в том числе акциз)
            try
            {
                WorkSQL.sql_p = "select * from final_in_that()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            ////////////////////////////
            //итоговый запрос с условием на данные(по значению)(выводит сотрудника и количество оформленных платежей c суммой>4000)
            try
            {
                WorkSQL.sql_p = "select * from final_with_data_1()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //////По маске происходит поиск

        //////с использованием индекса таблица payment 

        //////без использования индекса все остальные таблицы

        //////////////с условием на группы ниже
        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            /////////////////////////
            //итоговый запрос с условием на группы и на данные(выводит номер сотрудника количество 
            //оформленных платежей и среднюю сумму больше 3000)
            try
            {
                WorkSQL.sql_p = "select * from final_with_group_1()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MIQuary_final_on_select_Click(object sender, RoutedEventArgs e)
        {
            ///////////////
            ////запрос на запросе по принципу итогового запрос(самый старый сотрудник)
            try
            {
                WorkSQL.sql_p = "select * from final_on_select()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MIQuary_final_with_union_Click(object sender, RoutedEventArgs e)
        {
            /////////////////
            ////запрос с использованием обьединения(два предприятия и их средний платёж)
            try
            {
                WorkSQL.sql_p = "select * from final_with_union()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MIQuary_quary_with_in_Click(object sender, RoutedEventArgs e)
        {
            ////////////////////
            ////запрос с подзапросами с исп in (два типа платежей и сумма)
            try
            {
                WorkSQL.sql_p = "select * from quary_with_in()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MIQuary_quary_with_not_in_Click(object sender, RoutedEventArgs e)
        {
            ///////////////////////
            ////запрос с подзапросами с исп not in (оставшиеся типы платежей и сумма)
            try
            {
                WorkSQL.sql_p = "select * from quary_with_not_in()";

                ResultQuary rq = new ResultQuary(true);
                rq.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //////запрос с подзапросами с исп case(используется для обозначения штата в left outer join)

        //////запрос с подзапросами операциями над итоговыми данными(учавствует having в запросе по группам)

        #endregion

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            AddUsers au = new AddUsers(true, false);
            au.ShowDialog();
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            DeleteUsers du = new DeleteUsers();
            du.ShowDialog();
        }
        DataView LookForDepartment(string txt)
        {
            WorkSQL.sql_p = "select * from look_for_department('" + txt + "')";

            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
        }

        DataView LookForEmployee(string txt)
        {
            WorkSQL.sql_p = "select * from look_for_employee('" + txt + "')";

            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
        }

        DataView LookForCompany(string txt)
        {
            WorkSQL.sql_p = "select * from look_for_company('" + txt + "')";

            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
        }

        DataView LookForPayment(string txt)
        {
            WorkSQL.sql_p = "select * from look_for_payment('" + txt + "')";

            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
        }

        DataView LookForPaymentFor(string txt)
        {
            WorkSQL.sql_p = "select * from look_for_payment_for('" + txt + "','" + WorkSQL.login_p + "')";

            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
        }

        DataView LookForCross(string txt)
        {
            WorkSQL.sql_p = "select * from look_for_cross('" + txt + "')";

            var temp = WorkSQL.ConvertQueryToTable().DefaultView;
            return temp;
        }


        private async void Txt_look_for_TextChanged(object sender, TextChangedEventArgs e)
        {
            controll_false();

            string look_for = txt_look_for.Text.ToLower();

            if (TabDepartament.IsSelected)
            {
                dataGridView1.DataContext = await Task.Run(() => LookForDepartment(look_for));
            }

            if (TabEmployee.IsSelected)
            {
                dataGridView2.DataContext = await Task.Run(() => LookForEmployee(look_for));
                //dataGridView2.Columns[0].Visibility = Visibility.Collapsed;
            }

            if (TabCompany.IsSelected)
            {
                txt_look_for.Visibility = Visibility.Visible;
                dataGridView3.DataContext = await Task.Run(() => LookForCompany(look_for));
                //dataGridView3.Columns[0].Visibility = Visibility.Collapsed;
            }

            if (TabPayment.IsSelected)
            {
                txt_look_for.Visibility = Visibility.Visible;
                switch (WorkSQL.role_p)
                {
                    case "Tax_Admin":
                        break;
                    case "Tax_Employee":
                        dataGridView4.DataContext = await Task.Run(() => LookForPaymentFor(look_for));
                        break;
                    case "Tax_SuperVisor":
                        dataGridView4.DataContext = await Task.Run(() => LookForPayment(look_for));
                        break;
                }
                //dataGridView4.Columns[0].Visibility = Visibility.Collapsed;
            }

            if (TabCross.IsSelected)
            {
                txt_look_for.Visibility = Visibility.Visible;
                dataGridView10.DataContext = await Task.Run(() => LookForCross(look_for));
                //dataGridView10.Columns[0].Visibility = Visibility.Collapsed;
            }

            controll_true();
            TabIndex = 4;
            txt_look_for.Focus();
        }

        #region hide 0 columns
        private void DataGridView2_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            dataGridView2.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void DataGridView3_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            dataGridView3.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void DataGridView4_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            dataGridView4.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void DataGridView5_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            dataGridView5.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void DataGridView6_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            dataGridView6.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void DataGridView7_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            dataGridView7.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void DataGridView8_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            dataGridView8.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void DataGridView9_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            dataGridView9.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void DataGridView10_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            dataGridView10.Columns[0].Visibility = Visibility.Collapsed;
        }
        #endregion

        private void MIExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
                folderDialog.ShowNewFolderButton = false;
                folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
                WinForms.DialogResult result = folderDialog.ShowDialog();

                if (result == WinForms.DialogResult.OK)
                {
                    WorkSQL.sql_p = "select export_excel('" + folderDialog.SelectedPath + "\\tax_export.csv" + "')";
                    WorkSQL.ExecuteSQL();
                    MessageBox.Show("Экспорт завершился!");
                }
                //WorkSQL.drv_p = (DataRowView)dataGridView2.SelectedItem;
                //if (WorkSQL.drv_p == null) throw new Exception("Вы не выбрали сотрудника!");


                //WorkSQL.sql_p = "select * from show_payment";
                //ResultQuary rq = new ResultQuary();
                //rq.ShowDialog(); select export_excel('D:/tax_export.csv')
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MIDiagramm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WorkSQL.sql_p = "select * from final_with_out_1()";

                ResultQuary rq = new ResultQuary(false);
                rq.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}