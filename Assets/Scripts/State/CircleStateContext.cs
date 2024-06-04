public class CircleStateContext
{
    public ICircleState CurrentState { get; private set; }

    private readonly CircleCtrl _controller;

    public CircleStateContext(CircleCtrl controller)
    {
        _controller = controller;
    }

    public void Transition()
    {
        CurrentState.Handle(_controller);
    }

    public void Transition(ICircleState state)
    {
        CurrentState = state;
        CurrentState.Handle(_controller);
    }
}
