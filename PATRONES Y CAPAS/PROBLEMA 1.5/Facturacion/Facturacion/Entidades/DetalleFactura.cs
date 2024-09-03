using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entidades
{
    public class DetalleFactura
    {
        public int NroDetalle { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
    }
}
