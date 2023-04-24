using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LedBadgeProject.Models
{
    internal class Connection : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion

        #region Variables
        private string _macAddress;
        public string macAddress
        {
            get { return _macAddress; }
            set
            {
                _macAddress = value;
                NotifyPropertyChanged("macAddress");
            }
        }
        #endregion

        public Connection()
        {
            macAddress = "Right the mac adress";
        }

        #region Methods
        /// <summary>
        /// Connecte l'app au led badge
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns></returns>
        internal bool ConnectToLedBadge(string? macAddress)
        {
            if (!IsMACAddressValid())
            {
                return false;
            }
            try
            {
                // Connexion au LED Badge

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Si l'utilisateur n'a pas renseigné d'adresse mac, on prend celle par défaut qui correspond à notre Led badge
        /// </summary>
        /// <param name="userMacAddress"></param>
        /// <returns></returns>
        internal string GetMacAddress()
        {
            if (string.IsNullOrEmpty(macAddress) || macAddress == "Right the mac adress")
            {
                macAddress = "38:3B:26:EE:35:10";
            }
            return macAddress;
        }

        /// <summary>
        /// Met `macAddress` à vide
        /// </summary>
        internal void ClearMacAddress()
        {
            macAddress = string.Empty;
        }

        /// <summary>
        /// Vérifie que `macAddress` une adresse mac
        /// </summary>
        /// <returns></returns>
        internal bool IsMACAddressValid()
        {
            Regex regex = new Regex(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$");
            return regex.IsMatch(macAddress);
        }
        #endregion
    }
}
