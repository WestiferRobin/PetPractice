using Xamarin.Forms;

namespace PetPractice
{
    public partial class App : Application
    {
        public const string version = "v1.0";

        public App()
        {
            InitializeComponent();
            NavigationPage nav_page = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = (Color)Current.Resources["backgroundDark"],
                BarTextColor = (Color)Current.Resources["textLight"],
            };
            MainPage = nav_page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
