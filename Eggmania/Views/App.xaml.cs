using System.Collections.Generic;
using Eggmania.Models;
using Xamarin.Forms;

namespace Eggmania
{
    public partial class App : Application
    {
        public static Color ColorYellowTheme
        {
            get
            {
                return Color.FromHex("dba901");
            }
        }

        public static Color ColorWhiteTheme
        {
            get
            {
                return Color.FromHex("ffffff");
            }
        }


        public static List<MainMenuModel> mainMenuItems;


        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Login());
            mainMenuItems = new List<MainMenuModel>();
            PopulateMainMenuListItems();
        }

        private void PopulateMainMenuListItems()
        {
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Egg Samplers", ImageName = "EggSamplers.png" });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Egg Xotica", ImageName = "EggXotica.png" });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Butterly Delicious", ImageName = "ButterlyDelicious.png" });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Bombay Grill Sandwich", ImageName = "Grilled.png" });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Paneer Da Chaska", ImageName = "ButterlyDelicious.png" });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Rice", ImageName = "Rice.png" });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Beverages", ImageName = "Beverages.png" });
            mainMenuItems.Add(new MainMenuModel() { DisplayName = "Eggxtra", ImageName = "Extra.png" });

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
