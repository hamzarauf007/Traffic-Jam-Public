using UnityEngine;

namespace Traffic
{
    public interface ITrafficCar
    {
        int PlayerHitDeduction { get; set; }
        void SetTarget(Vector3 target);
    }
}