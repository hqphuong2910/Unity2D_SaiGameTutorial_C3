using _Game.Scripts.Core;
using _Game.Scripts.Spawner;
using UnityEngine;

namespace _Game.Scripts.Ship
{
    public class ShipShooting : MonoBehaviour
    {
        [SerializeField] private bool isShooting;

        [SerializeField] private float shootingDelay = 1f;
        [SerializeField] private float shootingTimer;

        private void Update()
        {
            CheckIsShooting();
        }

        private void FixedUpdate()
        {
            Shooting();
        }

        private void Shooting()
        {
            if (!isShooting) return;

            shootingTimer += Time.fixedDeltaTime;
            if (shootingTimer < shootingDelay) return;
            shootingTimer = 0f;

            var pos = transform.parent.position;
            var rot = transform.parent.rotation;
            var newBullet = BulletSpawner.Instance.Spawn(
                BulletSpawner.BulletOne, pos, rot);
            if (!newBullet) return;
            newBullet.gameObject.SetActive(true);

            Debug.Log(nameof(Shooting));
        }

        private void CheckIsShooting()
        {
            isShooting = InputManager.Instance.IsFiring;
        }
    }
}