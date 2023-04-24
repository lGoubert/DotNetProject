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

namespace LedBadgeProject.Main
{
    /// <summary>
    /// Logique d'interaction pour MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        internal MainModel Model { get; set; }
        public MainPage(string macAddress)
        {
            InitializeComponent();
            Model = new MainModel(macAddress);
            DataContext = Model;
        }

        private void OnItemClicked(object sender, SelectionChangedEventArgs e)
        {
            Model.messageToSend = (sender as ListBox).SelectedItem.ToString();
        }

        private void OnSendClicked(object sender, RoutedEventArgs e)
        {
            SendMessageToModel();
            MessageToSendEntry.Focus();
        }

        private void EntryTapped(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SendMessageToModel();
            }
        }

        private void SendMessageToModel()
        {
            if (!string.IsNullOrEmpty(Model.messageToSend))
            {
                if (Model.SendMessage())
                {
                    MessageBox.Show("Message sended");
                    Model.ClearMessageToSend();
                }
                else
                {
                    MessageBox.Show("An error occured");
                }
            }
            else
            {
                MessageBox.Show("Message to send is empty. Please write a message");
            }
        }

        private void OnClearClicked(object sender, RoutedEventArgs e)
        {
            Model.ClearMessageToSend();
        }

        private void DoubleClicked(object sender, MouseButtonEventArgs e)
        {
            SendMessageToModel();
        }

        private void DisconnectClicked(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
