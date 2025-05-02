using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
    public static class ValidacionesDeCuenta
    {
        public static void ValidarMonto(decimal monto)
        {
            if (monto <= 0)
                throw new MontoNoValido();
        }

        public static void ValidarCuentaActiva(Estado estado)
        {
            if (estado != Estado.Activa)
                throw new CuentaNoActiva(estado.ToString());
        }

        public static void ValidarSaldoSuficiente(decimal saldo, decimal monto, decimal limitePermitido = 0)
        {
            if (saldo - monto < -limitePermitido)
                throw new SaldoInsuficiente();
        }
    }
}
