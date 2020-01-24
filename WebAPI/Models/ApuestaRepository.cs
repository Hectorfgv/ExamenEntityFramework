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

        public Apuesta2 ToID(Apuesta a)
        {
            return new Apuesta2(a.ApuestaID);
        }
        /*
        internal List<Apuesta2> Retrieve()
        {
            DDBBContext context = new DDBBContext();
            List<Apuesta2> apuestasDTO = new List<Apuesta2>();

            apuestasDTO = context.Apuestas.Where(b => b.Cuota < 1.8).Select(m => ToID(m)).ToList();
            return apuestasDTO;
        }

        */

        internal List <Apuesta> RetrieveByTeam(String eq)
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using (DDBBContext context = new DDBBContext())
            {

                apuestas = context.Apuestas.Where(a => a.Mercado.Evento.Local == eq || a.Mercado.Evento.Visitante == eq).ToList();
            }
            return apuestas;
        }






    }
}
 