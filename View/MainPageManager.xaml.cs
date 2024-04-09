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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RentacarApp.Pages;

namespace RentacarApp.View
{
    /// <summary>
    /// Логика взаимодействия для MainPageManager.xaml
    /// </summary>
    public partial class MainPageManager : Page // Главная страница Менеджера
    {
        public MainPageManager()
        {
            InitializeComponent();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthPage()); // Выход из "аккаунта"
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientsPage()); // Переход на страницу клиентов
        }

        private void UpkeepButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UpkeepPage()); // Переход на страницу с обслуживанием авто
        }

        private void RentalButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RentalPage()); // Переход на страницу с арендой
        }

        private void CarsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CarsPage()); // Переход на страницу с автомобилями
        }
    }
}
