using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domine
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Cbu { get; set; }
        public double Saldo { get; set; }

        public TipoCuenta TipoCuenta { get; set; }
        public DateTime UltimoMovimiento { get; set; }
        public int IdCliente { get; set; }
    }
}
