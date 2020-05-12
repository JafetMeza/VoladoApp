using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoladoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VoladoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WinnerPage : PopupPage
    {
        public WinnerPage(Person Winner)
        {
            InitializeComponent();
            winner.Text = Winner.NickName;
        }
    }
}