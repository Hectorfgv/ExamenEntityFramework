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
            
            Id_usuario = id_usuario;
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;

        }
        public Usuario(String email)
        {
            Email = email;
        }

        
        public int Id_usuario { get; set; }
        public String Email { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Edad { get; set; }

    }
    public class UsuarioDTO
    {
        public UsuarioDTO(String email)
        {
            
            Email = email;
           
        }
        
        public String Email { get; set; }
       

    }
}
