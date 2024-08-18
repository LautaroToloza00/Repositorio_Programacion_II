using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_3
{
    public class Pack : Producto
    {
        public int Cantidad { get; set; }
        public override double CalcularPrecio()
        {
            return Cantidad * Precio;
        }
        public override string ToString()
        {
            return "Nombre: " + Nombre + ", Precio: " + CalcularPrecio();

        }
    }
}
