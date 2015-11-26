using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessTheGames.Models
{
    public class Team
    {

        public Team(int id, string teamname)
        {
            this.id = id;
            this.teamname = teamname;
        }

        public int id { get; set; }

        public string teamname { get; set; }

    }
}