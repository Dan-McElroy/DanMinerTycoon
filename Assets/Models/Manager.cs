using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private Pipeline Assignment;

    public void Start()
    {
        Assignment = gameObject.GetComponentInParent<Pipeline>();
    }

    public void Update()
    {
        foreach (var worker in Assignment.Workers)
        {
            if (worker.State == WorkerState.Idle)
            {
                worker.BeginWork();
            }
        }
    }
}
