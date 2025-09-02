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
        RenderField(state);
        
        return ValueTask.CompletedTask;
    }

    private void RenderField(IState state)
    {
        var (x,y) = state.Position;
        var (width, height) = _size;
        const int multiplier = 3;
        
        string emptyString = $"|{new string(' ', width*multiplier)}|";
        string.Intern(emptyString);
        
        Console.WriteLine($"|{new string('\u203E', width*multiplier)}|");
        for (int i = height-1; i >= 0; i--)
        {
            if (i != y)
            {
                Console.WriteLine(emptyString);
                continue;
            }
            
            Console.WriteLine($"|{new string(' ', x*multiplier)} {blackSquare} {new string(' ', (width - x - 1)*multiplier)}|");
        }
        Console.WriteLine($" {new string('\u203E', width*multiplier)} ");
    }
    
    
    const char blackSquare  = '\u25A0'; // ■ BLACK SQUARE
    const char whiteSquare  = '\u25A1'; // □ WHITE SQUARE
    const char smallBlack   = '\u25AA'; // ▪ SMALL BLACK SQUARE
    const char smallWhite   = '\u25AB'; // ▫ SMALL WHITE SQUARE
}