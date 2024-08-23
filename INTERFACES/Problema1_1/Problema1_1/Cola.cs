using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_1
{
    public class Cola : IColleccion
    {
        List<Object> lista;

        public Cola()
        {
            lista = new  List<Object>();
        }

        public bool Añadir(object obj)
        {
            int tamanioLista = lista.Count;
            lista.Add(obj);
            if (tamanioLista < lista.Count)
            {
                return true;
            }
            return false;
        }

        public bool EstaVacia()
        {
            // El Count te da el tamaño de la lista.
            if (lista.Count == 0)
            {
                return true;
            }
            return false;
        }

        public object Extraer()
        {
            if (! EstaVacia()) {
                Object primerElemento = lista[0];
                lista.RemoveAt(0);
                return primerElemento;
            }
            return "La lista está vacía";
        }

        public object Primero()
        {
            if (! EstaVacia())
            {
                return lista[0];
            }
            return "La lista está vacía";
        }
    }
}
