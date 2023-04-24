using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LedBadgeProject.Models
{
    internal class Connection
    {
        internal bool ConnectToLedBadge(string? macAddress)
        {
            return true;
        }

        /// <summary>
        /// Si l'utilisateur n'a pas renseigné d'adresse mac, on prend celle par défaut qui correspond à notre Led badge
        /// </summary>
        /// <param name="userMacAddress"></param>
        /// <returns></returns>
        internal string GetMacAddress(string userMacAddress)
        {
            if (string.IsNullOrEmpty(userMacAddress) || userMacAddress == "Right the mac adress")
            {
                userMacAddress = "38:3B:26:EE:35:10";
            }
            return userMacAddress;
        }
    }
}
