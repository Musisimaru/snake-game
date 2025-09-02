namespace MU.SnakeGame.CLI;

public interface IStateManager
{
    ValueTask ChangeDirection(IChangeableState state, Direction newValue, CancellationToken ct = default);
    ValueTask ChangePosition(IChangeableState state, (short x, short y) newValue, CancellationToken ct = default);
}