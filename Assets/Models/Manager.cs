using System;
using UnityEngine;

/// <summary>
/// A component that oversees <see cref="Worker"/>s in a <see cref="Pipeline"/>.
/// </summary>
public class Manager : MonoBehaviour
{
    /// <summary>
    /// Private variable for <see cref="Enabled"/>
    /// </summary>
    /// <remarks>
    /// Not for general use, <see cref="Enabled"/>
    /// should be used to access and mutate this
    /// value.
    /// </remarks>
    [SerializeField]
    [Obsolete("Use property Enabled instead.")]
    private bool _enabled;

    /// <summary>
    /// The renderer for the Manager sprite.
    /// </summary>
    private SpriteRenderer Renderer { get; set; }

// Disables warning for unassigned variables, as these
// variables will be set in the Unity editor.
#pragma warning disable 0649

    /// <summary>
    /// Sprite indicating that the manager is disabled.
    /// </summary>
    [SerializeField]
    private Sprite DisabledSprite;

    /// <summary>
    /// Sprite indicating that the manager is enabled.
    /// </summary>
    [SerializeField]
    private Sprite EnabledSprite;

#pragma warning restore 0649

    /// <summary>
    /// The <see cref="Pipeline"/> this <see cref="Manager"/> oversees.
    /// </summary>
    [SerializeField]
    private Pipeline Assignment;

    /// <summary>
    /// Indicates whether or not the manager has been enabled.
    /// </summary>
    [SerializeField]
    private bool Enabled   
    {
// Disable warnings for using Obsolete property.
#pragma warning disable 0618
        get { return _enabled; }
        set
        {
            _enabled = value;
            Renderer.sprite = _enabled
                ? EnabledSprite
                : DisabledSprite;
        }
#pragma warning restore 0618
    }

    /// <summary>
    /// Called at the start of this component's lifecycle, this
    /// method finds its related components.
    /// </summary>
    public void Start()
    {
        Assignment = gameObject.GetComponentInParent<Pipeline>();
        Renderer = gameObject.GetComponent<SpriteRenderer>();
        // Ensures correct sprite is rendered.
        Enabled = Enabled;
    }

    /// <summary>
    /// If the manager is enabled, checks for idle <see cref="Worker"/>s, 
    /// and re-engages them.
    /// </summary>
    public void Update()
    {
        if (!Enabled)
        {
            return;
        }
        foreach (var worker in Assignment.Workers)
        {
            if (worker.State == WorkerState.Idle)
            {
                worker.BeginWork();
            }
        }
    }

    public void OnMouseDown()
    {
        Enabled = !Enabled;    
    }
}
