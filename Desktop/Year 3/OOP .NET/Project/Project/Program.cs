

using DataLayer.DAL;
using DataLayer.Utilities;
using WindowsFormsApplication;
using WindowsFormsApplication.Forms;

namespace Project
{
    internal static class Program
    {


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (!File.Exists(Settings.filePath))
            {
                Application.Run(new InitialSettings());
            }
            else
            {
                Application.Run(new FifaWorldCup());
            }
            
        }
    }
}