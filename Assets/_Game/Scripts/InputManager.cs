using UnityEngine;

namespace _Game.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        public Vector3 MouseWorldPosition { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            UpdateMousePosition();
        }

        private void UpdateMousePosition()
        {
            MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}