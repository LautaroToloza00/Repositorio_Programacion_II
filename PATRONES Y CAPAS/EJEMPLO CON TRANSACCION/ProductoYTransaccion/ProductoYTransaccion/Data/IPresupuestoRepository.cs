using ProductoYTransaccion.Domine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoYTransaccion.Data
{
    public interface IPresupuestoRepository
    {
        List<Presupuesto> GetAll();
        Presupuesto? GetById(int id);
        bool Save(Presupuesto presupuesto);
        

    }
}
