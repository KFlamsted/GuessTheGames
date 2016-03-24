using System;
using System.Collections.Generic;
using System.Linq;
using GuessTheGames.Models;
using Npgsql;
using System.Web;

namespace GuessTheGames.Services
{
    public class TeamServices
    {

        // get id from teamname
        public int GetId(string teamname)
        {
            List<Team> teams = new List<Team>();
            string sqlstring = "SELECT * FROM teams WHERE teamname ='" + teamname + "';";
            teams = ReadFromDB(sqlstring);

            return teams[0].id; //there should only be one 
        }

        // get all teams
        public List<Team> GetAllTeams()
        {
            List<Team> teams = new List<Team>();
            string sqlstring = "SELECT * FROM teams;";
            teams = ReadFromDB(sqlstring);

            return teams;

        }

        // having a connecting to DB function with the sqlstring as input
        private List<Team> ReadFromDB(string sqlstring)
        {
            List<Team> teams = new List<Team>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=reader;Password=hej123;Database=guessthegame;");
            try
            {
                //connecting to the database
                conn.Open();

                // defining the sql npgsql command
                NpgsqlCommand command = new NpgsqlCommand(sqlstring, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                Team tempTeam;

                //reading all the users.
                while (dr.Read())
                {
                    tempTeam = new Team(dr.GetInt32(0), dr.GetString(1));
                    teams.Add(tempTeam);
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

            return teams;
        }
    }

    
}