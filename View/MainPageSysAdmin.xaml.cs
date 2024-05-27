﻿using System;
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
using RentacarApp.Models;
using RentacarApp.Pages;

namespace RentacarApp.View
{
    /// <summary>
    /// Логика взаимодействия для MainPageSysAdmin.xaml
    /// Страница содержит только кнопки для переходов на прочие страницы
    /// </summary>
    public partial class MainPageSysAdmin : Page 
    {
        public MainPageSysAdmin()
        {
            InitializeComponent();
        }

        private void CarsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CarsPage());
        }

        private void RentalButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RentalPage()); 
        }

        private void UpkeepButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UpkeepPage());
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientsPage());
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UsersPage());
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthPage());
        }

        private void ActionJournalButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LogsPage());
        }
    }
}
