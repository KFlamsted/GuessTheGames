using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuessTheGames.Models;
using Npgsql;
using System.Data;

namespace GuessTheGames.Services
{
    public class GameServices
    {

        // get all games
        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();

            string sqlstring = "SELECT * FROM games;";
            games = ReadFromDB(sqlstring);

            return games;
        }

        // get game by id
        public List<Game> GetGameByID(int id)
        {
            List<Game> games = new List<Game>();

            string sqlstring = "SELECT * FROM games WHERE id = '" + id + "';";
            games = ReadFromDB(sqlstring);

            return games;
        }


        /*
         * TODO for games services:
         * Get all games from at specific round
         * Get all games from a team
         * Get all games from a season
         * 

         */




        // having a connecting to DB function with the sqlstring as input
        private List<Game> ReadFromDB(string sqlstring)
        {
            List<Game> games = new List<Game>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=reader;Password=hej123;Database=guessthegame;");
            try
            {
                //connecting to the database
                conn.Open();

                // defining the sql npgsql command
                NpgsqlCommand command = new NpgsqlCommand(sqlstring, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                Game tempGame;
                Round tempRound;
                Team tempTeam1;
                Team tempTeam2;

                RoundServices rs = new RoundServices();
                TeamServices ts = new TeamServices();
                
                //reading all the users.
                while (dr.Read())
                {
                    //first we find the round from the ID.
                    tempRound = rs.GetRoundByID(dr.GetInt32(1));

                    //finding the two teams
                    tempTeam1 = ts.GetTeamByID(dr.GetInt32(2));
                    tempTeam2 = ts.GetTeamByID(dr.GetInt32(3));

                    //creating the game and adding it to the list of games
                    tempGame = new Game(dr.GetInt32(0), tempRound, tempTeam1, tempTeam2, dr.GetDateTime(4));

                    // Maybe it would be better to have this read directly from DB
                    if (dr.GetBoolean(5))
                    {
                        tempGame.GamePlayed(dr.GetInt32(6)); // need to have result from db as well
                    }
                    games.Add(tempGame);
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

            return games;
        }
    }
}