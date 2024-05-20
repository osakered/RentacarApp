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
    /// Логика взаимодействия для UpkeepPage.xaml
    /// </summary>
    public partial class UpkeepPage : Page
    {
        Core db = new Core();
        int idUpkeep = 0;
        public UpkeepPage()
        {
            InitializeComponent();

            DataGridUpkeep.ItemsSource = db.context.Upkeep.ToList(); // Обновление DataGrid
            CarsComboBox.ItemsSource = db.context.Cars.ToList(); // Подключение ComboBox'ов к БД 
            BeginUpkeepDatePicker.Text = DateTime.Now.Date.ToString(); // Выставляет сегодняшнюю дату в DatePicker
            EndUpkeepDatePicker.Text = DateTime.Now.Date.AddDays(+1).ToString(); // Выставляет завтрашнюю дату в DatePicker
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpkeepVM upkeepVM = new UpkeepVM(); //подключение класса
                bool checker = upkeepVM.CheckAddUpkeep(CarsComboBox.SelectedValue, PriceTextBox.Text); // проверка заполнения полей
                if (checker)
                {
                    upkeepVM.AddUpkeep((int)CarsComboBox.SelectedValue, Convert.ToDateTime(BeginUpkeepDatePicker.SelectedDate), Convert.ToDateTime(EndUpkeepDatePicker.SelectedDate), PriceTextBox.Text);
                    MessageBox.Show("Данные об обслуживании внесены");
                    DataGridUpkeep.ItemsSource = db.context.Upkeep.ToList(); //Добавляет данные об обслуживании и обновляет DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUpkeep.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены что хотите удалить данные об обслуживании?",
                    "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var selectedUpkeep = ((Upkeep)DataGridUpkeep.SelectedItem).IDUpkeep; //Получение ID выбранного в DataGrid обслуживания
                        idUpkeep = selectedUpkeep;
                        UpkeepVM upkeepVM = new UpkeepVM(); //подключение класса
                        upkeepVM.DeleteUpkeep(idUpkeep); // вызов метода в классе
                        MessageBox.Show("Данные об обслуживании удалены");
                    }
                    catch
                    {
                        throw new Exception("Ошибка при удалении данных");
                    }
                    DataGridUpkeep.ItemsSource = db.context.Upkeep.ToList(); // Обновление DataGrid
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
    }
}
