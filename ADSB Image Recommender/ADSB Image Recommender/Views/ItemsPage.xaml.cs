using ADSB_Image_Recommender.Models;
using ADSB_Image_Recommender.ViewModels;
using ADSB_Image_Recommender.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ADSB_Image_Recommender.Views
{
    public partial class ItemsPage : ContentPage
    {
        FormPageViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new FormPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}