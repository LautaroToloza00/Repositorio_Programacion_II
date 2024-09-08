using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Data
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;
        // Constructor privado
        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.StrConnection);
        }
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }
        public DataTable ExecuteSPQuery(string sp)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = null;
            try
            {
                _connection.Open();
                cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                table.Load(cmd.ExecuteReader());

            }
            catch (Exception)
            {

                table = null;
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return table;
        }
    }
}
