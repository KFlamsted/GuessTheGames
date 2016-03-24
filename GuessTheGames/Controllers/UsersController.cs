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
    public class UsersController : ApiController
    {
        private UserServices us = new UserServices();


        //Get all users 'GET api/users'
        [ActionName("DefaultAction")]
        public List<User> Get()
        {
            return us.GetUsers();
        }

        //finding a user by id 'GET api/users/1'
        [ActionName("DefaultAction")]
        public User Get(int id)
        {
            return us.GetUser(id);
        }

        //finding a user by email address 'GET api/users/byemail/<emailaddress>/
        [HttpGet]
        public User ByEmail(string id)
        {
            string email_addr = id;
            return us.GetUserFromEmail(email_addr);
        }

    }
}
