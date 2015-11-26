using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessTheGames.Models
{
    public class Playerleague
    {

        List<User> players;

        public Playerleague(int id, User owner, string leaguename, int season_id)
        {
            this.id = id;
            this.owner = owner;
            this.leaguename = leaguename;
            this.season_id = season_id;

            // creating the list with the owner in it
            players = new List<User>{owner};

        }

        public int id { get; set; }

        public User owner { get; set; }

        public string leaguename { get; set; }

        //wondering if the season "id" should be a list of seasons where the league existed
        public int season_id { get; set; }

        
        // might need to be the id as input and then it finds a player
        public void AddPlayer(User player)
        {
            // we don't want duplicates
            if(!players.Contains(player))
            {
                players.Add(player);
            }
        }

        // might need to be id as input and then it finds the player
        public void RemovePlayer(User player)
        {
            if(players.Contains(player))
            {
                players.Remove(player);
            }
        }
    }
}