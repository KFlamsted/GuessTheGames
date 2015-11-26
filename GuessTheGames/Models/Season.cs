using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessTheGames.Models
{
    public class Season
    {
        Dictionary<int, List<Game>> Games;

        public Season(int id, DateTime start_date, DateTime end_date)
        {
            Games = new Dictionary<int, List<Game>>();
            this.id = id;
            this.season_start_date = start_date;
            this.season_end_date = end_date;
        }

        public int id { get; set; }

        public DateTime season_start_date { get; set; }

        public DateTime season_end_date { get; set; }

        // method for adding a game to a given round
        public void AddGame(int round, Game game)
        {
            if(Games.ContainsKey(round))
            {
                Games[round].Add(game);
            } else
            {
                // if the round doesn't exist we create a new one with the list only including the game
                Games.Add(round, new List<Game>{game});
            }
        }
    }
}