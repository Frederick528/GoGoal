using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    Invoker invoker;
    CircleCtrl _controller;

    void Start()
    {
        //인보커 생성
        invoker = new();
        _controller = FindObjectOfType<CircleCtrl>(true);

        //커맨드 생성
        Left left = new(_controller);
        Right right = new(_controller);


        //인보커에 커맨드를 세팅해서 인보커가 커맨드를 실행할 수 있게함.
        invoker.SetCommand("left", left);
        invoker.SetCommand("right", right);
    }
    public void ClickBtn(string name)
    {
        EventBus.Subscribe(EventType.Start, () => invoker.ExecuteCommand(name));
    }
    
    public void StartGame()
    {
        _controller.gameObject.SetActive(true);
    }
}
