namespace calculadora_csharp.model.operacoes;

public interface IOperacao
{
    int Id { get; }
    
    float Executar(float numero1, float numero2);
}