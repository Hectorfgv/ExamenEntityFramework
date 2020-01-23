using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebAPI.Models
{
    public class Mercado
    {
        
        public Mercado()
        {
            

        }

        public Mercado(int id_mercado, double over_under, double cuota_over, double cuota_under, double dinero_over, double dinero_under, int id_evento)
        {
            MercadoID = id_mercado;  
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Dinero_over = dinero_over;
            Dinero_under = dinero_under;
            EventoID = id_evento;

        }

        public int MercadoID { get; set; }    
        public double Over_under { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
        public double Dinero_over { get; set; }
        public double Dinero_under { get; set; }
        public Evento Evento { get; set; }
        public int EventoID { get; set; }
        public List<Apuesta> Apuestas { get; set; }

    }
    /*
    public class MercadoDTO
    {
        public MercadoDTO(double over_under, double cuota_over, double cuota_under)
        {
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;

        }

       

        
        public double Over_under { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
       

    }
    */
}
