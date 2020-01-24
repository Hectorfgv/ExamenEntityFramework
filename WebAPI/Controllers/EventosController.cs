using System;
using WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<Evento> Get()
        {
            var repo = new EventoRepository();
            List<Evento> eventos = repo.Retrieve();
            return eventos;
        }
        //examen
        /*
        public List<Evento> Get(string equipo)
        {
            var repo = new EventoRepository();
            return repo.RetrieveByTeam(equipo);

        }*/


        // POST: api/Eventos
        public void Post([FromBody]Evento evento)
        {
            var repo = new EventoRepository();
            repo.Save(evento);
        }
        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]Evento ev)
        {
            var repo = new EventoRepository();
            repo.Update(id, ev);
        }
        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
            var repo = new EventoRepository();
            repo.Delete(id);
        }

        // GET: api/Eventos
        /*
        public IEnumerable<EventoDTO> GetEquipos()
        {
            var repo = new EventoRepository();
            List<EventoDTO> eventos = repo.RetrieveEquipos();
            return eventos;
        }


        // POST: api/Eventos
        public void PostEvento([FromBody]EventoEXA aps)
        {
            
            var repo = new EventoInsert();
            repo.insertarApuesta(aps);
        }*/

        // PUT: api/Eventos/5
        /*
        public void Put(int id, [FromBody]string value)
        {
        }
        */
        /*
        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
        */
    }
}
