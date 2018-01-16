using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Store : MonoBehaviour
{
    private float Quantity { get; set; }

    public float Extract(float desiredQuantity)
    {
        var extracted = Math.Min(Quantity, desiredQuantity);
        Quantity -= extracted;
        return extracted;
    }

    public void Deposit(float quantity)
    {
        Quantity += quantity;
    }
}
