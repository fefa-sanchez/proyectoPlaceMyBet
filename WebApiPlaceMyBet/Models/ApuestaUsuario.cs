using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class ApuestaUsuario
    {
        public ApuestaUsuario(int idApuesta, string idEvento, string tipoApuesta, decimal cuotaUnder, decimal cuotaOver, decimal dineroApostado)
        {
            IdApuesta = idApuesta;
            IdEvento = idEvento;
            TipoApuesta = tipoApuesta;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
            DineroApostado = dineroApostado;
        }

        public int IdApuesta { get; set; }
        public string IdEvento { get; set; }
        public string TipoApuesta { get; set; }
        public decimal CuotaUnder { get; set; }
        public decimal CuotaOver { get; set; }
        public decimal DineroApostado { get; set; }
    }
}