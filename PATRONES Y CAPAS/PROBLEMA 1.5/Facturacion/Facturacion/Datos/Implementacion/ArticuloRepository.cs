using Facturacion.Datos.Contratos;
using Facturacion.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.Implementacion
{
    public class ArticuloRepository : IArticuloRepository
    {
        public List<Articulo> GetAll()
        {
            string spName = "SP_OBTENER_ARTICULOS";
            List<Articulo> lstArticulos = new List<Articulo>();
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery(spName);
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    Articulo a = new Articulo();
                    a.Codigo = (int)row["ID"];
                    a.Nombre = row["ARTICULO"].ToString();
                    a.PrecioUnitario = Convert.ToDouble(row["PRE_UNITARIO"]);

                    lstArticulos.Add(a);

                }
            }
            return lstArticulos;
        }
    }
}
