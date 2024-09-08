using Producto.Domine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Data
{
    public class ProductRepository : IProductRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            string spName = "SP_RECUPERAR_PRODUCTOS";
            List<Product> lst = new List<Product>();

            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery(spName);

            if (dt.Rows.Count > 0) {
                
                foreach (DataRow row in dt.Rows)
                {
                    Product p = new Product();
                    p.Codigo = (int)row["CODIGO"];
                    p.Nombre = row["N_PRODUCTO"].ToString();
                    p.Precio = (double)row["PRECIO"];
                    p.Stock = (int)row["STOCK"];
                    p.Activo = (bool)row["ESTA_ACTIVO"];

                    lst.Add(p);
                }
            }

            return lst;
        }

        public Product? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
