using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Source : Endpoint
{
    public override void Interact(Worker worker)
    {
        worker.State = WorkerState.Gathering;
        var remainingCapacity = worker.Properties.WorkerCapacity - worker.Load;
        worker.Load += Infinite 
            ? remainingCapacity
            : Store.Extract(remainingCapacity);
    }
}