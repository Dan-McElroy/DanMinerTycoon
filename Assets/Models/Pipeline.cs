using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pipeline : MonoBehaviour
{
    protected Store Store { get; set; }

    protected Manager Manager { get; set; }

    public IEnumerable<Worker> Workers { get; protected set; }

    public Sink Sink { get; protected set; }

    public IEnumerable<Source> Sources { get; protected set; }
    
    public PipelineProperties Properties { get; protected set; }

    public Transform WorkerStation { get; protected set; }
}
