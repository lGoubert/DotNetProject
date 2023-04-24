using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace LedBadgeProject.Main
{
    internal class MainModel
    {
        public MainModel(string macAdress)
        {
            this.macAdress = macAdress;
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\www\DotNetProject\LedBadgeProject\DBLedBadge.accdb;Persist Security Info=False;");
            conn.Open();
            oldMessages = GetOldMessages();
        }

        private List<string> GetOldMessages()
        {
            string sql = "SELECT * FROM Messages";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            return new List<string>();
        }

        public OleDbConnection conn;

        public string macAdress
        {
            get; set;
        }

        public string macAdressDisplay
        {
            get { return "Connected to " + this.macAdress; }
        }

        private List<string> _oldMessages;
        public List<string> oldMessages
        {
            get { return _oldMessages; }
            set { _oldMessages = value; }
        }


        internal bool SendMessage(string message)
        {
            SaveMessage(message);
            return true;
        }

        private void SaveMessage(string message)
        {
            oldMessages.Add(message);

            //Ajouter le message à la bdd
            //string sql = "SELECT * FROM Messages";
            //OleDbCommand cmd = new OleDbCommand(sql, conn);
            //OleDbDataReader reader = cmd.ExecuteReader();
        }
    }
}
