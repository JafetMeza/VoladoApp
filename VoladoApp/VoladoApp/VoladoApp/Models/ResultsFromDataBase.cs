using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VoladoApp.Models
{
    public class ResultsFromDataBase
    {
        public string Winner { get; set; }
        public ObservableCollection<Person> AllPeople { get; set; }
        public int Height { get; set; }
        public Results Result { get; set; }
    }
}
