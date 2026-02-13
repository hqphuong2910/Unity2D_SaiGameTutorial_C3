using UnityEngine;

namespace _Game.Scripts
{
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 worldPosition;
        [SerializeField] private float moveSpeed = 1f;

        private void FixedUpdate()
        {
            worldPosition = InputManager.Instance.MouseWorldPosition;
            worldPosition.z = 0;

            var newPos = Vector3.Lerp(transform.parent.position, worldPosition, moveSpeed * Time.fixedDeltaTime);
            transform.parent.position = newPos;
        }
    }
}