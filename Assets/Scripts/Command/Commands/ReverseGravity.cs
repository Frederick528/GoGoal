using UnityEngine;

public class ReverseGravity : Command
{
    public override void Execute()
    {
        Physics.gravity *= -1;
    }
}
