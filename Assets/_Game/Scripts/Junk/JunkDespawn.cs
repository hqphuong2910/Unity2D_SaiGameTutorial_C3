using _Game.Scripts.Despawn;
using _Game.Scripts.Spawner;

namespace _Game.Scripts.Junk
{
    public class JunkDespawn : DespawnByDistance
    {
        protected override void DespawnObject()
        {
            JunkSpawner.Instance.Despawn(transform.parent);
        }

        protected override void ResetValue()
        {
            base.ResetValue();

            distanceLimit = 25f;
        }
    }
}