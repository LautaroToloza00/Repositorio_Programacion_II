using ProduccionBack.Data;
using ProduccionBack.Entities;

namespace ProduccionBack.Services
{
    public class ProduccionService : IProduccionService
    {
        private IOrdenRepository repository;
        public ProduccionService()
        {
            repository = new OrdenRepository();
        }

        public bool CancelarOrden(int nro)
        {
            return repository.CancelarOrdenProduccion(nro);
        }

        public List<Componente> ConsultarComponentes()
        {
            return repository.ObtenerComponentes();
        }

        public List<OrdenProduccion> ConsultarOrdenes(DateTime? fecha, string? estado)
        {
            return repository.OrdenesProduccion(fecha,estado);
        }

        public bool RegistrarProduccion(OrdenProduccion orden)
        {
            return repository.CrearOrden(orden);
        }

        //-----------------------------------------------------------
        //Validad reglas de negocio..
        public bool EsOrdenValida(OrdenProduccion orden)
        {
            return true;
        }
    }
}
