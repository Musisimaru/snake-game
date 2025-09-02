using System.Text;

namespace MU.SnakeGame.CLI;

public class ConsoleStateRenderer: IStateRenderer
{
    private readonly (short width, short height) _size;
    private const int Multiplier = 3;

    public ConsoleStateRenderer((short width, short height) size)
    {
        _size = size;
    }
    public ValueTask Render(IState state, CancellationToken ct = default)
    {
        var word =  Enum.GetName(typeof(Direction), state.Direction);

        var frame = PrepareFrame(state);
        Console.Clear();
        Console.Write(frame);
        
        return ValueTask.CompletedTask;
    }

    // TODO: Можно переделать на стримы и на StringBuilder
    private StringBuilder RenderField(IState state)
    {
        var (x,y) = state.Position;
        var (width, height) = _size;

        string emptyString = $"\u2502{new string(' ', width*Multiplier)}\u2502";
        string.Intern(emptyString);

        var field = new StringBuilder();
        
        field.AppendLine("┌" + new string('─', width*Multiplier) + "┐");
        for (int i = height-1; i >= 0; i--)
        {
            if (i != y)
            {
                field.AppendLine(emptyString);
                continue;
            }
            
            field.AppendLine($"\u2502{new string(' ', x*Multiplier)} {blackSquare} {new string(' ', (width - x - 1)*Multiplier)}\u2502");
        }
        field.AppendLine("└" + new string('─', width*Multiplier) + "┘");
        return field;
    }

    private StringBuilder RenderInfo(IState state)
    {
        var info = new StringBuilder();
        var word =  Enum.GetName(typeof(Direction), state.Direction);
        
        info.AppendLine(word);
        info.AppendLine($"x: {state.Position.x}, y: {state.Position.y}\n(size {_size})");
        
        return info;
    }

    private string PrepareFrame(IState state)
    {
        var frame = new StringBuilder();
        frame.Append(RenderInfo(state));
        frame.Append(RenderField(state));
        return frame.ToString();
    }
    
    
    const char blackSquare  = '\u25A0'; // ■ BLACK SQUARE
    const char whiteSquare  = '\u25A1'; // □ WHITE SQUARE
    const char smallBlack   = '\u25AA'; // ▪ SMALL BLACK SQUARE
    const char smallWhite   = '\u25AB'; // ▫ SMALL WHITE SQUARE
}