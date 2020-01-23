using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Cuenta
    {
        public Cuenta(int id_cuenta, string NombreBanco, string NumeroTarjeta, int SaldoActual, int usuariosId)
        {
            CuentaID = id_cuenta;
            NombreBanco = NombreBanco;
            NumeroTarjeta = NumeroTarjeta;
            SaldoActual = SaldoActual;
            UsuarioID = usuariosId;
        }
        public Cuenta () { }

        public int CuentaID { get; set; }
        public string NombreBanco { get; set; }
        public string NumeroTarjeta { get; set; }
        public int SaldoActual { get; set; }

        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
    }
}