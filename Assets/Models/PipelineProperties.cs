using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PipelineProperties
{
    private float BaseWorkerSpeed { get; set; }
    
    private float BaseWorkerCapacity { get; set; }
    
    private float BaseUpgradeCost { get; set; }

    public int Level { get; private set; }

    public void Upgrade()
    {
    }

    public float WorkerSpeed => BaseWorkerSpeed * Level;

    public float WorkerCapacity => BaseWorkerCapacity * Level;

    public float UpgradeCost => BaseUpgradeCost * Level;
}