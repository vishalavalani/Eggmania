using System;
using System.Collections.Generic;
using Eggmania.Models;
using Xamarin.Forms;

namespace Eggmania.Views
{
    public partial class MenuItemList : ContentPage
    {
        MainMenuModel selectedMenu;
        public static List<MenuItemModel> menuItemsList = new List<MenuItemModel>();
        public MenuItemList()
        {
            InitializeComponent();
            this.Title = "Items";
            selectedMenu = new MainMenuModel { DisplayName = "No Item Selected", ImageName = "" };
            //PopulateMenuItemList();
            //this.listViewMenuItems.ItemsSource = menuItemsList;
        }

        public MenuItemList(MainMenuModel mainMenu)
        {
            InitializeComponent();
            this.selectedMenu = mainMenu;
            this.Title = selectedMenu.DisplayName;
            this.listViewMenuItems.ItemsSource = App.menuItemsList;
        }
        private void PopulateMenuItemList()
        {
            menuItemsList.Add(new MenuItemModel() { Name = "Boiled eggs", Price = 1.99, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "French Toast", Price = 3.99, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "Boil Fry", Price = 5.49, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "Masala Omelet", Price = 3.99, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "Egg Katori", Price = 6.49, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "Jetty Rolls", Price = 6.49, IsVeg = true, IsSpicy = true, IsMostPopular = true });
            menuItemsList.Add(new MenuItemModel() { Name = "Masala Half Fry", Price = 5.99, IsVeg = true, IsSpicy = true, IsMostPopular = true });
        }
    }

}
