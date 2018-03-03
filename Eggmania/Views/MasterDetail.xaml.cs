using System;
using System.Collections.Generic;
using Eggmania.Models;
using Xamarin.Forms;

namespace Eggmania.Views
{
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            masterPage.ListView.ItemSelected += OnItemSelected;
            ((NavigationPage)Detail).BarBackgroundColor = Color.FromHex("fdc300");
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if (item.Title == "Sign Out")
                {
                    Navigation.PopModalAsync();
                }
                else
                {
                    NavigationPage mainNav = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    Detail = mainNav;
                    masterPage.ListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }
    }
}
