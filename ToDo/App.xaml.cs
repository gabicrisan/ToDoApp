using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo
{
    public partial class App : Application
    {
        private static ToDoDatabase database;

        public static ToDoDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ToDoDatabase();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CreatePage());
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
