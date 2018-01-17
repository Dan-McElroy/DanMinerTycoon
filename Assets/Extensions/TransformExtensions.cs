using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A static class containing extension methods for <see cref="Transform"/> objects.
/// </summary>
public static class TransformExtensions
{
    /// <summary>
    /// Finds the immediate children of this transform with the specified tag.
    /// </summary>
    /// <param name="transform">The transform with child objects to be searched.</param>
    /// <param name="tag">The tag to search with.</param>
    /// <returns></returns>
    public static IEnumerable<Transform> GetImmediateChildrenWithTag(this Transform transform, string tag)
    {
        var taggedChildren = new List<Transform>();
        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.tag == tag)
            {
                taggedChildren.Add(child);
            }
        }
        return taggedChildren;
    }
}
