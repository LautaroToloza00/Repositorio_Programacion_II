using Producto.Domine;
using Producto.Service;

ProductService oService = new ProductService();
List<Product> lstProducts = oService.GetProducts();

if(lstProducts.Count > 0)
{
	foreach (Product product in lstProducts)
	{
		Console.WriteLine(product.ToString());
	}
}
else
{
	Console.WriteLine("No hay productos cargados en la Base de Datos.");
}
