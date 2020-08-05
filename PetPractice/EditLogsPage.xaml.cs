using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PetPractice
{

    public partial class EditLogsPage : ContentPage
    {
        private readonly GeneralListFlag _flag;

        public ObservableCollection<DataEntry> ListViewItems { get; set; }

        public EditLogsPage(int flag)
        {
            InitializeComponent();
            _flag = (GeneralListFlag)flag;
        }

        public ContentPage GetNewStageView()
        {
            SourceView sc = new SourceView();
            switch (_flag)
            {
                case GeneralListFlag.ACITIVITY:
                    Title = "New Activity";
                    break;
                default:
                    DisplayAlert("Error", "not valid....", "okay");
                    break;
            }
            sc.Okay.Clicked += OnButtonClickedNew;
            Content = sc;

            return this;
        }

        private void OnButtonClickedNew(object sender, EventArgs args)
        {
            switch (_flag)
            {
                case GeneralListFlag.ACITIVITY:
                    break;
                default:
                    DisplayAlert("Error", "not valid....", "okay");
                    break;
            }
            Navigation.PopAsync();
        }

        public ContentPage GetEditStageView(DataEntry dataEntry)
        {
            switch (_flag)
            {
                case GeneralListFlag.ACITIVITY:
                    Title = "Edit Activity";
                    break;
                default:
                    DisplayAlert("Error", "not valid....", "okay");
                    break;
            }

            return this;
        }

        private void OnButtonClickedEdit(object sender, EventArgs args, DataEntry dataEntry)
        {
            switch (_flag)
            {
                case GeneralListFlag.ACITIVITY:
                    break;
                default:
                    DisplayAlert("Error", "not valid....", "okay");
                    break;
            }
            Navigation.PopAsync();
        }
    }
}
