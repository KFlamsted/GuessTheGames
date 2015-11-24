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


        //Get all users
        [HttpGet]
        public List<User> GetAllUsers()
        {
            return us.GetUsers();
        }

        //finding a user by id
        [HttpGet]
        public User GetUserFromId(int id)
        {
            return us.GetUser(id);
        }

        //finding a user by email address
        [HttpGet]
        public User GetUserFromEmail(string id)
        {
            string email_addr = id;
            return us.GetUserFromEmail(email_addr);
        }

    }
}
