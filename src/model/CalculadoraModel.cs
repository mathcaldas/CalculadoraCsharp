using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using calculadora_csharp.model.operacoes;

namespace calculadora_csharp.model;

public class CalculadoraModel
{
    public List<Type> ObterNomesDasClasses()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var classes = assembly.GetTypes()
                              .Where(TipoValidoDeOperacao)
                              .ToList();
        
        return classes;
    }
    
    private bool TipoValidoDeOperacao(Type tipo)
    {
        return typeof(IOperacao).IsAssignableFrom(tipo) && !tipo.IsAbstract && !tipo.IsInterface;
    }

    public void OrdenarListaDeClasses(List<Type> listaDeClasses)
    {
        listaDeClasses.Sort((c1, c2) =>
        {
            try
            {
                var instancia1 = Activator.CreateInstance(c1) as IOperacao;
                var instancia2 = Activator.CreateInstance(c2) as IOperacao;
                
                if (instancia1 != null && instancia2 != null)
                {
                    return instancia1.Id.CompareTo(instancia2.Id);
                }
                
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao ordenar a lista de classes");
                return -1;
            }
        });
    }
}