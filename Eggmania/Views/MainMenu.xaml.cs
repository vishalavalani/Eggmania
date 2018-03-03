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
    }


}
