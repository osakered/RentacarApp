﻿using RentacarApp.Models;
using RentacarApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace RentacarApp.View
{
    /// <summary>
    /// Логика взаимодействия для CarsPage.xaml
    /// </summary>
    public partial class CarsPage : Page
    {
        Core db = new Core();
        int idCar = 0;
        public CarsPage()
        {
            InitializeComponent();
            
            AvailabilityComboBox.ItemsSource = db.context.Availability.ToList();
            AvailabilityComboBox.DisplayMemberPath = "AvailabilityState"; 
            AvailabilityComboBox.SelectedValuePath = "IDAvailability"; 
            CarProdYearDatePicker.Text = DateTime.Now.Date.ToString(); 
            DataGridCars.ItemsSource = db.context.Cars.ToList(); 
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCars.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выбранный автомобиль?",
                    "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var selectedCars = ((Cars)DataGridCars.SelectedItem).IDCars;
                        idCar = selectedCars;
                        CarsVM carsVM = new CarsVM(); 
                        carsVM.DeleteCar(idCar); 
                        MessageBox.Show("Автомобиль удален");
                        DataGridCars.ItemsSource = db.context.Cars.ToList(); 
                    }
                    catch 
                    {
                        throw new Exception("Ошибка при удалении авто");
                    }
                }
            }
            else
            {
                MessageBox.Show("Автомобиль для удаления не выбран");
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CarsVM CarVM = new CarsVM();
                bool checker = CarVM.CheckCar(ModelTextBox.Text, ColorTextBox.Text, RegNumberTextBox.Text, AvailabilityComboBox.SelectedValue);
                if (checker)
                {
                    CarVM.AddCar(ModelTextBox.Text, Convert.ToDateTime(CarProdYearDatePicker.SelectedDate), ColorTextBox.Text, RegNumberTextBox.Text, (int)AvailabilityComboBox.SelectedValue);
                    MessageBox.Show("Автомобиль добавлен");
                    DataGridCars.ItemsSource = db.context.Cars.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }
        private void DataGridCars_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var EditRow = e.Row.Item as Cars;
                db.context.Entry(EditRow).State = EntityState.Modified;
                db.context.SaveChanges();
            }
        }
    }
}
