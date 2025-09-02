namespace MU.SnakeGame.CLI;

public class StateManager : IStateManager
{
    private readonly IChangeableState _state;

    public StateManager(IChangeableState state)
    {
        _state = state;
    }
    
    public ValueTask ChangeDirection(IChangeableState state, Direction newValue, CancellationToken ct = default)
    {
        state.Change(newValue);
        return ValueTask.CompletedTask;
    }
}