using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StarWeb.Models;

namespace StarWeb.Controllers
{
    public class SWGameController : ApiController
    {
		public List<Tile> tiles = new List<Tile>();

        // GET: api/SWGame
        public IEnumerable<string> Get()
        {
			
            return new string[] { "value1", "value2" };
        }

        // GET: api/SWGame/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SWGame
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SWGame/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SWGame/5
        public void Delete(int id)
        {
        }
    }
}
