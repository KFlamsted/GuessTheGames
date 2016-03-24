using GuessTheGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace GuessTheGames.Services
{
    public class SeasonServices
    {

        // get all seasons in DB
        public List<Season> GetAllSeasons()
        {
            List<Season> seasons = new List<Season>();
            string sqlstring = "SELECT * FROM seasons;";
            seasons = ReadFromDB(sqlstring);
            return seasons;
        }

        // getting a specific season by it's id in the db
        public List<Season> GetSeasonById(int id)
        {
            List<Season> seasons = new List<Season>();
            string sqlstring = "SELECT * FROM seasons WHERE id = " + id + ";";
            seasons = ReadFromDB(sqlstring);
            return seasons;
        }

        // getting all the already played seasons
        public List<Season> GetPlayedSeasons()
        {

            List<Season> seasons = new List<Season>();
            string sqlstring = "SELECT * FROM seasons WHERE is_ended = TRUE;";
            seasons = ReadFromDB(sqlstring);
            return seasons;
        }

        // getting the not played seasons
        public List<Season> GetNotPlayedSeasons()
        {
            List<Season> seasons = new List<Season>();
            string sqlstring = "SELECT * FROM seasons WHERE is_ended = FALSE;";
            seasons = ReadFromDB(sqlstring);
            return seasons;
        }

        // all seasons starting or ending in between two dates
        public List<Season> GetSeasonsInBetween(DateTime start_date, DateTime end_date)
        {
            //easier to convert the dates into ints
            int start_day = start_date.Date.Day; //should get the day of the month
            int start_month = start_date.Month;
            int start_year = start_date.Year;

            int end_day = end_date.Date.Day; //should get the day of the month
            int end_month = end_date.Month;
            int end_year = end_date.Year;
            
            List<Season> seasons = new List<Season>();
            string sqlstring = "SELECT * FROM mytable WHERE (season_start_year, season_end_year) OVERLAPS ('"+start_year+"-"+start_month+"-"+start_day+"'::DATE, '"+end_year+"-"+end_month+"-"+end_day+"'::DATE);";
            seasons = ReadFromDB(sqlstring);
            return seasons;
        }

        // get the season with a given start year
        public Season GetSeasonFromStartYear(int start_year)
        {
            List<Season> seasons = new List<Season>();
            string sqlstring = "SELECT * FROM seasons WHERE EXTRACT(year FROM season_start_year) = '" + start_year + "';";
            seasons = ReadFromDB(sqlstring);
            return seasons[0]; //should always only get one season
        }


        // get the season with a given end year
        public Season GetSeasonFromEndYear(int end_year)
        {
            List<Season> seasons = new List<Season>();
            string sqlstring = "SELECT * FROM seasons WHERE EXTRACT(year FROM season_end_year) = '" + end_year + "';";
            seasons = ReadFromDB(sqlstring);
            return seasons[0]; //should always only get one season
        }

        // used for connecting to the db; to remove redundancy
        private List<Season> ReadFromDB(string sqlstring)
        {
            List<Season> seasons = new List<Season>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=reader;Password=hej123;Database=guessthegame;");
            try
            {
                //connecting to the database
                conn.Open();

                // defining the sql npgsql command
                NpgsqlCommand command = new NpgsqlCommand(sqlstring, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                Season tempSeason;

                // reading all the seasons.
                while (dr.Read())
                {
                    tempSeason = new Season(dr.GetInt32(0), dr.GetDateTime(1), dr.GetDateTime(2), dr.GetBoolean(3));
                    seasons.Add(tempSeason);
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

            return seasons;
        }
    }
}