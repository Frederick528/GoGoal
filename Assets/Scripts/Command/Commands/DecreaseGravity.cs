using UnityEngine;

public class DecreaseGravity : Command
{
    public override void Execute()
    {
        Physics.gravity *= 0.5f; 
    }
}
