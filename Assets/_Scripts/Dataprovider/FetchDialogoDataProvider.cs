using System.Collections.Generic;
using Injection;
using _Scripts.Core.Entity;
using _Scripts.Core.Usecase.Gateway;

namespace _Scripts.Dataprovider
{
    public class FetchDialogoDataProvider: IFetchPerguntaGateway, IInjectable
    {
        public List<Dialogo> FetchAll()
        {
            return new List<Dialogo>();
        }
    }
}