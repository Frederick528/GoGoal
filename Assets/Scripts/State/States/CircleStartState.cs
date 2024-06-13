using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleStartState : MonoBehaviour, ICircleState
{
    private CircleCtrl _controller;

    public void Handle(CircleCtrl controller)
    {
        if (!_controller)
            _controller = controller;

        _controller.rd.isKinematic = false;
        EventBus.Publish(EventType.Start);
    }
}
