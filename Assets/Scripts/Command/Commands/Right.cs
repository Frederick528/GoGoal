public class Right : Command
{
    private CircleCtrl _controller;

    public Right(CircleCtrl controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.Right();
    }
}
