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

            DataGridClients.ItemsSource = db.context.Clients.ToList(); 
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
            if (DataGridClients.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены что хотите удалить клиента?",
                    "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var selectedClients = ((Clients)DataGridClients.SelectedItem).IDClients;
                        idClients = selectedClients;
                        ClientsVM clientsVM = new ClientsVM();
                        clientsVM.DeleteClient(idClients);
                        MessageBox.Show("Данные о клиенте удалены");
                    }
                    catch
                    {
                        throw new Exception("Ошибка при удалении данных");
                    }
                    DataGridClients.ItemsSource = db.context.Clients.ToList(); 
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientsVM clientsVM = new ClientsVM(); 
                bool checker = clientsVM.CheckClients(AddressTextBox.Text, PassportDataTextBox.Text, FullNameTextBox.Text, DLicenseNumberTextBox.Text, PhoneNumberTextBox.Text);
                if (checker)
                {
                    clientsVM.AddClients(AddressTextBox.Text, PassportDataTextBox.Text, FullNameTextBox.Text, DLicenseNumberTextBox.Text, PhoneNumberTextBox.Text);
                    MessageBox.Show("Данные о клиенте внесены");
                    DataGridClients.ItemsSource = db.context.Clients.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataDridClients_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var EditRow = e.Row.Item as Clients;
                db.context.Entry(EditRow).State = EntityState.Modified;
                db.context.SaveChanges();

                Logs addLogs = new Logs()
                {
                    IDUsers = Properties.Settings.Default.idUser,
                    LogTime = DateTime.Now,
                    ActionID = 2,
                    TableName = "Клиенты"
                };
                db.context.Logs.Add(addLogs);
            }
        }
    }
}
