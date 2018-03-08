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
        public static List<MenuItemModel> menuItemsList = new List<MenuItemModel>();

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Login());
            mainMenuItems = new List<MainMenuModel>();
            PopulateMainMenuListItems();
            PopulateMenuItemList();
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

        private void PopulateMenuItemList(){
            menuItemsList.Add(new MenuItemModel() { Name = "Boiled eggs", Price = 1.99, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "French Toast", Price = 3.99, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "Boil Fry", Price = 5.49, IsVeg = true, IsSpicy = false, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "Masala Omelet", Price = 3.99, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "Egg Katori", Price =6.49, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "Jetty Rolls", Price = 6.49, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "Masala Half Fry", Price = 5.99, IsVeg = true, IsSpicy = true, IsMostPopular = true });
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
