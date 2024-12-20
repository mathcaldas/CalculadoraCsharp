using System;

namespace calculadora_csharp.model.operacoes;

public class Divisao : IOperacao
{
    public int Id { get; set; } = 4;

    public float Executar(float numero1, float numero2)
    {
        if (numero2 == 0)
        {
            throw new ArithmeticException();
        }
        else
        {
            return numero1 / numero2;
        }
    }
}