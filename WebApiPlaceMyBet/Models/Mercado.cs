using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(string idMercado, string idEvento, double tipoMercado, double cuotaUnder, double cuotaOver)
        {
            IdMercado = idMercado;
            IdEvento = idEvento;
            TipoMercado = tipoMercado;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
        }

        public string IdMercado { get; set; }
        public string IdEvento { get; set; }
        public double TipoMercado { get; set; }
        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set; }

    }

    public class MercadoDTO
    {
        public MercadoDTO(double tipoMercado, double cuotaUnder, double cuotaOver)
        {
            TipoMercado = tipoMercado;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
        }

        public double TipoMercado { get; set; }
        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set; }

    }

    public class MercadoCuotasDTO
    {
        public MercadoCuotasDTO(string idMercado, double cuotaUnder, double cuotaOver)
        {
            IdMercado = idMercado;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
        }

        public String IdMercado { get; set; }
        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set; }

    }
}



