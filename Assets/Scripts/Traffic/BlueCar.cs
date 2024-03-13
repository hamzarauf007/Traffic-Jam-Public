using UnityEngine;

namespace Traffic
{
    public class BlueCar : TrafficCar
    {
        public override void SetTarget(Vector3 target)
        {
            base.SetTarget(target);
        }

        protected override void MoveTowardsTarget()
        {
            base.MoveTowardsTarget();
        }

        protected override void DisableCar()
        {
            base.DisableCar();
        }
    }
}