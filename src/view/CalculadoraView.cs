using System;
using System.Collections.Generic;
using calculadora_csharp.model.dto;
using calculadora_csharp.model.operacoes;

namespace calculadora_csharp.view;

public class CalculadoraView
{
    public void ExibirMenu(List<Type> listaDeOperacoes)
    {
        Console.WriteLine("#----------# CALCULADORA #----------#\n");
        try
        {
            foreach (Type tipo in listaDeOperacoes)
            {
                var instancia = Activator.CreateInstance(tipo) as IOperacao;
                int id = instancia.Id;
                Console.WriteLine($"{id}: {tipo.Name}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine("0: Sair\n");
        Console.Write("Escolha um número: ");
    }

    public float ObterEntradaUsuario()
    {
        float entrada = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            try
            {
                entrada = float.Parse(Console.ReadLine());
                entradaValida = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, insira um número.");
            }
        }

        return entrada;
    }

    public RequestDto ColetarEntrada()
    {
        float numero1, numero2;
        
        float opcao = ObterEntradaUsuario();

        while (opcao < 0 || opcao > 4)
        {
            Console.WriteLine("Entrada inválida.");
            opcao = ObterEntradaUsuario();
        }

        if (opcao == 0)
        {
            Console.WriteLine("Até logo!");
            return new RequestDto(0, 0, 0);
        }
        else
        {
            Console.Write("Digite o primeiro número: ");
            numero1 = ObterEntradaUsuario();
            Console.WriteLine("Digite o segundo número: ");
            numero2 = ObterEntradaUsuario();
        }

        return new RequestDto(opcao, numero1, numero2);
    }
}