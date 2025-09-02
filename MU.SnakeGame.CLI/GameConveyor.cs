namespace MU.SnakeGame.CLI;

class GameConveyor(IState state, IStateRenderer renderer, IProcessor processor)
{
    public async Task RunEveryAsync(TimeSpan period, CancellationToken ct = default)
    {
        using var timer = new PeriodicTimer(period);

        while (await timer.WaitForNextTickAsync(ct))
        {
            try
            {
                if (processor != null) _ = processor.MoveNext(ct);
                await renderer.Render(state, ct);
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested) { }
            catch (Exception ex)
            {
                // логируем, чтобы не оборвать цикл
            }
        }
    }
}