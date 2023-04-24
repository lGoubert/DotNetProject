using LedBadgeProject.Main;
using LedBadgeProject.Models;
using System.Net.Mail;
using System.Windows;

namespace LedBadgeProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Connection connection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            connection = new Connection();
            DataContext = connection;
        }

        private void OnConnectionButtonClicked(object sender, RoutedEventArgs e)
        {
            string macAddress = connection.GetMacAddress();
            if (connection.ConnectToLedBadge(macAddress))
            {
                MessageBox.Show("Connected to Led Badge");
                this.Content = new MainPage(macAddress);
            }
            else
            {
                MessageBox.Show("An error occured");
            }
        }

        private void RemovePlaceHolder(object sender, RoutedEventArgs e)
        {
            if (connection.macAddress == "Right the mac adress")
            {
                connection.ClearMacAddress();
            }
        }
    }
}
