using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A class representing a system with a number of sources
/// containing resources, a number of workers to extract
/// these resources, a sink to deposit the resources in,
/// and a manager to oversee them.
/// </summary>
public abstract class Pipeline : MonoBehaviour
{
    #region Properties

    #region Private

    /// <summary>
    /// Private variable for <see cref="Sink"/>
    /// </summary>
    /// <remarks>
    /// Not for general use, <see cref="Sink"/>
    /// should be used to access and mutate this
    /// value.
    /// </remarks>
    [SerializeField]
    [Obsolete("Use property Sink instead.")]
    private Sink _sink;

    /// <summary>
    /// Private variable for <see cref="Status"/>
    /// </summary>
    /// <remarks>
    /// Not for general use, <see cref="Status"/>
    /// should be used to access and mutate this
    /// value.
    /// </remarks>
    [SerializeField]
    [Obsolete("Use property Status instead.")]
    private PipelineStatus _status;
    
    /// <summary>
    /// Private variable for <see cref="WorkerStation"/>
    /// </summary>
    /// <remarks>
    /// Not for general use, <see cref="WorkerStation"/>
    /// should be used to access and mutate this
    /// value.
    /// </remarks>
    [SerializeField]
    [Obsolete("Use property WorkerStation instead.")]
    private Transform _workerStation;

    #endregion

    /// <summary>
    /// A reference to the <see cref="Store"/> tied 
    /// to this <see cref="Pipeline"/>.
    /// </summary>
    protected Store Store;

    /// <summary>
    /// The <see cref="Manager"/> for this 
    /// <see cref="Pipeline"/>, responsible for
    /// re-engaging idle workers.
    /// </summary>
    protected Manager Manager;

    /// <summary>
    /// A collection of workers that operate in
    /// this <see cref="Pipeline"/>.
    /// </summary>
    public IEnumerable<Worker> Workers
        => transform.GetComponentOfImmediateChildren<Worker>();

    /// <summary>
    /// A collection of <see cref="Source"/> objects
    /// that <see cref="Worker"/>s in this pipeline
    /// draw from.
    /// </summary>
    public IEnumerable<Source> Sources => GetSources();

    /// <summary>
    /// The <see cref="Sink"/> that gathered resources
    /// will be deposited into.
    /// </summary>
    public Sink Sink
    {
// Disable warnings for using Obsolete property.
#pragma warning disable 0618
        get { return _sink; }
        protected set { _sink = value; }
#pragma warning restore 0618
    }
    
    /// <summary>
    /// Contains information about the productivity
    /// of this pipeline and handles upgrades.
    /// </summary>
    public PipelineStatus Status
    {
// Disable warnings for using Obsolete property.
#pragma warning disable 0618
        get { return _status; }
        protected set { _status = value; }
#pragma warning restore 0618
    }

    /// <summary>
    /// 
    /// </summary>
    public Transform WorkerStation
    {
// Disable warnings for using Obsolete property.
#pragma warning disable 0618
        get { return _workerStation; }
        protected set { _workerStation = value; }
#pragma warning restore 0618
    }

    #endregion

    #region MonoBehaviour Methods

    /// <summary>
    /// Called at the start of this component's lifecycle, this
    /// method finds related components from surrounding objects.
    /// </summary>
    public virtual void Start()
    {
        Store = gameObject.GetComponent<Store>();
    }

    #endregion

    #region Abstract Methods

    /// <summary>
    /// Finds the sources for a given <see cref="Pipeline"/>.
    /// </summary>
    /// <returns>A list of sources.</returns>
    protected abstract IEnumerable<Source> GetSources();

    #endregion
}
