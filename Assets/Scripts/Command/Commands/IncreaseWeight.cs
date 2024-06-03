public class IncreaseWeight : Command
{
    private CircleCtrl _controller;

    public IncreaseWeight(CircleCtrl controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.Weight(100);
    }
}