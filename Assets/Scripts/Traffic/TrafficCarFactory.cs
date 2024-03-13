using UnityEngine;

namespace Traffic
{
    public class TrafficCarFactory : MonoBehaviour
    {
        [SerializeField]
        private TrafficPooler trafficPooler;
        
        public void SpawnTrafficCar(Vector3 spawnPosition, Quaternion spawnRotation, Vector3 targetPosition)
        {
            var car = trafficPooler.GetCar();
            car.transform.position = spawnPosition;
            car.transform.rotation = spawnRotation;
            car.SetActive(true);
            car.GetComponent<TrafficCar>().SetTarget(targetPosition);
        }
    }
}
