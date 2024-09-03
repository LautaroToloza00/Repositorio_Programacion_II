﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entidades
{
    public class Factura
    {
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public Cliente Cliente { get; set; }

        // La lista que representa la relación uno a muchos con DetalleFactura
        public List<DetalleFactura> DtlFactura { get; set; } = new List<DetalleFactura>();
    }
}
