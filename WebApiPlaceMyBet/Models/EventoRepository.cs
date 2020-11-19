using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApiPlaceMyBet.Models
{
    public class EventoRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=W0rkH4rd3r;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Evento> Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Evento ev = null;
                List<Evento> eventos = new List<Evento>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    ev = new Evento(res.GetString(0), res.GetString(1), res.GetString(2), res.GetDateTime(3));
                    eventos.Add(ev);

                }

                con.Close();
                return eventos;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        internal List<EventoDTO> RetrieveDTO()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                EventoDTO ev = null;
                List<EventoDTO> eventos = new List<EventoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    ev = new EventoDTO(res.GetString(1), res.GetString(2), res.GetDateTime(3));
                    eventos.Add(ev);

                }

                con.Close();
                return eventos;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        //ejercicio 2
        internal void SaveExamen(EventoExamen ee)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            command.CommandText = "insert into inserirApuesta (equipoLocal, equipoVisitante, tipoMercado, dineroApostado)" +
                                    "values(@equipoLocal, @equipoVisitante, @tipoMercado, @dineroApostado);";

            command.Parameters.AddWithValue("equipoLocal", ee.EquipoLocal);
            command.Parameters.AddWithValue("equipoVisitante", ee.EquipoVisitante);
            command.Parameters.AddWithValue("tipoMercado", ee.TipoMercado);
            command.Parameters.AddWithValue("dineroApostado", ee.DineroApostado);

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
        internal void Save(Evento ev)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            command.CommandText = "INSERT INTO eventos(idEventos, equipoLocal, equipoVisitante, fecha) " +
                " VALUES(@idEventos, @equipoLocal, @equipoVisitante, @fecha);";

            command.Parameters.AddWithValue("idEventos", ev.IdEvento);
            command.Parameters.AddWithValue("equipoLocal", ev.EquipoLocal);
            command.Parameters.AddWithValue("equipoVisitante", ev.EquipoVisitante);
            command.Parameters.AddWithValue("fecha", ev.FechaEvento);

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
            