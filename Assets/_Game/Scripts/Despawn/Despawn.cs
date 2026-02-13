using _Game.Scripts.Core;
using UnityEngine;

namespace _Game.Scripts.Despawn
{
    public abstract class Despawn : MyBehaviour
    {
        private void FixedUpdate()
        {
            Despawning();
        }

        protected virtual void Despawning()
        {
            if (!CanDespawn()) return;
            DespawnObject();
        }

        protected abstract bool CanDespawn();

        protected virtual void DespawnObject()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}