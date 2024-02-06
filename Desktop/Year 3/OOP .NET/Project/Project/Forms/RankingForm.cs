using DataLayer.DAL;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication.Controls;
using WindowsFormsApplication.Forms;

namespace WindowsFormsApplication
{
    public partial class RankingForm : Form
    {
        public string FavTeam { get; set; }
        public IRepository.Gender Gender { get; set; }

        private Settings settings;
        public RankingForm(string favTeam, IRepository.Gender gender)
        {
            settings = Settings.LoadSettings();

            InitializeComponent();
            Gender = gender;
            FavTeam = favTeam;
        }

        private void pbPlayerRanking_Click(object sender, EventArgs e)
        {

            PlayerRankingForm playerRankingForm = new PlayerRankingForm(settings.FavTeam, settings.Gender);
            playerRankingForm.Show();
        }

        private void pbTeamRanking_Click(object sender, EventArgs e)
        {
            TeamRankingForm teamRankingForm = new TeamRankingForm(settings.FavTeam, settings.Gender);
            teamRankingForm.Show();
        }
    }
}
