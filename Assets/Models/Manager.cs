using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private Pipeline Assignment { get; set; }
    
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
