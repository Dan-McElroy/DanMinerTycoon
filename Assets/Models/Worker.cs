using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A component representing the unit responsible
/// for extracting resources from the <see cref="Source"/>s
/// in a given <see cref="Pipeline"/> and depositing them in
/// a <see cref="Sink"/>.
/// </summary>
public class Worker : MonoBehaviour
{
    #region Properties

    #region private

    /// <summary>
    /// Private variable for <see cref="Load"/>
    /// </summary>
    /// <remarks>
    /// Not for general use, <see cref="Load"/>
    /// should be used to access and mutate this
    /// value.
    /// </remarks>
    [SerializeField]
    [Obsolete("Use property Load instead.")]
    private float _load;

    /// <summary>
    /// The <see cref="Pipeline"/> this <see cref="Worker"/> operates in.
    /// </summary>
    [SerializeField]
    private Pipeline Assignment;
    
    /// <summary>
    /// The status of the worker's <see cref="Pipeline"/>, which governs
    /// several elements of its behaviour.
    /// </summary>
    public PipelineStatus Status => Assignment.Status;

    /// <summary>
    /// A reference to the on-screen text denoting the currently
    /// held <see cref="Load"/>.
    /// </summary>
    [SerializeField]
    private TextMesh LoadText;

    /// <summary>
    /// The endpoints to be accessed in the <see cref="Worker"/>'s current task.
    /// </summary>
    [SerializeField]
    private Queue<Endpoint> TaskQueue;

    #endregion

    /// <summary>
    /// The current amount of resource carried by the <see cref="Worker"/>.
    /// </summary>
    public float Load
    {
// Disable warnings for using Obsolete property.
#pragma warning disable 0618
        get { return _load; }
        set
        {
            _load = value;
            LoadText.text = value.ToString();
#pragma warning restore 0618
        }
    }
    
    /// <summary>
    /// The current state of the Worker, indicating their current activity.
    /// </summary>
    public WorkerState State;

    #endregion

    #region MonoBehaviour Methods

    /// <summary>
    /// Called at the start of this component's lifecycle, this
    /// method finds its related components and sets up <see cref="LoadText"/>.
    /// </summary>
    public void Start()
    {
        Assignment = gameObject.GetComponentInParent<Pipeline>();
        LoadText = gameObject.GetComponentInChildren<TextMesh>();
        LoadText.text = Load.ToString();
    }

    /// <summary>
    /// Handles the <see cref="Worker"/>'s navigation through its
    /// task queue within the pipeline.
    /// </summary>
    public void FixedUpdate()
    {
        if (State == WorkerState.Travelling)
        {
            if (!TaskQueue.Any())
            {
                MoveTowards(Assignment.WorkerStation);
                if (Reached(Assignment.WorkerStation))
                {
                    State = WorkerState.Idle;
                }
                return;
            }
            var nextDestination = TaskQueue.Peek().AccessPoint;
            MoveTowards(nextDestination);
            if (Reached(nextDestination))
            {
                TaskQueue.Dequeue().Access(this);
                State = WorkerState.Travelling;
            }
        }
    }

    /// <summary>
    /// Will begin work if the <see cref="Worker"/> is idle.
    /// </summary>
    public void OnMouseDown()
    {
        if (State == WorkerState.Idle)
        {
            BeginWork();
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Builds the Worker's <see cref="TaskQueue"/> and activates them.
    /// </summary>
    public void BeginWork()
    {
        // Visit all sources in the assigned pipeline.
        TaskQueue = new Queue<Endpoint>(Assignment.Sources.ToArray());
        // Deposit acquired resources in the Sink.
        TaskQueue.Enqueue(Assignment.Sink);
        // Start travelling.
        State = WorkerState.Travelling;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Moves the <see cref="Worker"/> toward a given target at the
    /// speed defined by it's <see cref="Status"/>.
    /// </summary>
    /// <param name="target">The point to be moved toward.</param>
    private void MoveTowards(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position,
            Status.WorkerSpeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Determines whether or not the Worker has reached its target.
    /// </summary>
    /// <param name="target">The point being moved toward.</param>
    private bool Reached(Transform target)
        => Vector3.Distance(transform.position, target.position) < .1;

    #endregion
}
