using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FactXCO.Models
{
    public class FacturaProveedor
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public ICollection<VencimientoFactura> Vencimientos { get; set; }
        public decimal? TipoIRPF { get; set; }
        public decimal? ImporteIRPF { get; set; }
        public ICollection<IvaFactura> Iva { get; set; }
        public ProveedorModel Proveedor { get; set; }
        public int ProveedorId { get; set; }
        public decimal ImpertoTotal { get; set; }
        public bool EsRectificativa { get; set; }
        public string ReferenciaFacturaRectificada { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal ImporteTotal { get; set; }

    }
}
