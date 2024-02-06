namespace WindowsFormsApplication.Controls
{
    partial class PlayerRanking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerRanking));
            pbPlayerPic1 = new PictureBox();
            lb = new Label();
            lbFullName = new Label();
            label1 = new Label();
            label2 = new Label();
            lbGoals = new Label();
            lbYellowCard = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPlayerPic1).BeginInit();
            SuspendLayout();
            // 
            // pbPlayerPic1
            // 
            resources.ApplyResources(pbPlayerPic1, "pbPlayerPic1");
            pbPlayerPic1.Name = "pbPlayerPic1";
            pbPlayerPic1.TabStop = false;
            pbPlayerPic1.Click += pbPlayerPic1_Click;
            // 
            // lb
            // 
            resources.ApplyResources(lb, "lb");
            lb.Name = "lb";
            // 
            // lbFullName
            // 
            resources.ApplyResources(lbFullName, "lbFullName");
            lbFullName.Name = "lbFullName";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // lbGoals
            // 
            resources.ApplyResources(lbGoals, "lbGoals");
            lbGoals.Name = "lbGoals";
            // 
            // lbYellowCard
            // 
            resources.ApplyResources(lbYellowCard, "lbYellowCard");
            lbYellowCard.Name = "lbYellowCard";
            // 
            // PlayerRanking
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbYellowCard);
            Controls.Add(lbGoals);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbFullName);
            Controls.Add(lb);
            Controls.Add(pbPlayerPic1);
            Name = "PlayerRanking";
            Load += PlayerRanking_Load;
            ((System.ComponentModel.ISupportInitialize)pbPlayerPic1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbPlayerPic1;
        private Label lb;
        private Label lbFullName;
        private Label label1;
        private Label label2;
        private Label lbGoals;
        private Label lbYellowCard;
    }
}
