using System.Collections.Generic;
using System.Linq;
using Injection;
using UnityEngine;
using UnityEngine.AI;
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
            var tentativas = 0;
            do
            {                
                var rodadaSeguinte = rodadaAtual + 1;
                dialogoSelecionado = GetNextDialogInternal(rodadaSeguinte, respostaRodadaAtual, tags);
                tentativas++;
                Debug.Log("Tentativas: " + tentativas);
            } while (dialogoSelecionado == null && tentativas < 10);

            return dialogoSelecionado;
        }

        private Dialogo GetNextDialogInternal(int ordem, long respostaRodadaAtual, List<string> tags)
        {            
            var dialogosDaRodada = FetchDialogoDataProvider.FetchAll().FindAll((d) => d.ordem == ordem);

            var dialogo = dialogosDaRodada.Find((d) => d.respostaDialogoAnterior == respostaRodadaAtual && (d.conditionTag == null || tags.Contains(d.conditionTag)));

            return dialogo;
        }
        
        
        public Dialogo GetNextDialog(int rodadaAtual, List<string> tags)
        {
            Dialogo dialogoSelecionado;
            var tentativas = 0;
            do
            {
                int rodadaSeguinte = rodadaAtual + 1;
                dialogoSelecionado = GetNextDialogInternal(rodadaSeguinte, tags);
                tentativas++;
                Debug.Log("Tentativas: " + tentativas);
            } while (dialogoSelecionado == null && tentativas < 10);

            return dialogoSelecionado;
        }
        
        
        private Dialogo GetNextDialogInternal(int ordem, List<string> tags)
        {                      
            var dialogosDaRodada = FetchDialogoDataProvider.FetchAll().FindAll((d) => d.ordem == ordem);

            var dialogo = dialogosDaRodada.Find((d) => (d.conditionTag == null || tags.Contains(d.conditionTag)));

            return dialogo;
        }
    }
}