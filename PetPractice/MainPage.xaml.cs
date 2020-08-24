using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace PetPractice
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<PetData> PetList { get; set; }

        private readonly List<PetData> tempList = new List<PetData>
        {
            new PetData()
            {
                ImageUrl = new Uri("https://i.pinimg.com/originals/c8/f4/14/c8f41430be9090a265d77a96906faa4d.jpg"),
                Name = "Smokey",
                PetType = "Corn Snake",
                PetGender = "Male",
                DateOfBirth = DateTime.Parse("08/01/2017")
            },
            new PetData()
            {
                ImageUrl = new Uri("https://cdn11.bigcommerce.com/s-g64jf8ws/images/stencil/1280x1280/products/604/873/CANDY_CANE_CORN__66815.1405184394.JPG?c=2"),
                Name = "Rosey",
                PetType = "Corn Snake",
                PetGender = "Female",
                DateOfBirth = DateTime.Parse("08/01/2016")
            },
            new PetData()
            {
                ImageUrl = new Uri("https://cdn.shopify.com/s/files/1/0333/1814/1997/files/palmjpg.jpg?v=1582481807"),
                Name = "Buggsey",
                PetType = "Corn Snake",
                PetGender = "Male",
                DateOfBirth = DateTime.Parse("08/01/2018")
            },
            new PetData()
            {
                ImageUrl = new Uri("https://i.ytimg.com/vi/BL9wH1K9kXc/maxresdefault.jpg"),
                Name = "Cherry",
                PetType = "Corn Snake",
                PetGender = "Female",
                DateOfBirth = DateTime.Parse("08/01/2018")
            },
            new PetData()
            {
                ImageUrl = new Uri("https://herpsofnc.org/wp-content/uploads/2016/01/Elaphe-guttata-10.30.02-SREL-SC-in-tree-close-copy.jpg"),
                Name = "Berry",
                PetType = "Corn Snake",
                PetGender = "Female",
                DateOfBirth = DateTime.Parse("08/01/2018")
            },
            new PetData()
            {
                ImageUrl = new Uri("https://cdn.mysmelly.com/image:/sitefs/perm/pi/b/r/0/q/401.280.0_rttx4ycdpx49.jpg"),
                Name = "Molly",
                PetType = "Toy Fox Terrier",
                PetGender = "Female",
                DateOfBirth = DateTime.Parse("04/01/2010")
            },
        };

        private bool isPickerDone = true;

        private void InitializeAttributes()
        {
            removePicker.SelectedIndex = 0;
            removePicker.PropertyChanged += Pet_Remove_Clicked;
            PetList = new ObservableCollection<PetData>();
        }

        public MainPage()
        {
            InitializeComponent();
            InitializeAttributes();
            BindingContext = this;
        }

        public void Pet_Handle_Clicked(object sender, EventArgs e)
        {
            TappedEventArgs tea = (TappedEventArgs)e;
            PetData p = (PetData)tea.Parameter;
            StatsPage sp = new StatsPage(p);
            Navigation.PushAsync(sp);
        }

        async void Pet_Remove_Clicked(object sender, PropertyChangedEventArgs e)
        {
            if (PetList.Count > 0 && e.PropertyName == "IsFocused") 
            {
                if (isPickerDone)
                {
                    isPickerDone = false;
                }
                else
                {
                    foreach (PetData petData in PetList)
                    {
                        if (petData.Name == (string)removePicker.SelectedItem)
                        {
                            bool answer = await DisplayAlert("Deleting Entry", string.Format("Are you sure you want to remove {0}", petData.Name), "Yes", "No");
                            if (answer)
                            {
                                removePicker.Items.Remove(petData.Name);
                                petData.QueryLogs = new Dictionary<string, ObservableCollection<DataEntry>>();
                                PetList.Remove(petData);
                            }
                            isPickerDone = true;
                            break;
                        }
                    }
                } 
            }
        }

        private void Pet_Add_Clicked()
        {
            if (PetList.Count < tempList.Count)
            {
                Random rand = new Random();
                int instance = rand.Next(tempList.Count);
                while (PetList.Contains(tempList[instance]))
                {
                    instance = rand.Next(tempList.Count);
                }
                PetList.Add(tempList[instance]);
                removePicker.Items.Add(tempList[instance].Name);
            }
            else
            {
                DisplayAlert("Its Full", "Off debug pets", "Okay");
            }

        }

        public void Top_Handle_Clicked(object sender, EventArgs e)
        {
            ToolbarItem inst = (ToolbarItem)sender;
            switch (inst.ClassId.ToUpper())
            {
                case "S":
                    Navigation.PushAsync(new SettingsPage());
                    break;
            }
        }

        public void Bot_Handle_Clicked(object sender, EventArgs e)
        {
            Button inst = (Button)sender;
            switch (inst.ClassId.ToUpper())
            {
                case "E":
                    Navigation.PushAsync(new EmailPage());
                    break;
                case "A":
                    Pet_Add_Clicked();
                    break;
                case "R":
                    if (removePicker.Items.Count > 0) removePicker.Focus();
                    break;
            }
        }
    }
}
