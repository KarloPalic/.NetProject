using DataLayer.DAL;
using DataLayer.Model;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static DataLayer.Utilities.Settings;

namespace WindowsPresentationFoundationApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Settings settings;

        RepositoryFactory factory = new RepositoryFactory();
        private string repositoryType = "API";
        private IRepository repository;

        private Match match;

        private bool ChangeIndexEvent = true;
        public MainWindow()
        {
            settings = Settings.LoadSettings();
            InitMainWindowForm();
            
        }

        private void InitMainWindowForm()
        {
            ShowConfigurationForm();
            LoadRepository();
            InitConfiguration();
            InitHomeComboBoxAsync();
        }

        private void InitConfiguration()
        {
            SetCulture();
            InitializeComponent();

            SetResolution();
        }

        private void SetResolution()
        {
            if (settings.Resolution == "Fullscreen")
            {
                WindowState = WindowState.Maximized;
            }
            else if (settings.Resolution == "1320x800")
            {
                ApplyResolution(1320, 800);
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else if (settings.Resolution == "1280x720")
            {
                ApplyResolution(1280, 720);
            }
            else if (settings.Resolution == "800x690")
            {
                ApplyResolution(800, 690);
            }
        }

        private void ApplyResolution(int width, int height)
        {
            Width = width;
            Height = height;
            WindowState = WindowState.Normal;
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

        private void LoadRepository()
        {
            repository = factory.GetRepository(repositoryType);

        }
        private async Task InitHomeComboBoxAsync()
        {
            List<Team> teams = await repository.GetTeams(settings.Gender);

            foreach (Team team in teams)
            {
                cbHomeTeam.Items.Add(team);

            }
            cbHomeTeam.SelectedIndex = teams.IndexOf(teams.FirstOrDefault(t => t.FifaCode == settings.FavTeam));
        }

        private async Task InitAwayComboBoxAsync()
        {
            ChangeIndexEvent = false;
            cbAwayTeam.Items.Clear();
            ChangeIndexEvent = true;
            List<Team> teams = await repository.GetTeams(settings.Gender);
            List<Match> matches = await repository.GetMatchesByFifaCode(settings.FavTeam, settings.Gender);

            Team currentTeam = cbHomeTeam.SelectedItem as Team;

            foreach (var team in teams)
            {
                foreach (Match match in matches)
                {
                    if (team.FifaCode != currentTeam.FifaCode)
                    {
                        if (team.FifaCode == match.HomeTeam.Code)
                        {
                            cbAwayTeam.Items.Add(team);
                        }else if (team.FifaCode == match.AwayTeam.Code)
                        {
                            cbAwayTeam.Items.Add(team);
                        }
                    }
                }
            }
        }

        private void ShowConfigurationForm()
        {
            if (File.Exists(Settings.filePath))
            {
                return;
            }

            InitialSettings initialSettings = new InitialSettings();
            initialSettings.ShowDialog();
        }

        private void cbHomeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearPanels();
            pnlData.Visibility = Visibility.Hidden;
            var team = cbHomeTeam.SelectedItem as Team;
            settings.FavTeam = team.FifaCode;
            settings.SaveSettings();
            
            InitAwayComboBoxAsync();

        }

        private void ClearPanels()
        {
            pnlHomeGoalie.Children.Clear();
            pnlHomeDefence.Children.Clear();
            pnlHomeMid.Children.Clear();
            pnlHomeAttack.Children.Clear();

            pnlAwayGoalie.Children.Clear();
            pnlAwayDefence.Children.Clear();
            pnlAwayMid.Children.Clear();
            pnlAwayAttack.Children.Clear();
        }

        private async void cbAwayTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearPanels();
            if (!ChangeIndexEvent || cbHomeTeam.SelectedItem == null || cbAwayTeam.SelectedItem == null)
            {
                return;
            }

            await GetCurrentMatch();
            pnlData.Visibility = Visibility.Visible;

            var homeTeam = cbHomeTeam.SelectedItem as Team;
            var awayTeam = cbAwayTeam.SelectedItem as Team;

            lbHomeTeam.Content = homeTeam;
            lbAwayTeam.Content = awayTeam;

            if (match != null)
            {
                if (match.HomeTeam.Code == homeTeam.FifaCode)
                {
                    lbHomeScore.Content = match.HomeTeam.Goals;
                    lbAwayScore.Content = match.AwayTeam.Goals;
                }
                else
                {
                    lbHomeScore.Content = match.AwayTeam.Goals;
                    lbAwayScore.Content = match.HomeTeam.Goals;
                }
            }
            else
            {
                lbHomeScore.Content = "N/A";
                lbAwayScore.Content = "N/A";
            }

            await ShowLineups();
        }

        private async Task ShowLineups()
        {
            List<Player> homePlayers = await repository.GetStartingPlayers(settings.FavTeam, settings.Gender);
            List<Player> awayPlayers = await repository.GetStartingPlayers(match.AwayTeam.Code, settings.Gender);

            foreach (var homePlayer in homePlayers)
            {
                var playerView = new PlayerView(homePlayer);
                if (homePlayer.Position == "Goalie")
                {
                    pnlHomeGoalie.Children.Add(playerView);
                }
                else if (homePlayer.Position == "Defender")
                {
                    pnlHomeDefence.Children.Add(playerView);
                }
                else if (homePlayer.Position == "Midfield")
                {
                    pnlHomeMid.Children.Add(playerView);
                } 
                else if (homePlayer.Position == "Forward")
                {
                    pnlHomeAttack.Children.Add(playerView);
                }
            }

            foreach (var awayPlayer in awayPlayers)
            {
                var playerView = new PlayerView(awayPlayer);
                if (awayPlayer.Position == "Goalie")
                {
                    pnlAwayGoalie.Children.Add(playerView);
                }
                else if (awayPlayer.Position == "Defender")
                {
                    pnlAwayDefence.Children.Add(playerView);
                }
                else if (awayPlayer.Position == "Midfield")
                {
                    pnlAwayMid.Children.Add(playerView);
                }
                else if (awayPlayer.Position == "Forward")
                {
                    pnlAwayAttack.Children.Add(playerView);
                }
            }

        }

        private async Task GetCurrentMatch()
        {
            var homeTeam = cbHomeTeam.SelectedItem as Team;
            var awayTeam = cbAwayTeam.SelectedItem as Team;

            List<Match> matches = await repository.GetMatchesByFifaCode(settings.FavTeam, settings.Gender);

            match = matches.FirstOrDefault(m =>
                (m.HomeTeam.Code == homeTeam.FifaCode && m.AwayTeam.Code == awayTeam.FifaCode) ||
                (m.HomeTeam.Code == awayTeam.FifaCode && m.AwayTeam.Code == homeTeam.FifaCode));

        }

        private void lbAwayTeam_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnlargeTextAnimation(lbAwayTeam);

            if (lbAwayTeam.Content is Team selectedTeam)
            {
                TeamStats teamStats = new TeamStats(selectedTeam);
                teamStats.ShowDialog();
            }
        }


        private void lbHomeTeam_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnlargeTextAnimation(lbHomeTeam);

            if (lbHomeTeam.Content is Team selectedTeam)
            {
                TeamStats teamStats = new TeamStats(selectedTeam);
                teamStats.ShowDialog();
            }
        }
        private void EnlargeTextAnimation(Label team)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 14,
                To = 18,
                Duration = TimeSpan.FromSeconds(0.5),
                AutoReverse = true 
            };

            team.BeginAnimation(FontSizeProperty, animation);
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            InitialSettings initialSettings = new InitialSettings();

            initialSettings.ShowDialog();

            var result = MessageBox.Show("Restart Application to change the settings", "Message", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            if (result == MessageBoxResult.OK)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            
        }
    }
}
