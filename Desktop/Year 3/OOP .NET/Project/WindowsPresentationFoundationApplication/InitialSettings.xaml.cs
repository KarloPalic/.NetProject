using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static DataLayer.DAL.IRepository;
using static DataLayer.Utilities.Settings;

namespace WindowsPresentationFoundationApplication
{
    /// <summary>
    /// Interaction logic for InitialSettings.xaml
    /// </summary>
    public partial class InitialSettings : Window
    {
        private const string HR = "hr";
        private const string EN = "en";

        List<ResolutionSettings> resolutionOptions = new List<ResolutionSettings>
        {
            new ResolutionSettings(0,0, "Fullscreen"),
            new ResolutionSettings(1320, 800),
            new ResolutionSettings(1280, 720),
            new ResolutionSettings(800, 690)
        };

        private static bool allowLanguageChanged = false;

        private Settings settings;
        public InitialSettings()
        {
            settings = Settings.LoadSettings();
            InitializeComponent();
            InitInitialSettingsForm();

            this.KeyDown += Window_KeyDown;
        }

        private void InitInitialSettingsForm()
        {
            InitLanguageComboBox();
            InitGenderComboBox();
            InitResolutionComboBox();
            allowLanguageChanged = true;
        }

        private void InitResolutionComboBox()
        {
            foreach (var resolution in resolutionOptions)
            {
                cbResolution.Items.Add(resolution);
            }

            cbResolution.SelectedItem = settings.Resolution;
        }

        private void InitLanguageComboBox()
        {
            cbLanguage.Items.Add(EN);
            cbLanguage.Items.Add(HR);

            cbLanguage.SelectedItem = settings.Language;
        }

        private void InitGenderComboBox()
        {
            var genders = Enum.GetNames(typeof(Gender));
            foreach (var gender in genders)
            {
                cbGender.Items.Add(gender);
            }

            cbGender.SelectedItem = settings.Gender;
        }

        private void cbResolution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            settings.Resolution = cbResolution.SelectedItem.ToString();
        }

        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!allowLanguageChanged)
                {
                    return;
                }

                settings.Language = cbLanguage.SelectedItem.ToString();

            }
            catch
            {
                MessageBox.Show("Unable to select language!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            settings.Gender = Enum.Parse<Gender>(cbGender.SelectedItem.ToString());
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to save the settings?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    DialogResult = true;
                    settings.SaveSettings();
                    Close();

                }
                else if (result == MessageBoxResult.No)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving settings: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the application?", "Are you Sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnStart.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            } else if (e.Key == Key.Escape)
            {
                btnClose.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}
