using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
        /*internal void EventoInsert(EventoEXA aps)
        {

            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

           

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into apuestas(tipo_apuesta,cuota,dinero_apostado,mercados_id_mercado,usuarios_id_usuarios) values ('" + aps.Tipo_apuesta + "','" + aps.Cuota +
                "','" + aps.Dinero_apostado + "'" + ",'" + aps.Id_mercado + "','" + aps.Email + "')";
            Debug.WriteLine("comando " + command.CommandText);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                con.Close();
            }

            con.Open();

            command.CommandText = "select dinero_over from mercados where id_mercado=" + aps.Id_mercado + "; ";
            Debug.WriteLine("COMMAND " + command.CommandText);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();

            double dineroOver = reader.GetDouble(0);

            reader.Close();
            con.Close();
            con.Open();

            command.CommandText = "select dinero_under from mercados where id_mercado=" + aps.Id_mercado + "; ";

            reader = command.ExecuteReader();
            reader.Read();

            double dineroUnder = reader.GetDouble(0);

            reader.Close();
            con.Close();

            if (aps.Tipo_apuesta == 1)
            {
                dineroOver = dineroOver + aps.Dinero_apostado;
            }
            else
            {
                dineroUnder = dineroUnder + aps.Dinero_apostado;
            }

            Debug.WriteLine(dineroOver);
            Debug.WriteLine(dineroUnder);

            double po = dineroOver / (dineroOver + dineroUnder);
            double pu = dineroUnder / (dineroUnder + dineroOver);

            Debug.WriteLine(po);
            Debug.WriteLine(pu);

            double co = Convert.ToDouble((1 / po) * 0.95);
            double cu = Convert.ToDouble((1 / pu) * 0.95);


            if (aps.Tipo_apuesta == 1)
            {
                command.CommandText = "update mercados set cuota_over = '" + co + "',cuota_under = '" + cu + "',  dinero_over = '" + dineroOver + "' where id_mercado =" + aps.Id_mercado + ";";

                try
                {
                    con.Open();

                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Error " + e);
                }
                con.Close();
            }
            else
            {
                command.CommandText = "update mercados set cuota_under = '" + cu + "', cuota_over = '" + co + "',  dinero_under = '" + dineroUnder + "' where id_mercado =" + aps.Id_mercado + "; ";

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Error " + e);
                }
                con.Close();
            }

        }*/

    }
}