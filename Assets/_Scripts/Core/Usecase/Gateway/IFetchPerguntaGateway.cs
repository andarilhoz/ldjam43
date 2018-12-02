using System;
using System.Collections.Generic;
using Injection;
using _Scripts.Core.Entity;

namespace _Scripts.Core.Usecase.Gateway
{
    public interface IFetchPerguntaGateway: IInjectable
    {
        void FetchAll(Action<List<Dialogo>> callback);
    }
   
}