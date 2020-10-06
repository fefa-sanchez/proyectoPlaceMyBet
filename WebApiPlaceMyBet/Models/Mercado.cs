using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(string idMercado, string idEvento, double overUnder, double cuotaUnder, double cuotaOver)
        {
            IdMercado = idMercado;
            IdEvento = idEvento;
            OverUnder = overUnder;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
        }

        public string IdMercado { get; set; }
        public string IdEvento { get; set; }
        public double OverUnder { get; set; }
        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set; }

    }
}

public class MercadoDTO
{
    public MercadoDTO(string idEvento, double overUnder, double cuotaUnder, double cuotaOver)
    {
        IdEvento = idEvento;
        OverUnder = overUnder;
        CuotaUnder = cuotaUnder;
        CuotaOver = cuotaOver;
    }

    public string IdEvento { get; set; }
    public double OverUnder { get; set; }
    public double CuotaUnder { get; set; }
    public double CuotaOver { get; set; }

}
