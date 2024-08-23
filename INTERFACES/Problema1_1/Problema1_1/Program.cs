
using Problema1_1;

//La Pila es del tipo LIFO (Último en entrar, primero en irse)
Pila oPila = new Pila(5);

Console.WriteLine("Esta vacia la pila: " + oPila.EstaVacia());

// Cargando el arreglo
oPila.Añadir(10);
oPila.Añadir(30);
oPila.Añadir(40);
oPila.Añadir(50);
oPila.Añadir(7);

Console.WriteLine("Esta vacia la pila: "+oPila.EstaVacia());
Console.WriteLine("El primer elemento es: "+oPila.Primero());
Console.WriteLine("El primer elemento era: "+oPila.Extraer());
Console.WriteLine("El primer elemento es: " + oPila.Primero());
//------------------------------------------------------------------------------------
//La Cola es del tipo FIFO (Primero en entrar, primero en irse)
Cola oCola = new Cola();
Console.WriteLine("Esta vacia la pila: " + oCola.EstaVacia());

//Cargando la lista
oCola.Añadir(5);
oCola.Añadir(7);
oCola.Añadir(9);
oCola.Añadir(30);
Console.WriteLine("Esta vacia la pila: " + oCola.EstaVacia());
Console.WriteLine("El primer elemento es: " + oCola.Primero());
Console.WriteLine("El primer elemento era: " + oCola.Extraer());
Console.WriteLine("El primer elemento es: " + oCola.Primero());
//------------------------------------------------------------------------------------
// Recorre un arreglo de atras para adelante.
/*
int[] arreglo = new int[4];
arreglo[0] = 10;
arreglo[1] = 15;
arreglo[2] = 20;
arreglo[3] = 50;

for (int i = (arreglo.Length - 1); i >= 0; i--)
{
    Console.WriteLine(arreglo[i]);
}
 */



