namespace MU.SnakeGame.CLI;

public class ConsoleStateRenderer: IStateRenderer
{
    private readonly (short width, short height) _size;
    public ConsoleStateRenderer((short width, short height) size)
    {
        _size = size;
    }
    public ValueTask Render(IState state, CancellationToken ct = default)
    {
        var word =  Enum.GetName(typeof(Direction), state.Direction);
        
        Console.Clear();
        Console.WriteLine(word);
        Console.WriteLine($"x: {state.Position.x}, y: {state.Position.y}\n(size {_size})");
        
        return ValueTask.CompletedTask;
    }
}