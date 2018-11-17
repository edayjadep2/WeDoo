using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeDoo
{
    public partial class App : Application
    {
        static public NavigationPage mainNavigation;
        public App()
        {
            InitializeComponent();

            //MainPage = new MainView();
            //MainPage = new LoginPage();

            mainNavigation = new NavigationPage(new LoginPage());
            MainPage = mainNavigation;

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
