using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPlaceMyBet.Models;

namespace WebApiPlaceMyBet.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<MercadoDTO> Get()
        {
            var repoMercado = new MercadoRepository();
            //List<Mercado> mercados = repoMercado.Retrieve();
            List<MercadoDTO> mercados = repoMercado.RetrieveDTO();
            return mercados;
        }

        // GET: api/Mercados?idEvento=idEvento&tipoMercado=tipoMercado)
        public Mercado GetEventos(string idEvento, double tipoMercado)
        {
            var repoMercado = new MercadoRepository();
            Mercado mercados = repoMercado.RetrieveEvento(idEvento, tipoMercado);
            return mercados;
        }

        // GET: api/Mercados/5
        public Mercado Get(int id)
        {
           /* var repoMercado = new MercadoRepository();
            Mercado m = repoMercado.Retrieve();*/
            return null;
        }

        // POST: api/Mercados
        public void Post([FromBody]Mercado mercado)
        {
            var repoMercado = new MercadoRepository();
            repoMercado.Save(mercado);

        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
