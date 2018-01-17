namespace DanMinerTycoon.Entities
{
    /// <summary>
    /// An enum describing the current state of a <see cref="Worker"/>.
    /// </summary>
    public enum WorkerState
    {
        /// <summary>
        /// The <see cref="Worker"/> is inactive.
        /// </summary>
        Idle = 0,
        /// <summary>
        /// The <see cref="Worker"/> is travelling between points.
        /// </summary>
        Travelling = 1,
        /// <summary>
        /// The <see cref="Worker"/> is gathering resource from a <see cref="Source"/>.
        /// </summary>
        Gathering = 2,
        /// <summary>
        /// The <see cref="Worker"/> is depositing resource in a <see cref="Sink"/>.
        /// </summary>
        Depositing = 3
    }
}