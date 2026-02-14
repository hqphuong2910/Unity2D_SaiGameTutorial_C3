using _Game.Scripts.Core;
using UnityEngine;

namespace _Game.Scripts
{
    public class ParentFly : MyBehaviour
    {
        [SerializeField] protected Vector3 direction = Vector3.right;
        [SerializeField] protected float flySpeed = 1f;

        protected virtual void Update()
        {
            transform.parent.Translate(direction * (flySpeed * Time.deltaTime));
        }
    }
}