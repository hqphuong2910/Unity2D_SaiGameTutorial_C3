using _Game.Scripts.Core;
using _Game.Scripts.Spawner;
using UnityEngine;

namespace _Game.Scripts.Junk
{
    public class JunkController : MyBehaviour
    {
        [SerializeField] private JunkSpawner junkSpawner;
        [SerializeField] private SpawnPoints spawnPoints;
        public JunkSpawner JunkSpawner => junkSpawner;
        public SpawnPoints SpawnPoints => spawnPoints;

        protected override void OnLoadComponents()
        {
            base.OnLoadComponents();

            LoadJunkSpawner();
            LoadSpawnPoints();
        }

        private void LoadJunkSpawner()
        {
            if (junkSpawner) return;
            junkSpawner = GetComponent<JunkSpawner>();
            Debug.Log(transform.name + ": " + nameof(LoadJunkSpawner), gameObject);
        }

        private void LoadSpawnPoints()
        {
            if (spawnPoints) return;
            spawnPoints = FindObjectOfType<SpawnPoints>();
            Debug.Log(transform.name + ": " + nameof(LoadSpawnPoints), gameObject);
        }
    }
}