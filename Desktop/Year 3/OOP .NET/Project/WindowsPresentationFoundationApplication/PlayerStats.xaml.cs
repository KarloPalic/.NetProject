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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowsPresentationFoundationApplication
{
    /// <summary>
    /// Interaction logic for PlayerStats.xaml
    /// </summary>
    /// 
    public partial class PlayerStats : Window
    {
        private readonly Player selectedPlayer;
        public PlayerStats(Player player)
        {
            InitializeComponent();
            selectedPlayer = player;

            Loaded += PlayerStats_Loaded;

            DisplayPlayerStats();
        }

        private void PlayerStats_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            BeginAnimation(OpacityProperty, fadeInAnimation);
        }

        private void DisplayPlayerStats()
        {
            lbPlayerNumber.Content = selectedPlayer.Id;
            lbPlayerName.Content = selectedPlayer.Name;
            lbCaptain.Content = selectedPlayer.Captain is true ? "Yes" : "No"; ;
            lbPosition.Content = selectedPlayer.Position;
        }

        private void imgPlayerPic_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.InitialDirectory = @"C:\Users\wExzEk\Desktop\Year 3\OOP .NET\Project\Project\bin\Debug\net6.0-windows";
            openFileDialog.Title = selectedPlayer.Name;

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string selectedFileName = openFileDialog.FileName;

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(selectedFileName);
                    bitmap.EndInit();

                    Image newImage = new Image();
                    newImage.Source = bitmap;

                    ((Grid)sender).Background = new ImageBrush(newImage.Source);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
