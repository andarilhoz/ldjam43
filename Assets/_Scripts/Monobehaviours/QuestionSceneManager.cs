﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Injection;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Core.Entity;
using _Scripts.Core.Usecase;
using _Scripts.Dataprovider;
using _Scripts.Models;
using _Scripts.Monobehaviours;

public class QuestionSceneManager : MonoBehaviour
{
    public float answerCoolDown;

    [Inject] protected PlayerStatus PlayerStatus;
    [Inject] protected GetDialogoUseCase GetDialogoUseCase;

    public List<Button> Option1;
    public List<Button> Option2;
    public List<Button> Option3;

    public List<Button> NextButton;

    private bool answered = false;

    public List<ContentManager> ContentManagers;

    private Dialogo currentDialog;

    private void OnEnable()
    {
        answered = false;
    }

    private void Awake()
    {
        AppContext.Inject(this);

        Option1.ForEach(o => { o.onClick.AddListener(delegate { Answer(0); }); });
        Option2.ForEach(o => { o.onClick.AddListener(delegate { Answer(1); }); });
        Option3.ForEach(o => { o.onClick.AddListener(delegate { Answer(2); }); });
        NextButton.ForEach( n => n.onClick.AddListener(Next));
    }
    
    
    private void Answer(int option)
    {
        if (answered) return;
        answered = true;

        if (currentDialog.opcoes.Count < 1)
        {
            Next(option);
            return;
        }

        PlayerStatus.Amor.SetValueAndForceNotify(Mathf.Clamp( PlayerStatus.Amor.Value + currentDialog.opcoes[option].Tipo.Amor, 0 ,100));
        PlayerStatus.Amor.SetValueAndForceNotify(Mathf.Clamp( PlayerStatus.Dinheiro.Value + currentDialog.opcoes[option].Tipo.Dinheiro, 0 ,100));
        PlayerStatus.Amor.SetValueAndForceNotify(Mathf.Clamp( PlayerStatus.Saude.Value + currentDialog.opcoes[option].Tipo.Saude, 0 ,100));
        PlayerStatus.tags.Add(currentDialog.opcoes[option].tag);
   
        StartCoroutine(CoolDown(answerCoolDown, (() =>
        {
            Next(option);
        })));
    }

    public void InitialSetup()
    {
        currentDialog = GetDialogoUseCase.GetNextDialog();
        Setup();
    }

    public void Setup()
    {
        Debug.Log("OLar");
        var manager = ContentManagers.Find(c => c.DialogoType == currentDialog.dialogoType);
        Debug.Log(currentDialog.texto);
        manager.Setup(currentDialog);
    }

    public void Next(int option)
    {
        currentDialog = GetDialogoUseCase.GetNextDialog(currentDialog.ordem, option, PlayerStatus.tags);
        Setup();
        answered = false;
    }
    
    public void Next()
    {
        answered = false;
        currentDialog = GetDialogoUseCase.GetNextDialog(currentDialog.ordem, PlayerStatus.tags);
        Setup();
    }

    private IEnumerator CoolDown(float timer, Action callback)
    {
        yield return new WaitForSeconds(timer);
        callback();
    }
}