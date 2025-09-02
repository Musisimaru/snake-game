namespace MU.SnakeGame.CLI;

public interface IStateRenderer
{
    public ValueTask Render(IState state, CancellationToken ct = default);
}