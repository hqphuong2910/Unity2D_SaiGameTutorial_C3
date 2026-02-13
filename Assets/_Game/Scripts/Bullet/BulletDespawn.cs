using _Game.Scripts.Despawn;
using _Game.Scripts.Spawner;

namespace _Game.Scripts.Bullet
{
    public class BulletDespawn : DespawnByDistance
    {
        protected override void DespawnObject()
        {
            BulletSpawner.Instance.Despawn(transform.parent);
        }
    }
}