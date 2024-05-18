using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCtrl : MonoBehaviour
{
    [SerializeField]
    Rigidbody rd;

    int numberOfCollision;

    private void OnEnable()
    {
        EventBus.Publish(EventType.Start);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ++numberOfCollision;
        switch (numberOfCollision)
        {
            case 1:
                EventBus.Publish(EventType.Collision1);
                break;
            case 2:
                EventBus.Publish(EventType.Collision2);
                break;
        }
    }

    public void Right()
    {
        rd.AddForce(Vector2.right * 200);
    }
    public void Left()
    {
        rd.AddForce(Vector2.left * 200);
    }
}
