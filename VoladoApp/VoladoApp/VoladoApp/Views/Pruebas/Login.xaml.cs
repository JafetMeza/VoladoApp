using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VoladoApp.Views.Pruebas
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private const int AnimationDuration = 200;

        public Login()
        {
            InitializeComponent();
            submit.Pressed += Submit_Pressed;
            submit.Released += Submit_Released;
        }

        private void Submit_Released(object sender, EventArgs e)
        {
            submit.Opacity = 1;
        }

        private void Submit_Pressed(object sender, EventArgs e)
        {
            submit.Opacity = 0.3;
        }

        private async void SelectorOption_Tapped(object sender, System.EventArgs e)
        {
            if (!(sender is View view)) return;

            var index = Grid.GetColumn(view);

            SelectorButton.TranslateTo(index * view.Width, 0, AnimationDuration, Easing.CubicInOut).FireAndForget();

            await SelectorButtonLabel.FadeTo(0, AnimationDuration / 2);
            SelectorButtonLabel.Text = index == 1 ? "New" : "Existing";
            await SelectorButtonLabel.FadeTo(1, AnimationDuration / 2);

            var revealForm = index == 0 ? LoginForm : SignupForm;
            var hideForm = revealForm == LoginForm ? SignupForm : LoginForm;
            var direction = revealForm == LoginForm ? 1 : -1;

            await Task.WhenAll(
                hideForm.TranslateTo(direction * 200, 0, AnimationDuration, Easing.SinOut),
                hideForm.FadeTo(0, AnimationDuration));

            hideForm.IsVisible = false;

            revealForm.TranslationX = -direction * 200;
            revealForm.IsVisible = true;

            await Task.WhenAll(
                revealForm.TranslateTo(0, 0, AnimationDuration, Easing.SinOut),
                revealForm.FadeTo(1, AnimationDuration));

        }
    }
}