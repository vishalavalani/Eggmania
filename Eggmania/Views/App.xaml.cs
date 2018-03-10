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
            PopulateMenuEggSamplerItemList();
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

        private void PopulateMenuEggSamplerItemList(){
            
            var boiledEggs = new MenuItemModel() { Name = "Boiled eggs", Price = 1.99, IsVeg = false, IsSpicy = false, IsMostPopular = false };
            menuItemsList.Add(boiledEggs);

            var frenchToast = new MenuItemModel() { Name = "French Toast", Price = 3.99, IsVeg = false, IsSpicy = false, IsMostPopular = false };
            frenchToast.AddOnItems.Add(cookingPrefAddOn);
            menuItemsList.Add(frenchToast);

            var boilFry = new MenuItemModel() { Name = "Boil Fry", Price = 5.49, IsVeg = false, IsSpicy = true, IsMostPopular = true };
            boilFry.AddOnItems.Add(cookingPrefAddOn);
            menuItemsList.Add(boilFry);

            var masalOmelet = new MenuItemModel() { Name = "Masala Omelet", Price = 3.99, IsVeg = false, IsSpicy = false, IsMostPopular = false };
            masalOmelet.AddOnItems.Add(cookingPrefAddOn);
            menuItemsList.Add(masalOmelet);

            var eggKatori = new MenuItemModel() { Name = "Egg Katori", Price = 6.49, IsVeg = false, IsSpicy = false, IsMostPopular = true };
            eggKatori.AddOnItems.Add(cookingPrefAddOn);    
            menuItemsList.Add(eggKatori);

            var jettRolls = new MenuItemModel() { Name = "Jetty Rolls", Price = 6.49, IsVeg = false, IsSpicy = false, IsMostPopular = false };
            jettRolls.AddOnItems.Add(cookingPrefAddOn);
            menuItemsList.Add(jettRolls);

            var masalHalfFry = new MenuItemModel() { Name = "Masala Half Fry", Price = 5.99, IsVeg = false, IsSpicy = true, IsMostPopular = false };
            masalHalfFry.AddOnItems.Add(cookingPrefAddOn);
            menuItemsList.Add(masalHalfFry);
        }

        public static List<AddOnItem> breadItems = new List<AddOnItem>() { new AddOnItem { DisplayName = "Chapati - 1 piece:", Price = 0.0M }, new AddOnItem { DisplayName = "Bread - 3 piece", Price = 0.0M } };
        public static AddOn breadAddOn = new AddOn()
        {
            Title = "Choose your Bread (Required)",
            Description = "Select One",
            AddOnItems = breadItems
        };

        public static List<AddOnItem> cookingPrefItems = new List<AddOnItem>() { new AddOnItem { DisplayName = "Oil:", Price = 0.0M }, new AddOnItem { DisplayName = "Butter :", Price = 0.99M }, new AddOnItem { DisplayName = "Olive Oil:", Price = 1.99M } };
        public static AddOn cookingPrefAddOn = new AddOn()
        {
            Title = "Your Cooking Preference",
            Description = "All items cooked in Oil if no option selected",
            AddOnItems = cookingPrefItems
        };

        public static List<AddOnItem> extraCheeseItems = new List<AddOnItem>() { new AddOnItem { DisplayName = "Extra Cheese:", Price = 1.99M } };
        public static AddOn extraCheeseAddOn = new AddOn()
        {
            Title = "Extra Cheese",
            Description = "Please select",
            AddOnItems = extraCheeseItems
        };

        public static List<AddOnItem> sodaItems = new List<AddOnItem>() { new AddOnItem { DisplayName = "Coke:", Price = 0.00M }, new AddOnItem { DisplayName = "Diet Coke:", Price = 0.00M }, new AddOnItem { DisplayName = "Sprite:", Price = 0.00M } };
        public static AddOn sodaAddOn = new AddOn()
        {
            Title = "Your Choice (Required)",
            Description = "Please Select",
            AddOnItems = sodaItems
        };

        public static List<AddOnItem> thumsUpLimcaItems = new List<AddOnItem>() { new AddOnItem { DisplayName = "Thums Up:", Price = 0.00M }, new AddOnItem { DisplayName = "Limca:", Price = 0.00M } };
        public static AddOn thumsUpLimca = new AddOn()
        {
            Title = "Thums Up or Limca (Required)",
            Description = "Please Select",
            AddOnItems = sodaItems
        };

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
