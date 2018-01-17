/// <summary>
/// An endpoint which is responsible for interfacing with
/// a <see cref="Worker"/> to deposit resources in a <see cref="Store"/>.
/// </summary>
public class Sink : Endpoint
{
    /// <summary>
    /// Empties the load carried by a <see cref="Worker"/>
    /// into the related <see cref="Store"/>.
    /// </summary>
    /// <param name="worker">
    /// The <see cref="Worker"/> accessing the sink.
    /// </param>
    public override void Access(Worker worker)
    {
        worker.State = WorkerState.Depositing;
        Store.Deposit(worker.Load);
        worker.Load = 0;
    }
}
