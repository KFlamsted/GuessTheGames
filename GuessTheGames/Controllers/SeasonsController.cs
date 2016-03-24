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
    public class SeasonsController : ApiController
    {

        public SeasonServices ss = new SeasonServices();

        //Get all Seasons 'GET api/seasons'
        [ActionName("DefaultAction")]
        public List<Season> Get()
        {
            return ss.GetAllSeasons();
        }

        //getting season by id in DB 'GET api/seasons/<id>'
        [ActionName("DefaultAction")]
        public List<Season> Get(int id)
        {
            return ss.GetSeasonById(id);
        }

        //get a season by startyear of season 'GET api/seasons/bystartyear/<year>'
        [HttpGet]
        public Season ByStartYear(int id)
        {
            int startyear = id; //have to be named id, this is a rule from the wep api config
            return ss.GetSeasonFromStartYear(startyear);
        }

        
    }
}
