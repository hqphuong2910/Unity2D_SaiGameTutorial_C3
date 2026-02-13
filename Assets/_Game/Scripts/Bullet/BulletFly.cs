using UnityEngine;

namespace _Game.Scripts.Bullet
{
    public class BulletFly : MonoBehaviour
    {
        [SerializeField] private Vector3 direction = Vector3.right;
        [SerializeField] private float bulletSpeed = 10f;

        private void Update()
        {
            transform.parent.Translate(direction * (bulletSpeed * Time.deltaTime));
        }
    }
}