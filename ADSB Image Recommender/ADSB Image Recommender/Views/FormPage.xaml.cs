using ADSB_Image_Recommender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADSB_Image_Recommender.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using System.Net.Mail;

namespace ADSB_Image_Recommender.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1
        : ContentPage
    {
        FormContents _viewModel;
        public Page1()
        {
            InitializeComponent();

        }
        
        String messageProvider(String type, String topic, int num)
        {
            string[] animalStaticList = { "https://www.pexels.com/photo/close-up-portrait-of-lion-247502/", "https://www.pexels.com/photo/brown-squirrel-47547/", "https://www.pexels.com/photo/photo-of-perched-parakeet-1661179/", "https://www.pexels.com/photo/duckling-on-black-soil-during-daytime-162140/" };
            string[] animalGIFList = { "https://giphy.com/gifs/bbc-cute-bear-3oeHLrjZGBgnPx5VII", "https://giphy.com/gifs/perfect-loops-zlVf2eSgXIFFuTnEhz", "https://giphy.com/gifs/cute-hi-bulldog-Xev2JdopBxGj1LuGvt", "https://giphy.com/gifs/reactiongifs-h55EUEsTG9224" };
            string[] foodStaticList = { "https://www.pexels.com/photo/close-up-photo-of-a-burrito-461198/", "https://www.pexels.com/photo/close-up-photo-of-biryani-dish-1624487/", "https://www.pexels.com/photo/pancake-with-sliced-strawberry-376464/", "https://www.pexels.com/photo/close-up-photo-of-a-cheese-burger-1633578/" };
            string[] foodGIFList = { "https://giphy.com/gifs/pizza-birth-lion-king-m225vjrXFvEevNormi", "https://giphy.com/gifs/90s-eSQKNSmg07dHq", "https://giphy.com/gifs/food-thanksgiving-martin-EDV30lQQ9VW5q", "https://giphy.com/gifs/abcnetwork-abc-the-goldbergs-UW7uOP9uqWJ7V9w4GR" };
            string[] sportsStaticList = { "https://www.pexels.com/photo/soccer-ball-on-grass-field-during-daytime-46798/", "https://www.pexels.com/photo/person-swimming-on-body-of-water-863988/", "https://www.pexels.com/photo/football-player-carrying-brown-football-1618269/", "https://www.pexels.com/photo/ball-court-design-game-209977/" };
            string[] sportsGIFList = { "https://giphy.com/gifs/nfl-sports-football-sport-O92aG78R1YDBykkl1n", "https://giphy.com/gifs/actionaliens-viceland-action-bronson-friends-watch-ancient-aliens-l2SqcPdEf9DYMGGRi", "https://giphy.com/gifs/filmeditor-mean-girls-movie-3otPorZ08nPuaZfoeA", "https://giphy.com/gifs/basketball-win-QqMKFi59zy4Qo" };
            string[] natureStaticList = { "https://www.pexels.com/photo/person-walking-between-green-forest-trees-15286/", "https://www.pexels.com/photo/scenic-view-of-snow-capped-mountains-during-night-3408744/", "https://www.pexels.com/photo/photo-of-coconut-trees-on-seashore-1591373/", "https://www.pexels.com/photo/silhoutte-of-a-man-2923595/" };
            string[] natureGIFList = { "https://giphy.com/gifs/wilderpeople-hunt-for-the-wilderpeople-orchard-3o6ZtluYTKJeXXqt8s", "https://giphy.com/gifs/12qHWnTUBzLWXS", "https://giphy.com/gifs/loop-plant-grow-DYGbtrltNhHVX7xZTk", "https://giphy.com/gifs/stars-star-12zyJFTYPuMQI8" };
            String message = ""; 
            if(type == "Static" && topic == "Animals")
            {
                for (int i = 0; i< num; i++)
                {
                    message += animalStaticList[i] + "\n";
                }
            }
            if (type == "Gif" && topic == "Animals")
            {
                for (int i = 0; i < num; i++)
                {
                    message += animalGIFList[i] + "\n";
                }
            }
            if (type == "Static" && topic == "Food")
            {
                for (int i = 0; i < num; i++)
                {
                    message += foodStaticList[i] + "\n";
                }
            }
            if (type == "Gif" && topic == "Food")
            {
                for (int i = 0; i < num; i++)
                {
                    message += foodGIFList[i] + "\n";
                }
            }
            if (type == "Static" && topic == "Sports")
            {
                for (int i = 0; i < num; i++)
                {
                    message += sportsStaticList[i] + "\n";
                }
            }
            if (type == "Gif" && topic == "Sports")
            {
                for (int i = 0; i < num; i++)
                {
                    message += sportsGIFList[i] + "\n";
                }
            }
            if (type == "Static" && topic == "Nature")
            {
                for (int i = 0; i < num; i++)
                {
                    message += natureStaticList[i] + "\n";
                }
            }
            if (type == "Gif" && topic == "Nature")
            {
                for (int i = 0; i < num; i++)
                {
                    message += natureGIFList[i] + "\n";
                }
            }
            return message;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (ImageTopicEntry.SelectedIndex == -1 || ImageTypeSelection.SelectedIndex == -1 || QuantityEntry.Text == null  || NameEntry.Text == null || EmailFirst.Text == null)
            {
                DisplayAlert("Image Form", "Please Fill Out All Required Fields.", "OK");
                return;
            }

            FormContents imageType = ImageTypeSelection.SelectedItem as FormContents;
            FormContents imageTopic = ImageTopicEntry.SelectedItem as FormContents;
            FormContents imageQuantity = new FormContents { ImageQunatity = Int32.Parse(QuantityEntry.Text) };
            FormContents orderName = new FormContents { RecipientName = NameEntry.Text };
            FormContents emailRecipient = new FormContents { emailFirst = EmailFirst.Text };
            FormContents emailFriend = new FormContents { emailSecond = EmailSecond.Text };

            String messageFinal = "Hi " + orderName.RecipientName + "!" + " Here are your images: \n" + messageProvider(imageType.ImageType, imageTopic.ImageTopic, imageQuantity.ImageQunatity);


            btnSend_ClickedLimited(sender, e, messageFinal, emailRecipient.emailFirst);
            DisplayAlert("Image Form", "Your Image Has Been Sent!", "OK");
        }

        void btnSend_ClickedLimited(object sender, System.EventArgs e, String message, String emailFirst)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("email-smtp.us-east-1.amazonaws.com");

                mail.From = new MailAddress("nmatthew2014@gmail.com");
                mail.To.Add(emailFirst);
                mail.Body = message;
                mail.Subject = "Images";

                SmtpServer.Port = 587;
                SmtpServer.Host = "email-smtp.us-east-1.amazonaws.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("AKIAVVGL3AEPQ7CSNABK", "BBcH7lvOyXvciZFl3RowXfB1ZuTFmH2ZU+OGHFpaG3dc");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                DisplayAlert("Faild", ex.Message, "OK");
            }
        }

        async void btnView_Clicked(object sender, EventArgs e)
        {
            FormContents imageType = ImageTypeSelection.SelectedItem as FormContents;
            FormContents imageTopic = ImageTopicEntry.SelectedItem as FormContents;
            FormContents imageQuantity = new FormContents { ImageQunatity = Int32.Parse(QuantityEntry.Text) };
            FormContents orderName = new FormContents { RecipientName = NameEntry.Text };
            FormContents emailRecipient = new FormContents { emailFirst = EmailFirst.Text };
            FormContents emailFriend = new FormContents { emailSecond = EmailSecond.Text };

            if (imageTopic.ImageTopic == "Animals" && imageType.ImageType == "Static")
            {
                await Navigation.PushAsync(new AnimalStatic(Int32.Parse(QuantityEntry.Text)));
            }
            if (imageTopic.ImageTopic == "Animals" && imageType.ImageType == "Gif")
            {
                await Navigation.PushAsync(new AnimalGIF(Int32.Parse(QuantityEntry.Text)));
            }
            if (imageTopic.ImageTopic == "Food" && imageType.ImageType == "Static")
            {
                await Navigation.PushAsync(new FoodStatic(Int32.Parse(QuantityEntry.Text)));
            }
            if (imageTopic.ImageTopic == "Food" && imageType.ImageType == "Gif")
            {
                await Navigation.PushAsync(new FoodGIF(Int32.Parse(QuantityEntry.Text)));
            }
            if (imageTopic.ImageTopic == "Sports" && imageType.ImageType == "Static")
            {
                await Navigation.PushAsync(new SportsStatic(Int32.Parse(QuantityEntry.Text)));
            }
            if (imageTopic.ImageTopic == "Sports" && imageType.ImageType == "Gif")
            {
                await Navigation.PushAsync(new SportsGIF(Int32.Parse(QuantityEntry.Text)));
            }
            if (imageTopic.ImageTopic == "Nature" && imageType.ImageType == "Static")
            {
                await Navigation.PushAsync(new NatureStatic(Int32.Parse(QuantityEntry.Text)));
            }
            if (imageTopic.ImageTopic == "Nature" && imageType.ImageType == "Gif")
            {
                await Navigation.PushAsync(new NatureGIF(Int32.Parse(QuantityEntry.Text)));
            }
        }


    }
}