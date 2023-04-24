using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace LedBadgeProject.Main
{
    internal class MainModel
    {
        public MainModel(string macAdress)
        {
            this.macAdress = macAdress;
        }

        public string macAdress
        {
            get; set;
        }

        public string macAdressDisplay
        {
            get { return "Connected to " + this.macAdress; }
        }



        public List<string> oldMessages
        {
            get { return new List<String> { "Hello", "World", "!" }; }
        }

    }
}
