﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.Entity;


namespace WebAPI.Models
{
    public class EventoRepository
    {
        internal List<Evento> Retrieve()
        {


            List<Evento> todos = new List<Evento>();
            using (DDBBContext context = new DDBBContext())
            {
                todos = context.Eventos.ToList();
            }
            return todos;

        }
        internal void Save(Evento e)
        {
            DDBBContext context = new DDBBContext();
            context.Eventos.Add(e);
            context.SaveChanges();
        }
        internal void Update(int id, Evento ev)
        {
            Evento evento;
            using (DDBBContext context = new DDBBContext())
            {
                evento = context.Eventos.Where(e => e.EventoID == id).FirstOrDefault();
                evento.Local = ev.Local;
                evento.Visitante = ev.Visitante;
                context.SaveChanges();
            }
        }
        internal void Delete(int id)
        {
            using (DDBBContext context = new DDBBContext())
            {
                context.Eventos.Remove(context.Eventos.Where(e => e.EventoID == id).FirstOrDefault());
                context.SaveChanges();
            }
        }
        /*
        public EventoExamen ToID(Evento e)
        {
            return new EventoExamen(e.Local, e.Visitante, e.Mercado);
        }

        internal List<EventoExamen> RetrieveByTeam(String eq)
        {
            List<EventoExamen> apuestas = new List<EventoExamen>();
            using (DDBBContext context = new DDBBContext())
            {

                apuestas = context.Eventos.Where(e => e.Local == eq || e.Visitante == eq).Include(m => m.Mercado.).Select(m => ToID(m)).ToList();

                
            }
            return apuestas;
        }
        */
       

    }
}