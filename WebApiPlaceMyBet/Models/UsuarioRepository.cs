using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class UsuarioRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=W0rkH4rd3r;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Usuario> Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuarios";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Usuario u = null;
                List<Usuario> usuarios = new List<Usuario>(); 
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetString(4) + " " + res.GetInt64(5) + " " + res.GetDouble(6));
                    u = new Usuario(res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetString(4), res.GetInt64(5), res.GetDouble(6));
                    usuarios.Add(u);

                }

                con.Close();
                return usuarios;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        /*internal List<UsuarioDTO> RetrieveDTO()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuarios";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                UsuarioDTO u = null;
                List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetString(4) + " " + res.GetInt64(5) + " " + res.GetDouble(6));
                    u = new UsuarioDTO(res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetDouble(6));
                    usuarios.Add(u);

                }

                con.Close();
                return usuarios;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }*/

        internal void Save(Usuario u)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            command.CommandText = "INSERT INTO usuarios (idEmail, nombre, apellido, edad, banco, numTarjetaCredito, saldoActual)" +
                "VALUES (@IdEmail, @Nombre, @Apellido, @Edad, @Banco, @NumTarjetaCredito, @SaldoActual);";
            // + u.IdEmail + "','" + u.Nombre + "','" + u.Apellido + "','" + u.Edad + "','" + u.Banco + "','" + u.NumTarjetaCredito + "','" + u.SaldoActual.ToString().Replace(',','.') + "')";

            command.Parameters.AddWithValue("idEmail", u.IdEmail);
            command.Parameters.AddWithValue("nombre", u.Nombre);
            command.Parameters.AddWithValue("apellido", u.Apellido);
            command.Parameters.AddWithValue("edad", u.Edad);
            command.Parameters.AddWithValue("banco", u.Banco);
            command.Parameters.AddWithValue("numTarjetaCredito", u.NumTarjetaCredito);
            command.Parameters.AddWithValue("saldoActual", u.SaldoActual);

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