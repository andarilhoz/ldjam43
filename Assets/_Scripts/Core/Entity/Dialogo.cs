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

    }
}