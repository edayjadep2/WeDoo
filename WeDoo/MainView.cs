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
            this.Children.Add(SetWePage());
            this.Children.Add(new ContentPage
            {
                Title = "We",
                Icon = "we.png",
                Content = new StackLayout
                {
                    Children = {
                    new BoxView { Color = Color.Blue },
                    new BoxView { Color = Color.Red}
                }
                }
            });
            this.Children.Add(new ContentPage
            {
                Title = "Doo",
                Icon = "doo.png",
                Content = new StackLayout
                {
                    Children = {
                    new BoxView { Color = Color.Blue },
                    new BoxView { Color = Color.Red}
                }
                }
            });

        }

        ContentPage SetWePage() {
            var contentPage = new ContentPage();
            contentPage.Icon = "me.png";
            contentPage.Title = "Eric";
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

