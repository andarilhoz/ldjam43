using System;
using System.Collections;
using System.Collections.Generic;
using Injection;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Models;

public class QuestionSceneManager : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public float answerCoolDown;

    public List<Button> Option1;
    public List<Button> Option2;
    public List<Button> Option3;

    [Inject] protected PlayerStatus PlayerStatus;

    private bool answered = false;

    private void OnEnable()
    {
        answered = false;
    }

    private void Awake()
    {
        AppContext.Inject(this);

        Option1.ForEach(b => b.onClick.AddListener(delegate { UpdateStatus(PlayerStatus.First); }));

        Option2.ForEach(b => b.onClick.AddListener(delegate { UpdateStatus(PlayerStatus.Second); }));

        Option3.ForEach(b => b.onClick.AddListener(delegate { UpdateStatus(PlayerStatus.Third); }));
    }

    private void UpdateStatus(IntReactiveProperty property)
    {
        if (answered) return;
        answered = true;
        property.SetValueAndForceNotify(Mathf.Clamp(property.Value + 10, 0, 100));

        StartCoroutine(CoolDown(answerCoolDown, () =>
        {
            ZUIManager.Instance.OpenMenu("Resolution");
        }));
    }

    private IEnumerator CoolDown(float timer, Action callback)
    {
        yield return new WaitForSeconds(timer);
        callback();
    }
}