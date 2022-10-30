using ADSB_Image_Recommender.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ADSB_Image_Recommender.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}