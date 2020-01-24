using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    
    public class Usuario
    {
        
        public Usuario(int id_usuario, String email, String nombre, String apellido, int edad)
        {

            UsuarioID = id_usuario;
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;

        }
        public Usuario()
        {

        }
        

        
        public int UsuarioID { get; set; }
        public String Email { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Edad { get; set; }
        public List<Apuesta> Apuestas { get; set; }
        public List<Cuenta> Cuentas { get; set; }
    }
    
    public class Usuario2
    {

        public Usuario2(String nombre)
        {


            Nombre = nombre;

        }
        public Usuario2()
        {

        }




        public String Nombre { get; set; }


    }
}
    

