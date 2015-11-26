using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessTheGames.Models
{
    public class Round
    {

        // represent the round of a season; each round usually have an equal number of games
        // in daily talk it will be refered to as a week
        public Round(int id, int season_id, int round_number)
        {
            this.id = id;
            this.season_id = season_id;
            this.round_number = round_number; 

        }

        public int id { get; set; }

        public int season_id { get; set; }

        public int round_number { get; set; }
    }
}