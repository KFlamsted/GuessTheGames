using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuessTheGames.Models;

namespace GuessTheGames.Services
{
    public class UserRepository
    {

        private const string CacheKey = "UserStore";

        public UserRepository()
        {
            var ctx = HttpContext.Current;

            if(ctx != null)
            {
                if(ctx.Cache[CacheKey] == null)
                {

                    User[] users = new User[]
                    {
                        new User 
                        {
                            id = 1,
                            email_addr = "hej@hej.dk",
                            password = "xxx"
                        }
                    };

                    ctx.Cache[CacheKey] = users;           
                }
            }
        }

        public User[] GetUsers()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (User[])ctx.Cache[CacheKey];
            }

            return new User[]
            {
                new User 
                {
                id = 0,
                email_addr = "null@null.com",
                password = "null"
                }
            };
        }
    }
}