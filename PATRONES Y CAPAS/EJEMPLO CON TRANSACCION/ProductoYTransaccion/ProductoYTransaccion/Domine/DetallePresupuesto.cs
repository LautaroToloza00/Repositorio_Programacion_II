using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoYTransaccion.Domine
{
    public class DetallePresupuesto
    {
        public Product Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

        public double SubTotal()
        {
            return Cantidad * Precio;
        }
    }
}
