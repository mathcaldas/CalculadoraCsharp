namespace calculadora_csharp.model.operacoes;

public class Subtracao : IOperacao
{
    public int Id { get; set; } = 2;

    public float Executar(float numero1, float numero2)
    {
        return numero1 - numero2;
    }
}