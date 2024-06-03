public class DecreaseWeight : Command
{
    private CircleCtrl _controller;

    public DecreaseWeight(CircleCtrl controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.Weight(0.01f);
    }
}