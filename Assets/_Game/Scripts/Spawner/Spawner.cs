using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Core;
using UnityEngine;

namespace _Game.Scripts.Spawner
{
    public abstract class Spawner : MyBehaviour
    {
        [SerializeField] private List<Transform> prefabs;

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

        public virtual Transform Spawn(string prefabName, Vector3 pos, Quaternion rot)
        {
            var prefab = GetPrefabByName(prefabName);
            if (!prefab)
            {
                Debug.LogWarning("Prefab not found: " + prefabName);
                return null;
            }

            var newPrefab = Instantiate(prefab, pos, rot);
            return newPrefab;
        }

        protected virtual Transform GetPrefabByName(string prefabName)
        {
            return prefabs.FirstOrDefault(prefab => prefab.name == prefabName);
        }
    }
}