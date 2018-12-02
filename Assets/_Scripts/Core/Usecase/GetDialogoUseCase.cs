using System.Collections.Generic;
using System.Linq;
using _Scripts.Core.Entity;

namespace _Scripts.Core.Usecase
{
    public class GetDialogoUseCase
    {
        private List<Dialogo> dialogos;

        public GetDialogoUseCase(List<Dialogo> dialogos)
        {
            this.dialogos = dialogos;
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
            var dialogosDaRodada = dialogos.FindAll((d) => d.ordem == ordem);

            var dialogo = dialogosDaRodada.Find((d) => d.respostaDialogoAnterior == respostaRodadaAtual && (d.tag == null || tags.Contains(d.tag)));

            return dialogo;
        }
    }
}