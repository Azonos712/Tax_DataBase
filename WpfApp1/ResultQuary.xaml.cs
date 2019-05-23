using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ResultQuary.xaml
    /// </summary>
    public partial class ResultQuary : Window
    {
        bool chart = true;
        public ResultQuary(bool temp)
        {
            InitializeComponent();
            chart = temp;
            diagr.Visibility = Visibility.Hidden;
        }
        private void OnAutoGeneratinngColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }
        }

        //private async void Window_ContentRendered(object sender, EventArgs e)
        //{

        //}

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //log_prog.Visibility = Visibility.Visible;
            if (chart)
            {
                var temp = await Task.Run(() => WorkSQL.ConvertQueryToTable().DefaultView); ;

                ResGrid.DataContext = temp;

                log_prog.Visibility = Visibility.Hidden;

            }
            else
            {
                showChart();
            }
        }

        async void showChart()
        {
            ResGrid.Visibility = Visibility.Hidden;
            diagr.Visibility = Visibility.Visible;

            var temp = await Task.Run(() => WorkSQL.ConvertQueryToTable().DefaultView);
            List<ForChart> r = new List<ForChart>();

            for (int i = 0; i < temp.Count; i++)
            {
                r.Add(new ForChart { Name = temp[i].Row.ItemArray[0].ToString() + "-" + temp[i].Row.ItemArray[2].ToString(), Share = Convert.ToInt32(temp[i].Row.ItemArray[4]) });
            }
            diagr.DataContext = r;

            log_prog.Visibility = Visibility.Hidden;
        }

        class ForChart
        {
            public string Name { get; set; }
            public int Share { get; set; }
        }
    }
}
