using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactXCO.Models
{
    public class IvaFactura
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Tipo { get; set; }
        public decimal ImporteIva { get; set; }
        public decimal BaseImponible { get; set; }
    }
}
