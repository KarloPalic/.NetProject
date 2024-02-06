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
    public partial class PlayerRanking : UserControl, IComparable<PlayerRanking>
    {
        public string RankingPlayerName { get; set; }
        public int YellowCards { get; set; }
        public int GoalsScored { get; set; }
        public PlayerRanking(string playerName, int yellowCards, int goalsScored)
        {
            InitializeComponent();
            RankingPlayerName = playerName;
            YellowCards = yellowCards;
            GoalsScored = goalsScored;
        }


        private void PlayerRanking_Load(object sender, EventArgs e)
        {
            lbFullName.Text = RankingPlayerName;
            lbGoals.Text = GoalsScored.ToString();
            lbYellowCard.Text = YellowCards.ToString();
        }

        public int CompareTo(PlayerRanking? other)
        {
            int goalsCompared = other.GoalsScored.CompareTo(GoalsScored);
            if (goalsCompared != 0)
            {
                return goalsCompared;
            }

            return YellowCards.CompareTo(other.YellowCards);
        }

        public override bool Equals(object? obj)
        {
            return obj is PlayerRanking playerRanking && GoalsScored == playerRanking.GoalsScored
                                                      && YellowCards == playerRanking.YellowCards;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GoalsScored, YellowCards);
        }

        private void pbPlayerPic1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.InitialDirectory = @"C:\Users\wExzEk\Desktop\Year 3\OOP .NET\Project\Project\bin\Debug\net6.0-windows";
            openFileDialog.Title = RankingPlayerName;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFileName = openFileDialog.FileName;
                    pbPlayerPic1.Image = new System.Drawing.Bitmap(selectedFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
