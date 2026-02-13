using System;
using _Game.Scripts.Core;
using UnityEngine;

namespace _Game.Scripts.Ship
{
    public class ShipShooting : MonoBehaviour
    {
        [SerializeField] private Transform bulletPrefab;

        [SerializeField] private bool isShooting;

        [SerializeField] private float shootingDelay = 1f;
        [SerializeField] private float shootingTimer = 0f;

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

            var spawnPos = transform.parent.position;
            var spawnRot = transform.parent.rotation;
            Instantiate(bulletPrefab, spawnPos, spawnRot);

            Debug.Log(nameof(Shooting));
        }

        private void CheckIsShooting()
        {
            isShooting = InputManager.Instance.IsFiring;
        }
    }
}