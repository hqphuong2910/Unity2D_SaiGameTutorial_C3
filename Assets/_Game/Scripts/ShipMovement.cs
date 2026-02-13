using UnityEngine;

namespace _Game.Scripts
{
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 worldPosition;
        [SerializeField] private float moveSpeed = 1f;

        private void FixedUpdate()
        {
            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;

            var newPos = Vector3.Lerp(transform.position, worldPosition, moveSpeed * Time.fixedDeltaTime);
            transform.position = newPos;
        }
    }
}