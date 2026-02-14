using _Game.Scripts.Core;
using _Game.Scripts.Spawner;
using UnityEngine;

namespace _Game.Scripts.Junk
{
    public class JunkRandom : MyBehaviour
    {
        [SerializeField] private JunkController junkController;

        protected override void Start()
        {
            JunkSpawning();
        }

        protected override void OnLoadComponents()
        {
            base.OnLoadComponents();

            LoadJunkController();
        }

        private void LoadJunkController()
        {
            if (junkController) return;
            junkController = GetComponent<JunkController>();
            Debug.Log(transform.name + ": " + nameof(LoadJunkController), gameObject);
        }

        private void JunkSpawning()
        {
            var randomPoint = junkController.SpawnPoints.GetRandomPoint();
            var spawnPos = randomPoint.position;
            var rot = transform.rotation;
            var junk = junkController.JunkSpawner.Spawn(JunkSpawner.MeteoriteOne, spawnPos, rot);
            junk.gameObject.SetActive(true);
            Invoke(nameof(JunkSpawning), 1f);
        }
    }
}