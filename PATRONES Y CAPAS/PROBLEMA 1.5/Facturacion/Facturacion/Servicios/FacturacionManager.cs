using Facturacion.Datos.Contratos;
using Facturacion.Datos.Implementacion;
using Facturacion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Servicios
{
    public class FacturacionManager
    {
        IArticuloRepository _articuloRepository;
        public FacturacionManager()
        {
            _articuloRepository = new ArticuloRepository();
        }

        public List<Articulo> GetAllArticulos()
        {
            return _articuloRepository.GetAll();
        }
        public bool GuardarArticulo(Articulo articulo){
            return _articuloRepository.Save(articulo);
        }
    }
}
