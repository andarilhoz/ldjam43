<<<<<<< Updated upstream
using System;
=======
>>>>>>> Stashed changes
using System.Collections.Generic;
using _Scripts.Core.Enum;

namespace _Scripts.Core.Entity
{
    public class Dialogo
    {
<<<<<<< Updated upstream
        
        public string texto;

        public string imagem;
 
        public List<Opcao> opcoes;
        
        public DialogoType dialogoType;

        public DateTime dataHora;

        public LayoutType layoutType;
=======
        public string Texto;

        public List<Opcao> Opcoes;

        public long Ordem;

        public DialogoType Tipo;

        public long RespostaDialogoAnterior;
>>>>>>> Stashed changes

        public Dialogo(string texto, List<Opcao> opcoes, long ordem, DialogoType tipo, long respostaDialogoAnterior)
        {
            Texto = texto;
            Opcoes = opcoes;
            Ordem = ordem;
            Tipo = tipo;
            RespostaDialogoAnterior = respostaDialogoAnterior;
        }
    }
}