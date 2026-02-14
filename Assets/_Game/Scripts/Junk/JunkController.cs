using _Game.Scripts.Core;
using _Game.Scripts.Spawner;
using UnityEngine;

namespace _Game.Scripts.Junk
{
    public class JunkController : MyBehaviour
    {
        [SerializeField] private JunkSpawner junkSpawner;
        public JunkSpawner JunkSpawner => junkSpawner;

        protected override void OnLoadComponents()
        {
            base.OnLoadComponents();

            LoadJunkSpawner();
        }

        private void LoadJunkSpawner()
        {
            if (junkSpawner) return;
            junkSpawner = GetComponent<JunkSpawner>();
            Debug.Log(transform.name + ": " + nameof(LoadJunkSpawner), gameObject);
        }
    }
}