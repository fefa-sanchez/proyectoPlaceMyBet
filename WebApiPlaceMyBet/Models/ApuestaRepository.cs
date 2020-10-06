using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class ApuestaRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=W0rkH4rd3r;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Apuesta> Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta ap = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetString(5));
                    ap = new Apuesta(res.GetString(0), res.GetString(1), res.GetString(2), res.GetDouble(3), res.GetDouble(4), res.GetString(5));
                    apuestas.Add(ap);

                }

                con.Close();
                return apuestas;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }
        internal List<ApuestaDTO> RetrieveDTO()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO ap = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetString(5));
                    ap = new ApuestaDTO(res.GetString(0), res.GetDouble(3), res.GetDouble(4), res.GetString(5));
                    apuestas.Add(ap);

                }

                con.Close();
                return apuestas;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }
    }
}

            