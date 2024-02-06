namespace WindowsFormsApplication.Forms
{
    partial class PlayerRankingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerRankingForm));
            flpPlayers = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpPlayers
            // 
            resources.ApplyResources(flpPlayers, "flpPlayers");
            flpPlayers.AllowDrop = true;
            flpPlayers.Name = "flpPlayers";
            // 
            // PlayerRankingForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpPlayers);
            Name = "PlayerRankingForm";
            Load += PlayerRankingForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpPlayers;
    }
}