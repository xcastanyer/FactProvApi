using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactXCO.Models
{
    public class ProveedorModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string NIF { get; set; }
        public string Direccion { get; set; }
        public string DireccionFacturacion { get; set; }
        public string PersonaContacto1 { get; set; }
        public string PersonaContacto2 { get; set; }
        public string Telfono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Web { get; set; }
        public string DireccionMail1 { get; set; }
        public string NombreDireccionMail1 { get; set; }
        public string DireccionMail2 { get; set; }
        public string NombreDireccionMail2 { get; set; }

    }
}
