using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    private Dictionary<string, Command> commandDic = new();

    //커맨드를 세팅
    public void SetCommand(string name, Command command)
    {
        if (commandDic.ContainsValue(command))
        {
            Debug.Log("이미 커맨드가 리스트 포함되어있음.");
            return;
        }
        commandDic.Add(name, command);
    }
    public void ExecuteCommand(string name)
    {
        commandDic[name].Execute();
    }
}
