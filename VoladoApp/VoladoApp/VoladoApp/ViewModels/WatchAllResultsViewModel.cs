using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VoladoApp.Models;
using Xamarin.Forms;

namespace VoladoApp.ViewModels
{
    public class WatchAllResultsViewModel : BaseViewModel
    {
        public enum Position
        {
            Show,
            Hide
        }
        private Position position { get; set; }

        private ObservableCollection<ResultsFromDataBase> allResults;
        public ObservableCollection<ResultsFromDataBase> AllResults
        {
            get => allResults;
            set => SetProperty(ref allResults, value);
        }

        private bool isVisible = false;
        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }

        public WatchAllResultsViewModel()
        {
            AllResults = new ObservableCollection<ResultsFromDataBase>();
            position = Position.Hide;
            IsVisible = false;
        }

        public async Task GetResults()
        {
            var results = await App.Database.GetItemsAsync();
            foreach (var item in results)
            {
                var data = JsonConvert.DeserializeObject<List<Person>>(item.AllPeople);
                var list = new ObservableCollection<Person>();
                foreach (var person in data)
                {
                    list.Add(person);
                }
                AllResults.Add(new ResultsFromDataBase { Winner = item.Winner, AllPeople = list });
            }
        }

        public ICommand WatchAllPeopleCommand => new Command(() =>
        {
            //ARREGLAR ESTA COSA
            switch (position)
            {
                case Position.Hide:
                    IsVisible = false;
                    break;

                case Position.Show:
                    IsVisible = true;
                    break;
            }
        });
    }
}
