using System;
using System.Collections.Generic;

namespace Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public string PerfilImagen { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string TelefonoPersonal{ get; set; }
        public string TelefonoTrabajo { get; set; }
        public string Direccion { get; set; }
    }
}
