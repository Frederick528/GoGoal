using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : Command
{
    private CircleCtrl _controller;

    public Right(CircleCtrl controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.Right();
    }
}
