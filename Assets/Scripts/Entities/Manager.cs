using DanMinerTycoon.Environment;
using UnityEngine;

namespace DanMinerTycoon.Entities
{
    /// <summary>
    /// A component that oversees <see cref="Worker"/>s in a <see cref="Pipeline"/>.
    /// </summary>
    public class Manager : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="Pipeline"/> this <see cref="Manager"/> oversees.
        /// </summary>
        [SerializeField]
        private Pipeline Assignment;

        /// <summary>
        /// Called at the start of this component's lifecycle, this
        /// method finds its related <see cref="Pipeline"/>.
        /// </summary>
        public void Start()
        {
            Assignment = gameObject.GetComponentInParent<Pipeline>();
        }

        /// <summary>
        /// Checks for idle <see cref="Worker"/>s, and re-engages them.
        /// </summary>
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
}