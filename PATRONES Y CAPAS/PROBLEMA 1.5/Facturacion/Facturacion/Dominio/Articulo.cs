﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Dominio
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }

        public override string ToString()
        {
            return "Articulo: "+Codigo+", "+Nombre+", "+PrecioUnitario+" $";
        }
       
    }

}
