using UnityEngine;

namespace _Game.Scripts.Core
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        public Vector3 MouseWorldPosition { get; private set; }

        public bool IsFiring { get; private set; }

        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Debug.LogError(
                    "Multiple instances of " + nameof(InputManager) + " found in the scene.\n" +
                    "Only one could be exists, fix it.");
                return;
            }

            Instance = this;
        }

        private void Update()
        {
            UpdateMousePosition();
            UpdateFiringState();
        }

        private void UpdateMousePosition()
        {
            MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void UpdateFiringState()
        {
            IsFiring = Input.GetButton("Fire1");
        }
    }
}