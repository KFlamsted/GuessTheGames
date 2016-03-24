using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuessTheGames.Models;
using Npgsql;
using System.Data;

namespace GuessTheGames.Services
{
    public class PlayerLeagueServices
    {

       //get all playerleagues
        public List<Playerleague> GetAllPlayerleagues()
        {
            List<Playerleague> playerleagues = new List<Playerleague>();

            //getting all playerleagues in the DB
            string sqlstring = "SELECT * FROM playerleagues;";
            playerleagues = ReadFromDB(sqlstring);

            return playerleagues; 

        }

        //get player league from id
        public Playerleague GetLeagueFromId (int id)
        {
            List<Playerleague> playerleagues = new List<Playerleague>();

            //getting all playerleagues in the DB
            string sqlstring = "SELECT * FROM playerleagues WHERE id = '" + id + "';";
            playerleagues = ReadFromDB(sqlstring);

            return playerleagues[0]; //there should only be one in the list
        }

        //get one players league where he is owner
        public List<Playerleague> GetLeagueWhereOwner(int user_id)
        {
            List<Playerleague> playerleagues = new List<Playerleague>();

            //getting all playerleagues in the DB
            string sqlstring = "SELECT * FROM playerleagues WHERE owner_id = '" + user_id + "';";
            playerleagues = ReadFromDB(sqlstring);

            return playerleagues;
        }

        //get all leagues in a season
        public List<Playerleague> GetLeagueFromSeason(int season_id)
        {
            List<Playerleague> playerleagues = new List<Playerleague>();

            //getting all playerleagues in the DB
            string sqlstring = "SELECT * FROM playerleagues WHERE season_id = '" + season_id + "';";
            playerleagues = ReadFromDB(sqlstring);

            return playerleagues;
        }
        
        //get league by name
        public Playerleague GetLeagueFromName(string leaguename)
        {
            List<Playerleague> playerleagues = new List<Playerleague>();

            //getting all playerleagues in the DB
            string sqlstring = "SELECT * FROM playerleagues WHERE name = '" + leaguename + "';";
            playerleagues = ReadFromDB(sqlstring);

            return playerleagues[0]; //there should only be one in the list
        }

        //get all leagues a user is attending
        public List<Playerleague> GetLeaguesFromUser(int user_id)
        {
            List<Playerleague> playerleagues = new List<Playerleague>();

            //getting all playerleagues in the DB
            string sqlstring = "SELECT * FROM playersleagues AS pl INNER JOIN user_in_playerleague AS u_in_pl ON pl.id = u_in_pl.playerleague_id WHERE user_id = '" + user_id + "' ORDER BY season_id DESC;";
            playerleagues = ReadFromDB(sqlstring);

            return playerleagues;
        }
        
        
        // having a connecting to DB function with the sqlstring as input
        private List<Playerleague> ReadFromDB(string sqlstring)
        {
            List<Playerleague> playerleagues = new List<Playerleague>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=reader;Password=hej123;Database=guessthegame;");
            try
            {
                //connecting to the database
                conn.Open();

                // defining the sql npgsql command
                NpgsqlCommand command = new NpgsqlCommand(sqlstring, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                Playerleague tempPlayerleague;
                User tempUser;
                UserServices us = new UserServices();

                //reading all the users.
                while (dr.Read())
                {
                    tempUser = us.GetUser(dr.GetInt32(1)); //as the input into playerleague is user and not user id, we need to find the user
                    tempPlayerleague = new Playerleague(dr.GetInt32(0), tempUser, dr.GetString(3), dr.GetInt32(2));
                    playerleagues.Add(tempPlayerleague);
                }
            }
            catch (Exception msg)
            {
                //do something if exception
                System.Diagnostics.Debug.WriteLine(msg.ToString());
            }
            finally
            {
                conn.Close();
            }

            return playerleagues;
        }
    }
}