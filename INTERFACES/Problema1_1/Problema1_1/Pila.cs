using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_1
{
    public class Pila : IColleccion
    {
        Object[] lista;
        int contador;
        public Pila(int size)
        {
            lista = new Object[size];
            contador = 0;
        }
        public bool Añadir(Object obj)
        {
            bool flag = false;
            lista[contador] = obj;
            if (obj.Equals(lista[contador]))
            {
                flag = true;
            }

            contador++;
            return flag;
        }

        public bool EstaVacia()
        {
            if (contador == 0) {
                return true;
            }
            return false;
        }

        public object Extraer()
        {
            Object primerElemento;
            if (! EstaVacia())
            {
                primerElemento = lista[contador - 1];
                lista[contador -1] = null;
                contador--;
                return primerElemento;
            }
            return "No hay nada dentro del arreglo!!";
        }

        public object Primero()
        {
            if(! EstaVacia())
            {
                return lista[contador-1];
            }
            return "No hay nada dentro del arreglo!!";
        }
    }
}
