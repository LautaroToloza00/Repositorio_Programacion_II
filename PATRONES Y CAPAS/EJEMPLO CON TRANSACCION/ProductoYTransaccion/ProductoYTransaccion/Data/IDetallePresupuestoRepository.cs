using ProductoYTransaccion.Domine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoYTransaccion.Data
{
    public interface IDetallePresupuestoRepository
    {
        List<DetallePresupuesto> GetAll();
        DetallePresupuesto GetById(int id);
        bool Save(DetallePresupuesto detalle);
        bool Delete(int id);
    }
}
