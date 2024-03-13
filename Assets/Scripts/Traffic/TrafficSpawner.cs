using UnityEngine;
using Random = UnityEngine.Random;

namespace Traffic
{
    public class TrafficSpawner : MonoBehaviour
    {
        public TrafficCarFactory carFactory;
        public float spawnInterval = 2f;
        public float radius = 10f;
        
        private float timer = 0f;
        private bool isSpawning = false;

        private void OnEnable()
        {
            GameEvents.OnStartGame += StartSpawning;
            GameEvents.OnTimeComplete += StopSpawning;
        }

        private void OnDisable()
        {
            GameEvents.OnStartGame -= StartSpawning;
            GameEvents.OnTimeComplete -= StopSpawning;
        }

        private void StartSpawning()
        {
            isSpawning = true;
        }

        private void StopSpawning()
        {
            isSpawning = false;
        }

        void Update()
        {
            if (!isSpawning)
            {
                return;
            }

            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnCar();
                timer = 0;
            }
        }

        private void SpawnCar()
        {
            var positions = CalculateRandomBoundaryPosition();
            Vector3 spawnPosition = positions[0];
            Vector3 targetPosition = positions[1];
            Quaternion spawnRotation = Quaternion.identity;

            carFactory.SpawnTrafficCar(spawnPosition, spawnRotation, targetPosition);
        }
        
        private Vector3[] CalculateRandomBoundaryPosition()
        {
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float y = 0f;

            Vector3 spawnPosition = new Vector3(
                Mathf.Cos(angle) * radius, 
                y,
                Mathf.Sin(angle) * radius  
            );

            float angleDegrees = angle * Mathf.Rad2Deg;
            float minTargetAngleDegrees = (angleDegrees + 135) % 360; 
            float maxTargetAngleDegrees = (minTargetAngleDegrees + 90) % 360;
            float targetAngleDegrees = Random.Range(minTargetAngleDegrees, maxTargetAngleDegrees);
            float targetAngle = targetAngleDegrees * Mathf.Deg2Rad;
            
            Vector3 targetPosition = new Vector3(
                Mathf.Cos(targetAngle) * radius, 
                y,
                Mathf.Sin(targetAngle) * radius  
            );
            return new Vector3[] {spawnPosition, targetPosition};
        }
    }
}
