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

    public void CircleReset()
    {
        numberOfCollision = 0;
        transform.position = new Vector3(-2,0,0);
        transform.rotation = Quaternion.identity;
        rd.velocity = Vector3.zero;
        rd.mass = 1;
        rd.useGravity = true;
    }

    public void Right()
    {
        rd.AddForce(Vector2.right * 200);
    }
    public void Left()
    {
        rd.AddForce(Vector2.left * 200);
    }

    public void Up()
    {
        rd.AddForce(Vector2.up * 200);
    }

    public void Weight(float weight)
    {
        rd.mass *= weight;
    }
}
