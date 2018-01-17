using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Endpoint : MonoBehaviour
{
    public Transform AccessPoint;

    public Store Store;

    public string AccessPointTag;

    [SerializeField]
    private bool _infinite;

    public bool Infinite
    {
        get { return _infinite; }
        protected set { _infinite = value; }
    }

    public void Start()
    {
        AccessPoint = transform.GetChildObjectsWithTag(AccessPointTag).FirstOrDefault();
    }

    // Temporary name.
    public abstract void Interact(Worker worker);
}