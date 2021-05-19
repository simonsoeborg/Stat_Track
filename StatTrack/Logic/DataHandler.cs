using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Logic;
using StatTrack.Models;
using static DataLibrary.Logic.ClubProcessor;
using static DataLibrary.Logic.TeamProcessor;
using static DataLibrary.Logic.PlayerProcessor;
using static DataLibrary.Logic.PlayerStatsProcessor;
using TeamPlayerModel = DataLibrary.Models.TeamPlayerModel;

namespace StatTrack.Logic
{
    public class DataHandler
    {
        public static int GameId;

        public List<ClubModel> getClubs()
        {
            var data = LoadClubs();
            var clubs = new List<ClubModel>();

            foreach (var item in data)
                clubs.Add(new ClubModel
                {
                    Id = item.Id,
                    Initials = item.Initials,
                    Name = item.Name,
                    Address = item.Address,
                    Postal = item.Postal,
                    City = item.City
                });

            return clubs;
        }


        public List<string> GetLeagues()
        {
            var leagues = new List<string>();
            leagues.Add("Håndboldligaen");
            leagues.Add("1. Div");
            leagues.Add("2. Div");
            leagues.Add("3. Div");
            leagues.Add("Kvalifikationsrækken");
            leagues.Add("Jyllandsserien");
            leagues.Add("Fynsserien");
            leagues.Add("Serie 1");
            leagues.Add("Serie 2");
            leagues.Add("Serie 3");
            leagues.Add("Serie 4");
            leagues.Add("Niveaustævne");
            leagues.Add("Turnering");
            return leagues;
        }

        public List<string> getYears()
        {
            var uYearsNames = new List<string>();
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

        public List<string> getPositions()
        {
            var playerPositions = new List<string>();
            playerPositions.Add("Målvogter");
            playerPositions.Add("Højrefløj");
            playerPositions.Add("Venstrefløj");
            playerPositions.Add("Højreback");
            playerPositions.Add("Venstreback");
            playerPositions.Add("Playermaker");
            playerPositions.Add("Stregspiller");
            return playerPositions;
        }

        public string getTeamName(int teamId)
        {
            var teamModelData = GetTeam(teamId);

            var team = new List<TeamModel>();

            foreach (var item in teamModelData)
            {
                team.Add(new TeamModel
                {
                    Name = item.Name,
                    ClubId = item.ClubId,
                    CreatorId = item.CreatorId,
                    Division = item.Division,
                    TeamUYear = item.TeamUYear,
                    Id = item.Id
                });
                ;
            }

            return team[0].Name;
        }

        public TeamModel getTeamModel(int teamId)
        {
            var teamModelData = GetTeam(teamId);

            var team = new List<TeamModel>();

            foreach (var item in teamModelData)
            {
                team.Add(new TeamModel
                {
                    Name = item.Name,
                    ClubId = item.ClubId,
                    CreatorId = item.CreatorId,
                    Division = item.Division,
                    TeamUYear = item.TeamUYear,
                    Id = item.Id
                });
                ;
            }

            return team.FirstOrDefault();
        }

        public ClubModel getClub(int clubId)
        {
            var clubModelView = GetClub(clubId);

            var club = new List<ClubModel>();

            foreach (var item in clubModelView)
            {
                club.Add(new ClubModel
                {
                    Name = item.Name,
                    Initials = item.Initials,
                    Address = item.Address,
                    Postal = item.Postal,
                    City = item.City,
                    Id = item.Id
                });
                ;
            }

            return club.FirstOrDefault();
        }

        public List<TeamPlayerModel> GetAllPlayersFromAllTeams()
        {
            var userId = TeamController.GetCurrentUser;
            var teams = LoadTeams(userId);
            var AllPlayers = new List<TeamPlayerModel>();
            foreach (var team in teams)
            foreach (var player in LoadAllUsersPlayers(team.Id))
                AllPlayers.Add(player);

            return AllPlayers;
        }

        public List<PlayerStatsModel> GetCurrentSeasonPlayerStats(int playerId)
        {
            var currentSeasonData = PlayerStatsProcessor.GetCurrentSeasonPlayerStats(playerId);

            var myData = new List<PlayerStatsModel>();

            foreach (var item in currentSeasonData)
                myData.Add(new PlayerStatsModel
                {
                    PlayerId = item.PlayerId,
                    Attempts = item.Attempts,
                    Goals = item.Goals,
                    KeeperSaves = item.KeeperSaves,
                    Mins2 = item.Mins2,
                    Yellowcards = item.Gulekort,
                    Redcards = item.Roedekort,
                    Assists = item.Assists,
                    KampId = item.KampId,
                    KampDato = item.KampDato
                });
            return myData;
        }

        public List<PlayerStatsModel> GetOverAllPlayerStats(int playerId)
        {
            var overAllData = GetOverallPlayerStats(playerId);

            var myData = new List<PlayerStatsModel>();

            foreach (var item in overAllData)
                myData.Add(new PlayerStatsModel
                {
                    PlayerId = item.PlayerId,
                    Attempts = item.Attempts,
                    Goals = item.Goals,
                    KeeperSaves = item.KeeperSaves,
                    Mins2 = item.Mins2,
                    Yellowcards = item.Gulekort,
                    Redcards = item.Roedekort,
                    Assists = item.Assists,
                    KampId = item.KampId,
                    KampDato = item.KampDato
                });
            return myData;
        }

        public async Task<int> checkForGameId()
        {
            while (GameId == 0) await Task.Delay(500);

            return GameId;
        }
    }
}