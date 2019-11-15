using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebAPI.Models
{
    public class MercadoRepository
    {
        private MySqlConnection Connect()
        {
            String connString = "Server=localhost;Port=3306;Database=adt1;Uid=root;password=;SslMode=none";
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
                    Debug.WriteLine("Datos de mercado: id: " + res.GetInt32(0) + " id_evento: " + res.GetString(1) +
                        " over_under " + res.GetDouble(2) + " cuota_over: " + res.GetDouble(3) + " cuota_under " + res.GetDouble(4)
                        + " dinero_over " + res.GetDouble(5) + " dinero_under " + res.GetDouble(6));
                    m = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5)
                        , res.GetDouble(6));
                    mercados.Add(m);
                }
                con.Close();
                return mercados;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
        internal List<MercadoDTO> RetrieveTipoMercado()
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
                    Debug.WriteLine("Datos de mercado: Tipo: " + res.GetInt32(0) + " cuota_over: " + res.GetString(1) +
                        " cuota_under " + res.GetDouble(2));
                    m = new MercadoDTO(res.GetDouble(1), res.GetDouble(2), res.GetDouble(3));
                    mercados.Add(m);
                }
                con.Close();
                return mercados;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }


        }
        internal List<Mercado> RetrieveIdEvento(int id_evento)
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select over_under, cuota_over, cuota_under from mercados where eventos_id_evento=" + id_evento;


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
                List<Mercado> partidos = new List<Mercado>();

                while (res.Read())
                {
                    Debug.WriteLine("Cuotas de mercado:  tipo de mercado: " + res.GetDouble(0) +
                        " cuota over " + res.GetDouble(1) + " cuota under: " + res.GetDouble(2));

                    m = new Mercado(res.GetDouble(0), res.GetDouble(1), res.GetDouble(2));
                    partidos.Add(m);
                }
                con.Close();
                return partidos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }


        }

    }
}