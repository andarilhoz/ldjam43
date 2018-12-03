using System;
using System.Collections.Generic;
using System.Linq;
using Injection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Core.Entity;
using _Scripts.Core.Enum;
using _Scripts.Dataprovider;

namespace _Scripts.Monobehaviours
{
    public class ContentManager : MonoBehaviour
    {
        public TimerManager TimerManager;
        public List<TextMeshProUGUI> Text;
        public List<Image> Images;

        public List<TextMeshProUGUI> Option1;
        public List<TextMeshProUGUI> Option2;
        public List<TextMeshProUGUI> Option3;
        public Button NextButton;

        public GameObject FirstDialog;
        public GameObject SecondDialog;


        public DialogoType DialogoType;

        private Menu MyMenu;

        [Inject] protected ImageProvider ImageProvider;
        
        private void Awake()
        {
            AppContext.Inject(this);
            
            MyMenu = GetComponent<Menu>();
        }


        public void Setup(Dialogo dialog)
        {
            ZUIManager.Instance.OpenMenu(MyMenu);
            TimerManager?.SetTime(DateTimeOffset.FromUnixTimeMilliseconds(dialog.dataHora).LocalDateTime);
            Text.ForEach(t => { t.text = dialog.texto; });

            Option1.ForEach(o => o.text = dialog.opcoes.Count > 0 ? dialog.opcoes[0]?.Texto : "");
            Option2.ForEach(o => o.text = dialog.opcoes.Count > 1 ? dialog.opcoes[1]?.Texto : "");
            Option3.ForEach(o => o.text = dialog.opcoes.Count > 2 ? dialog.opcoes[2]?.Texto : "");
            if (!string.IsNullOrEmpty(dialog.imagem))
            {
                ImageProvider.GetImage(dialog.imagem, (sprite) =>
                {
                    Images.ForEach(i => { i.sprite = sprite; });
                });
            }
            
            
            if(FirstDialog)FirstDialog.gameObject.SetActive(dialog.layoutType == LayoutType.FIRST);
            if(SecondDialog)SecondDialog.gameObject.SetActive(dialog.layoutType == LayoutType.SECOND);
        }
    }
}