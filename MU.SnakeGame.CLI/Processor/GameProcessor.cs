namespace MU.SnakeGame.CLI;

public class GameProcessor(IState state, IStateManager stateManager, IChangeableState changeableState)
    : IProcessor
{
    public ValueTask MoveNext(CancellationToken ct = default)
    {
        var (x, y) = state.Position;
        switch (state.Direction)
        {
            case Direction.Up: y++ ; break;
            case Direction.Down: y--; break;
            case Direction.Left: x--; break;
            case Direction.Right: x++; break;
        }

        stateManager.ChangePosition(changeableState, (x, y), ct);
        return ValueTask.CompletedTask;
    }
}