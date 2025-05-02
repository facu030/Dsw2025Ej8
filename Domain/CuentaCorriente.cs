using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDeDescubierto { get; init; }
        public decimal Comision { get; set; }

        public CuentaCorriente(string numero, decimal saldo, string[] titulares)
            : base(numero, saldo, titulares)
        {
        }



        public override void Depositar(decimal monto)
        {
            try
            {
                ValidacionesDeCuenta.ValidarMonto(monto);
                ValidacionesDeCuenta.ValidarCuentaActiva(Estado);

                decimal montoFinal = monto - (monto * Comision);
                Saldo += montoFinal;
            }
            catch (MontoNoValido ex)
            {
                Console.WriteLine($"Error en depósito: {ex.Message}");
            }
            catch (CuentaNoActiva ex)
            {
                Console.WriteLine($"Error en depósito: {ex.Message}");
            }
        }

        public override void Retirar(decimal monto)
        {
            try
            {
                ValidacionesDeCuenta.ValidarMonto(monto);
                ValidacionesDeCuenta.ValidarCuentaActiva(Estado);
                ValidacionesDeCuenta.ValidarSaldoSuficiente(Saldo, monto, LimiteDeDescubierto);

                Saldo -= monto;

                if (Saldo < 0)
                {
                    Estado = Estado.Suspendida;
                }
            }
            catch (MontoNoValido ex)
            {
                Console.WriteLine($"Error en retiro: {ex.Message}");
            }
            catch (CuentaNoActiva ex)
            {
                Console.WriteLine($"Error en retiro: {ex.Message}");
            }
            catch (SaldoInsuficiente ex)
            {
                Console.WriteLine($"Error en retiro: {ex.Message}");
            }
        }
    }
}