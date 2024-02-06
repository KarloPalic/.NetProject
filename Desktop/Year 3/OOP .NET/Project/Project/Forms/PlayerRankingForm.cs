using DataLayer.DAL;
using DataLayer.Model;
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
    public partial class PlayerRankingForm : Form
    {
        public string FavTeam { get; set; }
        public IRepository.Gender Gender { get; set; }

        RepositoryFactory factory = new RepositoryFactory();
        private string repositoryType = "API";
        private IRepository repository;

        private List<PlayerRanking> sortedPlayers;


        private Settings settings;

        public PlayerRankingForm(string favTeam, IRepository.Gender gender)
        {
            settings = Settings.LoadSettings();

            InitializeComponent();
            repository = factory.GetRepository(repositoryType);

            FavTeam = favTeam;
            Gender = gender;
        }

        private async void PlayerRankingForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            List<Player> players = await repository.GetPlayers(settings.FavTeam, settings.Gender);

            List<PlayerRanking> playerRankings = await LoadPlayerRankings(players);

            sortedPlayers = playerRankings.OrderBy(player => -player.GoalsScored).ThenBy(player => player.YellowCards).ToList();

            flpPlayers.Controls.Clear();

            foreach (var player in sortedPlayers)
            {
                flpPlayers.Controls.Add(player);
            }

            PrintPlayerRankings();

            this.Cursor = Cursors.Default;
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

            graphics.DrawString("Player Rankings", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new PointF(20, ypos));
            ypos += 40;

            foreach (var player in sortedPlayers)
            { 
                string players = $"Player: {player.RankingPlayerName}\nYellow Cards: {player.YellowCards}\nGoals: {player.GoalsScored}";

                graphics.DrawString(players, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(20, ypos));
                graphics.DrawLine(new Pen(Brushes.Black), new PointF(20, ypos + 60), new PointF(300, ypos + 60));

                ypos += 80;
            }
        }

        private async Task<List<PlayerRanking>> LoadPlayerRankings(List<Player> players)
        {
            List<PlayerRanking> playerRankings = new List<PlayerRanking>();

            foreach (Player player in players)
            {
                
                int yellowCards = await GetPlayersYellowCards(player);
                int goalsScored = await GetPlayersGoalsScored(player);

                playerRankings.Add(new PlayerRanking(player.Name, yellowCards, goalsScored));
            }

            return playerRankings;
        }

        private async Task<int> GetPlayersYellowCards(Player player)
        {
            List<Match> matches = await repository.GetMatchesByFifaCode(settings.FavTeam, settings.Gender);

            int yellowCards = 0;

            foreach (Match match in matches)
            {
                List<Player> homePlayers = match.GetAllHomeTeamPlayers();
                List<Player> awayPlayers = match.GetAllAwayTeamPlayers();

                if (homePlayers.Contains(player))
                {
                    foreach (var events in match.HomeTeamEvents)
                    {
                        if (events.Player == player.Name && events.TypeOfEvent == "yellow-card")
                        {
                            yellowCards++;
                        }
                    }
                }
                else if (awayPlayers.Contains(player))
                {
                    foreach (var events in match.AwayTeamEvents)
                    {
                        if (events.Player == player.Name && events.TypeOfEvent == "yellow-card")
                        {
                            yellowCards++;
                        }
                    }
                }
            }

            return yellowCards;
        }

        private async Task<int> GetPlayersGoalsScored(Player player)
        {
            List<Match> matches = await repository.GetMatchesByFifaCode(settings.FavTeam, settings.Gender); 

            int goalsScored = 0;

            foreach (Match match in matches)
            {
                List<Player> homePlayers = match.GetAllHomeTeamPlayers();
                List<Player> awayPlayers = match.GetAllAwayTeamPlayers();

                if (homePlayers.Contains(player))
                {
                    foreach (var events in match.HomeTeamEvents)
                    {
                        if (events.Player == player.Name)
                        {
                            if (events.TypeOfEvent == "goal" || events.TypeOfEvent == "goal-own" || events.TypeOfEvent == "goal-penalty")
                            {
                                goalsScored++;
                            }

                        }
                    }
                }
                else if (awayPlayers.Contains(player))
                {
                    foreach (var events in match.AwayTeamEvents)
                    {
                        if (events.Player == player.Name)
                        {
                            if (events.TypeOfEvent == "goal" || events.TypeOfEvent == "goal-own" || events.TypeOfEvent == "goal-penalty")
                            {
                                goalsScored++;
                            }
                            
                        }
                    }
                }
            }

            return goalsScored;
        }
    }
}
