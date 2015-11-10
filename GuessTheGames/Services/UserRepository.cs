using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuessTheGames.Models;
using Npgsql;
using System.Data;

namespace GuessTheGames.Services
{
    public class UserRepository
    {

        private const string CacheKey = "UserStore";
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        

        // Loading in users from DB when starting the webservice.
        public UserRepository()
        {
            var ctx = HttpContext.Current;
            try
            {
                string connstring = String.Format("Server=localhost;Port=5432;User Id=reader;Password=hej123;Database=guessthegame;");
                //connecting to the database
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                
                //creating the sql string (this example is selecting all users and info)
                string sqlstring = "SELECT * FROM public.users;";

                //making the request using the sql data adapter
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlstring, conn);
                ds.Reset();

                da.Fill(ds);

                //selecting first table.
                dt = ds.Tables[0];

                User tempUser = new User();
                List<User> users = new List<User>();
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    //Not sure the data type convertion works properly
                    tempUser.password = ""+dr[0];
                    tempUser.id = (int) dr[1];
                    tempUser.email_addr = ""+dr[2];

                }

                if(ctx != null)
                {
                    if(ctx.Cache[CacheKey] == null)
                    {
                        ctx.Cache[CacheKey] = users;           
                    }
                }
            }catch (Exception msg)
            {
                //something went wrong with the connectiong to DB
            }
        }

        //might not be the right way to work the api
        public List<User> GetUsers()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (List<User>)ctx.Cache[CacheKey];
            }
            
            List<User> temp = new List<User>();
            temp.Add(new User
                {
                    id = 0,
                    email_addr = "null@null.com",
                    password = "null"
                });

            return temp;
        }
    }
}