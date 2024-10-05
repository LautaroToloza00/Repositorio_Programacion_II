using Banco.Data;
using Banco.Domine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Service
{
    public class TipoCuentaService
    {
        private ITipoCuentaRepository _repository;
        public TipoCuentaService()
        {
            _repository = new TipoCuentaRepository();
        }
        public List<TipoCuenta> GetTiposCuenta()
        {
            return _repository.GetAll();
        }
    }
}
