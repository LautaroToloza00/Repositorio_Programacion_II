﻿using ProduccionBack.Entities;

namespace ProduccionBack.Data
{
    public interface IOrdenRepository
    {
        List<Componente> ObtenerComponentes();
        bool CrearOrden(OrdenProduccion orden);

        List<OrdenProduccion> OrdenesProduccion(DateTime? fecha, string? estado);

        bool CancelarOrdenProduccion(int nro);
    
    }
}
