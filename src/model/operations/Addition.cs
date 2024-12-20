namespace calculadora_csharp.model.operacoes;

public class Adicao : IOperacao
{
    public int Id { get; } = 1;

    public float Executar(float numero1, float numero2)
    {
        return numero1 + numero2;
    }
}