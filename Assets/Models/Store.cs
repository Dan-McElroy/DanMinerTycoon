using System;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private float _quantity;

    private float Quantity
    {
        get { return _quantity; }
        set
        {
            _quantity = value;
            QuantityText.text = value.ToString("c2");
        }
    }

    private TextMesh QuantityText;

    public void Start()
    {
        QuantityText = gameObject.GetComponentInChildren<TextMesh>();
        Quantity = 0;
    }

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
