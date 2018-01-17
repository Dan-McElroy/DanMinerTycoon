using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A component representing the base level <see cref="Pipeline"/>.
/// </summary>
public class Tunnel : Pipeline
{
    #region Properties

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
        set
        {
            _depth = value;
            DepthText.text = _depth.ToString();
            var spriteRenderer = GetComponent<SpriteRenderer>();
            transform.Translate(
                0,
                -(_depth * spriteRenderer.size.y),
                0);
        }
#pragma warning restore 0618
    }

// Disables warning for unassigned variables, as these
// variables will be set in the Unity editor.
#pragma warning disable 0649

    /// <summary>
    /// A reference to the on-screen text denoting the tunnel's
    /// depth.
    /// </summary>
    [SerializeField]
    private Text DepthText;

#pragma warning restore 0649

    #endregion

    #region MonoBehaviour Methods

    /// <summary>
    /// Called at the start of this component's lifecycle, this
    /// method sets the <see cref="Depth"/> value to update the display.
    /// </summary>
    public override void Start()
    {
        base.Start();
        Depth = Depth;
    }

    #endregion

    #region Pipeline Methods

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

    #endregion
}