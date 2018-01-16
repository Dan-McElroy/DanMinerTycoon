using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PipelineProperties : MonoBehaviour
{
    [SerializeField]
    private float BaseWorkerSpeed;

    [SerializeField]
    private float BaseWorkerCapacity;

    [SerializeField]
    private float BaseUpgradeCost;

    [SerializeField]
    private int _level;
    
    public int Level
    {
        get { return _level; }
        private set { _level = value; }
    }

    public void Upgrade()
    {
        Level++;
    }

    public PipelineProperties()
    {
        Level = 1;
    }
    
    public float WorkerSpeed => BaseWorkerSpeed * Level;

    public float WorkerCapacity => BaseWorkerCapacity * Level;

    public float UpgradeCost => BaseUpgradeCost * Level;

}

