using UnityEngine;

namespace Traffic
{
    public abstract class TrafficCar : MonoBehaviour, ITrafficCar
    {
        public float speed = 5f;
        
        [SerializeField]
        private int playerHitDeduction = 10000; 
        
        private Vector3 targetPosition;
        private bool hasTarget = false;

        public int PlayerHitDeduction {
            get => playerHitDeduction;
            set { }
        }

        public virtual void SetTarget(Vector3 target)
        {
            targetPosition = target;
            hasTarget = true;
            transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
        }

        private void Update()
        {
            if (hasTarget)
            {
                MoveTowardsTarget();
            }
        }

        protected virtual void MoveTowardsTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                DisableCar();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayArea") || other.CompareTag("Player"))
            {
                DisableCar();
            }
        }

        protected virtual void DisableCar()
        {
            hasTarget = false;
            gameObject.SetActive(false);
            GameEvents.TrafficCarHit(gameObject);
        }
    }
}