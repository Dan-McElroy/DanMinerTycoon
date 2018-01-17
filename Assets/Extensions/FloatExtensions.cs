using System;

/// <summary>
/// A static class containing extension methods for <see cref="float"/>s.
/// </summary>
public static class FloatExtensions
{
    /// <summary>
    /// Checks whether two <see cref="float"/> values are approximately equal.
    /// </summary>
    /// <param name="firstValue">The first float value to compare.</param>
    /// <param name="secondValue">The second float value to compare.</param>
    public static bool ApproximatelyEquals(this float firstValue, float secondValue)
    {
        var epsilon = Math.Max(Math.Abs(firstValue), Math.Abs(secondValue)) * 1E-15;
        return Math.Abs(firstValue - secondValue) <= epsilon;
    }
}
