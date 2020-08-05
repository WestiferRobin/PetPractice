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
                ImageUrl = "http://iansvivarium.com/morphs/charcoal/pics/charcoal-e.jpg",
                Name = "Smokey",
                PetType = SnakeTypes.CORN_SNAKE,
                PetGender = "Male",
                DateOfBirth = DateTime.Parse("08/01/2017")
            },
            new PetData()
            {
                ImageUrl = "http://www.coldblooded-novelties.com/images/Corns/m_ultramotley_het%20Carmel_.jpg",
                Name = "Rosey",
                PetType = SnakeTypes.CORN_SNAKE,
                PetGender = "Female",
                DateOfBirth = DateTime.Parse("08/01/2016")
            },
            new PetData()
            {
                ImageUrl = "https://www.cornsnake.net/wp-content/uploads/2019/06/pm7559-1050.jpg",
                Name = "Buggsey",
                PetType = SnakeTypes.CORN_SNAKE,
                PetGender = "Male",
                DateOfBirth = DateTime.Parse("08/01/2018")
            },
            new PetData()
            {
                ImageUrl = "https://www.lllreptile.com/uploads/images/StoreInventoryImage/13318/large",
                Name = "Daisy",
                PetType = SnakeTypes.BALL_PYTHON,
                PetGender = "Female",
                DateOfBirth = DateTime.Parse("08/01/2017")
            },
            new PetData()
            {
                ImageUrl = "https://www.lllreptile.com/uploads/images/StoreInventoryImage/13440/large",
                Name = "Lilly",
                PetType = SnakeTypes.BALL_PYTHON,
                PetGender = "Female",
                DateOfBirth = DateTime.Parse("08/01/2017")
            },
            new PetData()
            {
                ImageUrl = "https://cdn1.bigcommerce.com/server3900/g64jf8ws/products/441/images/566/DSCN52421__91509.1385941349.1280.1280.JPG?c=2",
                Name = "Stanley",
                PetType = SnakeTypes.BALL_PYTHON,
                PetGender = "Male",
                DateOfBirth = DateTime.Parse("11/01/2018")
            },
            new PetData()
            {
                ImageUrl = "https://www.exotic-pets.co.uk/data/images/100l.jpg",
                Name = "Cherry",
                PetType = SnakeTypes.CORN_SNAKE,
                PetGender = "Female",
                DateOfBirth = DateTime.Parse("08/01/2018")
            },
            new PetData()
            {
                ImageUrl = "https://66.media.tumblr.com/8ae59b35aff6c548fd32b63d40c78ffe/tumblr_inline_orwpiy1pZE1tdmmeu_1280.jpg",
                Name = "Berry",
                PetType = SnakeTypes.CORN_SNAKE,
                PetGender = "Female",
                DateOfBirth = DateTime.Parse("08/01/2018")
            },
            new PetData()
            {
                ImageUrl = "http://rivista-cdn.reptilesmagazine.com/images/cache/cache_c/cache_8/cache_6/rainbow-boa-shutterstock_255081319-9ef6a68c.jpeg?ver=1542817181&aspectratio=1.5047021943574",
                Name = "Crimsion",
                PetType = SnakeTypes.RAINBOW_BOA,
                PetGender = "Male",
                DateOfBirth = DateTime.Parse("12/01/2018")
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
