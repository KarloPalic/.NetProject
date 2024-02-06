using DataLayer.DAL;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication.Controls;

namespace WindowsFormsApplication.Forms
{
    public partial class TeamRankingForm : Form
    {
        public string FavTeam { get; set; }
        public IRepository.Gender Gender { get; set; }

        RepositoryFactory factory = new RepositoryFactory();
        private string repositoryType = "API";
        private IRepository repository;

        private Settings settings;

        private List<TeamRanking> teamRankings = new List<TeamRanking>();
        public TeamRankingForm(string favTeam, IRepository.Gender gender)
        {
            settings = Settings.LoadSettings();

            InitializeComponent();
            repository = factory.GetRepository(repositoryType);

            FavTeam = favTeam;
            Gender = gender;
        }

        private async void TeamRankingForm_Load(object sender, EventArgs e)
        {
            var games = await repository.GetMatchesByFifaCode(settings.FavTeam, settings.Gender);
            

            games.Sort();

            foreach (var game in games)
            {
                teamRankings.Add(new TeamRanking(game.HomeTeamCountry, game.AwayTeamCountry, game.Location, game.Attendance));
            }

            flpTeamRankings.Controls.Clear();

            foreach (var game in teamRankings)
            {
                flpTeamRankings.Controls.Add(game);
            }

            PrintPlayerRankings();
        }

        private void PrintPlayerRankings()
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintPreviewDialog printDialog = new PrintPreviewDialog();
            printDialog.Document = printDocument;

            printDialog.ShowDialog();
        }

        private async void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            float ypos = 20;

            graphics.DrawString("Team Rankings", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new PointF(20, ypos));
            ypos += 40;

            foreach (var team in teamRankings)
            {
                string teams = $"{team.HomeTeam} vs {team.AwayTeam}\nLocation: {team.GameLocation}\nAttendance: {team.Visitors}";

                graphics.DrawString(teams, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(20, ypos));
                graphics.DrawLine(new Pen(Brushes.Black), new PointF(20, ypos + 60), new PointF(300, ypos + 60));
                ypos += 80;
            }
        }
    }
}
