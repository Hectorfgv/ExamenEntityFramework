using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebAPI.Models
{
    public class EventoRepository
    {
        private MySqlConnection Connect()
        {
            String connString = "Server=localhost;Port=3306;Database=adt1;Uid=root;password=;SslMode=none";
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

                Evento p = null;
                List<Evento> eventos = new List<Evento>();

                while (res.Read())
                {
                    Debug.WriteLine("Datos de partido: " + res.GetInt32(0) + " Equipo Local: " + res.GetString(1) +
                        " Equipo Visitante: " + res.GetString(2) + " Goles: " + res.GetInt32(3));
                    p = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
                    eventos.Add(p);
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
        internal List<EventoDTO> RetrieveEquipos()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select elocal, visitante from eventos";


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                EventoDTO p = null;
                List<EventoDTO> eventos = new List<EventoDTO>();

                while (res.Read())
                {
                    Debug.WriteLine(" Equipo Local: " + res.GetString(0) +
                        " Equipo Visitante: " + res.GetString(1));
                    p = new EventoDTO(res.GetString(0), res.GetString(1));
                    eventos.Add(p);
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
    }
}