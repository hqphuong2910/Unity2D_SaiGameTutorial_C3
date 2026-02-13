using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class ShipShooting : MonoBehaviour
    {
        [SerializeField] private bool isShooting = false;
        [SerializeField] private Transform bulletPrefab;

        private void FixedUpdate()
        {
            Shooting();
        }

        private void Shooting()
        {
            if (!isShooting) return;

            Instantiate(bulletPrefab);

            Debug.Log(nameof(Shooting));
        }
    }
}