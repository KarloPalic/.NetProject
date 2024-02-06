using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication.Controls
{
    public partial class TeamRanking : UserControl, IComparable<TeamRanking>
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string GameLocation { get; set; }
        public int Visitors { get; set; }

        public TeamRanking(string homeTeam, string awayTeam, string gameLocation, int visitors)
        {
            InitializeComponent();

            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            GameLocation = gameLocation;
            Visitors = visitors;
        }

        private void TeamRanking_Load(object sender, EventArgs e)
        {
            lbHomeTeam.Text = HomeTeam;
            lbAwayTeam.Text = AwayTeam;
            lbLocation.Text = GameLocation;
            lbVisitors.Text = Visitors.ToString();
        }

        public int CompareTo(TeamRanking? other)
        {
            return Visitors.CompareTo(other.Visitors);
        }

        public override bool Equals(object? obj)
        {
            return obj is TeamRanking teamRanking && HomeTeam == teamRanking.HomeTeam
                                                  && AwayTeam == teamRanking.AwayTeam
                                                  && GameLocation == teamRanking.GameLocation
                                                  && Visitors == teamRanking.Visitors;
        }
    }
}
