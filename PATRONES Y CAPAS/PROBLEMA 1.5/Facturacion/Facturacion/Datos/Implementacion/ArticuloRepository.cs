using Facturacion.Datos.Contratos;
using Facturacion.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public bool Save(Articulo articulo)
        {
            bool result = true;
            SqlConnection cnn = null;
            string nameSp = "SP_GUARDAR_ARTICULO";
            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(nameSp,cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@articulo",articulo.Nombre);
                cmd.Parameters.AddWithValue("@precio",articulo.PrecioUnitario);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                result = false;
            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
