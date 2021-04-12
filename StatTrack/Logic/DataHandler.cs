using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataLibrary.Logic.ClubProcessor;
using StatTrack.Models;
using DataLibrary;
using DataLibrary.Logic;

namespace StatTrack.Logic
{
    public class DataHandler
    {
        public DataHandler()
        {

        }

        public List<ClubModel> getClubs()
        {
            var data = LoadClubs();
            List<ClubModel> clubs = new List<ClubModel>();

            foreach (var item in data)
            {
                clubs.Add(new ClubModel()
                {
                    Id = item.Id,
                    Initials = item.Initials,
                    Name = item.Name,
                    Address = item.Address,
                    Postal = item.Postal,
                    City = item.City
                });
            }

            return clubs;
        }

        public List<string> GetLeagues()
        {
            List<string> leagues = new List<string>();
            leagues.Add("Liga");
            leagues.Add("1. Div");
            leagues.Add("2. Div");
            leagues.Add("3. Div");
            leagues.Add("Niveaustævne");
            leagues.Add("Turnering");
            return leagues;
        }

        public List<string> getYears()
        {
            List<string> uYearsNames = new List<string>();
            uYearsNames.Add("Senior");
            uYearsNames.Add("Oldies");
            uYearsNames.Add("U19");
            uYearsNames.Add("U17");
            uYearsNames.Add("U15");
            uYearsNames.Add("U13");
            uYearsNames.Add("U11");
            uYearsNames.Add("U10");
            uYearsNames.Add("U9");
            uYearsNames.Add("U8");
            uYearsNames.Add("U7");
            uYearsNames.Add("U6");
            uYearsNames.Add("U5");
            uYearsNames.Add("U4");

            return uYearsNames;
        }

        /*
         * Positioner:
         * Målvogter
         * Højrefløj
         * Venstrefløj
         * Højreback
         * Venstreback
         * Playermaker
         * Stregspiller
         */
    }
}
