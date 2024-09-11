using Facturacion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.Contratos
{
    public interface IArticuloRepository
    {
        // CRUD

        // Read
        List<Articulo> GetAll();

        // Create - Update
        bool Save(Articulo articulo);

        // Delete
        bool Delete(int id);


    }
}
