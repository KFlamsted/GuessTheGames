using GuessTheGames.Models;
using GuessTheGames.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuessTheGames.Controllers
{
    public class UserController : ApiController
    {
        private UserServices us = new UserServices();

        public List<User> GetAllUsers()
        {
            return us.GetUsers();
        }

        //finding a user by id
        public User GetUser([FromUri] int id)
        {
            return us.GetUser(id);
        }
    }
}
