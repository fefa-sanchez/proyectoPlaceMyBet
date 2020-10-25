
﻿using System;
﻿using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class Usuario
    {
        public Usuario(string idEmail, string nombre, string apellido, int edad, string banco, long numTarjetaCredito, double saldoActual)
        {
            IdEmail = idEmail;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Banco = banco;
            NumTarjetaCredito = numTarjetaCredito;
            SaldoActual = saldoActual;
        }

        public string IdEmail { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Banco { get; set; }
        public long NumTarjetaCredito { get; set; }
        public double SaldoActual { get; set; }

    }


   /* public class UsuarioDTO
    {
        public UsuarioDTO(string idEmail, string nombre, string apellido, int edad, double saldoActual)
        {
            IdEmail = idEmail;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            SaldoActual = saldoActual;
        }


        public string IdEmail { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public double SaldoActual { get; set; }
    }*/
}