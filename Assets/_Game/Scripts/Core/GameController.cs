using UnityEngine;

namespace _Game.Scripts.Core
{
    public class GameController : MyBehaviour
    {
        [SerializeField] private Camera mainCamera;
        public Camera MainCamera => mainCamera;

        public static GameController Instance { get; private set; }

        protected override void Awake()
        {
            if (Instance && Instance != this)
            {
                Debug.LogError(
                    "Multiple instances of " + nameof(GameController) + " found in the scene.\n" +
                    "Only one could be exists, fix it.");
                return;
            }

            Instance = this;
        }

        protected override void OnLoadComponents()
        {
            base.OnLoadComponents();

            LoadCamera();
        }

        private void LoadCamera()
        {
            if (mainCamera) return;
            mainCamera = FindObjectOfType<Camera>();
            Debug.Log(transform.name + ": " + nameof(LoadCamera), gameObject);
        }
    }
}