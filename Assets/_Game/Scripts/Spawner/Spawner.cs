using System.Collections.Generic;
using _Game.Scripts.Core;
using UnityEngine;

namespace _Game.Scripts.Spawner
{
    public class Spawner : MyBehaviour
    {
        [SerializeField] private List<Transform> prefabs;

        public static Spawner Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            Instance = this;
        }

        protected override void OnLoadComponents()
        {
            base.OnLoadComponents();

            LoadPrefabs();
        }

        private void LoadPrefabs()
        {
            if (prefabs.Count > 0) return;

            var prefabObj = transform.Find("Prefabs");
            foreach (Transform prefab in prefabObj)
            {
                prefabs.Add(prefab);
                prefab.gameObject.SetActive(false);
            }

            Debug.Log(transform.name + ": " + nameof(LoadPrefabs), gameObject);
        }

        public virtual Transform Spawn(Vector3 pos, Quaternion rot)
        {
            var prefab = prefabs[0];
            var newPrefab = Instantiate(prefab, pos, rot);
            return newPrefab;
        }
    }
}