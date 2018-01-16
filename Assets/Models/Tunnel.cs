using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Tunnel : Pipeline
{
    public void Start()
    {
        Store = gameObject.GetComponent<Store>();
        Sources = gameObject.GetComponentsInChildren<Source>();
        Workers = gameObject.GetComponentsInChildren<Worker>();
        Sink = gameObject.GetComponentInChildren<Sink>();
    }
}