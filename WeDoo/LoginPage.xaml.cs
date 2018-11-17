using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WeDoo
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            facebook.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command((obj) => {
                    App.mainNavigation.PushAsync(new MainView());
                })
            });
            twitter.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command((obj) => {
                    App.mainNavigation.PushAsync(new MainView());
                })
            });
            email.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command((obj) => {
                    App.mainNavigation.PushAsync(new MainView());
                })
            });
        }

        private void OnLoginButtonClicked(View view, object obj)
        {
            //this.Navigation.PushModalAsync(new MainView(), true);
            App.mainNavigation.PushAsync(new MainView());
        }

        private void OnSignUpButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
