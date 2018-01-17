/// <summary>
/// An endpoint which is responsible for interfacing with
/// a <see cref="Worker"/> to extract resources from a <see cref="Store"/>.
/// </summary>
public class Source : Endpoint
{
    /// <summary>
    /// Transfers a load from the related <see cref="Store"/> to 
    /// the <see cref="Worker"/>, the value of which is determined 
    /// by its remaining capacity and the quantity available in
    /// the store.
    /// </summary>
    /// <param name="worker"></param>
    /// <remarks>
    /// If <see cref="Infinite"/> is true, the worker will be transferred
    /// as much as they can carry.
    /// </remarks>
    public override void Access(Worker worker)
    {
        worker.State = WorkerState.Gathering;;
        worker.Load += Store.Extract(worker.RemainingCapacity);
    }
}