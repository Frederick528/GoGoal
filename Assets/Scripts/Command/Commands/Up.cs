public class Up : Command
{
    private CircleCtrl _controller;

    public Up(CircleCtrl controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.Up();
    }
}
