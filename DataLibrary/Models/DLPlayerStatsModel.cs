using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class DLPlayerStatsModel
    {
        public int PlayerId { get; set; }
        public int Attempts { get; set; }
        public int Goals { get; set; }
        public int KeeperSaves { get; set; }
        public int Assists { get; set; }
        public int Mins2 { get; set; }
        public int Gulekort { get; set; }
        public int Roedekort { get; set; }
        public string Tidspunkt { get; set; }
        public int KampId { get; set; }
        public string KampDato { get; set; }

    }
}
