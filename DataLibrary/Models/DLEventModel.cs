using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class DLEventModel
    {
        public string EventType { get; set; }
        public int PlayerId { get; set; }
        public string Time { get; set; }
        public int KampId { get; set; }
    }
}
