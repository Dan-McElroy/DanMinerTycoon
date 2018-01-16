using System.Collections.Generic;
using System.Linq;

namespace Assets.Models
{
    public class Mine : Pipeline
    {
        protected override IEnumerable<Source> GetSources()
            => GetComponentsInChildren<Tunnel>()
                .Select(tunnel => tunnel.GetComponent<Source>());
    }
}
