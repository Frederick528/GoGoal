﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    Invoker invoker;
    CircleCtrl _controller;
    EventType selectType = EventType.Start;

    void Start()
    {
        //인보커 생성
        invoker = new();
        _controller = FindObjectOfType<CircleCtrl>(true);

        //커맨드 생성
        Left left = new(_controller);
        Right right = new(_controller);
        Up up = new(_controller);

        IncreaseGravity iG = new();
        DecreaseGravity dG = new();
        ReverseGravity rG = new();

        IncreaseWeight iW = new(_controller);
        DecreaseWeight dW = new(_controller);



        //인보커에 커맨드를 세팅해서 인보커가 커맨드를 실행할 수 있게함.
        invoker.SetCommand("Left", left);
        invoker.SetCommand("Right", right);
        invoker.SetCommand("Up", up);

        invoker.SetCommand("IncreaseGravity", iG);
        invoker.SetCommand("DecreaseGravity", dG);
        invoker.SetCommand("ReverseGravity", rG);
        invoker.SetCommand("IncreaseWeight", iW);
        invoker.SetCommand("DecreaseWeight", dW);
    }
    public void SelectTypeBtn(int typeIndex)
    {
        switch (typeIndex)
        {
            case 0:
                selectType = EventType.Start; break;
            case 1:
                selectType = EventType.Collision1; break;
            case 2:
                selectType = EventType.Collision2; break;
        }
    }
    public void AddEvent(string name, Sprite eventImage)
    {
        if (!GameManager.instance.operable)
            return;

        switch (selectType)
        {
            case EventType.Start:
                EventBus.Subscribe(selectType, () => invoker.ExecuteCommand(name), eventImage);
                break;
            case EventType.Collision1:
                EventBus.Subscribe(selectType, () => invoker.ExecuteCommand(name), eventImage);
                break;
            case EventType.Collision2:
                EventBus.Subscribe(selectType, () => invoker.ExecuteCommand(name), eventImage);
                break;
        }
    }

    public void RemoveEvent()
    {
        if (!GameManager.instance.operable)
            return;

        switch (selectType)
        {
            case EventType.Start:
                EventBus.Unsubscribe(selectType);
                break;
            case EventType.Collision1:
                EventBus.Unsubscribe(selectType);
                break;
            case EventType.Collision2:
                EventBus.Unsubscribe(selectType);
                break;
        }
    }

    public void RemoveAllEvent()
    {
        if (!GameManager.instance.operable)
            return;

        EventBus.Clear();
        ButtonManager.instance.AllBtnActClear();
    }
}
