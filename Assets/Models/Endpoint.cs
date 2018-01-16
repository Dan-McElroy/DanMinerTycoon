using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Endpoint : MonoBehaviour
{
    [SerializeField]
    public Transform AccessPoint { get; set; }

    public Store Store { get; set; }

    public void Start()
    {
        Store = gameObject.GetComponentInParent<Store>();
    }

    // Temporary name.
    public abstract void Interact(Worker worker);
}