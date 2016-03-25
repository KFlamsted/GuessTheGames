using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessTheGames.Models
{
    public class Game
    {

        public Game(int id, Round round_id, Team team1, Team team2, DateTime planned_date)
        {
            this.id = id;
            this.round_id = round_id;
            this.team1 = team1;
            this.team2 = team2;
            this.planned_date = planned_date;

            //wondering if games should've been played when being defined
            game_played = false;
            result = -1;
        }

        public int id { get; set; }

        public Round round_id { get; set; }

        public Team team1 { get; set; }

        public Team team2 { get; set; }

        public DateTime planned_date {get; set;}

        public bool game_played { get; set; }

        // before this result can have a value, the game have has to be played(i.e. the game_played bool need to be true).
        public int result 
        { 
            get
            {
                return result;
            }
            set
            {
                //if the game haven't been played then the value should be set to -1, might not be the best solution
                if (!game_played)
                {
                    value = -1;
                }
                else
                {
                    // making sure that the value is inbetween 0 & 2
                    if (value > 2)
                    {
                        value = 2;
                    }
                    else if (value < 0)
                    {
                        value = 0;
                    }
                }
            }
        }

        //method for when a game has been played; making sure the boolean changes first
        public void GamePlayed(int result)
        {
            game_played = true;
            this.result = result;
        }
    }
}