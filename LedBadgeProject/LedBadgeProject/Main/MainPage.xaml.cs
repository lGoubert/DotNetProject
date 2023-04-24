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
    public partial class MainPage : Page
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
            MessageToSendEntry.Text = (sender as ListBox).SelectedItem.ToString();
        }
    }
}
