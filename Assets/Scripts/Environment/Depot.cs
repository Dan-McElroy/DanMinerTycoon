using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The final stage of the mining process, where resources gathered by an
/// elevator are transported by minecarts into the user's cash.
/// </summary>
public class Depot : Pipeline
{
    /// <summary>
    /// Finds <see cref="Source"/>s from child <see cref="Mine"/> objects.
    /// </summary>
    /// <returns>A list of sources to draw from.</returns>
    protected override IEnumerable<Source> GetSources()
        => GetComponentsInChildren<Mine>()
                .Select(mine => mine.GetComponent<Source>());
}

