namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{

    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; set; }
    public string[] Titulares { get; set; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Titulares = titulares;
        Estado = Estado.Activa;
    }



    public abstract void Depositar(decimal monto);
    public abstract void Retirar(decimal monto);

}