using RentacarApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RentacarApp.View
{
    /// <summary>
    /// Логика взаимодействия для ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        Core db = new Core();
        public ReportsPage()
        {
            InitializeComponent();

            DataGridReports.ItemsSource = db.context.Cars.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("До этого не было открыто ни одной страницы");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var filepath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Report.csv");

            using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
            {
                sw.WriteLine("Модель;Год выпуска;Цвет;Госномер;Статус");

                foreach (var item in DataGridReports.Items)
                {
                    var row = (Cars)item;

                    sw.WriteLine($"{row.CarModel};{row.CarProdYear};{row.CarColor};{row.RegNumber};{row.Availability.AvailabilityState}");
                }
                MessageBox.Show("Данные успешно сохранены на рабочем столе, возвращение на главную страницу.");
                this.NavigationService.GoBack();
            }
        }
    }
}
