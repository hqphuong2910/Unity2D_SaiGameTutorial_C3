using _Game.Scripts.Core;

namespace _Game.Scripts.Despawn
{
    public abstract class Despawn : MyBehaviour
    {
        protected virtual void FixedUpdate()
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