using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RentacarApp.Models;

namespace RentacarApp.View
{
    /// <summary>
    /// Логика взаимодействия для LogsPage.xaml
    /// </summary>
    public partial class LogsPage : Page
    {
        Core db = new Core();
        public LogsPage()
        {
            InitializeComponent();

            DataGridLogs.ItemsSource = db.context.Logs.ToList();
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
            var filepath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Logs.csv");

            using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
            {
                sw.WriteLine("ID лога;Пользователь;Дата лога;Действие;Таблица");

                foreach (var item in DataGridLogs.Items)
                {
                    var row = (Logs)item;

                    sw.WriteLine($"{row.LogID};{row.Users.Username};{row.LogTime};{row.Actions.ActionType};{row.TableName}");
                }
                MessageBox.Show("Данные успешно сохранены на рабочем столе, возвращение на главную страницу.");
                this.NavigationService.GoBack();
            }
        }
    }
}
