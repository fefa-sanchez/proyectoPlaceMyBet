using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class Usuario
    {
        public Usuario(string usuarioId, string nombre, string apellido, int edad, string banco, Int64 numTarjeta, double saldoActual)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Banco = banco;
            NumTarjeta = numTarjeta;
            SaldoActual = saldoActual;
        }

        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Banco { get; set; }
        public Int64 NumTarjeta { get; set; }
        public double SaldoActual { get; set; }

    }

    public class UsuarioDTO
    {
        public UsuarioDTO(string usuarioId, string nombre, string apellido, int edad, double saldoActual)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            SaldoActual = saldoActual;
        }

        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public double SaldoActual { get; set; }
    }
}