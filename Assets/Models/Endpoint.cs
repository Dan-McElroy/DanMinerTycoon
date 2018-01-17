using System;
using System.Linq;
using UnityEngine;

/// <summary>
/// A component accessed by <see cref="Worker"/> to
/// extract or deposit resources.
/// </summary>
public abstract class Endpoint : MonoBehaviour
{
    #region Properties
    
    /// <summary>
    /// The point from which a worker can access
    /// this endpoint.
    /// </summary>
    public Transform AccessPoint;

    /// <summary>
    /// A reference to the <see cref="Store"/> tied 
    /// to this endpoint.
    /// </summary>
    public Store Store;

    /// <summary>
    /// The tag used to find the AccessPoint object
    /// at runtime.
    /// </summary>
    public string AccessPointTag;
    
    #endregion

    #region MonoBehaviour Methods
    
    /// <summary>
    /// Called at the start of this component's lifecycle, this
    /// method finds the access point from a provided tag.
    /// </summary>
    public void Start()
    {
        AccessPoint = transform.GetImmediateChildrenWithTag(AccessPointTag).FirstOrDefault();
    }

    #endregion

    #region Abstract Methods

    /// <summary>
    /// Behaviour for when the <see cref="Endpoint"/> is accessed
    /// by a <see cref="Worker"/>.
    /// </summary>
    /// <param name="worker">
    /// The <see cref="Worker"/> accessing the endpoint.
    /// </param>
    public abstract void Access(Worker worker);

    #endregion
}