namespace WindowsFormsApplication
{
    partial class RankingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingForm));
            lbRankPref = new Label();
            pb1 = new PictureBox();
            pb2 = new PictureBox();
            pbPlayerRanking = new PictureBox();
            pbTeamRanking = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPlayerRanking).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbTeamRanking).BeginInit();
            SuspendLayout();
            // 
            // lbRankPref
            // 
            resources.ApplyResources(lbRankPref, "lbRankPref");
            lbRankPref.Name = "lbRankPref";
            // 
            // pb1
            // 
            resources.ApplyResources(pb1, "pb1");
            pb1.Name = "pb1";
            pb1.TabStop = false;
            // 
            // pb2
            // 
            resources.ApplyResources(pb2, "pb2");
            pb2.Name = "pb2";
            pb2.TabStop = false;
            // 
            // pbPlayerRanking
            // 
            resources.ApplyResources(pbPlayerRanking, "pbPlayerRanking");
            pbPlayerRanking.Name = "pbPlayerRanking";
            pbPlayerRanking.TabStop = false;
            pbPlayerRanking.Click += pbPlayerRanking_Click;
            // 
            // pbTeamRanking
            // 
            resources.ApplyResources(pbTeamRanking, "pbTeamRanking");
            pbTeamRanking.Name = "pbTeamRanking";
            pbTeamRanking.TabStop = false;
            pbTeamRanking.Click += pbTeamRanking_Click;
            // 
            // RankingForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbTeamRanking);
            Controls.Add(pbPlayerRanking);
            Controls.Add(pb2);
            Controls.Add(pb1);
            Controls.Add(lbRankPref);
            Name = "RankingForm";
            ((System.ComponentModel.ISupportInitialize)pb1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPlayerRanking).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbTeamRanking).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbRankPref;
        private PictureBox pb1;
        private PictureBox pb2;
        private PictureBox pbPlayerRanking;
        private PictureBox pbTeamRanking;
    }
}