using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class Evento
    {
        public Evento(string idEvento, string equipoLocal, string equipoVisitante, string fechaEvento)
        {
            IdEventoId = idEvento;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            FechaEvento = fechaEvento;
        }

        public static object IdEvento { get; internal set; }

        public string IdEventoId { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public string FechaEvento { get; set; }
    }
}