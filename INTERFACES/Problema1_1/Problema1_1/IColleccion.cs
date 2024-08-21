using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_1
{
    public interface IColleccion
    {
        bool EstaVacia();
        Object Extraer();
        Object Primero();
        bool Añadir(Object obj);
    }
}
