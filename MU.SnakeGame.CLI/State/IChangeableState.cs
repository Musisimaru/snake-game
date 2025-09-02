namespace MU.SnakeGame.CLI;

public interface IChangeableState
{
    public void ChangeDirection(Direction direction);
    public void ChangePosition(short x, short y);
}