using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    Invoker invoker;
    CircleCtrl _controller;
    EventType selectType = EventType.Start;


    int limitNum = 3;
    int startCount, collCount1, collCount2;

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
        invoker.SetCommand("left", left);
        invoker.SetCommand("right", right);
        invoker.SetCommand("up", up);

        invoker.SetCommand("iG", iG);
        invoker.SetCommand("dG", dG);
        invoker.SetCommand("rG", rG);
        invoker.SetCommand("iW", iW);
        invoker.SetCommand("dW", dW);
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
    public void AddEvent(string name)
    {
        if (!GameManager.instance.operable)
            return;

        switch (selectType)
        {
            case EventType.Start:
                if (startCount > limitNum) break;
                else if (startCount == limitNum)
                    EventBus.ChangeSubscribe(selectType, () => invoker.ExecuteCommand(name));
                else
                    startCount += EventBus.Subscribe(selectType, () => invoker.ExecuteCommand(name));
                break;
            case EventType.Collision1:
                if (collCount1 >= limitNum) break;
                else if (collCount1 == limitNum)
                    EventBus.ChangeSubscribe(selectType, () => invoker.ExecuteCommand(name));
                else
                    collCount1 += EventBus.Subscribe(selectType, () => invoker.ExecuteCommand(name));
                break;
            case EventType.Collision2:
                if (collCount2 >= limitNum) break;
                else if (collCount2 == limitNum)
                    EventBus.ChangeSubscribe(selectType, () => invoker.ExecuteCommand(name));
                else
                    collCount2 += EventBus.Subscribe(selectType, () => invoker.ExecuteCommand(name));
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
                if (startCount <= 0 || ButtonManager.instance.currBtn == null) break;
                startCount -= EventBus.Unsubscribe(selectType);
                break;
            case EventType.Collision1:
                if (collCount1 <= 0 || ButtonManager.instance.currBtn == null) break;
                collCount1 -= EventBus.Unsubscribe(selectType);
                break;
            case EventType.Collision2:
                if (collCount2 <= 0 || ButtonManager.instance.currBtn == null) break;
                collCount2 -= EventBus.Unsubscribe(selectType);
                break;
        }
    }

    public void RemoveAllEvent()
    {
        if (!GameManager.instance.operable)
            return;

        EventBus.Clear();
        ButtonManager.instance.AllBtnActClear();
        startCount = 0; collCount1 = 0; collCount2 = 0;
    }
}
