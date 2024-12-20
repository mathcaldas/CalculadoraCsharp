// See https://aka.ms/new-console-template for more information

using System;
using calculadora_csharp.controller;
using calculadora_csharp.model;
using calculadora_csharp.view;

namespace calculadora_csharp;
public class Program
{
    public static void Main(string[] args)
    {
        var view = new CalculadoraView();
        var model = new CalculadoraModel();
        var controller = new CalculadoraController(view, model);
        
        while (true)
        {
            var dto = controller.ExibirMenuEObterEntrada();
            
            if (dto.Option == 0)
            {
                break;
            }
            
            var resultado = controller.Calcular(dto);
            Console.WriteLine($"Resultado: {resultado}\n");
        }
    }
}