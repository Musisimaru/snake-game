namespace MU.SnakeGame.CLI;

public class StateManager : IStateManager
{
    private readonly IChangeableState _state;
    private readonly (short width, short height) _fieldSize;

    public StateManager(IChangeableState state, (short width, short height) fieldSize)
    {
        _state = state;
        _fieldSize = fieldSize;
    }
    
    public ValueTask ChangeDirection(IChangeableState state, Direction newValue, CancellationToken ct = default)
    {
        state.ChangeDirection(newValue);
        return ValueTask.CompletedTask;
    }
    public ValueTask ChangePosition(IChangeableState state, (short x, short y)  newValue, CancellationToken ct = default)
    {
        var (x, y) = newValue;
        
        GoingBeyond(ref x, 0, (short)(_fieldSize.width - 1));
        GoingBeyond(ref y, 0, (short)(_fieldSize.height - 1));
        
        state.ChangePosition(x,y);
        return ValueTask.CompletedTask;
    }
    
    private void GoingBeyond(ref short coord, short min, short max){
        if (coord > max)
        {
            coord = min;
        }else if (coord < min)
        {
            coord = max;
        }
    }
}