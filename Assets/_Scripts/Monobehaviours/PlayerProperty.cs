using System;
using DG.Tweening;
using Injection;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Core.Enum;
using _Scripts.Models;

namespace _Scripts.Monobehaviours
{
    public class PlayerProperty : MonoBehaviour
    {
        public Image PropertyLogo;
        public Image PropertyBarBackground;
        public Image PropertyBar;
        public IndicadorType PropertyType;
        
        private float totalFill;

        [Inject] protected PlayerStatus PlayerStatus;
        
        private void Awake()
        {
            AppContext.Inject(this);
        }

        private void Start()
        {
            totalFill = PropertyBarBackground.transform.localScale.x;
            Setup();
        }

        public void Setup()
        {
            switch (PropertyType)
            {
                case IndicadorType.DINHEIRO:
                    PropertyBar.transform.localScale = new Vector3(GetPercent(PlayerStatus.Dinheiro.Value),1,1);
                    PlayerStatus.Dinheiro.Subscribe(UpdateBar).AddTo(this);
                    break;
                case IndicadorType.AMOR:
                    PropertyBar.transform.localScale = new Vector3(GetPercent(PlayerStatus.Amor.Value),1,1);
                    PlayerStatus.Amor.Subscribe(UpdateBar).AddTo(this);
                    break;
                case IndicadorType.SAUDE:
                    PropertyBar.transform.localScale = new Vector3(GetPercent(PlayerStatus.Saude.Value),1,1);
                    PlayerStatus.Saude.Subscribe(UpdateBar).AddTo(this);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void UpdateBar(int value){
            PropertyBar.transform.DOScaleX(GetPercent(value), 1);
        }

        public float GetPercent(int value)
        {
            var final = value / 100f;
            return totalFill * final;
        }
    }
}