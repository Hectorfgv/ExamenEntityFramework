using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Apuesta
    {
        public Apuesta(int id_apuesta, int id_mercado, int id_usuario, int tipo_apuesta, double cuota, double dinero_apostado)
        {
            Id_apuesta = id_apuesta;
            Id_mercado = id_mercado;
            Id_usuario = id_usuario;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;
         
        }
        public Apuesta(int tipo_apuesta, double cuota, double dinero_apostado)
        {
            
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;

        }
         public Apuesta (int id_evento, double tipo_mercado, int tipo_apuesta, double cuota, double dinero_apostado)
        {
            Id_evento = id_evento;
            Tipo_mercado = tipo_mercado;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;


        }
        public Apuesta(String email, double tipo_mercado, int tipo_apuesta, double cuota, double dinero_apostado)
        {
            Email = email;
            Tipo_mercado = tipo_mercado;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;


        }

        public int Id_apuesta { get; set; }
        public String Email { get; set; }

        public int Id_evento { get; set; }
        public int Id_mercado { get; set; }
        public int Id_usuario { get; set; }
        public int Tipo_apuesta { get; set; }
        public double Tipo_mercado { get; set; }
        public double Cuota { get; set; }
        public double Dinero_apostado { get; set; }
       
    }
    public class ApuestaDTO
    {
        public ApuestaDTO(int tipo_apuesta, double cuota, double dinero_apostado, String email, int id_mercado)
        {
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;
            Email = email;
            Id_mercado = id_mercado;
            

        }

      
        public int Id_mercado { get; set; }
        public int Tipo_apuesta { get; set; }
        public String Email { get; set; }
        public double Cuota { get; set; }
        public double Dinero_apostado { get; set; }

    }
    
}