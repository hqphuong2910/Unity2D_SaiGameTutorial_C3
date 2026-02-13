using System;
using _Game.Scripts.Core;
using UnityEngine;

namespace _Game.Scripts.Ship
{
    public class ShipShooting : MonoBehaviour
    {
        [SerializeField] private bool isShooting;
        [SerializeField] private Transform bulletPrefab;

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