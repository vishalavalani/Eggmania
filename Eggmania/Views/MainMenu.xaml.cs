using System;
using System.Collections.Generic;
using Eggmania.Models;
using Xamarin.Forms;

namespace Eggmania.Views
{
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
            this.Title = "Menu";
            this.listViewMainMenu.ItemsSource = App.mainMenuItems;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menuItem = e.SelectedItem as MainMenuModel;
            if (menuItem == null)
            {
                return;
            }

            await Navigation.PushAsync(new MenuItemList(menuItem));

            // Manually deselect item
            listViewMainMenu.SelectedItem = null;
        }
    }


}
