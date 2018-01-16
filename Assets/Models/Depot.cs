using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Depot : Pipeline
{
    public IEnumerable<Source> GetSources()
        => GetComponentsInChildren<Mine>()
                .Select(tunnel => tunnel.GetComponent<Source>());
}

