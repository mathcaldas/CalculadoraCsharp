namespace calculadora_csharp.model.operacoes;

public class Multiplicacao : IOperacao
{
    public int Id { get; set; } = 3;

    public float Executar(float numero1, float numero2)
    {
        return numero1 * numero2;
    }
}