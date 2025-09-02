namespace MU.SnakeGame.CLI;

public interface IProcessor
{
    public ValueTask MoveNext(CancellationToken ct = default);
}