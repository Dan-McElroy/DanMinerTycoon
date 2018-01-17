using System;
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
        => transform.SelectImmediateChildrenWhere(
            child => child.tag == tag,
            child => child);
    
    /// <summary>
    /// Finds components of the specified type within the transform's immediate children.
    /// </summary>
    /// <typeparam name="T">The type of component required.</typeparam>
    /// <param name="transform">The transform with child objects to be searched.</param>
    /// <returns></returns>
    public static IEnumerable<T> GetComponentOfImmediateChildren<T>(this Transform transform)
        => transform.SelectImmediateChildrenWhere(
            child => child.GetComponent<T>() != null, 
            child => child.GetComponent<T>());

    /// <summary>
    /// Filters the transform's immediate children by a predicate function, and
    /// projects each of these children into the specified type via the selector function.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="transform">The transform with child objects to be selected.</param>
    /// <param name="predicate">A function to filter children by.</param>
    /// <param name="selector">A function to select the required value from a child.</param>
    /// <returns></returns>
    private static IEnumerable<T> SelectImmediateChildrenWhere<T>(this Transform transform, 
        Func<Transform, bool> predicate, Func<Transform, T> selector)
    {
        var selected = new List<T>();
        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (predicate(child))
            {
                selected.Add(selector(child));
            }
        }
        return selected;
    }
}
