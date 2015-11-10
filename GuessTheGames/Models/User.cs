using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessTheGames.Models
{
    public class User
    {
        // the constructor with variables
        public User(int id, string email_addr, string password)
        {
            this.id = id;
            this.email_addr = email_addr;
            this.password = password;
        }

        public int id { get; set; }

        public string email_addr { get; set; }

        public string password { get; set;}


    }
}