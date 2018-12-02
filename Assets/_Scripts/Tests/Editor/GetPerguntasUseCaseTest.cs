using System.Collections.Generic;
using Injection;
using NUnit.Framework;
using _Scripts.Core.Entity;
using _Scripts.dataprovider;

namespace _Scripts 
{
    public class GetPerguntasUseCaseTest
    {
        protected FetchPerguntaDataProvider dataProvider;

        [SetUp]
        public void setup()
        {
            
            dataProvider = new FetchPerguntaDataProvider();         
        }
        
        [Test]
        public void fetchPerguntas()
        {   
            
            List<Dialogo> perguntas = this.dataProvider.FetchAll();
            
            Assert.That(perguntas.Count == 1);
        }
    }
}