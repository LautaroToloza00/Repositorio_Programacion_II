using Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Repositories.Contratos
{
    interface IClienteRepository
    {
        List<Cliente> GetAll();
        bool Add(Cliente cliente);
    }
}
