﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeDoo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var mainLayout = new RelativeLayout();
            //mainLayout.Children.Add(new MyView());

            this.Content = mainLayout;
        }
    }
}
