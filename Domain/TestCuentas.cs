using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public static class TestCuentas
    {
        public static void ProbarCuentas()
        {
            var caja1 = new CajaDeAhorro("CA001", 1000, new[] { "Juan Pérez" })
            {
                TasaDeInteres = 0.05m
            };

            var caja2 = new CajaDeAhorro("CA002", 0, new[] { "Ana Gómez" })
            {
                TasaDeInteres = 0.03m
            };

            var corriente1 = new CuentaCorriente("CC001", 500, new[] { "Carlos López" })
            {
                Comision = 0.02m,
                LimiteDeDescubierto = 200
            };

            var corriente2 = new CuentaCorriente("CC002", -50, new[] { "María Fernández" })
            {
                Comision = 0.01m,
                LimiteDeDescubierto = 100
            };

            Console.WriteLine("\n--- Operaciones válidas ---");
            caja1.Depositar(500);
            caja1.Retirar(300);
            caja1.AplicarInteres();

            corriente1.Depositar(1000);
            corriente1.Retirar(1200);

            Console.WriteLine("\n--- Operaciones inválidas (deben lanzar excepciones) ---");
            caja2.Retirar(100);        
            caja2.Depositar(0);        

            corriente2.Estado = Estado.Inactiva;
            corriente2.Depositar(100); 

            Console.WriteLine("\n--- Resumen de cuentas ---");

            var cuentas = new List<CuentaBancaria> { caja1, caja2, corriente1, corriente2 };

            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.GetType().Name,
                    Saldo = cuenta.Saldo
                };

                Console.WriteLine($"Cuenta: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo:C}");
            }

        }

    }
}

