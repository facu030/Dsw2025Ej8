using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
    public class Excepciones
    {
        public class MontoNoValido : Exception
        {
            public MontoNoValido()
                : base("El monto ingresado no es válido para la operacion solicitada.")
            {
            }

            public MontoNoValido(string mensaje)
                : base(mensaje)
            {
            }
        }

        public class CuentaNoActiva : Exception
        {
            public CuentaNoActiva(string estado)
                : base($"No se puede operar con la cuenta {estado}.")
            {
            }

            public CuentaNoActiva(string estado, string mensaje)
                : base($"No se puede operar con la cuenta {estado}: {mensaje}")
            {
            }
        }

        public class SaldoInsuficiente : Exception
        {
            public SaldoInsuficiente()
                : base("La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida..")
            {
            }

            public SaldoInsuficiente(string mensaje)
                : base(mensaje)
            {
            }
        }
    }

}
