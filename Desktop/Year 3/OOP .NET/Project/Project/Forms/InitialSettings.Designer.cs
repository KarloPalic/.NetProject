namespace WindowsFormsApplication
{
    partial class InitialSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialSettings));
            lbWelcome = new Label();
            lbLanguage = new Label();
            lbChampionship = new Label();
            cbGender = new ComboBox();
            cbLanguage = new ComboBox();
            btnStart = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lbWelcome
            // 
            resources.ApplyResources(lbWelcome, "lbWelcome");
            lbWelcome.Name = "lbWelcome";
            // 
            // lbLanguage
            // 
            resources.ApplyResources(lbLanguage, "lbLanguage");
            lbLanguage.Name = "lbLanguage";
            // 
            // lbChampionship
            // 
            resources.ApplyResources(lbChampionship, "lbChampionship");
            lbChampionship.Name = "lbChampionship";
            // 
            // cbGender
            // 
            resources.ApplyResources(cbGender, "cbGender");
            cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGender.FormattingEnabled = true;
            cbGender.Name = "cbGender";
            cbGender.SelectedIndexChanged += cbGender_SelectedIndexChanged;
            // 
            // cbLanguage
            // 
            resources.ApplyResources(cbLanguage, "cbLanguage");
            cbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLanguage.FormattingEnabled = true;
            cbLanguage.Name = "cbLanguage";
            cbLanguage.SelectedIndexChanged += cbLanguage_SelectedIndexChanged;
            // 
            // btnStart
            // 
            resources.ApplyResources(btnStart, "btnStart");
            btnStart.BackColor = Color.LightGreen;
            btnStart.Name = "btnStart";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnClose
            // 
            resources.ApplyResources(btnClose, "btnClose");
            btnClose.BackColor = Color.Salmon;
            btnClose.Name = "btnClose";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // StartingWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnClose);
            Controls.Add(btnStart);
            Controls.Add(cbLanguage);
            Controls.Add(cbGender);
            Controls.Add(lbChampionship);
            Controls.Add(lbLanguage);
            Controls.Add(lbWelcome);
            Name = "StartingWindow";
            Load += StartingWindow_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lbWelcome;
        private Label lbLanguage;
        private Label lbChampionship;
        private ComboBox cbGender;
        private ComboBox cbLanguage;
        private Button btnStart;
        private Button btnClose;
    }
}