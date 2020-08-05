using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PetPractice
{
    public partial class SettingsPage : ContentPage
    {

        public SettingsPage()
        {
            InitializeComponent();
        }

        public void HistoryCleared(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VerificationPage(_clearHistory));
        }
    }
}
