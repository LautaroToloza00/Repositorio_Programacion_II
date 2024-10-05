using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoYTransaccion.Domine
{
    public class Presupuesto
    {
        //Budget
        public int IdPresupuesto { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public int Vigencia { get; set; }

        public List<DetallePresupuesto> Detalles { get; set; }

        public Presupuesto()
        {
            Detalles = new List<DetallePresupuesto>();
        }
        public void AgregarDetalle(DetallePresupuesto detalle)
        {
            Detalles.Add(detalle);
            
        }
        public void EliminarDetalle(int index)
        {
            Detalles.RemoveAt(index);
        }
        public double CalcularTotal()
        {
            double total = 0;
            foreach (DetallePresupuesto detalle in Detalles)
            {
                total += detalle.SubTotal();
            }
            return total;
        }
    }
}
