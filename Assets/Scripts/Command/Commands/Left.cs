public class Left : Command
{
    private CircleCtrl _controller;

    public Left(CircleCtrl controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.Left();
    }
}
