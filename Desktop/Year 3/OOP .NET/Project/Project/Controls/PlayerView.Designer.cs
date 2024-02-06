namespace WindowsFormsApplication
{
    partial class PlayerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerView));
            lbCapitain = new Label();
            lbShirtNumber = new Label();
            lbPosition = new Label();
            lbName = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pbStar = new PictureBox();
            pbPlayerPic = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbStar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPlayerPic).BeginInit();
            SuspendLayout();
            // 
            // lbCapitain
            // 
            resources.ApplyResources(lbCapitain, "lbCapitain");
            lbCapitain.Name = "lbCapitain";
            // 
            // lbShirtNumber
            // 
            resources.ApplyResources(lbShirtNumber, "lbShirtNumber");
            lbShirtNumber.Name = "lbShirtNumber";
            // 
            // lbPosition
            // 
            resources.ApplyResources(lbPosition, "lbPosition");
            lbPosition.Name = "lbPosition";
            // 
            // lbName
            // 
            resources.ApplyResources(lbName, "lbName");
            lbName.Name = "lbName";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // pbStar
            // 
            resources.ApplyResources(pbStar, "pbStar");
            pbStar.Name = "pbStar";
            pbStar.TabStop = false;
            // 
            // pbPlayerPic
            // 
            resources.ApplyResources(pbPlayerPic, "pbPlayerPic");
            pbPlayerPic.Name = "pbPlayerPic";
            pbPlayerPic.TabStop = false;
            pbPlayerPic.Click += pbPlayerPic_Click_1;
            // 
            // PlayerView
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbCapitain);
            Controls.Add(lbShirtNumber);
            Controls.Add(lbPosition);
            Controls.Add(lbName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pbStar);
            Controls.Add(pbPlayerPic);
            Name = "PlayerView";
            Load += PlayerView_Load;
            ((System.ComponentModel.ISupportInitialize)pbStar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPlayerPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbCapitain;
        private Label lbShirtNumber;
        private Label lbPosition;
        private Label lbName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        public PictureBox pbStar;
        private PictureBox pbPlayerPic;
    }
}
