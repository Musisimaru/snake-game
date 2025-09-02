namespace MU.SnakeGame.CLI;

public class GameState : IState, IChangeableState
{
    private Direction _direction = Direction.Down;
    public Direction Direction => _direction;
    
    public void Change(Direction direction)
    {
        _direction = direction;
    }
}