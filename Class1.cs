using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_W4
{
    class team
    {
        private string name;
        private string country;
        private string city;
        public List<player> players = new List<player>();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public void nambah(player a)
        {
            players.Add(a);
        }
    }
    class player
    {
        private string playername;
        private string playernumber;
        private string playerposition;
        public string PlayerName
        {
            get { return playername; }
            set { playername = value; }
        }
        public string PlayerNumber
        {
            get { return playernumber; }
            set { playernumber = value; }
        }
        public string PlayerPosition
        {
            get { return playerposition; }
            set { playerposition = value; }
        }
    }
}
