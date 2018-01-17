using System;
using UnityEngine;

/// <summary>
/// A store of resources.
/// </summary>
public class Store : MonoBehaviour
{
    #region Properties

    /// <summary>
    /// Private variable for <see cref="Quantity"/>
    /// </summary>
    /// <remarks>
    /// Not for general use, <see cref="Quantity"/>
    /// should be used to access and mutate this
    /// value.
    /// </remarks>
    [SerializeField]
    [Obsolete("Use property Quantity instead.")]
    private float _quantity;

    /// <summary>
    /// The amount of resource available in the <see cref="Store"/>.
    /// </summary>
    private float Quantity
    {
// Disable warnings for using Obsolete property.
#pragma warning disable 0618
        get { return _quantity; }
        set
        {
            _quantity = value;
            QuantityText.text = value.ToString("c2");
        }
#pragma warning restore 0618
    }
    
    /// <summary>
    /// A reference to the on-screen text denoting the currently
    /// held <see cref="Quantity"/>.
    /// </summary>
    private TextMesh QuantityText;

    #endregion

    #region MonoBehaviour Methods

    /// <summary>
    /// Called at the start of this component's lifecycle, this
    /// method finds its related <see cref="TextMesh"/> component.
    /// </summary>
    public void Start()
    {
        QuantityText = gameObject.GetComponentInChildren<TextMesh>();
        // Updates the display
        Quantity = Quantity;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Removes and returns the desired quantity, or its entire
    /// <see cref="Quantity"/> if it does not have enough to meet
    /// demand.
    /// </summary>
    /// <param name="desiredQuantity">The value to extract.</param>
    /// <returns>
    /// The value actually extracted, which may be less than desired.
    /// </returns>
    public float Extract(float desiredQuantity)
    {
        var extracted = Math.Min(Quantity, desiredQuantity);
        Quantity -= extracted;
        return extracted;
    }

    /// <summary>
    /// Adds a given value to the store's <see cref="Quantity"/>.
    /// </summary>
    /// <param name="quantity">The value to deposit.</param>
    public void Deposit(float quantity)
    {
        Quantity += quantity;
    }

    #endregion
}
