using System;
using System.Collections.Generic;
using Eggmania.Views;
using Xamarin.Forms;

namespace Eggmania
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            btnLogin.Clicked += BtnLogin_Clicked;
            btnRegister.Clicked += BtnRegister_Clicked;
        }

        async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MasterDetail());
        }

    }
}
