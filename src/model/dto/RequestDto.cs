namespace calculadora_csharp.model.dto;

public class RequestDto (float option, float number1, float number2)
{
    public float Option { get; set; } = option;
    public float Number1 { get; set; } = number1;
    public float Number2 { get; set; }  = number2;
    
}