using Xamarin.Forms;


namespace PetPractice
{

    public class SourceView : TableView
    {
        public EntryCell WebsiteTitleEntry { get; set; }
        public EntryCell UrlEntry { get; set; }

        public Button Okay { get; } = new Button()
        {
            Text = "Add Source",
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };

        public SourceView(bool flag = true, WebsiteEntry data_entry = null)
        {
            ConfigureEnv(flag, data_entry);
            var layout = new StackLayout() { Orientation = StackOrientation.Vertical };
            layout.Children.Add(Okay);
            Root = new TableRoot
            {
                new TableSection("Source desired Website.")
                {
                    WebsiteTitleEntry,
                    UrlEntry,
                    new ViewCell { View = layout }
                }
            };
            Intent = TableIntent.Settings;
        }

        private void ConfigureEnv(bool flag, WebsiteEntry data_entry)
        {
            if (flag)
            {
                WebsiteTitleEntry = new EntryCell()
                {
                    Label = "Enter Website Title: ",
                    Placeholder = "Enter Title"
                };

                UrlEntry = new EntryCell()
                {
                    Label = "Enter URL: ",
                    Placeholder = "Enter URL"
                };

            }
            else
            {
                WebsiteTitleEntry = new EntryCell()
                {
                    Label = "Enter Website Title: ",
                    Placeholder = data_entry.Title
                };

                UrlEntry = new EntryCell()
                {
                    Label = "Enter URL: ",
                    Placeholder = data_entry.Url
                };

            }
        }

    }

    public class ActivityView : TableView
    {
        public ActivityView()
        {

        }
    }
}
