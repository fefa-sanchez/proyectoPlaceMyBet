using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class Evento
    {
        public Evento(string idEvento, string equipoLocal, string equipoVisitante, DateTime fechaEvento)
        {
            IdEvento = idEvento;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            FechaEvento = fechaEvento;
        }

        public string IdEvento { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime FechaEvento { get; set; }
    }

    public class EventoDTO
    {
        public EventoDTO(string equipoLocal, string equipoVisitante, DateTime fechaEvento)
        {
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            FechaEvento = fechaEvento;
        }

        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime FechaEvento { get; set; }
    }
}