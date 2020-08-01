using System;

namespace CalculadoraDeJuros.Domain.CalculadoraDeJuros
{
    public class CalculadoraDeJuros
    {
        public decimal Calcular(decimal valorInicial, int tempo, decimal taxaDeJuros)
        {
            var potencia = (decimal)Math.Pow((double)(1 + taxaDeJuros), tempo);
            var resultado = valorInicial * potencia;
            return Math.Round(resultado, 2);
        }
    }
}