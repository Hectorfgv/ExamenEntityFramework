using System;
using WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

namespace WebAPI.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<Apuesta> Get()
        {
            var repo = new ApuestaRepository();
            List<Apuesta> apuestas = repo.Retrieve();
            return apuestas;
        }

        public Apuesta Get(int ApuestaId)
        {
            var repo = new ApuestaRepository();
            Apuesta m = repo.RetrieveById(ApuestaId);
            return m;
        }
        //[Authorize(Roles="Standard")]
        //GET: API/Apuestas
        /*public IEnumerable<ApuestaDTO> GetDatosApuesta()
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveApuesta();
            return apuestas;
        }*/
        // GET: api/Apuestas?email={email} 
        /*
        public IEnumerable<Apuesta2> GetApuestas1(double menor, double mayor)
        {
            var repo = new ApuestaRepository();
            List<Apuesta2> apuesta = repo.RetrieveApuestas1(menor, mayor);
            return apuesta;
        }
        // GET: api/Apuestas?id_mercado={id_mercado}
        public IEnumerable<ApuestaExamen> GetApuestasExamen()
        {
            var repo = new ApuestaRepository();
            List<ApuestaExamen> apuesta = repo.ApuestasExamen();
            return apuesta;
        }

        // POST: api/Apuestas
        public void PostApuesta([FromBody]ApuestaDTO aps)
        {
            Debug.WriteLine("DENTRO de post apuesta vale " + aps);
            var repo = new ApuestaRepository();
            repo.insertarApuesta(aps);
        }
        */


        // PUT: api/Apuestas/5
        /*public void Put(int id, [FromBody]string value)
        {
        }*/


        /*public void PutApuesta(int id_mercado, String email_usuario, int tipo_apuesta, double cuota, double dinero)
        {
            var repo = new ApuestaRepository();
            repo.insertarApuesta(id_mercado, email_usuario, tipo_apuesta, cuota, dinero);
        }*/

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
