using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A component representing the base level <see cref="Pipeline"/>.
/// </summary>
public class Tunnel : Pipeline
{
    /// <summary>
    /// Private variable for <see cref="Depth"/>
    /// </summary>
    /// <remarks>
    /// Not for general use, <see cref="Depth"/>
    /// should be used to access and mutate this
    /// value.
    /// </remarks>
    [SerializeField]
    [Obsolete("Use property Depth instead.")]
    private int _depth;

    /// <summary>
    /// The depth of this tunnel within the mine.
    /// </summary>
    public int Depth
    {
// Disable warnings for using Obsolete property.
#pragma warning disable 0618
        get { return _depth; }
        private set { _depth = value; }
#pragma warning restore 0618
    }

    /// <summary>
    /// Finds all child <see cref="Source"/>s, and excludes
    /// the <see cref="Source"/> component on the attached object.
    /// </summary>
    /// <returns>The sources attached to this tunnel.</returns>
    protected override IEnumerable<Source> GetSources()
    {
        var sources = gameObject.GetComponentsInChildren<Source>().ToList();
        // Removes the tunnel's own source from the list.
        sources.Remove(gameObject.GetComponent<Source>());
        return sources;
    }
}