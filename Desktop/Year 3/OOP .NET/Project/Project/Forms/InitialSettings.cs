using DataLayer.DAL;
using DataLayer.Utilities;
using System.Globalization;
using WindowsFormsApplication.Forms;
using static DataLayer.DAL.IRepository;


namespace WindowsFormsApplication
{
    public partial class InitialSettings : Form
    {

        private const string HR = "hr";
        private const string EN = "en";
        
        

        private static bool allowLanguageChanged = false;

        private Settings settings;

        public InitialSettings()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void StartingWindow_Load(object sender, EventArgs e)
        {
            settings = Settings.LoadSettings();
            InitLanguageComboBox();
            InitGenderComboBox();

            allowLanguageChanged = true;

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(InitialSettings_KeyDown);
        }

        private void InitGenderComboBox()
        {
            if (cbGender.Items.Count < 2)
            {
                cbGender.Items.AddRange(Enum.GetNames(typeof(Gender)));
            }
            
        }

        private void InitLanguageComboBox()
        {
            cbLanguage.Items.Add(EN);
            cbLanguage.Items.Add(HR);

            cbLanguage.SelectedItem = settings.Language;
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!allowLanguageChanged)
                {
                    return;
                }

                settings.Language = cbLanguage.SelectedItem.ToString();
                SetCulture(settings.Language);
            }
            catch
            {
                MessageBox.Show("Unable to select language!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetCulture(string language)
        {
            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            ResetComponents();
        }

        private void ResetComponents()
        {
            this.Controls.Clear();
            InitializeComponent();
            allowLanguageChanged = false;
            InitLanguageComboBox();
            InitGenderComboBox();
            allowLanguageChanged = true;
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.Gender = Enum.Parse<Gender>(cbGender.SelectedItem.ToString());

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show("Are you sure you want to save the settings?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Yes;
                    settings.SaveSettings();
                    this.Close();

                }
                else if (result == DialogResult.No)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitialSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnStart.Enabled)
            {
                e.Handled = true;
                btnStart.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape && btnClose.Enabled)
            {
                e.Handled = true;
                btnClose.PerformClick();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Are you Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
