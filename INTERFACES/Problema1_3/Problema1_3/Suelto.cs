using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_3
{
    public class Suelto : Producto
    {
        public int Medida { get; set; }

        public override double CalcularPrecio()
        {
            return Medida * Precio;
        }
        public override string ToString()
        {
            return "Nombre: " + Nombre + ", Precio: " + CalcularPrecio();

        }

    }
}
