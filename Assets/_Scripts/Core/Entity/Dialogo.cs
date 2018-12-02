using System;
using System.Collections.Generic;
using _Scripts.Core.Enum;

namespace _Scripts.Core.Entity
{
    public class Dialogo
    {   
        public string texto;

        public string imagem;
 
        public List<Opcao> opcoes;
        
        public DialogoType dialogoType;

        public DateTime dataHora;

        public LayoutType layoutType;

        public long respostaDialogoAnterior;

        public int ordem;

        public string tag;

        public Dialogo()
        {
        }

        public Dialogo(string texto, string imagem, List<Opcao> opcoes, DialogoType dialogoType, DateTime dataHora,
            LayoutType layoutType, long respostaDialogoAnterior, int ordem)
        {
            this.texto = texto;
            this.imagem = imagem;
            this.opcoes = opcoes;
            this.dialogoType = dialogoType;
            this.dataHora = dataHora;
            this.layoutType = layoutType;
            this.respostaDialogoAnterior = respostaDialogoAnterior;
            this.ordem = ordem;
        }
    }
}