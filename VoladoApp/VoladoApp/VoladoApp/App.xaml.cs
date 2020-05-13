using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VoladoApp.Views;
using VoladoApp.Services;

namespace VoladoApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        static ItemDatabase database;

        public static ItemDatabase Database
        {
            get
            {
                if(database == null )
                {
                    database = new ItemDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
