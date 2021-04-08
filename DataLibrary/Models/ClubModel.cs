using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class ClubModel
    {
        public int Id { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Postal { get; set; }
        public string City { get; set; }
    }
}
