

using ProduccionBack.Entities;
using System.Data;
using System.Data.SqlClient;

namespace ProduccionBack.Data
{
    public class OrdenRepository : IOrdenRepository
    {
        public bool CancelarOrdenProduccion(int nro)
        {

            List<SqlParameter> listaParam = new List<SqlParameter>();
            listaParam.Add(new SqlParameter("@nro",nro));
            return DBHelper.GetInstancia().EjecutarSQL("SP_CANCELAR_ORDEN", listaParam) == 1;
            
            //------------------------------------------------------------------
            //bool aux = true;
            //SqlConnection conexion = DBHelper.GetInstancia().GetConnection();

            //try
            //{
            //    conexion.Open();
            //    SqlCommand cmd = new SqlCommand("SP_CANCELAR_ORDEN", conexion);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@nro", nro);
            //    aux = cmd.ExecuteNonQuery() == 1;
            //}
            //catch
            //{
            //    aux = false;
            //}
            //finally
            //{
            //    conexion.Close();
               
            //}

            //return aux;
        }

        public bool CrearOrden(OrdenProduccion orden)
        {
            bool aux = true;
            SqlConnection conexion = DBHelper.GetInstancia().GetConnection();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_MAESTRO", conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@nro_orden", SqlDbType.Int);
                p.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(p);
                cmd.Parameters.AddWithValue("@fecha", orden.Fecha);
                cmd.Parameters.AddWithValue("@modelo", orden.Modelo);
                cmd.Parameters.AddWithValue("@estado", orden.Estado);
                cmd.Parameters.AddWithValue("@cantidad", orden.Cantidad);
                cmd.ExecuteNonQuery();

                int nroOrden = (int)p.Value;

                foreach (DetalleOrden det in orden.ListaDetalles)
                {
                    SqlCommand cmd2 = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@nro_orden", nroOrden);
                    cmd2.Parameters.AddWithValue("@id", det.Id);
                    cmd2.Parameters.AddWithValue("@componente", det.Componente.Codigo);
                    cmd2.Parameters.AddWithValue("@cantidad", det.Cantidad);
                    cmd2.ExecuteNonQuery();

                }
                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                {
                    aux = false;
                    t.Rollback();
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }


            return aux;
        }



        public List<Componente> ObtenerComponentes()
        {
            DataTable tabla = DBHelper.GetInstancia().Consultar("SP_CONSULTAR_COMPONENTES");
            List<Componente> lista = new List<Componente>();

            foreach (DataRow row in tabla.Rows)
            {
                int cod = int.Parse(row["codigo"].ToString());
                string nombre = row["nombre"].ToString();
                Componente c = new Componente(cod, nombre);
                lista.Add(c);
            }

            return lista;
        }

        public List<OrdenProduccion> OrdenesProduccion(DateTime? fecha, string? estado)
        {
            List<SqlParameter> listParam = new List<SqlParameter>();

            if (!fecha.HasValue)
            {
                //DBNull le pasa el nulo dependiendo la BD
                listParam.Add(new SqlParameter("@fecha", DBNull.Value));
            }    
            else { 
                listParam.Add(new SqlParameter("@fecha",fecha));
            }

            if (string.IsNullOrEmpty(estado))
            {
                listParam.Add(new SqlParameter("@estado", DBNull.Value));
            }
            else
            {
                listParam.Add(new SqlParameter("@estado", estado));
            }
            DataTable tabla = DBHelper.GetInstancia().Consultar("SP_CONSULTAR_ORDENES",listParam);
            List<OrdenProduccion> lista = new List<OrdenProduccion>();

            foreach (DataRow row in tabla.Rows)
            {
                int nro_orden = Convert.ToInt32(row["nro_orden"].ToString());
                DateTime date = Convert.ToDateTime(row["fecha"].ToString());
                string modelo = row["modelo"].ToString();
                string state = row["estado"].ToString();
                int cantidad = Convert.ToInt32(row["cantidad"].ToString());

                //OrdenProduccion orden = new OrdenProduccion(nro_orden,date,modelo,state,cantidad);
                //lista.Add(orden);

                // Igual a llamar a un constructor con parametros
                lista.Add(new OrdenProduccion()
                {
                    Nro = nro_orden,
                    Fecha = date,
                    Modelo = modelo,
                    Estado = state,
                    Cantidad = cantidad
                });
            }
            return lista;
        }
    }
}
