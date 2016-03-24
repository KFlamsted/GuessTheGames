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

        //getting a season by id in DB 'GET api/seasons/<id>'
        [ActionName("DefaultAction")]
        public List<Season> Get(int id)
        {
            return ss.GetSeasonById(id);
        }

        //get a season by startyear of season 'GET api/seasons/bystartyear/<year>'
        [HttpGet]
        public Season ByStartYear(int id)
        {
            int startyear = id;
            return ss.GetSeasonFromStartYear(startyear);
        }

        //get a season by end of season 'GET api/seasons/byendyear/<year>'
        [HttpGet]
        public Season ByEndYear(int id)
        {
            int endyear = id;
            return ss.GetSeasonFromStartYear(endyear);
        }

        //get all the seasons already played 'GET api/seasons/played'
        [HttpGet]
        public List<Season> Played()
        {
            return ss.GetPlayedSeasons();
        }

        //get all not played seasons registered in DB 'GET api/seasons/notplayed'
        [HttpGet]
        public List<Season> NotPlayed()
        {
            return ss.GetNotPlayedSeasons();
        }

        //get all seasons in between two dates. 'GET api/season/inbetween/<DD-MM-YYYY>/<DD-MM-YYYY>
        //not sure this input way is the best practice
        [HttpGet]
        public List<Season> InBetween(string id, string id2)
        {
            string date1 = id;
            string date2 = id2;
            //input should be received in 'DD-MM-YYYY', however a check is needed
            return ss.GetSeasonsInBetween(date1, date2);
        }

    }
}
