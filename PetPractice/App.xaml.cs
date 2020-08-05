using Xamarin.Forms;

/*
------------------------ BACKLOG OF APPLICATION ------------------------ 
BLOCKED:
    - Icons need symbol working and splash screen needs logo.
    - Splash Screen needs to be fixed

COMPLETED:
    - Completed rough layout of the screens for the app from blue prints.
    - Picked a "ocean" color scheme.
    - Finish writing Source Page and has working functionality for adding and removing entries.
    - Finished Cleaning Page and Feeding Page functionality.
    - Start applying the comment backlog thing (what im typing now).
    - Add the new UI query selector at the top of the Feeding and Cleaning Pages. (Dummy logic wasn't applied for query testing aka nightmare)
    - Fix edge case of just having a link to get to the new page
    - Add Title and Url for the View and display just the title in the Source Page.
    - Edits for the Source page.
    - Added titles to all pages.
    - Removed EntryPage and GeneLab page.
    - Add query buttons to the bottom for Cleaning and Feeding Page
    - Edit title display for Cleaning and Feeding Page
    - Refactor MainPage to be two buttons on top (settings and reminders), middle screen (Pets), and bottom buttons (feeding, cleaning, and source)
        - bottom buttons is feeding, cleaning, and add pets
        - source page is now related with reminder
    - Apply back the buttons for names month and year.
    - Refactor Feeding and Cleaning Entries. Apply test cases and replace dummy data.
    - Refactor Cleaning and Feeding Pages to be under a General page.
    - Finish Pets page main Screen, and Pets Stats page.
    - Apply functionality for adding and removing pets on main
    - Ensure that query buttons are working with existing data.
        - Map From Notes and Activity Page
    - Work with Jessica and apply the Stats page life cycle and design.
        - Stats Page (DONE)
        - Apply Notes and Activity Page (DONE)
            - REFACTOR OF CLEANING/FEEDING PAGE 
            - Remainders moved and is now a general page

IN PROGRESS:
    - Create Pages and UI for EditReminders, EditNotes, EditActivity, (Replace Source with Recept), and AddPet.
        - Note about New Recept functionality
            - Add a print food list in email. (have textarea holding email and then a button to send all last food logs notes)
                - Replace the source page to just send email of feeding list. (Receipt page and button and have setting to automate that by button)
    - Refactor to be Breed (type of animals) instead of Snake across the app.
    - Add a filter on home page for different animals.


TODOS:
    - Add Azure for Xamarin Forms or use your raspberry pi server.
        - for pets and logs
    - Add Preset Themes with custom options. 
    - Map settings and reminders page to actually work in the phone
        - Come up with new name too as well for the re-brand
    - Get it deployed for peronal testing on my phone
    - Get Ready
        - Testing and fixes
    - Polish and Push to github
        - REMOVE ANY VULRABLE REST API INFO!!! I DONT WANT HACKERS IN HERE!!!!
*/

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
