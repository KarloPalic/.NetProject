using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class PlayerView : UserControl
    {
        public long Id { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public bool Captain { get; set; }
        public PlayerView(long shirtNumber, string fullName, string position, bool captain)
        {
            InitializeComponent();
            Id = shirtNumber;
            PlayerName = fullName;
            Position = position;
            Captain = captain;
        }
        private void PlayerView_Load(object sender, EventArgs e)
        {
            lbName.Text = PlayerName;
            lbShirtNumber.Text = Id.ToString();
            lbPosition.Text = Position;
            lbCapitain.Text = Captain is true ? "Yes" : "No";
            pbStar.Visible = false;
        }
        

        public override string ToString() => $"{PlayerName}";

        private void pbPlayerPic_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.InitialDirectory = @"C:\Users\wExzEk\Desktop\Year 3\OOP .NET\Project\Project\bin\Debug\net6.0-windows";
            openFileDialog.Title = PlayerName;
            

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFileName = openFileDialog.FileName;
                    pbPlayerPic.Image = new System.Drawing.Bitmap(selectedFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
