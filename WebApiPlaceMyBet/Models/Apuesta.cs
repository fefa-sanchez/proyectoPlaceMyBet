using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(string idUsuario, string idMercado, string tipoApuesta, double dineroApostado, DateTime fechaApuesta)
        {
            IdUsuario = idUsuario;
            IdMercado = idMercado;
            TipoApuesta = tipoApuesta;
            DineroApostado = dineroApostado;
            FechaApuesta = fechaApuesta;
        }

        public string IdUsuario { get; set; }
        public string IdMercado { get; set; }
        public string TipoApuesta { get; set; }
        public double DineroApostado { get; set; }
        public DateTime FechaApuesta { get; set; }

    }

    public class ApuestaDTO
    {
        public ApuestaDTO(string idUsuario, double tipoMercado, string tipoApuesta, float cuotaUnder, float cuotaOver, double dineroApostado, DateTime fechaApuesta)
        {
            IdUsuario = idUsuario;
            TipoMercado = tipoMercado;
            TipoApuesta = tipoApuesta;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
            DineroApostado = dineroApostado;
            FechaApuesta = fechaApuesta;
        }

        public string IdUsuario { get; set; }
        public double TipoMercado { get; set; }
        public string TipoApuesta { get; set; }
        public float CuotaUnder { get; set; }
        public float CuotaOver { get; set; }
        public double DineroApostado { get; set; }
        public DateTime FechaApuesta { get; set; }

    }

    public class SumaApuestas
    {
        public SumaApuestas(String idMercado, float total, float totalOver, float totalUnder)
        {
            IdMercado = idMercado;
            Total = total;
            TotalOver = totalOver;
            TotalUnder = totalUnder;

        }

        public string IdMercado { get; set; }
        public float Total { get; set; }
        public float TotalOver { get; set; }
        public float TotalUnder { get; set; }
    }
}

