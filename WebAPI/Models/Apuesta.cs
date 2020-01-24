using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Apuesta
    {
        public Apuesta(int id_apuesta, int id_evento, int id_mercado, int id_usuario, int tipo_apuesta, double cuota, double dinero_apostado)
        {
            ApuestaID = id_apuesta;
            EventoID = id_evento;
            MercadoID = id_mercado;
            UsuarioID = id_usuario;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;
         
        }
        

        public Apuesta()
        {

        }

        public int ApuestaID { get; set; }
        
        public int EventoID { get; set; }
        public int MercadoID { get; set; }
        public int UsuarioID { get; set; }
        public int Tipo_apuesta { get; set; }
        
        public double Cuota { get; set; }
        public double Dinero_apostado { get; set; }
        
        public Usuario Usuario { get; set; }
        public Mercado Mercado { get; set; }

    }
    public class ApuestaDTO
    {
        public ApuestaDTO(int id_apuesta, int id_evento, int id_usuario, int tipo_apuesta, double cuota, double dinero_apostado, Mercado mercado)
        {
            ApuestaID = id_apuesta;
            EventoID = id_evento;
            UsuarioID = id_usuario;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;
            Mercado = mercado;
  

        }

        public int ApuestaID { get; set; }
        public int EventoID { get; set; }
        public int Tipo_apuesta { get; set; }
        public double Cuota { get; set; }
        public double Dinero_apostado { get; set; }
        public int UsuarioID { get; set; }
        public Mercado Mercado { get; set; }
    }
    public class ApuestaExamen
    {
        public ApuestaExamen(double dinero_apostado, int tipo_apuesta, double cuota)
        {
            Dinero_apostado = dinero_apostado;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
     

        }


        
        public String Nombre { get; set; }
        public int Tipo_apuesta { get; set; }
        public double Cuota { get; set; }
        public double Dinero_apostado { get; set; }
        
    }
    public class Apuesta2
    {
        public Apuesta2(int id_apuesta)
        {
            
            ApuestaID = id_apuesta;


        }

     
        public int ApuestaID { get; set; }


    }



}