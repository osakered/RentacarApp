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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        Core db = new Core();
        int idClients = 0;
        public ClientsPage()
        {
            InitializeComponent();

            DataGridClients.ItemsSource = db.context.Clients.ToList(); // Обновление DataGrid
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridClients.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены что хотите удалить клиента?",
                    "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var selectedClients = ((Clients)DataGridClients.SelectedItem).IDClients; //Получение ID выбранного в DataGrid клиента
                        idClients = selectedClients;
                        ClientsVM clientsVM = new ClientsVM(); //подключение класса
                        clientsVM.DeleteClient(idClients); // вызов метода в классе
                        MessageBox.Show("Данные о клиенте удалены");
                    }
                    catch
                    {
                        throw new Exception("Ошибка при удалении данных");
                    }
                    DataGridClients.ItemsSource = db.context.Clients.ToList(); // Обновление DataGrid
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientsVM clientsVM = new ClientsVM(); //подключение класса
                bool checker = clientsVM.CheckAddClients(AddressTextBox.Text, PassportDataTextBox.Text, FullNameTextBox.Text, DLicenseNumberTextBox.Text); // проверка заполнения полей
                if (checker)
                {
                    clientsVM.AddClients(AddressTextBox.Text, PassportDataTextBox.Text, FullNameTextBox.Text, DLicenseNumberTextBox.Text);
                    MessageBox.Show("Данные о клиенте внесены");
                    DataGridClients.ItemsSource = db.context.Clients.ToList(); //Добавляет данные о клиентах и обновляет DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
