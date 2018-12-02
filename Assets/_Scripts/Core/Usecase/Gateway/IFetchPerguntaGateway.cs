using System.Collections.Generic;
using Injection;
using _Scripts.Core.Entity;

namespace _Scripts.Core.Usecase.Gateway
{
    public interface IFetchPerguntaGateway: IInjectable
    {
        List<Dialogo> FetchAll();
    }
   
}