using UnityEngine;
using Random = UnityEngine.Random;

namespace Cash
{
    public class MoneySpawner : MonoBehaviour
    {
        [SerializeField]
        private MoneyFactory moneyFactory;

        [SerializeField] 
        private MoneyPooler moneyPooler;
        
        public float spawnInterval = 2f;
        public float radius = 10f; 
        
        private float timer = 0f;
        private bool isSpawning;

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

        private void Update()
        {
            if (!isSpawning)
            {
                return;
            }
            
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnMoney();
                timer = 0;
            }
        }

        private void SpawnMoney()
        {
            Vector3 spawnPosition = CalculateRandomCirclePosition();
            
            var moneyType = moneyPooler.moneyTypes[Random.Range(0, moneyPooler.moneyTypes.Count)].tag;

            moneyFactory.SpawnMoney(moneyType, spawnPosition);
        }

        private Vector3 CalculateRandomCirclePosition()
        {
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float distanceFromCenter = Random.Range(0f, radius);
            float x = Mathf.Cos(angle) * distanceFromCenter;
            float z = Mathf.Sin(angle) * distanceFromCenter;

            return new Vector3(x,0.2f, z); 
        }
    }
}