using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ADSB_Image_Recommender.Views
{
    public class SportsStatic : ContentPage
    {
        public SportsStatic(int num)

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

            Image img1 = new Image { Source = "soccer.png" };
            Image img2 = new Image { Source = "blank.png" };
            Image img3 = new Image { Source = "blank.png" };
            Image img4 = new Image { Source = "blank.png" };

            if (num >= 2)
            {
                img2.Source = "swimming.png";
            }
            if (num >= 3)
            {
                img3.Source = "football.png";
            }
            if (num >= 4)
            {
                img4.Source = "tennis.png";
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
            Title = "Static Sports Images";
            Content = new StackLayout
            {
                Margin = new Thickness(16),
                Children = { scrollView }
            };
        }
    }
}