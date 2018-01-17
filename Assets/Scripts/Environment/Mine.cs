using DanMinerTycoon.Resource;
using System.Collections.Generic;
using System.Linq;

namespace DanMinerTycoon.Environment
{
    /// <summary>
    /// A component containing all <see cref="Tunnel"/>s and overseeing an elevator
    /// which gathers resources from them.
    /// </summary>
    public class Mine : Pipeline
    {
        /// <summary>
        /// Finds <see cref="Source"/>s from child <see cref="Tunnel"/> objects.
        /// </summary>
        /// <returns>A list of sources to draw from.</returns>
        protected override IEnumerable<Source> GetSources()
            => GetComponentsInChildren<Tunnel>()
                .Select(tunnel => tunnel.GetComponent<Source>());
    }
}