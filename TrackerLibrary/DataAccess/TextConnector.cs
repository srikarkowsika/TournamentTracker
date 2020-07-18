using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
using System.Xml;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;


namespace TrackerLibrary.DataAccess
{
    
    public class TextConnector : IDataConnection
    {
        // TODO - Wire up the CreatePrize for text files. 
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";
        private const string TournamentFile = "TournamentModels.csv";
        private const string MatchupFile = "MatchupModels.csv";
        private const string MatchupEntryFile = "MatchupEntryModels.csv";

        //TODO - Wire up the CreatePrize for text files.  
        public void CreatePrize(PrizeModel model)
        {
            //Load the text file and convert the text into a List<PrizeModel>

            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            //Find the max ID (using Linq queries)
            int currentId = 1;

            if(prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            //Add the new record with the new ID (max+1)
            prizes.Add(model);

            
            //Save the list<string> to the text file.
            prizes.SaveToPrizeFile(PrizesFile);


            
        }

        public void CreatePerson(PersonModel model)
        {
            //Load the text file and convert the text into a List<PrizeModel>

            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

           
            //Find the max ID (using Linq queries)
            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            //Add the new record with the new ID (max+1)
            people.Add(model);

            
            //Save the list<string> to the text file.
            people.SaveToPeopleFile(PeopleFile); 


            
        }

        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
             
        }

        public void CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);

            //Find the max ID (using Linq queries)
            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            //Add the new record with the new ID (max+1)
            teams.Add(model);

            teams.SaveToTeamFile(TeamFile);

            
        }

        public List<TeamModel> GetTeam_All()
        {
            return TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels(TeamFile, PeopleFile, PrizesFile);

            int currentId = 1;

            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            model.SaveRoundsToFile(MatchupFile, MatchupEntryFile);

            tournaments.Add(model);

            tournaments.SaveToTournamentFile(TournamentFile);

            TournamentLogic.UpdateTournamentResults(model);
        }

        public List<TournamentModel> GetTournament_All()
        {
            return TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels(TeamFile, PeopleFile, PrizesFile);
        }

        public void UpdateMatchup(MatchupModel model)
        {
            model.UpdateMatchupToFile();
        }

        public void CompleteTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels(TeamFile, PeopleFile, PrizesFile);

            tournaments.Remove(model);

            tournaments.SaveToTournamentFile(GlobalConfig.TournamentFile);

            TournamentLogic.UpdateTournamentResults(model);

        }
    }
}
