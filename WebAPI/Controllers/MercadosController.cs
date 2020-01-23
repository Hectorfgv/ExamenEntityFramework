using WebAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<Mercado> Get()
        {
            var repo = new MercadoRepository();
            List<Mercado> mercados = repo.Retrieve();
            return mercados;
        }

        public Mercado Get(int MercadoId)
        {
            var repo = new MercadoRepository();
            Mercado m = repo.RetrieveById(MercadoId);
            return m;
        }
        // GET: api/Mercados/tipo
        /*
        public IEnumerable<MercadoDTO> GetTipoMercado()
        {
            var repo = new MercadoRepository();
            List<MercadoDTO> mercados = repo.RetrieveTipoMercado();
            return mercados;
        }

        // GET: api/Mercados/5
        public IEnumerable<Mercado> GetIdEvento(int id_evento)
        {
            var repo = new MercadoRepository();
            List<Mercado> mercados = repo.RetrieveIdEvento(id_evento);
            return mercados;
        }
        */
        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
