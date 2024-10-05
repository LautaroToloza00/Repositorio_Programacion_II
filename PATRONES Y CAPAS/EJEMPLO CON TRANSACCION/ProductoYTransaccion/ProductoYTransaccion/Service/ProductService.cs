using ProductoYTransaccion.Data;
using ProductoYTransaccion.Domine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoYTransaccion.Service
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
