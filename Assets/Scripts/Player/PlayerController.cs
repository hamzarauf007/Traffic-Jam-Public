using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 5f;
        [SerializeField]
        private float rotateSpeed = 0.1f;
        
        private Vector3 targetDirection;
        private float rotationProgress = 0f; 
        private bool isRotating = false;
        private bool isMoving = false;
        private bool isFirstTime = false;
        
        private void OnEnable()
        {
            GameEvents.OnTimeComplete += StopMovement;
        }

        private void OnDisable()
        {
            GameEvents.OnTimeComplete -= StopMovement;
        }

        private void StopMovement()
        {
            this.GetComponent<Collider>().enabled = false;
            this.enabled = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetTargetDirection();
                if (!isFirstTime)
                {
                    isFirstTime = true;
                    GameEvents.GameStarted();
                }
            }

            if (isRotating)
            {
                RotateTowardsTargetDirection();
            }

            if (isMoving)
            {
                MoveForward();
            }
        }

        private void SetTargetDirection()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 clickPosition = hit.point;
                clickPosition.y = transform.position.y; 
                targetDirection = (clickPosition - transform.position).normalized;
                isMoving = true;
                isRotating = true;
                rotationProgress = 0f;
            }
        }

        private void RotateTowardsTargetDirection()
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        
            rotationProgress += Time.deltaTime * rotateSpeed;
            rotationProgress = Mathf.Clamp01(rotationProgress);

            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationProgress);

            if (rotationProgress >= 0.9f)
            {
                isRotating = false;
            }
        }

        private void MoveForward()
        {
            transform.position += transform.forward * (moveSpeed * Time.deltaTime);
        }

        public void ResetCar()
        {
            isMoving = false;
            transform.position = Vector3.zero;
        }
    }
}
