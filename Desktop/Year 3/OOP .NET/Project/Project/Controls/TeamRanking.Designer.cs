namespace WindowsFormsApplication.Controls
{
    partial class TeamRanking
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamRanking));
            lbHomeTeam = new Label();
            label1 = new Label();
            lbAwayTeam = new Label();
            label2 = new Label();
            label3 = new Label();
            lbLocation = new Label();
            lbVisitors = new Label();
            SuspendLayout();
            // 
            // lbHomeTeam
            // 
            resources.ApplyResources(lbHomeTeam, "lbHomeTeam");
            lbHomeTeam.Name = "lbHomeTeam";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // lbAwayTeam
            // 
            resources.ApplyResources(lbAwayTeam, "lbAwayTeam");
            lbAwayTeam.Name = "lbAwayTeam";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // lbLocation
            // 
            resources.ApplyResources(lbLocation, "lbLocation");
            lbLocation.Name = "lbLocation";
            // 
            // lbVisitors
            // 
            resources.ApplyResources(lbVisitors, "lbVisitors");
            lbVisitors.Name = "lbVisitors";
            // 
            // TeamRanking
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbVisitors);
            Controls.Add(lbLocation);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lbAwayTeam);
            Controls.Add(label1);
            Controls.Add(lbHomeTeam);
            Name = "TeamRanking";
            Load += TeamRanking_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbHomeTeam;
        private Label label1;
        private Label lbAwayTeam;
        private Label label2;
        private Label label3;
        private Label lbLocation;
        private Label lbVisitors;
    }
}
