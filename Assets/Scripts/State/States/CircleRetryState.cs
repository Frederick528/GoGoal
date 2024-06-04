using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRetryState : MonoBehaviour, ICircleState
{
    private CircleCtrl _controller;
    Vector3 baseGravity = new Vector3(0, -9.81f, 0);

    public void Handle(CircleCtrl controller)
    {
        if (!_controller)
            _controller = controller;

        Physics.gravity = baseGravity;

        _controller.numberOfCollision = 0;
        _controller.transform.position = new Vector3(-2, 0, 0);
        _controller.transform.rotation = Quaternion.identity;
        _controller.rd.velocity = Vector3.zero;
        _controller.rd.mass = 1;
        _controller.rd.useGravity = true;
        _controller.rd.isKinematic = true;
    }
}
