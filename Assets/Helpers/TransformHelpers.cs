using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class TransformHelpers
{
    public static IEnumerable<Transform> GetChildObjectsWithTag(this Transform transform, string tag)
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
