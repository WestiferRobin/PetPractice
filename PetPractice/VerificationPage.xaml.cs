using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PetPractice
{
    public partial class VerificationPage : ContentPage
    {
        public VerificationPage(ViewCell flag)
        {
            InitializeComponent();

        }

        public void LastChance(object sender, EventArgs e)
        {
            ViewCell response = (ViewCell)sender;
            if (response == _cellYes)
            {
                DisplayAlert("History Cleared", "Your history has been cleared", "Okay");
            }
            else if (response == _cellNo)
            {
                DisplayAlert("History Not Cleared", "Your history has not been cleared", "Okay");
            }
            Navigation.PopAsync();
        }
    }
}
