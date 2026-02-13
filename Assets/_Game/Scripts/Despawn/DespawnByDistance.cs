using UnityEngine;

namespace _Game.Scripts.Despawn
{
    public class DespawnByDistance : Despawn
    {
        [SerializeField] protected float distanceLimit = 30f;
        [SerializeField] protected float distance;
        [SerializeField] protected Camera mainCamera;

        protected override void OnLoadComponents()
        {
            LoadCamera();
        }

        protected virtual void LoadCamera()
        {
            if (mainCamera) return;
            mainCamera = FindObjectOfType<Camera>();
            Debug.Log(transform.name + ": " + nameof(LoadCamera), gameObject);
        }

        protected override bool CanDespawn()
        {
            distance = Vector3.Distance(mainCamera.transform.position, transform.parent.position);
            return distance > distanceLimit;
        }
    }
}