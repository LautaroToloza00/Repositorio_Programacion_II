using Facturacion.Dominio;
using Facturacion.Servicios;

FacturacionManager oServicio = new FacturacionManager();
List<Articulo> lstArticulos = oServicio.GetAllArticulos();

if(lstArticulos.Count > 0)
{
    Console.WriteLine("Lista de Articulos..");
	foreach (Articulo articulo in lstArticulos)
	{
        Console.WriteLine(articulo.ToString());
        
    }
}
else
{
    Console.WriteLine("No hay artículos cargados!!");
}