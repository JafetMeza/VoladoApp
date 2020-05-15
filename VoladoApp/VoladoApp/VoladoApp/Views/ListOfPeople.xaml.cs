using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoladoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VoladoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfPeople : ContentPage
    {
        private const int timeAnimation = 500;
        private bool touched = false;

        public ListOfPeople()
        {
            InitializeComponent();
            sendButton.IsEnabled = false;
            sendData.Opacity = 0;
            sendData.IsVisible = false;
            firstImage.IsVisible = true;

            myEntry.Completed += MyEntry_Completed;

            MessagingCenter.Subscribe<ListOfPeopleViewModel, bool>(this, "lottie", async (sender, args) =>
            {
                if(args)
                {
                    //Borrar Lottie
                    collectionView.Opacity = 0;
                    collectionView.IsVisible = true;
                    var animationLottie = lottie.FadeTo(0, timeAnimation, Easing.Linear);
                    var animation = collectionView.FadeTo(1, timeAnimation, Easing.Linear);

                    await Task.WhenAny(animationLottie, animation);
                    lottie.IsVisible = false;
                    lottie.Opacity = 1;
                }
                else
                {
                    //Poner Lottie
                    lottie.Opacity = 0;
                    lottie.IsVisible = true;
                    var animationLottie = lottie.FadeTo(1, timeAnimation, Easing.Linear);
                    var animation = collectionView.FadeTo(0, timeAnimation, Easing.Linear);

                    await Task.WhenAny(animationLottie, animation);
                    collectionView.IsVisible = false;
                    collectionView.Opacity = 1;
                }
            });
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                sendButton.IsEnabled = false;
            }
            else
            {
                sendButton.IsEnabled = true;
            }
        }

        private async Task HideEntry()
        {
            if (touched)
            {
                var widht = ImageFrame.WidthRequest;
                ImageFrame.Animate("reduce",
                    percent =>
                    {
                        var change = widht * percent;
                        var newChange = widht - change;
                        if (newChange > 40)
                            ImageFrame.WidthRequest = widht - change;
                    }, 0, timeAnimation, easing: Easing.Linear);

                var imageAnimation = firstImage.FadeTo(1, 300, Easing.Linear);
                var gridAnimation = sendData.FadeTo(0, 300, Easing.Linear);

                firstImage.IsVisible = true;
                await Task.WhenAny(imageAnimation, gridAnimation);
                sendData.IsVisible = false;

                touched = false;
            }
        }

        private async Task ExpandEntry()
        {
            if (!touched)
            {
                var widht = this.Width;
                ImageFrame.Animate("expand",
                    percent =>
                    {
                        var change = (widht - 20) * percent;
                        if (change > 50)
                            ImageFrame.WidthRequest = change;
                    }, 0, 600, easing: Easing.Linear);

                var imageAnimation = firstImage.FadeTo(0, 100, Easing.Linear);
                var gridAnimation = sendData.FadeTo(1, 100, Easing.Linear);

                sendData.IsVisible = true;
                await Task.WhenAny(imageAnimation, gridAnimation);
                firstImage.IsVisible = false;
                myEntry.Focus();

                touched = true;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!touched)
            {
                await ExpandEntry();
            }
        }

        private async void firstImage_Clicked(object sender, EventArgs e)
        {
            await ExpandEntry();
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await HideEntry();
        }

        private async void sendButton_Clicked(object sender, EventArgs e)
        {
            await HideEntry();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await HideEntry();
        }

        private async void MyEntry_Completed(object sender, EventArgs e)
        {
            await HideEntry();
            var vm = BindingContext as ListOfPeopleViewModel;
            vm.OnSendPeopleCommand();
        }
    }
}