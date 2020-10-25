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

        // GET: api/Apuestas?idUsuario=Email&&tipoMercado=tipoMercado
        public List<ApuestaUsuario> GetApUs(string idUsuario, double tipoMercado)
        {
            var repoApUs = new ApuestaRepository();
            List<ApuestaUsuario> apuestas = repoApUs.RetrieveApuestasUsuario(idUsuario, tipoMercado);
            return apuestas;
        }

        // GET: api/Apuestas?idUsuario=Email&&idMercado=idMercado
        public List<ApuestaMercado> GetAp(string idUsuario, string idMercado)
        {
            var repoApMe = new ApuestaRepository();
            List<ApuestaMercado> apuestas = repoApMe.RetrieveApuestasMercado(idUsuario, idMercado);
            return apuestas;
        }

        // POST: api/Apuestas
        public void Post([FromBody]Apuesta apuesta)
        {
            //Update Apuestas
            var repoApuesta = new ApuestaRepository();
            repoApuesta.Save(apuesta);

            //Update Cuotas in the Mercado table
            UpdateCuotas(apuesta.IdMercado);

        }

        private void UpdateCuotas(string idMercado)
        {
            //Retreive sum of the cuotas for the Mercado
            var repoAp = new ApuestaRepository();
            var sumaApuestas = repoAp.RetrieveSumaApuestas(idMercado);
            
            //Calculate Cuotas
            var probOver = sumaApuestas.TotalOver / sumaApuestas.Total;
            var cuotaOver = (1 / probOver) * 0.95;

            var probUnder = sumaApuestas.TotalUnder / sumaApuestas.Total;
            var cuotaUnder = (1 / probUnder) * 0.95;
            
            //Update Mercado
            new MercadoRepository().UpdateCuotas(new MercadoCuotasDTO(idMercado, cuotaUnder, cuotaOver));

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
