namespace MU.SnakeGame.CLI;

public interface IStateManager
{
    ValueTask ChangeDirection(IChangeableState state, Direction newValue, CancellationToken ct = default);
}