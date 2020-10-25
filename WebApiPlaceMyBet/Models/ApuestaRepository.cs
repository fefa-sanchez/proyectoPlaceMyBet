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
            command.CommandText = "SELECT DISTINCT *  FROM apuestas;";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta ap = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetDateTime(4));
                    ap = new Apuesta(res.GetString(0), res.GetString(1), res.GetString(2), res.GetDouble(3), res.GetDateTime(4));
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
            command.CommandText = "SELECT DISTINCT *  FROM apuestas ap INNER JOIN mercados m ON m.idMercado=ap.idMercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO ap = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(6) + " " + res.GetString(1) + " " + res.GetDouble(7) + " " + res.GetString(2) + " " + res.GetFloat(8) + " " + res.GetFloat(9) + " " + res.GetDouble(3) + " " + res.GetDateTime(4));
                    ap = new ApuestaDTO (res.GetString(0), res.GetDouble(7), res.GetString(2), res.GetFloat(8), res.GetFloat(9), res.GetDouble(3), res.GetDateTime(4));
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

        internal void Save(Apuesta ap)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            /*command.CommandText = "INSERT INTO apuestas (idUsuario, idMercado, tipoApuesta, dineroApostado, fecha) VALUES ('"
                + ap.IdUsuario + "','" + ap.IdMercado + "','" + ap.TipoApuesta + "','" + ap.DineroApostado + "','" + ap.FechaApuesta + "')";*/
            command.CommandText = "INSERT INTO apuestas (idUsuario, idMercado, tipoApuesta, dineroApostado, fecha) " +
                                   "VALUES(@IdUsuario, @IdMercado, @TipoApuesta, @DineroApostado, @FechaApuesta);";

            command.Parameters.AddWithValue("idUsuario", ap.IdUsuario);
            command.Parameters.AddWithValue("idMercado", ap.IdMercado);
            command.Parameters.AddWithValue("tipoApuesta", ap.TipoApuesta);
            command.Parameters.AddWithValue("dineroApostado", ap.DineroApostado);
            command.Parameters.AddWithValue("fechaApuesta", ap.FechaApuesta);

            Debug.WriteLine("comando " + command.CommandText);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
            }
        }

        internal SumaApuestas RetrieveSumaApuestas(string idMercado)
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT idMercado, sum(dineroApostado)  as Total, " +
                                            "sum(case When tipoApuesta = 'Over' Then dineroApostado Else 0 End) as TotalOver," +
                                            "sum(case When tipoApuesta = 'Under' Then dineroApostado Else 0 End) as TotalUnder " +
                                    "FROM apuestas " +
                                    "WHERE idMercado = @idMercado " +
                                    "GROUP by idMercado " +
                                    "ORDER by idMercado;";
            command.Parameters.AddWithValue("idMercado", idMercado);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                SumaApuestas sc = null;
                //TODO: Si retorna más que uno, devuelve error?
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3));
                    sc = new SumaApuestas(res.GetString(0), res.GetFloat(1), res.GetFloat(2), res.GetFloat(3));
                }

                con.Close();
                return sc;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }

        }
    }
}

            