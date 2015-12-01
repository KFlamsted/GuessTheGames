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

       // methods for getting all users.
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            //creating the sql string (this example is selecting all users and info)
            string sqlstring = "SELECT * FROM public.users;";
            users = ReadFromDB(sqlstring);

            return users; 
        }

        //method finding user by user id
        public User GetUser(int id)
        {
            List<User> users = new List<User>();
            string sqlstring = "SELECT * FROM users WHERE user_id = " + id + ";";
            users = ReadFromDB(sqlstring);

            //returning the first user, there should only be one.
            return users[0];
        }

        //method finding user by email address
        public User GetUserFromEmail(string email_addr)
        {
            List<User> users = new List<User>();
            string sqlstring = "SELECT * FROM users WHERE email_addr = '" + email_addr + "';";
            users = ReadFromDB(sqlstring);

            //returning the first user, there should only be one.
            return users[0];
        }

        // having a connecting to DB function with the sqlstring as input
        private List<User> ReadFromDB(string sqlstring)
        {
            List<User> users = new List<User>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=reader;Password=hej123;Database=guessthegame;");
            try
            {
                //connecting to the database
                conn.Open();

                // defining the sql npgsql command
                NpgsqlCommand command = new NpgsqlCommand(sqlstring, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                User tempUser;

                //reading all the users.
                while (dr.Read())
                {
                    tempUser = new User(dr.GetInt32(1), dr.GetString(3), dr.GetString(2), dr.GetString(0));
                    users.Add(tempUser);
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

            return users;
        }


    }
}