using System.Collections.Generic;
using System.Linq;

public class Depot : Pipeline
{
    protected override IEnumerable<Source> GetSources()
        => GetComponentsInChildren<Mine>()
                .Select(mine => mine.GetComponent<Source>());
}

