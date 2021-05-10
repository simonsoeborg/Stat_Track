using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class DLGameDataModel
    {
        public int KampId { get; set; }
        public string CreatorID { get; set; }
        public int CreatorTeamId { get; set; }
        public string Modstander { get; set; }
        public string KampDato { get; set; }
        public int CreatorTeamGoals { get; set; }
        public int ModstanderGoals { get; set; }
    }
}
