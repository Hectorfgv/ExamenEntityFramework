using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebAPI.Models;
using System.Data.Entity;

namespace WebAPI.Models
{
    public class ApuestaRepository
    {
        internal List<Apuesta> Retrieve()
        {


            List<Apuesta> todos = new List<Apuesta>();
            using (DDBBContext context = new DDBBContext())
            {
                //todos = context.Apuestas.ToList();
                todos = context.Apuestas.Include(m => m.Mercado).ToList();
            }
            return todos;


        }

        internal Apuesta RetrieveById(int id)
        {
            Apuesta apuestas;
            using (DDBBContext context = new DDBBContext())
            {
                apuestas = context.Apuestas
                    .Where(s => s.ApuestaID == id)
                    .FirstOrDefault();
            }
            return apuestas;
        }

        internal void Save(Apuesta a)
        {
            DDBBContext context = new DDBBContext();
            context.Apuestas.Add(a);
            context.SaveChanges();

            Mercado mer = new Mercado();
            mer = context.Mercados
                        .Where(m => m.MercadoID == a.MercadoID).FirstOrDefault();


            if (a.Tipo_apuesta == 0)
            {
                mer.Dinero_under += a.Dinero_apostado;

            }
            else
            {
                mer.Dinero_over += a.Dinero_apostado;
            }

            var probOver = mer.Dinero_over / (mer.Dinero_under + mer.Dinero_over);
            var probUnder = mer.Dinero_under / (mer.Dinero_over + mer.Dinero_under);

            mer.Cuota_under = Math.Round(Convert.ToDouble((1 / probOver) * 0.95));
            mer.Cuota_over = Math.Round(Convert.ToDouble((1 / probUnder) * 0.95));

            context.Mercados.Update(mer);
            context.SaveChanges();
        }

        public ApuestaDTO ToDTO(Apuesta a)
        {
            return new ApuestaDTO(a.ApuestaID, a.EventoID, a.UsuarioID, a.Tipo_apuesta, a.Cuota, a.Dinero_apostado, a.Mercado);
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            DDBBContext context = new DDBBContext();
            List<ApuestaDTO> apuestasDTO = new List<ApuestaDTO>();
           
            apuestasDTO = context.Apuestas.Include(a => a.Mercado).Select(m => ToDTO(m)).ToList();
            return apuestasDTO;
        }
        /*
        private MySqlConnection Connect()
        {
            String connString = "Server=localhost;Port=3306;Database=adt1;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
       
        internal List<ApuestaDTO> RetrieveApuesta()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT a.tipo_apuesta, a.cuota, a.dinero_apostado, b.email, c.id_mercado FROM apuestas a," +
                " usuarios b, mercados c WHERE b.id_usuario = a.usuarios_id_usuarios AND c.id_mercado=a.mercados_id_mercado";


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();

                while (res.Read())
                {
                    Debug.WriteLine("Tipo de apuesta: " + res.GetInt32(0) + " Cuota: " + res.GetDouble(1) +
                        " Dinero apostado: " + res.GetDouble(2) + " Email Usuario: " + res.GetString(3) + " Id Mercado: " + res.GetInt32(4));
                    a = new ApuestaDTO(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetString(3), res.GetInt32(4));

                    apuestas.Add(a);

                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }



        }
       
        internal void insertarApuesta(ApuestaDTO aps)
        {

            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            Debug.WriteLine("apuesta vale " + aps);

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

        }
        /*internal List<Apuesta> RetrieveApuestas1(String email)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select id_usuario from usuarios where email='"+email+"'";
            Debug.WriteLine("COMMAND " + command.CommandText);
       
            try
            {
                Debug.WriteLine("Entro por aqui");
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión "+e.Message);
                con.Close();
            }

            con.Open();
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();

            int userid = reader.GetInt32(0);

            Debug.WriteLine("Obtento " + userid);

            reader.Close();
            con.Close();

            
            con.Open();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select m.eventos_id_evento, m.over_under, a.tipo_apuesta, a.cuota, a.dinero_apostado from mercados m, apuestas a" +
                " where a.mercados_id_mercado=m.id_mercado and a.usuarios_id_usuarios=" + userid;
            
            con.Close();
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta m = null;
                List<Apuesta> datos = new List<Apuesta>();

                while (res.Read())
                {
                    Debug.WriteLine("Id evento:  " + res.GetInt32(0) + " tipo mercado " + res.GetDouble(1) + " tipo apuesta : " + res.GetInt32(2)
                        + " cuota : " + res.GetDouble(3) + " cinero postado : " + res.GetDouble(4));

                    m = new Apuesta(res.GetInt32(0), res.GetDouble(1), res.GetInt32(2), res.GetDouble(3), res.GetDouble(4));
                    datos.Add(m);
                }
                con.Close();
                return datos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }


        }

        internal List<Apuesta> RetrieveApuestas2(int id_mercado)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT u.email, m.over_under, a.tipo_apuesta, a.cuota, a.dinero_apostado FROM usuarios u, mercados m, " +
                "apuestas a WHERE m.id_mercado= " + id_mercado + "AND a.mercados_id_mercado= " + id_mercado+" AND u.id_usuario= a.usuarios_id_usuarios;";
            

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta m = null;
                List<Apuesta> datos = new List<Apuesta>();

                while (res.Read())
                {
                    Debug.WriteLine("Email de usuario:  " + res.GetString(0) +" tipo de mercado:  " + res.GetDouble(1) + " tipo de apuesta: " + res.GetInt32(2)
                        + " cuota:  " + res.GetDouble(3)+" dinero apostado:  " + res.GetDouble(4));

                    m = new Apuesta(res.GetString(0), res.GetDouble(1), res.GetInt32(2), res.GetDouble(3), res.GetDouble(4));
                    datos.Add(m);
                }
                con.Close();
                return datos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }


        }
        
        internal List<Apuesta2> RetrieveApuestas1(double menor, double mayor)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM apuestas WHERE cuota BETWEEN " + menor + " AND " + mayor;


            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta2 a = null;
                List<Apuesta2> apuestas = new List<Apuesta2>();

                while (res.Read())
                {
                    Debug.WriteLine("Tipo de apuesta: " + res.GetInt32(0) + " Cuota: " + res.GetDouble(1) +
                        " Dinero apostado: " + res.GetDouble(2) + " Id Mercado: " + res.GetInt32(3) + " Id Usuario: " + res.GetInt32(4) + " Id Evento" +res.GetInt32(5));
                    a = new Apuesta2(res.GetInt32(0), res.GetDouble(1), res.GetInt32(2), res.GetInt32(3), res.GetInt32(4), res.GetInt32(5));

                    apuestas.Add(a);

                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }



        }
        internal List<ApuestaExamen> ApuestasExamen()
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select a.dinero_apostado, a.cuota, u.nombre from apuestas a, usuarios u where u.id_usuario=a.usuarios_id_usuarios";
            Debug.WriteLine("COMMAND " + command.CommandText);
            
    
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaExamen m = null;
                List<ApuestaExamen> datos = new List<ApuestaExamen>();

                while (res.Read())
                {
                    Debug.WriteLine("Cantidad:  " + res.GetDouble(0) + " Nombre_usuario " + res.GetString(2) + " Cuota_apuesta : " + res.GetDouble(1));

                    m = new ApuestaExamen(res.GetDouble(0), res.GetString(2), res.GetDouble(1));
                    datos.Add(m);
                }
                con.Close();
                return datos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }


        }*/





    }
}
 