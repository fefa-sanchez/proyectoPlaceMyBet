using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPlaceMyBet.Models;

namespace WebApiPlaceMyBet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<ApuestaDTO> Get()
        {
            var repoApuesta = new ApuestaRepository();
            //List<Apuesta> apuestas = repoApuesta.Retrieve();
            List<ApuestaDTO> apuestas = repoApuesta.RetrieveDTO();
            return apuestas;
        }

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            /*var repoAp = new ApuestaRepository();
            Apuesta ap = repoAp.Retrieve();*/
            return null;
        }

        // POST: api/Apuestas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
