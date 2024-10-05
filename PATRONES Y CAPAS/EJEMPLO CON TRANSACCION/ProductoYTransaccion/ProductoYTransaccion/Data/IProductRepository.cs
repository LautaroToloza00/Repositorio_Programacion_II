using ProductoYTransaccion.Domine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoYTransaccion.Data
{
    public interface IProductRepository
    {
        //Select
        List<Product> GetAll();
        Product? GetById(int id); // ? indica que permite retornar un valor nulo.

        //Insert - Update
        bool Save(Product product);
        // Delete
        bool Delete(int id);
    }
}
