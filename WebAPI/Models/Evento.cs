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
            EventoID = id_evento;
            Local = local;
            Visitante = visitante;
            Goles = goles;
        }
        public Evento ()
        {

        }
        

        public int EventoID { get; set; }
        public String Local { get; set; }
        public String Visitante { get; set; }
        public int Goles { get; set; }
        public List<Mercado> Mercados { get; set; }
    }
    public class EventoTeam
    {
        public EventoTeam(int id_evento)
        {
            EventoID = id_evento;
            
        }
        public EventoTeam()
        {

        }


        public int EventoID { get; set; }
        
    }
    /*
    public class EventoDTO
    {
        public EventoDTO(string local, string visitante)
        {
            
            Local = local;
            Visitante = visitante;
            
        }


        public String Local { get; set; }
        public String Visitante { get; set; }
        
    }*/
}

/*
public class EventoEXA
{
    public EventoEXA(int id_evento, string local, string visitante, double tipo_mercado)
    {
        EventoID = id_evento;
        Local = local;
        Visitante = visitante;
        Tipo_mercado = tipo_mercado;

    }

    public int EventoID { get; set; }
    public String Local { get; set; }
    public String Visitante { get; set; }
    public double Tipo_mercado { get; set; }
}*/
