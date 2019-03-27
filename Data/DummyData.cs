using FactXCO.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactXCO.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Contexto>();
                context.Database.EnsureCreated();

                if (context.Proveedores != null && context.Proveedores.Any())
                {
                    return;
                }

                var Proveedores = DummyData.GetProveedores().ToArray();
                context.Proveedores.AddRange(Proveedores);
                context.SaveChanges();

                var Facturas = DummyData.GetFacturas().ToArray();
                context.FacturasProveedor.AddRange(Facturas);
                context.SaveChanges();
            }
        }

        private static List<FacturaProveedor> GetFacturas()
        {
            List<FacturaProveedor> F = new List<FacturaProveedor>()
            {
                new FacturaProveedor { ProveedorId = 1}
            };
            return F;
        }

        private static List<ProveedorModel> GetProveedores()
        {
            List<ProveedorModel> p = new List<ProveedorModel>()
            {
                new ProveedorModel { Nombre = "Proveedor 1", NIF = "B00000001", Direccion = "C/P, 1", DireccionFacturacion = "C/P, 1" },
                new ProveedorModel { Nombre = "Proveedor 2", NIF = "B00000002", Direccion = "C/P, 2", DireccionFacturacion = "C/P, 2" },
                new ProveedorModel { Nombre = "Proveedor 3", NIF = "B00000003", Direccion = "C/P, 3", DireccionFacturacion = "C/P, 3" }
            };
            return p;
        }
    }
}
