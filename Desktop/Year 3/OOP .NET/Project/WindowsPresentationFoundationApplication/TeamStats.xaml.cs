using DataLayer.Model;
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
using System.Windows.Shapes;

namespace WindowsPresentationFoundationApplication
{
    /// <summary>
    /// Interaction logic for TeamStats.xaml
    /// </summary>
    public partial class TeamStats : Window
    {
        private readonly Team selectedTeam;

        public TeamStats(Team team)
        {
            InitializeComponent();
            selectedTeam = team;

            DisplayTeamStats();
        }

        private void DisplayTeamStats()
        {
            
            lbTeamName.Content = selectedTeam.Country;
            lbFifaCode.Content = selectedTeam.FifaCode;
            lbGroupLetter.Content = selectedTeam.GroupLetter;
            
        }
    }
}
