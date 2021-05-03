﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ClubId { get; set; }

        public string CreatorId { get; set; }

        public string TeamUYear { get; set; }
        public string Division { get; set; }
   
    }
}
