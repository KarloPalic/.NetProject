using DataLayer.Model;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsPresentationFoundationApplication
{
    /// <summary>
    /// Interaction logic for PlayerView.xaml
    /// </summary>
    public partial class PlayerView : UserControl
    {
        public long Id { get; set; }
        public string PlayerName { get; set; }

        private readonly Player selectedPlayer;
        public PlayerView(Player player)
        {
            InitializeComponent();
            selectedPlayer = player;
            lbPlayerName.Content = player.Name;
            lbPlayerNumber.Content = player.Id;
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayerStats playerStats = new PlayerStats(selectedPlayer);
            playerStats.ShowDialog();
        }
    }
}
