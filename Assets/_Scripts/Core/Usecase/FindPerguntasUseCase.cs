using System.Collections.Generic;
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

        public Dialogo getNextDialog(int rodadaAtual, long respostaRodadaAtual)
        {
            return new Dialogo();
        }
    }
}