using RentacarApp.Pages;
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

namespace RentacarApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthPage());
            ResizeMode = ResizeMode.CanMinimize; 
            this.MinWidth = 750;
            this.MinHeight = 550;
            this.MaxWidth = 750;
            this.MaxHeight = 550;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}
