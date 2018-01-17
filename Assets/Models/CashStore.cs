using System;

/// <summary>
/// A <see cref="Store"/> that represents the player's amount of cash.
/// </summary>
public class CashStore : Store
{
    /// <summary>
    /// Removes and returns the desired quantity, if it has enough 
    /// to meet demand.
    /// </summary>
    /// <param name="desiredQuantity">The value to extract.</param>
    /// <returns>
    /// The extracted value desired.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws if the desired quantity exceeds the amount of cash in
    /// the store.
    /// </exception>
    public override float Extract(float desiredQuantity)
    {
        if (!CanAfford(desiredQuantity))
        {
            throw new ArgumentOutOfRangeException(nameof(desiredQuantity),
                "Store does not have enough resource to meet demand.");
        }
        Quantity -= desiredQuantity;
        return desiredQuantity;
    }

    /// <summary>
    /// Checks if the store has enough cash to meet the required amount.
    /// </summary>
    /// <param name="requisiteQuantity">The quantity required.</param>
    /// <returns></returns>
    public bool CanAfford(float requisiteQuantity)
        => Quantity >= requisiteQuantity;
}
