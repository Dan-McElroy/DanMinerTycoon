using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField]
    private Pipeline Assignment;
    

    public PipelineProperties Properties => Assignment.Properties;
    

    
    public WorkerState State;
    
    public float Load;

    [SerializeField]
    private Queue<Endpoint> TaskQueue;
    

    public void Start()
    {
        Assignment = gameObject.GetComponentInParent<Pipeline>();
        State = WorkerState.Idle;
    }

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
                TaskQueue.Dequeue().Interact(this);
                State = WorkerState.Travelling;
            }
        }
    }

    public void OnMouseDown()
    {
        if (State == WorkerState.Idle)
        {
            BeginWork();
        }
    }

    public void BeginWork()
    {
        // Go get the resources from the source, put them in the sink
        TaskQueue = new Queue<Endpoint>(Assignment.Sources.ToArray());
        TaskQueue.Enqueue(Assignment.Sink);
        State = WorkerState.Travelling;
    }

    private void MoveTowards(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position,
            Properties.WorkerSpeed * Time.fixedDeltaTime);
    }

    private bool Reached(Transform target)
        => Vector3.Distance(transform.position, target.position) < .1;
}
