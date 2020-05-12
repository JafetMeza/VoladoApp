using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoladoApp.Models
{
    public class Results 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public Person Winner { get; set; }

        public People AllPeople { get; set; }
    }
}
