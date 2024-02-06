namespace WindowsFormsApplication.Forms
{
    partial class FifaWorldCup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FifaWorldCup));
            lbFavTeam = new Label();
            cbFavTeam = new ComboBox();
            btnRanking = new Button();
            lbPlayers = new Label();
            lbFavPlayers = new Label();
            flpPlayers = new FlowLayoutPanel();
            flpFavPlayers = new FlowLayoutPanel();
            btnChangeSettings = new Button();
            SuspendLayout();
            // 
            // lbFavTeam
            // 
            resources.ApplyResources(lbFavTeam, "lbFavTeam");
            lbFavTeam.Name = "lbFavTeam";
            // 
            // cbFavTeam
            // 
            resources.ApplyResources(cbFavTeam, "cbFavTeam");
            cbFavTeam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFavTeam.FormattingEnabled = true;
            cbFavTeam.Name = "cbFavTeam";
            cbFavTeam.SelectedIndexChanged += cbFavTeam_SelectedIndexChanged;
            // 
            // btnRanking
            // 
            resources.ApplyResources(btnRanking, "btnRanking");
            btnRanking.Name = "btnRanking";
            btnRanking.UseVisualStyleBackColor = true;
            btnRanking.Click += btnRanking_Click;
            // 
            // lbPlayers
            // 
            resources.ApplyResources(lbPlayers, "lbPlayers");
            lbPlayers.Name = "lbPlayers";
            // 
            // lbFavPlayers
            // 
            resources.ApplyResources(lbFavPlayers, "lbFavPlayers");
            lbFavPlayers.Name = "lbFavPlayers";
            // 
            // flpPlayers
            // 
            resources.ApplyResources(flpPlayers, "flpPlayers");
            flpPlayers.AllowDrop = true;
            flpPlayers.BorderStyle = BorderStyle.FixedSingle;
            flpPlayers.Name = "flpPlayers";
            // 
            // flpFavPlayers
            // 
            resources.ApplyResources(flpFavPlayers, "flpFavPlayers");
            flpFavPlayers.AllowDrop = true;
            flpFavPlayers.BorderStyle = BorderStyle.FixedSingle;
            flpFavPlayers.Name = "flpFavPlayers";
            // 
            // btnChangeSettings
            // 
            resources.ApplyResources(btnChangeSettings, "btnChangeSettings");
            btnChangeSettings.Name = "btnChangeSettings";
            btnChangeSettings.UseVisualStyleBackColor = true;
            btnChangeSettings.Click += btnChangeSettings_Click;
            // 
            // FifaWorldCup
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnChangeSettings);
            Controls.Add(flpFavPlayers);
            Controls.Add(flpPlayers);
            Controls.Add(lbFavPlayers);
            Controls.Add(lbPlayers);
            Controls.Add(btnRanking);
            Controls.Add(cbFavTeam);
            Controls.Add(lbFavTeam);
            Name = "FifaWorldCup";
            Load += NationalTeams_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lbFavTeam;
        private ComboBox cbFavTeam;
        private Button btnRanking;
        private Label lbPlayers;
        private Label lbFavPlayers;
        private FlowLayoutPanel flpPlayers;
        private FlowLayoutPanel flpFavPlayers;
        private Button btnChangeSettings;
    }
}