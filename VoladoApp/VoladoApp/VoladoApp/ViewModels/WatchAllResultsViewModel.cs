using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VoladoApp.Models;
using Xamarin.Forms;

namespace VoladoApp.ViewModels
{
    public class WatchAllResultsViewModel : BaseViewModel
    {
        private ObservableCollection<ResultsFromDataBase> allResults;
        public ObservableCollection<ResultsFromDataBase> AllResults
        {
            get => allResults;
            set => SetProperty(ref allResults, value);
        }

        public WatchAllResultsViewModel()
        {
            AllResults = new ObservableCollection<ResultsFromDataBase>();
        }

        public async Task GetResults()
        {
            AllResults.Clear();

            var results = await App.Database.GetItemsAsync();
            foreach (var item in results)
            {
                var data = JsonConvert.DeserializeObject<List<Person>>(item.AllPeople);
                var list = new ObservableCollection<Person>();

                foreach (var person in data)
                {
                    list.Add(person);
                }
                AllResults.Add(new ResultsFromDataBase { Winner = item.Winner, AllPeople = list , Height = (list.Count * 40) + (list.Count * 10), Result = item});
            }

            if(AllResults.Count > 0)
            {
                MessagingCenter.Send(this, "lottie", false);
            }
            else
            {
                MessagingCenter.Send(this, "icon", true);
            }
        }

        public ICommand DeleteCommand => new Command(async (item) =>
        {
            var data = (ResultsFromDataBase)item;

            await App.Database.DeleteItemAsync(data.Result);
            //await GetResults();
            AllResults.Remove(data);

            if (AllResults.Count > 0)
            {
                MessagingCenter.Send(this, "lottie", false);
            }
            else
            {
                MessagingCenter.Send(this, "lottie", true);
            }
        });
    }
}
