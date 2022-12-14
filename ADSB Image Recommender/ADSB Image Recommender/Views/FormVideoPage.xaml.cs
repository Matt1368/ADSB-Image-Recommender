using ADSB_Image_Recommender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ADSB_Image_Recommender.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormVideoPage : ContentPage
    {
        public FormVideoPage()
        {
            InitializeComponent();
        }
        String messageProvider(String topic, int num)
        {
            string[] animalVideoList = { "https://www.pexels.com/photo/close-up-portrait-of-lion-247502/", "https://www.pexels.com/photo/brown-squirrel-47547/", "https://www.pexels.com/photo/photo-of-perched-parakeet-1661179/", "https://www.pexels.com/photo/duckling-on-black-soil-during-daytime-162140/" };
            string[] foodVideoList = { "https://www.pexels.com/photo/close-up-photo-of-a-burrito-461198/", "https://www.pexels.com/photo/close-up-photo-of-biryani-dish-1624487/", "https://www.pexels.com/photo/pancake-with-sliced-strawberry-376464/", "https://www.pexels.com/photo/close-up-photo-of-a-cheese-burger-1633578/" };
            string[] sportsVideoList = { "https://www.pexels.com/photo/soccer-ball-on-grass-field-during-daytime-46798/", "https://www.pexels.com/photo/person-swimming-on-body-of-water-863988/", "https://www.pexels.com/photo/football-player-carrying-brown-football-1618269/", "https://www.pexels.com/photo/ball-court-design-game-209977/" };
            string[] natureVideoList = { "https://www.pexels.com/photo/person-walking-between-green-forest-trees-15286/", "https://www.pexels.com/photo/scenic-view-of-snow-capped-mountains-during-night-3408744/", "https://www.pexels.com/photo/photo-of-coconut-trees-on-seashore-1591373/", "https://www.pexels.com/photo/silhoutte-of-a-man-2923595/" };
            String message = "";
            if (topic == "Animals")
            {
                for (int i = 0; i < num; i++)
                {
                    message += animalVideoList[i] + "\n";
                }
            }
            if (topic == "Food")
            {
                for (int i = 0; i < num; i++)
                {
                    message += foodVideoList[i] + "\n";
                }
            }
           
            if (topic == "Sports")
            {
                for (int i = 0; i < num; i++)
                {
                    message += sportsVideoList[i] + "\n";
                }
            }
           
            if (topic == "Nature")
            {
                for (int i = 0; i < num; i++)
                {
                    message += natureVideoList[i] + "\n";
                }
            }
        
            return message;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (VideoTopicEntry.SelectedIndex == -1 || VideoQuantityEntry.Text == null || VideoNameEntry.Text == null || VideoEmailFirst.Text == null)
            {
                DisplayAlert("Image Form", "Please Fill Out All Required Fields.", "OK");
                return;
            }

            FormVideoContent videoTopic = VideoTopicEntry.SelectedItem as FormVideoContent;
            FormVideoContent videoQuantity = new FormVideoContent { VideoQuantity = Int32.Parse(VideoQuantityEntry.Text) };
            FormVideoContent videoorderName = new FormVideoContent { RecipientName = VideoNameEntry.Text };
            FormVideoContent videoemailRecipient = new FormVideoContent { emailFirst = VideoEmailFirst.Text };
            FormVideoContent videoemailFriend = new FormVideoContent { emailSecond = VideoEmailSecond.Text };

            String messageFinal = "Hi " + videoorderName.RecipientName + "!" + " Here are your images: \n" + messageProvider(videoTopic.VideoTopic, videoQuantity.VideoQuantity);


            btnSend_ClickedLimited(sender, e, messageFinal, videoemailRecipient.emailFirst);
            DisplayAlert("Video Form", "Your Image Has Been Sent!", "OK");
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
    }
}