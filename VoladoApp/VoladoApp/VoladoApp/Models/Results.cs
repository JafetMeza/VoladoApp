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

        public string Winner { get; set; }
        public string AllPeople { get; set; }
    }
}
