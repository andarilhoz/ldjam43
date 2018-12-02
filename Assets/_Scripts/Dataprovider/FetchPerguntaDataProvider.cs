using System.Collections.Generic;
using Injection;
using _Scripts.Core.Entity;
using _Scripts.Core.Usecase.Gateway;

namespace _Scripts.dataprovider
{
    public class FetchPerguntaDataProvider: IFetchPerguntaGateway, IInjectable
    {
        public List<Dialogo> FetchAll()
        {
            Dialogo p1 = new Dialogo();

            List<Dialogo> perguntas = new List<Dialogo>();
            
            perguntas.Add(p1);

            return perguntas;
        }
    }
}