using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Tunnel : Pipeline
{
    public void Start()
    {
        Properties = gameObject.GetComponent<PipelineProperties>();
        Store = gameObject.GetComponent<Store>();
        Sources = gameObject.GetComponentsInChildren<Source>().ToList();
        // Removes the tunnel's own source from the list.
        Sources.Remove(gameObject.GetComponent<Source>());
        Workers = gameObject.GetComponentsInChildren<Worker>().ToList();
        Sink = gameObject.GetComponentInChildren<Sink>();
    }
}