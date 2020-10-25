using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class MercadoRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=W0rkH4rd3r;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Mercado> Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
                List<Mercado> mercados = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4));
                    m = new Mercado(res.GetString(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4));
                    mercados.Add(m);

                }

                con.Close();
                return mercados;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }

        }

        internal List<MercadoDTO> RetrieveDTO()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO m = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4));
                    m = new MercadoDTO(res.GetDouble(2), res.GetDouble(3), res.GetDouble(4));
                    mercados.Add(m);

                }

                con.Close();
                return mercados;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }

        }

        internal Mercado RetrieveEvento(string idEvento, double tipoMercado)
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados where idEvento=@idEvento and tipoMercado=@tipoMercado";
            command.Parameters.AddWithValue("@idEvento", idEvento);
            command.Parameters.AddWithValue("@tipoMercado", tipoMercado);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4));
                    m = new Mercado(res.GetString(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4));

                }

                con.Close();
                return m;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }

        }

        internal void Save(Mercado m)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            command.CommandText = "INSERT INTO mercados (idMercado, idEvento, tipoMercado, cuotaUnder, cuotaOver)" + " " +
                "VALUES (@IdMercado, @IdEvento, @TipoMercado, @CuotaUnder, @CuotaOver);";

            command.Parameters.AddWithValue("idMercado", m.IdMercado);
            command.Parameters.AddWithValue("idEvento", m.IdEvento);
            command.Parameters.AddWithValue("tipoMercado", m.TipoMercado);
            command.Parameters.AddWithValue("cuotaUnder", m.CuotaUnder);
            command.Parameters.AddWithValue("cuotaOver", m.CuotaOver);

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

        internal void UpdateCuotas(MercadoCuotasDTO m)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            command.CommandText = "UPDATE mercados SET cuotaUnder = @cuotaUnder, cuotaOver = @cuotaOver WHERE idMercado = @IdMercado;";

            command.Parameters.AddWithValue("idMercado", m.IdMercado);
            command.Parameters.AddWithValue("cuotaUnder", m.CuotaUnder);
            command.Parameters.AddWithValue("cuotaOver", m.CuotaOver);

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
    }
}