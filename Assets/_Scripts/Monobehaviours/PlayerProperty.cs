using System;
using DefaultNamespace;
using DG.Tweening;
using Injection;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Models;

namespace _Scripts.Monobehaviours
{
    public class PlayerProperty : MonoBehaviour
    {
        public Image PropertyLogo;
        public Image PropertyBarBackground;
        public Image PropertyBar;
        public Property PropertyType;
        
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
                case Property.FIRST:
                    PropertyBar.transform.localScale = new Vector3(GetPercent(PlayerStatus.First.Value),1,1);
                    PlayerStatus.First.Subscribe(UpdateBar).AddTo(this);
                    break;
                case Property.SECOND:
                    PropertyBar.transform.localScale = new Vector3(GetPercent(PlayerStatus.Second.Value),1,1);
                    PlayerStatus.Second.Subscribe(UpdateBar).AddTo(this);
                    break;
                case Property.THIRD:
                    PropertyBar.transform.localScale = new Vector3(GetPercent(PlayerStatus.Third.Value),1,1);
                    PlayerStatus.Third.Subscribe(UpdateBar).AddTo(this);
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