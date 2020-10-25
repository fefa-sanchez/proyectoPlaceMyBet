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
        public IEnumerable<EventoDTO> Get()
        {
            var repoEvento = new EventoRepository();
           // List<Evento> eventos = repoEvento.Retrieve();
            List<EventoDTO> eventos = repoEvento.RetrieveDTO();
            return eventos;
        }

        // GET: api/Eventos/5
        public Evento Get(int id)
        {
            /*var repoEvento = new EventoRepository();
            Evento ev = repoEvento.Retrieve();*/
            return null;
        }

        // POST: api/Eventos
        public void Post([FromBody]Evento evento)
        {
            var repoEvento = new EventoRepository();
            repoEvento.Save(evento);
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
