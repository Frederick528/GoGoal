using UnityEngine;

public class IncreaseGravity : Command
{
    public override void Execute()
    {
        Physics.gravity *= 2f;
    }
}
