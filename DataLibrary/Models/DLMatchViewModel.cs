using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class DLMatchViewModel
    {
        public int Id { get; set; }
        public int KampId { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string EventType { get; set; }
        public string Modstander { get; set; }
        public string KampDato { get; set; }
    }
}
