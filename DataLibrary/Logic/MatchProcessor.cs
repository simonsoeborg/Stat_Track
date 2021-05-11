using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;


namespace DataLibrary.Logic
{
    public class MatchProcessor
    {
        public static List<DLGameDataModel> LoadMatches(string userID)
        {
            // Indputtet userId her sørger for at kun dine egne oprettede hold bliver vist.
            string query = @"SELECT * FROM KampData WHERE CreatorID = '" + userID + "';";


            return SqlDataAccess.GetData<DLGameDataModel>(query);
        }


        public static List<DLMatchViewModel> LoadSpecifiMatchView (int MatchId)
        {
            string query = @"SELECT t.Name, e.Time, e.EventType, k.Modstander, k.KampDato 
                            FROM EventData e 
                            INNER JOIN TeamPlayer t ON e.PlayerId = t.Id
                            INNER JOIN KampData k ON e.KampId = k.KampId
                            WHERE k.KampId = '" + MatchId + "' ORDER BY e.Time DESC;";
            return SqlDataAccess.GetData<DLMatchViewModel>(query);
        }

    }
}
