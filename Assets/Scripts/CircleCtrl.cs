using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCtrl : MonoBehaviour
{
    private ICircleState
        _startState, _retryState, _coll1State, _coll2State;
    private CircleStateContext _circleStateContext;

    [HideInInspector]
    public Rigidbody rd;

    [HideInInspector]
    public int numberOfCollision;

    private void Start()
    {
        _circleStateContext = new CircleStateContext(this);

        _startState = gameObject.AddComponent<CircleStartState>();
        _retryState = gameObject.AddComponent<CircleRetryState>();
        _coll1State = gameObject.AddComponent<CircleColl1State>();
        _coll2State = gameObject.AddComponent<CircleColl2State>();

        _circleStateContext.Transition(_retryState);

        rd = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Probably add effects by stage later. ex) 5 Collision = dead.
        if (numberOfCollision >= 3)
            return;

        ++numberOfCollision;
        switch (numberOfCollision)
        {
            case 1:
                _circleStateContext.Transition(_coll1State);
                break;
            case 2:
                _circleStateContext.Transition(_coll2State);
                break;
        }
    }

    public void StartCircle()
    {
        if (!GameManager.instance.operable)
            return;

        GameManager.instance.operable = false;
        _circleStateContext.Transition(_startState);
    }

    public void RetryCircle()
    {
        GameManager.instance.operable = true;
        _circleStateContext.Transition(_retryState);
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
        if (rd.mass * weight >= 10)
            rd.mass = 10;
        else if (rd.mass * weight <= 0.5f)
            rd.mass = 0.5f;
        else rd.mass *= weight;
    }
}
