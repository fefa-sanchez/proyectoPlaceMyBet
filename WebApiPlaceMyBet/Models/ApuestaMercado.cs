using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class ApuestaMercado
    {
        public ApuestaMercado(string idMercado, int idApuesta, double tipoMercado, string tipoApuesta, decimal cuotaUnder, decimal cuotaOver, decimal dineroApostado)
        {
            IdMercado = idMercado;
            IdApuesta = idApuesta;
            TipoMercado = tipoMercado;
            TipoApuesta = tipoApuesta;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
            DineroApostado = dineroApostado;
        }

        public string IdMercado { get; set; }
        public int IdApuesta { get; set; }
        public double TipoMercado { get; set; }
        public string TipoApuesta { get; set; }
        public decimal CuotaUnder { get; set; }
        public decimal CuotaOver { get; set; }
        public decimal DineroApostado { get; set; }
    }
}
