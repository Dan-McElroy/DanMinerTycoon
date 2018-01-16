using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Sink : Endpoint
{
    public override void Interact(Worker worker)
    {
        worker.State = WorkerState.Depositing;
        Store.Deposit(worker.Load);
        worker.Load = 0;
    }
}
