using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Facturacion.Datos
{
    public class DataHelper
    {
        /*Acá se aplica el patron de diseño (SINGLETON).
         
        PASOS: 
        1. ATRIBUTO ESTATICO DEL TIPO DATAHELPER. LO LLAMAREMOS _INSTANCE
        2. EL CONSTRUCTOR TIENE QUE ESTAR EN PRIVATE.
        3. METODO ESTATICO CON ACCESO A LA UNICA INSTANCIA DEL DATAHELPER.*/

        private static DataHelper _instance; //Paso 1 implementado.
        private SqlConnection _connection;

        private DataHelper() //Paso 2 implementado
        {
            /*Para pasarle la cadena de conexion, tenes que ir al nombre del proyecto (Facturacion).
             * ir a propiedades.
             * recursos y generar recursos.
             * ponerle un nombre y pasarle la cadena de conexion.
             * esto te generara una carpeta Properties con un archivo Resources.
             */

            _connection = new SqlConnection(Properties.Resources.StrConnection);
        }
        public static DataHelper GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
