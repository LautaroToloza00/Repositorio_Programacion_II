using Facturacion.Dominio;
using Facturacion.Servicios;
using System;
using System.Runtime.CompilerServices;

FacturacionManager oServicio = new FacturacionManager();

Factura fac = new Factura();
fac = InsertarFactura();
Console.WriteLine(fac.Detalles.Count);

//Console.WriteLine("\tBienvenido al programa facturacion!! ");
//Console.WriteLine("----------------------------------------------------");
//string codigo = "";
//string menu = "----------------------------------------------------" +
//    "\nBienvenido al menú de opciones... \n" +
//    "\t1. Para mostrar la lista de artículos.\n" +
//    "\t2. Para insertar un artículo nuevo.\n" +
//    "\t3. Para actualizar un artículo.\n" +
//    "\t4. Para eliminar un artículo.\n" +
//    "\t0. Para salir del programa.\n" +
//    "----------------------------------------------------";
//List<Articulo> lstArticulos;

//while (!codigo.Equals("0"))
//{
//    lstArticulos = oServicio.GetAllArticulos();
//    Console.WriteLine(menu);
//    Console.Write("\nIngrese un código: ");
//    codigo = Console.ReadLine();

//    if(codigo == "1")
//    {
//        Console.WriteLine("\nElegiste la opción 1.");
//        // Mostrar lista de articulos
//        MostrarArticulos(lstArticulos);
        
//    }
//    else if(codigo == "2"){
//        Console.WriteLine("\nElegiste la opción 2.");

//        //Insertar un nuevo articulo
//        Articulo newArticulo = new Articulo();
//        InsertarNuevoArticulo(newArticulo);
        
//    }
//    else if(codigo == "3")
//    {
//        Console.WriteLine("\nElegiste la opción 3.");
//        //Update de articulo
//        Articulo artic = new Articulo();
//        ActualizarArticuloPorId(artic);

//    }
//    else if (codigo == "4")
//    {
//        Console.WriteLine("\nElegiste la opción 4.");
//        //Delete de articulo
//        EliminarArticuloPorId();

//    }
//    else if (codigo == "0") {
//        Console.WriteLine("\nElegiste la opción 0. Gracias por usar el programa!!");
//    }
//    else
//    {
//        Console.WriteLine("\nError, código inexistente.");
//    }
//}

Factura InsertarFactura()
{
    FormaPago fo = new FormaPago();
    fo.Id = 1;
    //Datos para la factura
    Factura newFactura = new Factura();
    newFactura.FormaPago = fo;
    newFactura.Cliente = "Lionel Messi";


    Articulo art = new Articulo();
    art.Codigo = 1;
    //Datos para la factura, pero del detalle
    List<DetalleFactutura> lstDetalles = new List<DetalleFactutura>();
    DetalleFactutura detalle = new DetalleFactutura();
    detalle.Articulo.Codigo = art.Codigo;
    detalle.Cantidad = 10;
    lstDetalles.Add(detalle);
    art.Codigo = 4;
    detalle.Articulo.Codigo = art.Codigo;
    detalle.Cantidad = 3;
    lstDetalles.Add(detalle);
    newFactura.Detalles = lstDetalles;
    return newFactura;
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
    newArticulo.Codigo = 0;

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

void ActualizarArticuloPorId(Articulo articulo)
{
    //Console.Write("Ingrese el codigo del artículo a modificar: ");
    //articulo.Codigo = int.Parse(Console.ReadLine());
    //Console.Write("\nIngrese el nombre del artículo a modificar: ");
    //articulo.Nombre = Console.ReadLine();
    //Console.Write("\nIngrese el precio del artículo a modificar: ");
    //articulo.PrecioUnitario = double.Parse(Console.ReadLine());
    //int id_mayor = lstArticulos[lstArticulos.Count - 1].Codigo;
    //if (articulo.Codigo > 0 && articulo.Codigo <= id_mayor)
    //{
    //    bool result = oServicio.GuardarArticulo(articulo);
    //    if (result)
    //    {
    //        Console.WriteLine("Se actualizo con éxito el artículo ingresado!!");
    //    }
    //    else
    //    {
    //        Console.WriteLine("No se pudo actualizar el artículo.");
    //    }
    //}
    //else
    //{
    //    Console.WriteLine("Ingreso un código de artículo inexistente.");
    //}
}

void EliminarArticuloPorId()
{
    Console.Write("Ingrese el codigo del artículo a eliminar: ");
    int codigo = int.Parse(Console.ReadLine());

    bool result = oServicio.EliminarArticulo(codigo);
    if (result)
    {
        Console.WriteLine("Se eliminó con éxito el artículo!!");
    }
    else
    {
        Console.WriteLine("No se pudo eliminar el artículo");
    }
}
bool Existe(Articulo articulo)
{
    //foreach (Articulo art in lstArticulos)
    //{
    //    if (art.Nombre.Equals(articulo.Nombre))
    //    {
    //        return true;
    //    }
    //}
    return false;
}