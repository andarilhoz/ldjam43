using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace _Scripts.Monobehaviours
{
    public class TimerManager : MonoBehaviour
    {

        public TextMeshProUGUI Date;
        public TextMeshProUGUI Hour;
        public TextMeshProUGUI Minutes;
        public TextMeshProUGUI Colon;


        public void SetTime(DateTime time)
        {
            Date.text = time.ToString("D",
                CultureInfo.CreateSpecificCulture("en-US"));
            
            Hour.text = time.ToString("HH");
            Minutes.text = time.ToString("mm");
        }

        private void OnEnable()
        {
            ToggleTimer();           
            SetTime(DateTime.Now);
        }

        private void ToggleTimer()
        {
            if (!this.isActiveAndEnabled) return;
            StartCoroutine(CoolDown(0.8f, () =>
            {
                ToggleTimer();
                ToggleDoubleDot();
            }));
        }

        private void ToggleDoubleDot()
        {
            Colon.enabled = !Colon.enabled;
        }

        private static IEnumerator CoolDown(float time, Action callback )
        {
            yield return new WaitForSeconds(time);
            callback();
        }
    }
}