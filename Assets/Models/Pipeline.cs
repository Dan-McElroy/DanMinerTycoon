using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Pipeline : MonoBehaviour
{
    protected Store Store { get; set; }

    protected Manager Manager { get; set; }

    [SerializeField]
    private IEnumerable<Worker> _workers;

    public IEnumerable<Worker> Workers
    {
        get { return _workers; }
        protected set { _workers = value; }
    }

    [SerializeField]
    private IList<Source> _sources;
    
    public IList<Source> Sources
    {
        get { return _sources; }
        protected set { _sources = value; }
    }

    [SerializeField]
    private Sink _sink;

    public Sink Sink
    {
        get { return _sink; }
        protected set { _sink = value; }
    }


    [SerializeField]
    private PipelineProperties _properties;

    public PipelineProperties Properties
    {
        get { return _properties; }
        protected set { _properties = value; }
    }

    [SerializeField]
    private Transform _workerStation;

    public Transform WorkerStation
    {
        get { return _workerStation; }
        protected set { _workerStation = value; }
    }

    public void Start()
    {
        Properties = gameObject.GetComponentInChildren<PipelineProperties>();
        Store = gameObject.GetComponent<Store>();
        Sources = gameObject.GetComponentsInChildren<Source>().ToList();
        // Removes the tunnel's own source from the list.
        Sources.Remove(gameObject.GetComponent<Source>());
        Workers = gameObject.GetComponentsInChildren<Worker>().ToList();
        Sink = gameObject.GetComponentInChildren<Sink>();
    }
}
