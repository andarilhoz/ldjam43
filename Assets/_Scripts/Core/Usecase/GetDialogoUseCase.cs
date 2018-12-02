using System.Collections.Generic;
using System.Linq;
using Injection;
using _Scripts.Core.Entity;
using _Scripts.Dataprovider;

namespace _Scripts.Core.Usecase
{
    public class GetDialogoUseCase : IInjectable
    {
        [Inject] protected FetchDialogoDataProvider FetchDialogoDataProvider;
        
        
        public Dialogo GetNextDialog()
        {
            return FetchDialogoDataProvider.FetchAll().FindAll((d) => d.ordem == 0).First();
        }

        public Dialogo GetNextDialog(int rodadaAtual, long respostaRodadaAtual, List<string> tags)
        {
            Dialogo dialogoSelecionado;
            do
            {
                var rodadaSeguinte = rodadaAtual++;
                dialogoSelecionado = GetNextDialogInternal(rodadaSeguinte, respostaRodadaAtual, tags);
                
            } while (dialogoSelecionado == null);

            return dialogoSelecionado;
        }

        private Dialogo GetNextDialogInternal(int ordem, long respostaRodadaAtual, List<string> tags)
        {            
            var dialogosDaRodada = FetchDialogoDataProvider.FetchAll().FindAll((d) => d.ordem == ordem);

            var dialogo = dialogosDaRodada.Find((d) => d.respostaDialogoAnterior == respostaRodadaAtual && (d.conditionTag == null || tags.Contains(d.conditionTag)));

            return dialogo;
        }
    }
}