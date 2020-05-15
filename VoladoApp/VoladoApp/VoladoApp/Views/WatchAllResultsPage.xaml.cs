using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoladoApp.Services;
using VoladoApp.ViewModels;
using VoladoApp.Views.Pruebas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VoladoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatchAllResultsPage : ContentPage
    {
        public WatchAllResultsPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<WatchAllResultsViewModel, bool>(this, "lottie", (sender, args) =>
            {
                if (args)
                {
                    lottieGrid.IsVisible = true;
                    lottie.Loop = true;
                    lottie.Play();
                    collectionView.IsVisible = false;
                    icon.IsVisible = false;
                }
                else
                {
                    lottieGrid.IsVisible = false;
                    collectionView.IsVisible = true;
                    icon.IsVisible = false;
                }
            });

            MessagingCenter.Subscribe<WatchAllResultsViewModel>(this, "icon", (sender) =>
            {
                icon.IsVisible = true;
                lottie.IsVisible = false;
                collectionView.IsVisible = false;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as WatchAllResultsViewModel;
            vm.GetResults().FireAndForget();
        }
    }
}