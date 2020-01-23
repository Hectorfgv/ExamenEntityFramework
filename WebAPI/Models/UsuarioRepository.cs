using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data.Entity;



namespace WebAPI.Models
{
    public class UsuarioRepository
    {   
        /*
        private MySqlConnection Connect()
        {
            String connString = "Server=localhost;Port=3306;Database=adt1;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<UsuarioDTO> RetrieveEmail()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados";


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                UsuarioDTO m = null;
                List<UsuarioDTO> mercados = new List<UsuarioDTO>();

                while (res.Read())
                {
                    Debug.WriteLine("Email Usuario: " + res.GetString(1));
                    m = new UsuarioDTO(res.GetString(1));
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

        }*/
    }
}