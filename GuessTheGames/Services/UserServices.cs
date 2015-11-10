using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuessTheGames.Models;
using Npgsql;
using System.Data;

namespace GuessTheGames.Services
{
    public class UserServices
    {

        //might not be the right way to work the api
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            //connecting to the database
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=reader;Password=hej123;Database=guessthegame;");
            try
            {
                conn.Open();

                //creating the sql string (this example is selecting all users and info)
                string sqlstring = "SELECT * FROM public.users;";

                // defining the sql npgsql command
                NpgsqlCommand command = new NpgsqlCommand(sqlstring, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                User tempUser;
                
                //reading all the users.
                while (dr.Read())
                {
                    tempUser = new User(dr.GetInt32(1), dr.GetString(2), dr.GetString(0));
                    users.Add(tempUser);
                }
            }catch (Exception msg)
            {
                //do something if exception
                System.Diagnostics.Debug.WriteLine(msg.ToString());
            }
            finally
            {
                conn.Close();
            }

            return users; 
        }
    }
}