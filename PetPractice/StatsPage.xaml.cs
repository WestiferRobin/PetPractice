using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PetPractice
{
    public partial class StatsPage : ContentPage
    {
        private static PetData PetInst { get; set; }

        public StatsPage(PetData pet)
        {
            InitializeComponent();
            PetInst = pet;
            this.Title = pet.Name + " Stats";
            petFace.Source = pet.ImageUrl;
            petName.Text += string.Concat("\n\t", pet.Name);
            petType.Text += string.Concat("\n\t", TranslateUtility.TranslateType(pet.PetType));
            petSex.Text += string.Concat("\n\t", pet.PetGender);
            petBirth.Text += string.Concat("\n\t", TranslateUtility.GetBirthDateString(pet.DateOfBirth));
        }

        public void Navigate_Page(object sender, System.EventArgs e)
        {
            Button inst = (Button)sender;
            GeneralPage generalPage = new GeneralPage(GeneralListFlag.DEFAULT, PetInst);
            switch (inst.Text.ToLower())
            {
                case "activity":
                    generalPage = new GeneralPage(GeneralListFlag.ACITIVITY, PetInst);
                    break;
                case "notes":
                    generalPage = new GeneralPage(GeneralListFlag.NOTES, PetInst);
                    break;
                case "reminders":
                    generalPage = new GeneralPage(GeneralListFlag.REMINDER, PetInst);
                    break;
                case "edit":
                    DisplayAlert("Navigate Debug", "edit", "Okay");
                    break;
            }
            Navigation.PushAsync(generalPage);
        }
    }
}
