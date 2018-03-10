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
        }

        public MenuItemList(MainMenuModel mainMenu)
        {
            InitializeComponent();
            this.selectedMenu = mainMenu;
            this.Title = selectedMenu.DisplayName;
            this.listViewMenuItems.ItemsSource = App.menuItemsList;
        }

        async void OnItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItemModel;

            if(item == null){
                return;
            }

            await Navigation.PushModalAsync(new ItemDetail(item));

            listViewMenuItems.SelectedItem = null;
        }
    }

}
