using Banco.Domine;
using Banco.Service;

TipoCuentaService oService = new TipoCuentaService();
List<TipoCuenta> lstTiposCuenta = oService.GetTiposCuenta();

if (lstTiposCuenta.Count > 0) {
	foreach (TipoCuenta tc in lstTiposCuenta)
	{
		Console.WriteLine(tc.ToString());
	}
}
else
{
	Console.WriteLine("No hay tipos de cuentas cargados");
}
