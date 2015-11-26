using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessTheGames.Models
{
    public class Pick
    {

        public Pick(int id, int user_id, int game_id, int pick)
        {
            this.id = id;
            this.user_id = user_id;
            this.game_id = game_id;
            /* the pick property is the users pick:
             * if user chooses 0 it means he chooses draw
             * if user chooses 1 it means he think the home team wins
             * if user chooses 2 it means he thinks the away team wins */
            this.pick = pick; 
        }

        public int id { get; set; }

        public int user_id { get; set; }

        public int game_id { get; set; }

        //making sure the value of pick cant be higher than 2 or below 0
        public int pick
        {
            get;
            set
            {
                if (value > 2)
                {
                    value = 2;
                } else if (value < 0)
                {
                    value = 0;
                }
            }
        }





    }
}