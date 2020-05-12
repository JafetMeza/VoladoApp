using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VoladoApp.Models;
using VoladoApp.Views;
using Xamarin.Forms;

namespace VoladoApp.ViewModels
{
    public class ListOfPeopleViewModel : BaseViewModel
    {
        private ObservableCollection<Person> _NewPeople;
        public ObservableCollection<Person> NewPeople
        {
            get => _NewPeople;
            set => SetProperty(ref _NewPeople, value);
        }

        private string name = string.Empty;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private bool lottieVisible = false;
        public bool LottieVisible
        {
            get => lottieVisible;
            set => SetProperty(ref lottieVisible, value);
        }

        private bool isVisible = false;
        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }

        public ListOfPeopleViewModel()
        {
            NewPeople = new ObservableCollection<Person>();

            IsVisible = false;
            LottieVisible = true;
        }

        public ICommand SendPeopleCommand => new Command(() => OnSendPeopleCommand());

        private void OnSendPeopleCommand()
        {
            var person = new Person()
            {
                NickName = Name
            };

            MessagingCenter.Send(this, "lottie", true);

            NewPeople.Add(person);
            Name = string.Empty;
        }

        public ICommand EliminatePeople => new Command((item) => OnEliminatePeople(item));

        private void OnEliminatePeople(object item)
        {
            var person = item as Person;
            NewPeople.Remove(person);

            if(NewPeople.Count == 0)
            {
                MessagingCenter.Send(this, "lottie", false);
            }
        }

        public ICommand StartCommand => new Command(() => OnStartCommand());

        private void OnStartCommand()
        {
            //SELECT A RANDOM ITEM IN THE LIST
            if(NewPeople.Count > 0)
            {
                var random = new Random();
                var index = random.Next(NewPeople.Count);
                var winner = NewPeople[index];
                Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new WinnerPage(winner));
            }
        }

        public ICommand SeeResultsCommand => new Command(() => OnSeeResultsCommand());

        private void OnSeeResultsCommand()
        {
            //READ DATA BASE TO WATCH ALL THE RESULTS
            //BOTON PARA BORRAR TODO
        }
    }
}
