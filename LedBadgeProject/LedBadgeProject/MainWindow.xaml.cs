using LedBadgeProject.Main;
using LedBadgeProject.Models;
using System.Windows;

namespace LedBadgeProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnConnectionButtonClicked(object sender, RoutedEventArgs e)
        {
            Connection connection = new Connection();
            string macAddress = connection.GetMacAddress(MacEntry.Text);
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
            if (MacEntry.Text == "Right the mac adress")
            {
                MacEntry.Text = "";
            }
        }
    }
}
