using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField]
    private Pipeline Assignment { get; set; }
    
    [SerializeField]
    public WorkerState State { get; set; }
    
    [SerializeField]
    public float Load { get; set; }

    [SerializeField]
    private Queue<Endpoint> TaskQueue { get; set; }
    

    public void Start()
    {
        Assignment = gameObject.GetComponentInParent<Pipeline>();
        State = WorkerState.Idle;
    }

    public void Update()
    {
    }
    
    public void BeginWork()
    {
    }
}
