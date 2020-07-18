﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {

        /// <summary>
        /// The unique id that represents each Matchup Entry. 
        /// </summary>
        public int id { get; set; }

       
        /// <summary>
        /// The unique identifier for the team
        /// </summary>
        public int TeamCompetingId { get; set; }

        /// <summary>
        /// Represents one team in the matchup. 
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// Represents the score for this particular team. 
        /// </summary>
       
        public double Score { get; set; }

        /// <summary>
        /// The unique identifier for the parent matchup (team).
        /// </summary>
        public int ParentMatchupId { get; set; }


        /// <summary>
        /// Represents the matchup that this team came
        /// from as the winner. 
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialScore">
       
        
        
      
    }
}
