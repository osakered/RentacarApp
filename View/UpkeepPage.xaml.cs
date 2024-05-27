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

            DataGridUpkeep.ItemsSource = db.context.Upkeep.ToList(); 
            CarsComboBox.ItemsSource = db.context.Cars.ToList(); 
            BeginUpkeepDatePicker.Text = DateTime.Now.Date.ToString(); 
            EndUpkeepDatePicker.Text = DateTime.Now.Date.AddDays(+1).ToString(); 
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpkeepVM upkeepVM = new UpkeepVM();
                bool checker = upkeepVM.CheckUpkeep(CarsComboBox.SelectedValue, PriceTextBox.Text, Convert.ToDateTime(BeginUpkeepDatePicker.SelectedDate), Convert.ToDateTime(EndUpkeepDatePicker.SelectedDate)); 
                if (checker)
                {
                    upkeepVM.AddUpkeep((int)CarsComboBox.SelectedValue, Convert.ToDateTime(BeginUpkeepDatePicker.SelectedDate), Convert.ToDateTime(EndUpkeepDatePicker.SelectedDate), PriceTextBox.Text);
                    MessageBox.Show("Данные об обслуживании внесены");
                    DataGridUpkeep.ItemsSource = db.context.Upkeep.ToList(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                        var selectedUpkeep = ((Upkeep)DataGridUpkeep.SelectedItem).IDUpkeep; 
                        idUpkeep = selectedUpkeep;
                        UpkeepVM upkeepVM = new UpkeepVM(); 
                        upkeepVM.DeleteUpkeep(idUpkeep); 
                        MessageBox.Show("Данные об обслуживании удалены");
                    }
                    catch
                    {
                        throw new Exception("Ошибка при удалении данных");
                    }
                    DataGridUpkeep.ItemsSource = db.context.Upkeep.ToList();
                }
            }
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

        private void DataGridUpkeep_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var EditRow = e.Row.Item as Upkeep;
                db.context.Entry(EditRow).State = EntityState.Modified;
                db.context.SaveChanges();

                Logs addLogs = new Logs()
                {
                    IDUsers = Properties.Settings.Default.idUser,
                    LogTime = DateTime.Now,
                    ActionID = 2,
                    TableName = "Обслуживание"
                };
                db.context.Logs.Add(addLogs);
            }
        }
    }
}
