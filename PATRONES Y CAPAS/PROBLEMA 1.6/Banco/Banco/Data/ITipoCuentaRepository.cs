using Banco.Domine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data
{
    public interface ITipoCuentaRepository
    {
        List<TipoCuenta> GetAll();

    }
}
