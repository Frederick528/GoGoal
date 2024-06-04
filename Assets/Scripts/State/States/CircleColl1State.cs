using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleColl1State : MonoBehaviour, ICircleState
{
    private CircleCtrl _controller;

    public void Handle(CircleCtrl controller)
    {
        // Actually, It don't need parameter because it's not using parameter right now.
        // Just use EventBus...
        if (!_controller)
            _controller = controller;

        EventBus.Publish(EventType.Collision1);
    }
}