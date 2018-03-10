using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static Eggmania.Views.ItemDetail;

namespace Eggmania.Views
{
    public partial class PreferencesView : ContentView
    {

        public PreferencesView()
        {
            InitializeComponent();
            stackSubPref.IsVisible = false;
        }

        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = " + " + value;
            }
        }

        public string SubTitle
        {
            get
            {
                return lblSubTitle.Text;
            }
            set
            {
                lblSubTitle.Text = value;
            }
        }

        public string[] Items
        {
            set
            {
                pickerPref.ItemsSource = value;
                pickerPref.SelectedIndex = 0;
            }
        }

        public string SelectedPickerValue
        {
            get
            {
                return Convert.ToString(pickerPref.SelectedItem);
            }
        }



        void OnTapPref(object sender, System.EventArgs e)
        {
            ToggleVisibility(stackSubPref, lblTitle);
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
            //Action<double> callback = input => layout.HeightRequest = input;
            //double startingHeight = 0;
            //double endingHeight = layout.Height;
            //Easing easing = Easing.SinIn;
            //uint rate = 10;
            //uint length = 200;
            //layout.Animate("invis", callback, startingHeight, endingHeight, rate, length, easing);

        }
    }
}
