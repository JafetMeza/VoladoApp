using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace VoladoApp.Models
{
    public class Person
    {
        [MaxLength(15)]
        public string NickName { get; set; }
    }
}
