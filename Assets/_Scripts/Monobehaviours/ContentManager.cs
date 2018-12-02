using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Core.Entity;
using _Scripts.Core.Enum;

namespace _Scripts.Monobehaviours
{
    public class ContentManager : MonoBehaviour
    {
        public TimerManager TimerManager;
        public List<TextMeshProUGUI> Text;
        public List<Image> Image;

        public List<TextMeshProUGUI> Option1;
        public List<TextMeshProUGUI> Option2;
        public List<TextMeshProUGUI> Option3;
        public Button NextButton;

        public GameObject FirstDialog;
        public GameObject SecondDialog;


        public DialogoType DialogoType;

        private Menu MyMenu;
        
        private void Awake()
        {
            MyMenu = GetComponent<Menu>();
        }


        public void Setup(Dialogo dialog)
        {
            ZUIManager.Instance.OpenMenu(MyMenu);
            TimerManager?.SetTime(DateTimeOffset.FromUnixTimeMilliseconds(dialog.dataHora).LocalDateTime);
            Text.ForEach(t => { t.text = dialog.texto; });
            Option1.ForEach(o => o.text = dialog.opcoes[0]?.Texto);
            Option2.ForEach(o => o.text = dialog.opcoes[1]?.Texto);
            Option3.ForEach(o => o.text = dialog.opcoes[2]?.Texto);
            
            FirstDialog?.gameObject.SetActive(dialog.layoutType == LayoutType.FIRST);
            SecondDialog?.gameObject.SetActive(dialog.layoutType == LayoutType.SECOND);
        }
    }
}