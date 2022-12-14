using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ADSB_Image_Recommender.Views
{
    public class AnimalStatic : ContentPage
    {
        public AnimalStatic(int num)
        {
            Label lbl1 = new Label();
            lbl1.Text = "Image 1:";
            lbl1.FontSize = 20;
            lbl1.TextColor = Color.Gray;

            Label lbl2 = new Label();
            lbl2.Text = "Image 2:";
            lbl2.FontSize = 20;
            lbl2.TextColor = Color.Gray;

            Label lbl3 = new Label();
            lbl3.Text = "Image 3:";
            lbl3.FontSize = 20;
            lbl3.TextColor = Color.Gray;

            Label lbl4 = new Label();
            lbl4.Text = "Image 4:";
            lbl4.FontSize = 20;
            lbl4.TextColor = Color.Gray;

            Image img1 = new Image { Source = "lion.png" };
            Image img2 = new Image { Source = "blank.png" };
            Image img3 = new Image { Source = "blank.png" };
            Image img4 = new Image { Source = "blank.png" };

            if (num >= 2)
            {
                img2.Source = "squirrel.png";
            }
            if (num >= 3)
            {
                img3.Source = "bird.png";
            }
            if (num >= 4)
            {
                img4.Source = "duck.png";
            }
            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                    { lbl1, img1, lbl2, img2, lbl3, img3, lbl4, img4


                    }
                }
            };
            Title = "Static Animal Images";
            Content = new StackLayout
            {
                Margin = new Thickness(16),
                Children = { scrollView }
            };
        }
    }
}