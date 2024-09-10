using Facturacion.Dominio;
using Facturacion.Servicios;
using System;
using System.Runtime.CompilerServices;

FacturacionManager oServicio = new FacturacionManager();

Console.WriteLine("\tBienvenido al programa facturacion!! ");
Console.WriteLine("----------------------------------------------------");
string codigo = "";
string menu = "----------------------------------------------------" +
    "\nBienvenido al menú de opciones... \n" +
    "\t1. Para mostrar la lista de artículos.\n" +
    "\t2. Para insertar un artículo nuevo.\n" +
    "\t0. Para salir del programa.\n" +
    "----------------------------------------------------";
List<Articulo> lstArticulos;

while (!codigo.Equals("0"))
{
    lstArticulos = oServicio.GetAllArticulos();
    Console.WriteLine(menu);
    Console.Write("\nIngrese un código: ");
    codigo = Console.ReadLine();

    if(codigo == "1")
    {
        Console.WriteLine("\nElegiste la opción 1.");
        // Mostrar lista de articulos
        MostrarArticulos(lstArticulos);
        
    }
    else if(codigo == "2"){
        Console.WriteLine("\nElegiste la opción 2.");

        //Insertar un nuevo articulo
        Articulo newArticulo = new Articulo();
        InsertarNuevoArticulo(newArticulo);
        
    }
    else if (codigo == "0") {
        Console.WriteLine("\nElegiste la opción 0. Gracias por usar el programa!!");
    }
    else
    {
        Console.WriteLine("\nError, código inexistente.");
    }
}


void MostrarArticulos(List<Articulo> lstArticulos)
{
    if (lstArticulos.Count > 0)
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
}

void InsertarNuevoArticulo(Articulo newArticulo)
{
    //Primero tengo que cargar el artículo.
    newArticulo.Nombre = "Play Station 5";
    newArticulo.PrecioUnitario = 545700.50;

    //Tiene que devolver false para ser cargado.
    if (!Existe(newArticulo))
    {
        bool result = oServicio.GuardarArticulo(newArticulo);
        if (result)
        {
            Console.WriteLine("El artículo nuevo fue cargado con éxito!!");
        }
        else
        {
            Console.WriteLine("No se pudo cargar el artículo.");
        }
    }
    else
    {
        Console.WriteLine("El artículo ya existe!!");
    }
    
}
bool Existe(Articulo articulo)
{
    foreach (Articulo art in lstArticulos)
    {
        if (art.Nombre.Equals(articulo.Nombre))
        {
            return true;
        }
    }
    return false;
}