using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPlaceMyBet.Models;

namespace WebApiPlaceMyBet.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<Evento> Get()
        {
            var repoEvento = new EventoRepository();
            List<Evento> eventos = repoEvento.Retrieve();
            return eventos;
        }

        // GET: api/Eventos/5
        public Evento Get(int id)
        {
            /*var repoEvento = new EventoRepository();
            Evento ev = repoEvento.Retrieve();*/
            return null;
        }

        //ejercicio 2
        // POST: api/Eventos
        public void Post([FromBody] EventoExamen evento)
        {
            var repoEvento = new EventoRepository();
            repoEvento.SaveExamen(evento);

        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
