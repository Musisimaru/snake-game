namespace MU.SnakeGame.CLI;

public interface IState
{
    public Direction Direction { get; }
    
    /// <summary>
    /// Coordinate: first x - by horizontal, second y = by vertical
    /// </summary>
    public (short x, short y) Position { get; }
}