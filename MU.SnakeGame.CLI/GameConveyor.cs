namespace MU.SnakeGame.CLI;

class GameConveyor
{
    private readonly IState _state;
    private readonly IStateRenderer _renderer;

    public GameConveyor(IState state, IStateRenderer renderer)
    {
        _state = state;
        _renderer = renderer;
    }
    
    public async Task RunEveryAsync(TimeSpan period, CancellationToken ct = default)
    {
        using var timer = new PeriodicTimer(period);

        while (await timer.WaitForNextTickAsync(ct))
        {
            try
            {
                _renderer.Render(_state);
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested) { }
            catch (Exception ex)
            {
                // логируем, чтобы не оборвать цикл
            }
        }
    }
}