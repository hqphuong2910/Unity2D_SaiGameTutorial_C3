using UnityEngine;

namespace _Game.Scripts.Spawner
{
    public class JunkSpawner : Spawner
    {
        public const string MeteoriteOne = "Meteorite_1";
        public static JunkSpawner Instance { get; private set; }

        protected override void Awake()
        {
            if (Instance && Instance != this)
            {
                Debug.LogError(
                    "Multiple instances of " + nameof(JunkSpawner) + " found in the scene.\n" +
                    "Only one could be exists, fix it.");
                return;
            }

            Instance = this;
        }
    }
}