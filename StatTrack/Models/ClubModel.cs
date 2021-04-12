using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Models
{
    public class ClubModel
    {
        public int Id { get; set; }

        [Display(Name = "Forkortelse for klubnavn")]
        [Required(ErrorMessage = "Der skal indtastes en forkortelse")]
        public string Initials { get; set; }
        
        [Display(Name = "Klub")]
        [Required(ErrorMessage = "Der skal indtastes et klubnavn")]
        public string Name { get; set; }
        
        public string Address { get; set; }

        public int Postal { get; set; }

        public string City { get; set; }
    }
}
