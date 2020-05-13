using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoladoApp.Services;
using VoladoApp.ViewModels;
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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as WatchAllResultsViewModel;
            vm.GetResults().SafeFireAndForget(false);
        }
    }
}