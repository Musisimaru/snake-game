namespace MU.SnakeGame.CLI;

class Program
{
    private static readonly (short width, short height) _size = (100, 100);
    private static readonly GameState GameState = new(_size);
    
    static async Task Main(string[] args)
    {
        using var cts = new CancellationTokenSource();

        var renderer = new ConsoleStateRenderer(_size);
        var stateManager = new StateManager(GameState, _size);
        var processor = new GameProcessor(GameState, stateManager, GameState); 
        var gameConveyor = new GameConveyor(GameState, renderer, processor);
        var task = gameConveyor.RunEveryAsync(TimeSpan.FromSeconds(1), cts.Token);
        

        while (true)
        {
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.Backspace)
            {
                break;
            }

            switch (key)
            {
                case ConsoleKey.LeftArrow: stateManager.ChangeDirection( GameState, Direction.Left); break;
                case ConsoleKey.RightArrow: stateManager.ChangeDirection( GameState, Direction.Right); break;
                case ConsoleKey.UpArrow: stateManager.ChangeDirection( GameState, Direction.Up); break;
                case ConsoleKey.DownArrow: stateManager.ChangeDirection( GameState, Direction.Down); break;
                default: continue;
            }
        }
        
        cts.Cancel();

        try
        {
            await task;
        }
        catch (OperationCanceledException e)
        {
        }
        
        Console.WriteLine("Program is completed...");
    }
}