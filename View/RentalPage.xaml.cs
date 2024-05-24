using RentacarApp.Models;
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
    /// Логика взаимодействия для RentalPage.xaml
    /// </summary>
    public partial class RentalPage : Page
    {
        Core db = new Core();
        int idRent = 0;
        public RentalPage()
        {
            InitializeComponent();

            DataGridRent.ItemsSource = db.context.Rental.ToList(); //Обновление DataGrid
            ClientsComboBox.ItemsSource = db.context.Clients.ToList();
            CarsComboBox.ItemsSource = db.context.Cars.ToList(); // Подключение ComboBox'ов к БД
            DateStartPicker.Text = DateTime.Now.Date.ToString(); // Выставляет сегодняшнюю дату в DatePicker
            DateEndPicker.Text = DateTime.Now.Date.AddDays(+1).ToString(); // Выставляет завтрашнюю дату в DatePicker
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RentalVM RentVM = new RentalVM(); //подключение класса
                bool checker = RentVM.CheckRental(ClientsComboBox.SelectedValue, CarsComboBox.SelectedValue, CostTextBox.Text); // проверка заполнения полей
                if (checker)
                {
                    RentVM.AddRental((int)ClientsComboBox.SelectedValue, (int)CarsComboBox.SelectedValue, CostTextBox.Text, Convert.ToDateTime(DateStartPicker.SelectedDate), Convert.ToDateTime(DateEndPicker.SelectedDate));
                    MessageBox.Show("Данные об аренде внесены");
                    DataGridRent.ItemsSource = db.context.Rental.ToList(); //Добавляет данные об аренде и обновляет DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridRent.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выбранную аренду?",
                    "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var selectedRents = ((Rental)DataGridRent.SelectedItem).IDRent; //Получение ID выбранной в DataGrid аренды
                        idRent = selectedRents;
                        RentalVM rentVM = new RentalVM(); //подключение класса
                        rentVM.DeleteRent(idRent); // вызов метода в классе
                        MessageBox.Show("Данные об аренде удалены");
                    }
                    catch
                    {
                        throw new Exception("Ошибка при удалении данных аренды");
                    }
                    DataGridRent.ItemsSource = db.context.Rental.ToList(); // Обновление DataGrid
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack(); // Возврат на прошлую страницу
            }
            else
            {
                MessageBox.Show("До этого не было открыто ни одной страницы");
            }
        }

        private void DataGridRent_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var EditRow = e.Row.Item as Rental;
                db.context.Entry(EditRow).State = EntityState.Modified;
                db.context.SaveChanges();
            }
        }

        //private void EditButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DataGridRent.SelectedItem != null)
        //    {
        //        try
        //        {
        //            var selectedRents = ((Rental)DataGridRent.SelectedItem).IDRent;
        //            idRent = selectedRents;
        //            RentalVM RentVM = new RentalVM(); //подключение класса
        //            bool checker = RentVM.CheckRental(ClientsComboBox.SelectedValue, CarsComboBox.SelectedValue, CostTextBox.Text); // проверка заполнения полей
        //            if (checker)
        //            {
        //                RentVM.EditRent(idRent, (int)ClientsComboBox.SelectedValue, (int)CarsComboBox.SelectedValue, CostTextBox.Text, Convert.ToDateTime(DateStartPicker.SelectedDate), Convert.ToDateTime(DateEndPicker.SelectedDate));
        //                MessageBox.Show("Данные об аренде отредактированы");
        //                DataGridRent.ItemsSource = db.context.Rental.ToList(); //Обновление DataGrid
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Аренда для редактирования не выбран");
        //    }
        //}
    }
}
