using Facturacion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.Contratos
{
    public interface IFacturaRepository
    {
        List<Factura> GetAll();

        Factura? GetById(int id); //? significa que acepta valor nulo como retorno.
        bool Save(Factura factura);
        
    }
}
