/// <summary>
/// A <see cref="Source"/> with unlimited capacity.
/// </summary>
public class UnlimitedSource : Source
{
    public override void Access(Worker worker)
    {
        worker.State = WorkerState.Gathering; ;
        worker.Load += worker.RemainingCapacity;
    }
}
