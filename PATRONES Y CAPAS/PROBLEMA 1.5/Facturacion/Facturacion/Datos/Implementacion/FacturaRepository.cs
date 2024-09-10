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
    public class FacturaRepository : IFacturaRepository
    {
        public List<Factura> GetAll()
        {
            throw new NotImplementedException();
        }

        public Factura? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Factura factura)
        {
            bool result = true;
            SqlConnection cnn = null;
            SqlTransaction t = null;
            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                //Comienza el maestro
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_MAESTRO",cnn,t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_forma_pago",factura.FormaPago.Id);
                cmd.Parameters.AddWithValue("@cliente",factura.Cliente);
                SqlParameter param = new SqlParameter("@id",SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                int nro_factura = (int)param.Value;
                //Comienza el detalle
                int id_detalle = 1;
                
                foreach (DetalleFactutura detalle in factura.Detalles)
                {
                    SqlCommand detCmd = new SqlCommand("SP_INSERTAR_DETALLE",cnn,t);
                    detCmd.CommandType = CommandType.StoredProcedure;
                    
                    detCmd.Parameters.AddWithValue("@id_detalle",id_detalle);
                    detCmd.Parameters.AddWithValue("@nro_factura",nro_factura);
                    detCmd.Parameters.AddWithValue("@id_articulo",detalle.Articulo.Codigo);
                    detCmd.Parameters.AddWithValue("@cantidad",detalle.Cantidad);
                    detCmd.ExecuteNonQuery();
                    id_detalle++;
                }
                t.Commit();
                

            }
            catch (SqlException)
            {

                if(t != null)
                {
                    t.Rollback();
                }
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
