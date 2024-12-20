using System;
using System.Collections.Generic;
using calculadora_csharp.model;
using calculadora_csharp.model.dto;
using calculadora_csharp.model.operacoes;
using calculadora_csharp.view;

namespace calculadora_csharp.controller;

public class CalculadoraController
{
    private readonly CalculadoraView _view;
    private readonly CalculadoraModel _model;

    public CalculadoraController(CalculadoraView view, CalculadoraModel model)
    {
        _view = view;
        _model = model;
    }

    public RequestDto ExibirMenuEObterEntrada()
    {
        List<Type> listaDeClasses = _model.ObterNomesDasClasses();
        _model.OrdenarListaDeClasses(listaDeClasses);
        _view.ExibirMenu(listaDeClasses);

        return _view.ColetarEntrada();
    }

    public IOperacao ObterOperacao(int opcao)
    {
        List<Type> listaDeClasses = _model.ObterNomesDasClasses();

        try
        {
            foreach (var classe in listaDeClasses)
            {
                var instancia = Activator.CreateInstance(classe) as IOperacao;
                int id = instancia?.Id ?? -1;
                if (id == opcao)
                {
                    return instancia;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return null;
    }
      public float Calcular(RequestDto dto)
    {
        var opcao = (int) dto.Option;
        
        if (opcao == 0) { return 0; }
        
        var operacao = ObterOperacao(opcao);

        if (operacao == null)
        {
            throw new Exception("DEU RUIM");
        }
        else
        {
            return operacao.Executar(dto.Number1, dto.Number2);
        }
    }
}