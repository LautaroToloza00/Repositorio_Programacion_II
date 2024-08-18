using Problema1_3;

var pack = new Pack();
pack.Precio = 250;
pack.Cantidad = 6;
pack.Nombre = "Coca Cola";

var suelto = new Suelto();
suelto.Precio = 400;
suelto.Medida = 2;
suelto.Nombre = "Fanta";

Producto[] listaProductos = { pack, suelto };

double total = 0;
foreach (Producto p in listaProductos)
{
    
    Console.WriteLine(p); //Muestra el método ToString()
    total += p.CalcularPrecio();
}
Console.WriteLine("Total: "+total);