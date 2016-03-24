using GuessTheGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace GuessTheGames.Services
{
    public class RoundServices
    {

        //get all rounds in DB
        public List<Round> GetAllRounds()
        {
            List<Round> rounds = new List<Round>();
            string sqlstring = "SELECT * FROM rounds;";
            rounds = ReadFromDB(sqlstring);
            return rounds;
        }

        //get the round with id in DB
        public Round GetRoundByID(int id)
        {
            List<Round> rounds = new List<Round>();
            string sqlstring = "SELECT * FROM rounds WHERE id = '" + id +"';";
            rounds = ReadFromDB(sqlstring);
            return rounds[0];
        }

        //get all rounds from a season
        public List<Round> GetRoundsFromSeason(int season_id)
        {
            List<Round> rounds = new List<Round>();
            string sqlstring = "SELECT * FROM rounds WHERE season_id = '" + season_id + "';";
            rounds = ReadFromDB(sqlstring);
            return rounds;
        }

        //get a specific round from a season using the round number
        public Round GetRoundFromSeasonAndRound(int season_id, int round)
        {
            List<Round> rounds = new List<Round>();
            string sqlstring = "SELECT * FROM rounds WHERE season_id = '" + season_id + "' AND round_number = '" + round + ";";
            rounds = ReadFromDB(sqlstring);
            return rounds[0];
        }

        // used for connecting to the db; to remove redundancy
        private List<Round> ReadFromDB(string sqlstring)
        {
            List<Round> rounds = new List<Round>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=reader;Password=hej123;Database=guessthegame;");
            try
            {
                //connecting to the database
                conn.Open();

                // defining the sql npgsql command
                NpgsqlCommand command = new NpgsqlCommand(sqlstring, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                Round tempRound;

                // reading all the rounds.
                while (dr.Read())
                {
                    tempRound = new Round(dr.GetInt32(0), dr.GetInt32(1), dr.GetInt32(2));
                    rounds.Add(tempRound);
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

            return rounds;
        }

    }
}