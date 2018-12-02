using System.Collections.Generic;
using Injection;
using _Scripts.Core.Entity;
using _Scripts.Core.Usecase.Gateway;

namespace _Scripts.dataprovider
{
    public class FetchPerguntaDataProvider: IFetchPerguntaGateway, IInjectable
    {
        public List<Pergunta> FetchAll()
        {
            Pergunta p1 = new Pergunta();

            List<Pergunta> perguntas = new List<Pergunta>();
            
            perguntas.Add(p1);

            return perguntas;
        }
    }
}