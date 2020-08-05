using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PetPractice
{
    public partial class GeneralPage : ContentPage
    {
        private ObservableCollection<DataEntry> dataItems;

        public ObservableCollection<DataEntry> DisplayItems
        {
            get { return dataItems ?? (dataItems = new ObservableCollection<DataEntry>()); }
            set { dataItems = value; OnPropertyChanged(); }
        }

        private PetData PetInst { get; set; }

        private int counter;    // is a debug property and needs to be deleted.
        private readonly ControlGeneral controlGeneral;
        private EditLogsPage editLogsPage;

        public GeneralPage(GeneralListFlag flag, PetData petInst)
        {
            counter = 0;
            PetInst = petInst;
            controlGeneral = new ControlGeneral(flag);
            editLogsPage = new EditLogsPage((int)controlGeneral.Flag);
            InitializeComponent();
            InitializeAttributes();
            BindingContext = this;
        }

        private void InitializeAttributes()
        {
            Title = controlGeneral.Title;
            if (!PetInst.QueryLogs.ContainsKey(controlGeneral.QueryKey))
            {
                PetInst.QueryLogs[controlGeneral.QueryKey] = new ObservableCollection<DataEntry>();
            }
            DisplayItems = PetInst.QueryLogs[controlGeneral.QueryKey];
            editButton.Text = controlGeneral.EditName;
            if (controlGeneral.Flag != GeneralListFlag.ACITIVITY)
            {
                foreach (string filter in controlGeneral.Filters)
                {
                    filterPicker.Items.Add(filter);
                }
                filterPicker.SelectedIndex = 0;
                filterPicker.PropertyChanged += UpdateProp;
            }
        }

        public void UpdateProp(object sender, EventArgs e)
        {
            filterButton.Text = (string)filterPicker.SelectedItem;
        }

        public void Update(object sender, EventArgs e)
        {
            ToolbarItem inst = (ToolbarItem)sender;

            if (inst.Equals(filterButton))
            {
                filterPicker.Focus();
            }
        }

        public void OnDelete(object sender, EventArgs e)
        {
            MenuItem instance_btn = (MenuItem)sender;
            PetInst.QueryLogs[controlGeneral.QueryKey].Remove((DataEntry)instance_btn.CommandParameter);
            DisplayItems = PetInst.QueryLogs[controlGeneral.QueryKey];
        }

        public void OnPress(object sender, ItemTappedEventArgs e)
        {
            DataEntry we = (DataEntry)e.Item;
            Navigation.PushAsync(editLogsPage.GetEditStageView(we));
        }

        public void Add_Entry(object sender, EventArgs e)
        {
            DataEntry asdf = new DataEntry(controlGeneral.Title + " Log #" + counter);
            DisplayItems.Add(asdf);
            counter++;
        }

        public void QueryCurrentText(object sender, EventArgs e)
        {
            string text = ((SearchBar)sender).Text;
            if (string.IsNullOrEmpty(text))
            {
                DisplayItems = PetInst.QueryLogs[controlGeneral.QueryKey];
                return;
            }
            ObservableCollection<DataEntry> newDisplayList = new ObservableCollection<DataEntry>();
            foreach (DataEntry dataEntry in PetInst.QueryLogs[controlGeneral.QueryKey])
            {
                if (dataEntry.Title.ToLower().Contains(text.ToLower()))
                {
                    newDisplayList.Add(dataEntry);
                }
            }
            DisplayItems = newDisplayList;
        }
    }

    public class ControlGeneral
    {
        public GeneralListFlag Flag { get; set; } = GeneralListFlag.DEFAULT;

        public ControlGeneral(GeneralListFlag paramFlag)
        {
            Flag = paramFlag;
        }

        public string QueryKey 
        {
            get
            {
                switch (this.Flag)
                {
                    case GeneralListFlag.ACITIVITY:
                        return "activity";
                    case GeneralListFlag.NOTES:
                        return "notes";
                    case GeneralListFlag.REMINDER:
                        return "reminder";
                    case GeneralListFlag.DEFAULT:
                    default:
                        return "Default";
                }
            }
        }

        public string EditName
        {
            get
            {
                switch (this.Flag)
                {
                    case GeneralListFlag.ACITIVITY:
                        return "Add Activity";
                    case GeneralListFlag.NOTES:
                        return "Add Note";
                    case GeneralListFlag.REMINDER:
                        return "Add Reminder";
                    case GeneralListFlag.DEFAULT:
                    default:
                        return "Default";
                }
            }
        }

        public string Title
        {
            get
            {
                switch (this.Flag)
                {
                    case GeneralListFlag.ACITIVITY:
                        return "Activity";
                    case GeneralListFlag.NOTES:
                        return "Notes";
                    case GeneralListFlag.REMINDER:
                        return "Reminder";
                    case GeneralListFlag.DEFAULT:
                    default:
                        return "Default";
                }
            }
        }

        public string[] Filters
        {
            get
            {
                switch (this.Flag)
                {
                    case GeneralListFlag.ACITIVITY:
                        return new string[]{
                            "All",
                            "Cleaning",
                            "Feeding"
                        };
                    case GeneralListFlag.NOTES:
                        return new string[]{
                            "Filter 1",
                            "Filter 2",
                            "Filter 3",
                            "Filter 4",
                            "Filter 5"
                        };
                    case GeneralListFlag.REMINDER:
                        return new string[] {
                            "All",
                            "Daily",
                            "Weekly",
                            "Yearly"
                        };
                    case GeneralListFlag.DEFAULT:
                    default:
                        return new string[]{
                            "Filter 1",
                            "Filter 2",
                            "Filter 3",
                        };
                }
            }
        }
    }
}
