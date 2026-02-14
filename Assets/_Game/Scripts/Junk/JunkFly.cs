using _Game.Scripts.Core;
using UnityEngine;

namespace _Game.Scripts.Junk
{
    public class JunkFly : ParentFly
    {
        [SerializeField] private float minCamPos = -15f;
        [SerializeField] private float maxCamPos = 15f;

        protected override void OnEnable()
        {
            base.OnEnable();

            GetFlyDirection();
        }

        private void GetFlyDirection()
        {
            var camPos = GameController.Instance.MainCamera.transform.position;
            camPos.x += Random.Range(minCamPos, maxCamPos);

            var objPos = transform.parent.position;

            var diff = camPos - objPos;
            diff.Normalize();
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rotZ);

            Debug.DrawLine(objPos, objPos + diff * 7f, Color.red, Mathf.Infinity);
        }
    }
}