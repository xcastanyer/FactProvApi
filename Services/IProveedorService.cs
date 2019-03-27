using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactXCO.Models;

namespace FactXCO.Services
{
    public interface IProveedorService
    {
        ProveedorModel AddProveedor(ProveedorModel item);
    }
}
