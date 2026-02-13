using UnityEngine;

namespace _Game.Scripts.Spawner
{
    public class BulletSpawner : Spawner
    {
        public const string BulletOne = "Bullet_1";
        public static BulletSpawner Instance { get; private set; }

        protected override void Awake()
        {
            if (Instance && Instance != this)
            {
                Debug.LogError(
                    "Multiple instances of " + nameof(BulletSpawner) + " found in the scene.\n" +
                    "Only one could be exists, fix it.");
                return;
            }

            Instance = this;
        }
    }
}