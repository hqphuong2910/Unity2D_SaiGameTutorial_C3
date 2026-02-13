using UnityEngine;

namespace _Game.Scripts
{
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 targetPosition;
        [SerializeField] private float moveSpeed = 1f;

        private void Update()
        {
            UpdateTargetPosition();
        }

        private void FixedUpdate()
        {
            HandleMovement();
            HandleRotation();
        }

        private void UpdateTargetPosition()
        {
            targetPosition = InputManager.Instance.MouseWorldPosition;
            targetPosition.z = 0;
        }

        private void HandleMovement()
        {
            var newPos = Vector3.Lerp(transform.parent.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            transform.parent.position = newPos;
        }

        private void HandleRotation()
        {
            var diff = targetPosition - transform.parent.position;
            diff.Normalize();
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
        }
    }
}