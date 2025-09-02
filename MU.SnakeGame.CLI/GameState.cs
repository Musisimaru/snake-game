namespace MU.SnakeGame.CLI;

public class GameState : IState, IChangeableState
{
    private Direction _direction = Direction.Down;
    public Direction Direction => _direction;
    
    private (short x, short y) _position;
    public (short x, short y) Position => _position;

    public GameState((short width,short height) gameFieldSize)
    {
        var center = Math.Round((double)gameFieldSize.width / 2);
        _position = (Convert.ToInt16(center), --gameFieldSize.height);
    }

    public void ChangeDirection(Direction direction)
    {
        _direction = direction;
    }

    public void ChangePosition(short x, short y)
    {
        _position = (x, y);
    }
}