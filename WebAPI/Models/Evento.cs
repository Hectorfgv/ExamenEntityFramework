using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Evento
    {
        public Evento(int id_evento, string local, string visitante, int goles)
        {
            Id_evento = id_evento;
            Local = local;
            Visitante = visitante;
            Goles = goles;
        }
        

        public int Id_evento { get; set; }
        public String Local { get; set; }
        public String Visitante { get; set; }
        public int Goles { get; set; }
    }

    public class EventoDTO
    {
        public EventoDTO(string local, string visitante)
        {
            
            Local = local;
            Visitante = visitante;
            
        }


        public String Local { get; set; }
        public String Visitante { get; set; }
        
    }
}
public class EventoEXA
{
    public EventoEXA(int id_evento, string local, string visitante, double tipo_mercado)
    {
        Id_evento = id_evento;
        Local = local;
        Visitante = visitante;
        Tipo_mercado = tipo_mercado;

    }

    public int Id_evento { get; set; }
    public String Local { get; set; }
    public String Visitante { get; set; }
    public double Tipo_mercado { get; set; }
}
