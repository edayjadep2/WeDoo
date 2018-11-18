using System;

using Xamarin.Forms;

namespace WeDoo
{
    public class MainView : TabbedPage
    {
        public MainView() {
            NavigationPage.SetHasNavigationBar(this, false);
            BarBackgroundColor = Color.White;
            BarTextColor = Color.FromHex("f5a623");
            this.Title = "";
            this.ToolbarItems.Add(new ToolbarItem
            {
                ClassId = "Notification",
                Icon = "Icons/ic_notification.png",
                Order = ToolbarItemOrder.Primary
            });
            this.Children.Add(SetMePage());
            this.Children.Add(SetWePage());
            this.Children.Add(SetDooPage());

        }

        ContentPage SetMe2Page() {
            var contentPage = new ContentPage();
            contentPage.Icon = "me.png";
            contentPage.Title = "Janet";
            contentPage.ToolbarItems.Add(new ToolbarItem {
                ClassId = "Notification",
                Icon = "Icons/ic_notification.png",
                Order = ToolbarItemOrder.Primary
            });
            var mainlayout = new StackLayout(){ VerticalOptions = LayoutOptions.Fill};
            var scrollview = new ScrollView() { VerticalOptions = LayoutOptions.Fill};
            var contentLayout = new StackLayout() {};
            contentLayout.Children.Add(new Label() { Text = "Popular Activities" });
            var popularActivitiesLayout = new StackLayout();
            popularActivitiesLayout.Children.Add(new Image() { Source = "we-doo.png" });

            contentLayout.Children.Add(popularActivitiesLayout);
            contentLayout.Children.Add(new Label() { Text = "Recently Doo" });
            contentLayout.Children.Add(new Label() { Text = "Frequent Connection" });
            scrollview.Content = contentLayout;
            mainlayout.Children.Add(scrollview);
            contentPage.Content = mainlayout;
            
            return contentPage;
        }

        ContentPage SetMePage()
        {
            var contentPage = new ContentPage();
            contentPage.Icon = "me.png";
            contentPage.Title = "Janet";
            contentPage.ToolbarItems.Add(new ToolbarItem
            {
                ClassId = "Notification",
                Icon = "Icons/ic_notification.png",
                Order = ToolbarItemOrder.Primary
            });
            var mainlayout = new StackLayout() { VerticalOptions = LayoutOptions.Fill };
            mainlayout.Children.Add(new Image(){Source = "me-top.png"});
            var segmentLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 10, 10, 10),
                Margin = new Thickness(0, 30, 0, 30),
                HorizontalOptions = LayoutOptions.Fill

            };
            var lbl_aboutme = new Label() { Text = "About Me", Margin = new Thickness(50, 0, 70, 0), HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Center, FontSize = Device.GetNamedSize(NamedSize.Small, typeof(EntryCell)), FontAttributes = FontAttributes.Bold };
            var lbl_mydoo = new Label() { Text = "My Doo", Margin = new Thickness(50, 0, 0, 0), HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Center, FontSize = Device.GetNamedSize(NamedSize.Small, typeof(EntryCell)), FontAttributes = FontAttributes.Bold };
            
            var bottom = new Image() { Source = "about me.png" };
            var bottom2 = new Image() { Source = "" };
            lbl_aboutme.GestureRecognizers.Add(new TapGestureRecognizer {
                Command = new Command((obj) => {
                    lbl_aboutme.TextColor = Color.FromHex("F5A623");
                    lbl_mydoo.TextColor = Color.FromHex("9B9B9B");
                    bottom.Source = "about me.png";
                    bottom.Margin = new Thickness(0, 0, 0, 0);
                    bottom2.Source = "";
                    bottom2.Margin = new Thickness(0, 0, 0, 0);
                })
            });
            lbl_mydoo.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command((obj) => {
                    lbl_mydoo.TextColor = Color.FromHex("F5A623");
                    lbl_aboutme.TextColor = Color.FromHex("9B9B9B");
                    bottom.Source = "upcoming-doo.png";
                    bottom.Margin = new Thickness(-30, -10, 0, 0);
                    bottom2.Source = "past-doo.png";
                    bottom2.Margin = new Thickness(-10, 20, 0, 0);
                })
            });
            lbl_aboutme.TextColor = Color.FromHex("F5A623");
            lbl_mydoo.TextColor = Color.FromHex("9B9B9B");
            segmentLayout.Children.Add(lbl_aboutme); 
            segmentLayout.Children.Add(lbl_mydoo);
            segmentLayout.BackgroundColor = Color.FromHex("FFF4E7");
            mainlayout.Children.Add(segmentLayout);

            mainlayout.Children.Add(bottom);
            mainlayout.Children.Add(bottom2);
            contentPage.Content = mainlayout;

            return contentPage;
        }

        ContentPage SetDooPage(){
            var contentPage = new ContentPage();
            contentPage.Icon = "doo.png";
            contentPage.Title = "Doo";
            var mainlayout = new StackLayout() { VerticalOptions = LayoutOptions.Fill };
            mainlayout.Children.Add(new Image() { Source = "doo-page.png" });

            contentPage.Content = mainlayout;
            return contentPage;
        }

        ContentPage SetWePage(){
            var contentPage = new ContentPage();
            contentPage.Icon = "we.png";
            contentPage.Title = "We";
            var mainlayout = new StackLayout() { VerticalOptions = LayoutOptions.Fill };
            mainlayout.Children.Add(new Image() { Source = "we-page.png" });

            contentPage.Content = mainlayout;
            return contentPage;
        }

        void SetToolbarItem() {
            var appointmentItem = new ToolbarItem
            {
                ClassId = "Calendar",
                Icon = "Icons/ic_calendar_white.png",
                Order = ToolbarItemOrder.Primary
            };
            appointmentItem.Clicked += OnMenuItemClicked;

            var notificationItem = new ToolbarItem
            {
                ClassId = "Notification",
                Icon = "Icons/ic_notification.png",
                Order = ToolbarItemOrder.Primary
            };
            notificationItem.Clicked += OnMenuItemClicked;

            ToolbarItems.Add(appointmentItem);
            ToolbarItems.Add(notificationItem);
        }

        void OnMenuItemClicked(object sender, EventArgs e)
        {
            var toolbarItem = sender as ToolbarItem;


        }
    }
}

