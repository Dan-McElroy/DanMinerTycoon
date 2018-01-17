using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A component containing all <see cref="Tunnel"/>s and overseeing an elevator
/// which gathers resources from them.
/// </summary>
public class Mine : Pipeline
{
// Disables warning for unassigned variables, as these
// variables will be set in the Unity editor.
#pragma warning disable 0649

    /// <summary>
    /// A template for a new tunnel.
    /// </summary>
    [SerializeField]
    private Tunnel TunnelTemplate;

#pragma warning restore 0649

    /// <summary>
    /// Finds <see cref="Source"/>s from child <see cref="Tunnel"/> objects.
    /// </summary>
    /// <returns>A list of sources to draw from.</returns>
    protected override IEnumerable<Source> GetSources()
        => GetComponentsInChildren<Tunnel>()
            .OrderBy(tunnel => tunnel.Depth)
            .Select(tunnel => tunnel.GetComponent<Source>());
    
    /// <summary>
    /// Adds a new tunnel to the mine.
    /// </summary>
    public void AddTunnel()
    {
        var newTunnel = Instantiate(TunnelTemplate, transform);
        newTunnel.Depth = Sources.Count() - 1;
    }
}