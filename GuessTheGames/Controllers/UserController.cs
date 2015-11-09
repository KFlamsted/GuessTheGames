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
        private UserRepository userRepository;

        public UserController()
        {
            this.userRepository = new UserRepository();
        }

        public User[] Get()
        {

            return this.userRepository.GetUsers();
        }

    }
}
