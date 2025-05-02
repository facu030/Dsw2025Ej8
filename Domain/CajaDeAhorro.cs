using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public decimal TasaDeInteres { get; init; }

        public CajaDeAhorro(string numero, decimal saldo, string[] titulares)
            : base(numero, saldo, titulares)
        {
        }



        public override void Depositar(decimal monto)
        {
            try
            {
                ValidacionesDeCuenta.ValidarMonto(monto);
                ValidacionesDeCuenta.ValidarCuentaActiva(Estado);

                Saldo += monto;
            }
            catch (MontoNoValido ex)
            {
                // Manejo de la excepción sin interrumpir el flujo
                Console.WriteLine($"Error en depósito: {ex.Message}");
            }
            catch (CuentaNoActiva ex)
            {
                // Manejo de la excepción sin interrumpir el flujo
                Console.WriteLine($"Error en depósito: {ex.Message}");
            }
        }

        public override void Retirar(decimal monto)
        {
            try
            {
                ValidacionesDeCuenta.ValidarMonto(monto);
                ValidacionesDeCuenta.ValidarCuentaActiva(Estado);
                ValidacionesDeCuenta.ValidarSaldoSuficiente(Saldo, monto);

                Saldo -= monto;

                if (Saldo < 0)
                {
                    Estado = Estado.Suspendida;
                }
            }
            catch (MontoNoValido ex)
            {
                // Manejo de la excepción sin interrumpir el flujo
                Console.WriteLine($"Error en retiro: {ex.Message}");
            }
            catch (CuentaNoActiva ex)
            {
                // Manejo de la excepción sin interrumpir el flujo
                Console.WriteLine($"Error en retiro: {ex.Message}");
            }
            catch (SaldoInsuficiente ex)
            {
                // Manejo de la excepción sin interrumpir el flujo
                Console.WriteLine($"Error en retiro: {ex.Message}");
            }
        }

        public void AplicarInteres()
        {
            try
            {
                ValidacionesDeCuenta.ValidarCuentaActiva(Estado);
                Saldo += Saldo * TasaDeInteres;
            }
            catch (CuentaNoActiva ex)
            {
                // Manejo de la excepción sin interrumpir el flujo
                Console.WriteLine($"Error al aplicar interés: {ex.Message}");
            }
        }
    }
}