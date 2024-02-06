using DataLayer.DAL;
using DataLayer.Model;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication.Forms
{
    public partial class FifaWorldCup : Form
    {
        RepositoryFactory factory = new RepositoryFactory();
        private string repositoryType = "API";
        private IRepository repository;

        private Settings settings;

        private bool allowChangeIndexEvent = true;
        public FifaWorldCup()
        {
            InitializeComponent();
            settings = Settings.LoadSettings();
            FormClosing += FifaWorldCup_FormClosing;

        }


        private void NationalTeams_Load(object sender, EventArgs e)
        {

            LoadRepository();
            InitConfiguration();
            InitDnD();
            InitTeamComboBox();

        }

        private void InitDnD()
        {
            flpPlayers.AllowDrop = true;
            flpPlayers.DragEnter += FlpPlayers_DragEnter;
            flpPlayers.DragDrop += FlpPlayers_DragDrop;

            flpFavPlayers.AllowDrop = true;
            flpFavPlayers.DragEnter += FlpFavPlayers_DragEnter;
            flpFavPlayers.DragDrop += FlpFavPlayers_DragDrop;

        }

        private void FlpFavPlayers_DragDrop(object? sender, DragEventArgs e)
        {
            PlayerView playerView = (PlayerView)e.Data.GetData(typeof(PlayerView));

            if (playerView != null)
            {
                if (flpFavPlayers.Controls.Count != 3)
                {
                    flpPlayers.Controls.Remove(playerView);
                    flpFavPlayers.Controls.Add(playerView);
                    playerView.pbStar.Visible = true;

                    List<string> favoritePlayerNames = settings.FavPlayerNames ?? new List<string>();

                    favoritePlayerNames.Add(playerView.PlayerName);

                    settings.FavPlayerNames = favoritePlayerNames;
                    settings.SaveSettings();
                }
                else
                {
                    MessageBox.Show("You can only add 3 players");
                    return;
                }

            }
        }

        private void FlpFavPlayers_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerView)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void FlpPlayers_DragDrop(object? sender, DragEventArgs e)
        {
            PlayerView playerView = (PlayerView)e.Data.GetData(typeof(PlayerView));

            if (playerView != null)
            {
                flpFavPlayers.Controls.Remove(playerView);
                flpPlayers.Controls.Add(playerView);
                playerView.pbStar.Visible = false;

                List<string> favoritePlayerNames = settings.FavPlayerNames ?? new List<string>();

                favoritePlayerNames.Remove(playerView.PlayerName);

                settings.FavPlayerNames = favoritePlayerNames;
                settings.SaveSettings();
            }
        }

        private void FlpPlayers_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerView)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void PlayerView_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is PlayerView playerView)
            {
                flpPlayers.DoDragDrop(playerView, DragDropEffects.Move);
            }
        }

        private async Task InitTeamComboBox()
        {
            List<Team> teams = await repository.GetTeams(settings.Gender);

            foreach (Team team in teams)
            {
                cbFavTeam.Items.Add(team);
            }
            cbFavTeam.SelectedIndex = teams.IndexOf(teams.FirstOrDefault(t => t.FifaCode == settings.FavTeam));
        }
        private void LoadRepository()
        {
            repository = factory.GetRepository(repositoryType);
        }

        private void InitConfiguration()
        {
            this.Controls.Clear();
            SetCulture();
            InitializeComponent();
        }

        private void SetCulture()
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(settings.Language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.Language);
            }
            catch
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(settings.Language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.Language);
            }
        }

        private async void cbFavTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChangeIndexEvent)
            {
                return;
            }

            var team = (Team)cbFavTeam.SelectedItem;
            settings.FavTeam = team.FifaCode;
            settings.SaveSettings();

            if (flpFavPlayers.Controls.Count > 0)
            {
                DialogResult result = MessageBox.Show("You have existing Favorite players, Are you sure you want to change your Favorite team?", "Are you Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    settings.FavPlayerNames.Clear();
                    flpFavPlayers.Controls.Clear();
                    flpPlayers.Controls.Clear();
                }
                else
                {
                    return;
                }
            }

            flpPlayers.Controls.Clear();

            if (team != null)
            {

                List<Player> players = await repository.GetPlayers(settings.FavTeam, settings.Gender);

                foreach (var player in players)
                {
                    var playerView = new PlayerView(player.Id, player.Name, player.Position, player.Captain);

                    if (settings.FavPlayerNames.Any(p => p == player.Name))
                    {
                        flpFavPlayers.Controls.Add(playerView);
                        playerView.pbStar.Visible = true;
                        flpPlayers.Controls.Remove(playerView);
                    }
                    else
                    {
                        flpPlayers.Controls.Add(playerView);
                    }

                    playerView.MouseDown += PlayerView_MouseDown;

                }
            }



        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            RankingForm rankingForm = new RankingForm(settings.FavTeam, settings.Gender);

            rankingForm.Show();
        }

        private void btnChangeSettings_Click(object sender, EventArgs e)
        {

            using (var initialSettings = new InitialSettings())
            {
                var result = initialSettings.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    settings = Settings.LoadSettings();

                    LoadRepository();
                    InitConfiguration();
                    InitDnD();
                    InitTeamComboBox();
                }
            }

        }

        private void FifaWorldCup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }


    }
}
