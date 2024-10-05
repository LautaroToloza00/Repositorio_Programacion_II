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
        IFacturaRepository _facturaRepository;
        public FacturacionManager()
        {
            _articuloRepository = new ArticuloRepository();
            _facturaRepository = new FacturaRepository();
        }
        public bool InsertarFactura(Factura factura)
        {
            return _facturaRepository.Save(factura);
        }

        // Metodos para articulos
        public List<Articulo> GetAllArticulos()
        {
            return _articuloRepository.GetAll();
        }
        public bool GuardarArticulo(Articulo articulo){
            return _articuloRepository.Save(articulo);
        }
        public bool EliminarArticulo(int id)
        {
            return _articuloRepository.Delete(id);
        }
    }
}
