namespace MU.SnakeGame.CLI;

public interface IChangeableState
{
    public void Change(Direction direction);
}