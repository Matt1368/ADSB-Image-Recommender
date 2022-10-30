using ADSB_Image_Recommender.ViewModels;
using ADSB_Image_Recommender.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ADSB_Image_Recommender
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
