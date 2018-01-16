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
        var capacity = 1;
        var remainingCapacity = capacity - worker.Load;
        worker.Load = Math.Min(capacity,
            Store?.Extract(remainingCapacity)
            // If Store is null, source is unlimited, 
            ?? remainingCapacity);
    }
}