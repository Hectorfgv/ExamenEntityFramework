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

    }
}