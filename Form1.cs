using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_W4
{
    public partial class Form1 : Form
    {
        List<string> playerMU = new List<string>() {"David de Gea", "Victor Lindelof" , "Phil Jones", "Harry Maguire", "Lisandro Martinez",
        "Bruno Fernandez", "Anthony Martial", "Marcus Rashford", "Tyrell Malacia", "Christian Eriksen" , "Casemiro"};
        List<string> nomerMU = new List<string>() {"01", "02", "04", "05", "06", "08", "09", "10", "12", "14", "18"};
        List<string> posisiMU = new List<string>() {"GK", "DF", "DF", "DF", "DF", "MF", "FW", "FW", "DF", "MF", "MF"};

        List<string> playerCH = new List<string>() {"Kepa Arrizabalaga", "Benoit Badiashile", "Enzo Fernandez", "Thiago Silva", "N'Golo Kante",
        "Mateo Kovacic", "Pierre-Emerick Aubameyang", "Christian Pulisic", "Joao Felix", "Ruben Loftus-Cheek", "Raheem Sterling"};
        List<string> nomerCH = new List<string>() {"01", "04", "05", "06", "07", "08", "09", "10", "11", "12", "17"};
        List<string> posisiCH = new List<string>() { "GK", "DF", "MF", "DF", "MF", "MF", "FW", "MF", "FW", "MF", "MF"};

        List<string> playerBM = new List<string>() {"(01) Manuel Neuer, GK", "(02) Dayot Upamecano, DF", "(04) Matthijs de Ligt, DF", "(05) Benjamin Pavart, DF", "(06) Joshua Kimmich, MF",
        "(07) Serge Gnabry, FW", "(08) Leon Goretzka, MF", "(10) Leroy Sane, FW", "(14) Paul Wanner, MF", "(21) Lucas Hernandez, DF", "(25) Thomas Muller, FW"};
        List<string> nomerBM = new List<string>() {"01", "02", "04", "05", "06", "07", "08", "10", "14", "21", "25"};
        List<string> posisiBM = new List<string>() {"GK", "DF", "DF", "DF", "MF", "FW", "MF", "FW", "MF", "DF", "FW"};

        List<team> teamku = new List<team>();
        
        int count = 0;
        string passNegara = "";
        string passTim = "";
        public void updatenegara()
        {
            listnegara.Items.Clear();
            foreach (team a in teamku)
            {
                count = 0;
                foreach (string b in listnegara.Items)
                {
                    if (a.Country == b)
                    {
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    listnegara.Items.Add(a.Country);
                }               
            }
        }

        public void updatetim()
        {
            listtim.Items.Clear();
            foreach (team a in teamku)
            {
                if (a.Country == passNegara)
                {
                    listtim.Items.Add(a.Name);
                }
            }
        }

        public void updateplayer()
        {
            listplayer.Items.Clear();
            foreach (team a in teamku)
            {
                if (a.Name == passTim && a.Country == passNegara)
                {
                    foreach (player b in a.players)
                    {
                        listplayer.Items.Add($"({b.PlayerNumber}) {b.PlayerName}, {b.PlayerPosition}");
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        
        private void listnegara_SelectionChangeCommitted(object sender, EventArgs e)
        {
            passNegara = listnegara.SelectedItem.ToString();
            updatetim();
        }

        private void listtim_SelectionChangeCommitted(object sender, EventArgs e)
        {
            passTim = listtim.SelectedItem.ToString();
            updateplayer();
        }

        private void addtim_Click(object sender, EventArgs e)
        {
            count = 0;
            if (namatim.Text == "" || negaratim.Text == "" || kotatim.Text == "")
            {
                MessageBox.Show("Error please input first");
            }
            else
            {
                foreach (team a in teamku)
                {
                    if (a.Name == namatim.Text)
                    {
                        count = 1;
                    }
                }
                if (count == 1)
                {
                    MessageBox.Show("Error team already exists");
                }
                else
                {
                    team teams = new team();
                    teams.Name = namatim.Text;
                    teams.Country = negaratim.Text;
                    teams.City = kotatim.Text;
                    teamku.Add(teams);
                }
                namatim.Clear();
                negaratim.Clear();
                kotatim.Clear();
                updatenegara();
                updatetim();
            }
            
        }

        private void addplayer_Click(object sender, EventArgs e)
        {
            if (namaplayer.Text == "" || noplayer.Text == "" || posisiplayer.SelectedItem == null)
            {
                MessageBox.Show("Error please input first");
            }
            else
            {
                if (listtim.SelectedItem == null)
                {
                    MessageBox.Show("Please choose team");
                }
                else
                {
                    count = 0;
                    foreach (string b in listplayer.Items)
                    {
                        if (b == ($"({noplayer.Text}) {namaplayer.Text}, {posisiplayer.SelectedItem.ToString()}"))
                        {
                            count = 1;
                        }
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("Error player already exists");
                    }
                    else
                    {
                        foreach (team a in teamku)
                        {
                            if (a.Name == passTim && a.Country == passNegara)
                            {
                                player players = new player();
                                players.PlayerName = namaplayer.Text;
                                players.PlayerNumber = noplayer.Text;
                                players.PlayerPosition = posisiplayer.SelectedItem.ToString();
                                a.nambah(players);
                            }
                        }
                    }
                    namaplayer.Clear();
                    noplayer.Clear();
                    posisiplayer.Text = null;
                    updateplayer();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            team teams = new team();
            teams.Name = "Manchester United";
            teams.Country = "England";
            teams.City = "London"; 
            for (int x = 0; x < 11; x++)
            {
                player players = new player();
                players.PlayerName = playerMU[x];
                players.PlayerNumber = nomerMU[x];
                players.PlayerPosition = posisiMU[x];
                teams.nambah(players);
            }
            teamku.Add(teams);

            teams = new team();
            teams.Name = "Chelsea";
            teams.Country = "England";
            teams.City = "London";
            for (int x = 0; x < 11; x++)
            {
                player players = new player();
                players.PlayerName = playerCH[x];
                players.PlayerNumber = nomerCH[x];
                players.PlayerPosition = posisiCH[x];
                teams.nambah(players);
            }
            teamku.Add(teams);

            teams = new team();
            teams.Name = "Bayern Munich";
            teams.Country = "Germany";
            teams.City = "Germany";
            for (int x = 0; x < 11; x++)
            {
                player players = new player();
                players.PlayerName = playerBM[x];
                players.PlayerNumber = nomerBM[x];
                players.PlayerPosition = posisiBM[x];
                teams.nambah(players);
            }
            teamku.Add(teams);
            updatenegara();
        }

        private void listtim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (listplayer.SelectedItem == null)
            {
                MessageBox.Show("Error please choose player");
            }
            else
            {
                foreach (team a in teamku)
                {
                    if (a.Country == passNegara && a.Name == passTim)
                    {
                        if (a.players.Count > 11)
                        {
                            foreach (player b in a.players)
                            {
                                if (($"({b.PlayerNumber}) {b.PlayerName}, {b.PlayerPosition}") == listplayer.SelectedItem.ToString())
                                {
                                    a.players.Remove(b);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error players is 11");
                            break;
                        }
                    }
                }
                updateplayer();
            }
        }
    }
}
