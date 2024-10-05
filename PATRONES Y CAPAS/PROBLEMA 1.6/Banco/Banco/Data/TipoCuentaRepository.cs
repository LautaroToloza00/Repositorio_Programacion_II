using Banco.Domine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data
{
    public class TipoCuentaRepository : ITipoCuentaRepository
    {
        public List<TipoCuenta> GetAll()
        {
            List<TipoCuenta> lst = new List<TipoCuenta>();
            string sp = "OBTENER_TIPOS_CUENTAS";

            var dt =  DataHelper.GetInstance().ExecuteSPQuery(sp);
            if(dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    TipoCuenta tc = new TipoCuenta();

                    tc.Id =  (int)row["ID"];
                    tc.Nombre = row["NOMBRE"].ToString();

                    lst.Add(tc);
                }
            }
            return lst;
        }

        
    }
}
