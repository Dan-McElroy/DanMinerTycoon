using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanMinerTycoon.Extensions
{
    /// <summary>
    /// A static class containing extension methods for <see cref="float"/>s.
    /// </summary>
    public static class FloatExtensions
    {
        public static bool ApproximatelyEquals(this float firstValue, float secondValue)
        {
            var epsilon = Math.Max(Math.Abs(firstValue), Math.Abs(secondValue)) * 1E-15;
            return Math.Abs(firstValue - secondValue) <= epsilon;
        }
    }
}

