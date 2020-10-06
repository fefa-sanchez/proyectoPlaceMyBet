﻿using MySql.Data.MySqlClient;
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
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3));
                    ev = new Evento(res.GetString(0), res.GetString(1), res.GetString(2), res.GetString(3));
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
    }
}
            