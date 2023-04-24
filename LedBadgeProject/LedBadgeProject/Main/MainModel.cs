using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace LedBadgeProject.Main
{
    internal class MainModel : INotifyPropertyChanged
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
        public OleDbConnection conn;

        public string macAdress
        {
            get; set;
        }
        public string macAdressDisplay
        {
            get { return "Connected to " + this.macAdress; }
        }

        private ObservableCollection<string> _oldMessages;
        public ObservableCollection<string> oldMessages
        {
            get { return _oldMessages; }
            set
            {
                _oldMessages = new ObservableCollection<string>(value.Reverse());
                NotifyPropertyChanged("oldMessages");
            }
        }

        private string _messageToSend;
        public string messageToSend
        {
            get { return _messageToSend; }
            set
            {
                _messageToSend = value;
                NotifyPropertyChanged("messageToSend");
            }
        }
        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="macAdress"></param>
        public MainModel(string macAdress)
        {
            this.macAdress = macAdress;
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\..\DBLedBadge.accdb;Persist Security Info=False;");
            conn.Open();
            oldMessages = GetOldMessages();
        }

        #region Methods
        /// <summary>
        /// Get les anciens mesages sur la Bdd
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<string> GetOldMessages()
        {
            try
            {
                ObservableCollection<string> messages = new ObservableCollection<string>();

                string sql = "SELECT * FROM Messages";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                // Lecture des données
                while (reader.Read())
                {
                    messages.Add(reader["Texte"].ToString());
                }
                return messages;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Sauvegarde le `message` dans bdd, effectue une requete pour Get les derniers messages et envoie le message au Led Badge
        /// </summary>
        /// <returns></returns>
        internal bool SendMessage()
        {
            SaveMessage(messageToSend);
            oldMessages = GetOldMessages();
            try
            {
                // ENVOYER LE MESSAGE AU LED BADGE

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sauvegarde `message` dans la bdd
        /// </summary>
        /// <param name="message"></param>
        private void SaveMessage(string message)
        {
            try
            {
                // Ajoute le message à la bdd
                string sql = "INSERT INTO Messages (Texte) VALUES ('" + message + "');";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Efface la variable `messageToSend`
        /// </summary>
        internal void ClearMessageToSend()
        {
            messageToSend = string.Empty;
        }
        #endregion
    }
}
