using ProductoYTransaccion.Domine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoYTransaccion.Data
{
    public class PresupuestoRepository : IPresupuestoRepository
    {
        

        public List<Presupuesto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Presupuesto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Presupuesto presupuesto)
        {
            bool result = true;
            SqlConnection cnn = null;
            SqlTransaction t = null;
            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();
                //Quiero ver si puedo mandar el comand arriba despues
                var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente",presupuesto.Cliente);
                cmd.Parameters.AddWithValue("@vigencia",presupuesto.Vigencia);
                SqlParameter param = new SqlParameter("@id",SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                // A partir de acá comienza el detalle..
                int nro_presupuesto = Convert.ToInt32(param.Value);
                int id_detalle = 1;

                foreach (DetallePresupuesto detalle in presupuesto.Detalles)
                {
                    SqlCommand detCmd = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    detCmd.CommandType = CommandType.StoredProcedure;
                    detCmd.Parameters.AddWithValue("@presupuesto",nro_presupuesto);
                    detCmd.Parameters.AddWithValue("@id_detalle", id_detalle);
                    detCmd.Parameters.AddWithValue("@producto",detalle.Producto.Codigo);
                    detCmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    detCmd.Parameters.AddWithValue("@precio", detalle.Precio);
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
