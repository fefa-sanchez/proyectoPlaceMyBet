using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(string idUsuario,
                        string idMercado, 
                        string tipoApuesta, 
                        double dineroApostadoOver, 
                        double dineroApostadoUnder, 
                        string fechaApuesta)
        {
            IdUsuario = idUsuario;
            IdMercado = idMercado;
            TipoApuesta = tipoApuesta;
            DineroApostadoOver = dineroApostadoOver;
            DineroApostadoUnder = dineroApostadoUnder;
            FechaApuesta = fechaApuesta;
        }

        public string IdUsuario { get; set; }
        public string IdMercado { get; set; }
        public string TipoApuesta { get; set; }
        public double DineroApostadoOver { get; set; }
        public double DineroApostadoUnder { get; set; }
        public string FechaApuesta { get; set; }

    }
}

public class ApuestaDTO
{
    public ApuestaDTO(string idUsuario, double dineroApostadoOver, double dineroApostadoUnder, string fechaApuesta)
    {
        IdUsuario = idUsuario;
        DineroApostadoOver = dineroApostadoOver;
        DineroApostadoUnder = dineroApostadoUnder;
        FechaApuesta = fechaApuesta;
    }

    public string IdUsuario { get; set; }
    public double DineroApostadoOver { get; set; }
    public double DineroApostadoUnder { get; set; }
    public string FechaApuesta { get; set; }

}
