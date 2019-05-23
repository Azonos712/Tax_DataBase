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
    /// Логика взаимодействия для BetweenDate.xaml
    /// </summary>
    public partial class BetweenDate : Window
    {
        public BetweenDate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((DateTime)dp_date1.SelectedDate > (DateTime)dp_date2.SelectedDate)
                {
                    throw new Exception("Дата после не может превышать дату до!");
                }
                WorkSQL.first_date_p = ((DateTime)dp_date1.SelectedDate).ToString("dd-MM-yyyy");
                WorkSQL.second_date_p = ((DateTime)dp_date2.SelectedDate).ToString("dd-MM-yyyy");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
