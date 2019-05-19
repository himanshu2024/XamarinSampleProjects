using System;
using WorkingOnDatabase.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingOnDatabase
{
    public partial class App : Application
    {
        public static Repo repo;

        public App(string dbPath)
        {
            InitializeComponent();

            Console.WriteLine($"Database path at: {dbPath}");

            repo = new Repo(dbPath);

            MainPage = new NavigationPage( new Views.MainPage());
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
