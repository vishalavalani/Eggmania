using System;
using System.Collections.Generic;
using Eggmania.Models;
using Xamarin.Forms;

namespace Eggmania.Views
{
    public partial class ItemDetail : ContentPage
    {
        MenuItemModel menuItem;
        PreferencesView cookingPref;
        PreferencesView breadPref;

        public ItemDetail()
        {
            InitializeComponent();
        }

        public ItemDetail(MenuItemModel item)
        {
            InitializeComponent();
            menuItem = item;
            stackSpecialInst.IsVisible = false;

            cookingPref = new PreferencesView();
            cookingPref.Title = "Your Cooking Preference";
            cookingPref.SubTitle = "";
            cookingPref.Items = new string[]{
                "Oil",
                "Butter",
                "Olive Oil"
            };

            breadPref = new PreferencesView();
            breadPref.Title = "Choose your Bread (Required)";
            breadPref.SubTitle = "Select One";
            breadPref.Items = new string[]{
                "Chapati - 1 piece:",
                "Bread - 3 piece:",
            };
            stackPreferences.Children.Add(cookingPref);
            stackPreferences.Children.Add(breadPref);
        }

        async void DismissView(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }

        void AddItemToCart(object sender, System.EventArgs e)
        {

        }

        void OnSpecialInst(object sender, System.EventArgs e)
        {
            ToggleVisibility(stackSpecialInst, lblSpecialInst);
        }

        private void ToggleVisibility(StackLayout layout, Label lbl)
        {
            if (layout.IsVisible)
            {
                layout.IsVisible = false;
                lbl.Text = lbl.Text.Replace("-", "+");
            }
            else
            {
                layout.IsVisible = true;
                lbl.Text = lbl.Text.Replace("+", "-");
            }
        }
    }
}
