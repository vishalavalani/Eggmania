using System;
using System.Collections.Generic;
using Eggmania.Models;
using Xamarin.Forms;

namespace Eggmania.Views
{
    public partial class ItemDetail : ContentPage
    {
        MenuItemModel menuItem;
        public ItemDetail()
        {
            InitializeComponent();
        }

        public ItemDetail(MenuItemModel item)
        {
            InitializeComponent();
            menuItem = item;
        }

        async void DismissView(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}
