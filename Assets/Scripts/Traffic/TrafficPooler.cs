using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    public class TrafficPooler : MonoBehaviour
    {
        public GameObject trafficCarPrefab;
        
        private Queue<GameObject> carsPool = new Queue<GameObject>();
        
        private void OnEnable()
        {
            GameEvents.OnTrafficCarHit += ReturnCarToPool;
        }

        private void OnDisable()
        {
            GameEvents.OnTrafficCarHit += ReturnCarToPool;
        }

        public GameObject GetCar()
        {
            if (carsPool.Count == 0)
            {
                AddCars(1);
            }
            return carsPool.Dequeue();
        }

        private void AddCars(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var newCar = Instantiate(trafficCarPrefab,this.transform);
                newCar.SetActive(false);
                carsPool.Enqueue(newCar);
            }
        }

        private void ReturnCarToPool(GameObject car)
        {
            car.SetActive(false);
            carsPool.Enqueue(car);
        }
    }
}
