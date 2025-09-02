namespace MU.SnakeGame.CLI;

public class ConsoleStateRenderer: IStateRenderer
{
    public void Render(IState state)
    {
        var word =  Enum.GetName(typeof(Direction), state.Direction);
        
        Console.Clear();
        Console.WriteLine(word);
    }
}