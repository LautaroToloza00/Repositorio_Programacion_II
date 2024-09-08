using Producto.Data;
using Producto.Domine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Service
{
    public class ProductService
    {
        private IProductRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }
        public List<Product> GetProducts()
        {
            return _repository.GetAll();
        }
    }
}
