using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPlaceMyBet.Models;

namespace WebApiPlaceMyBet.Controllers
{
    public class MercadosExamenController : ApiController
    {
        // GET: api/MercadosExamen
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //Ejercicio 1
        // GET: api/MercadosExamen/5
        public MercadoExamen Get(string idEventos)
        {
            var repoMercado = new MercadoRepository();
            MercadoExamen mercados = repoMercado.RetrieveMercadoExamen();
            return mercados;
        }

        // POST: api/MercadosExamen
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MercadosExamen/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MercadosExamen/5
        public void Delete(int id)
        {
        }
    }
}
