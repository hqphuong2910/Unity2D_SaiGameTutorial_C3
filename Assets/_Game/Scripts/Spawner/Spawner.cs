using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Core;
using UnityEngine;

namespace _Game.Scripts.Spawner
{
    public abstract class Spawner : MyBehaviour
    {
        [SerializeField] protected List<Transform> prefabs;

        [SerializeField] protected List<Transform> objectPool;

        [SerializeField] protected Transform holder;

        protected override void OnLoadComponents()
        {
            base.OnLoadComponents();

            LoadPrefabs();
            LoadHolder();
        }

        protected virtual void LoadPrefabs()
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

        protected virtual void LoadHolder()
        {
            if (holder) return;
            holder = transform.Find("Holder");
            Debug.Log(transform.name + ": " + nameof(LoadHolder), gameObject);
        }

        public virtual Transform Spawn(string prefabName, Vector3 pos, Quaternion rot)
        {
            var prefab = GetPrefabByName(prefabName);
            if (!prefab)
            {
                Debug.LogWarning("Prefab not found: " + prefabName);
                return null;
            }

            var newPrefab = GetObjectFromPool(prefab);
            newPrefab.SetPositionAndRotation(pos, rot);
            newPrefab.parent = holder;
            return newPrefab;
        }

        protected virtual Transform GetPrefabByName(string prefabName)
        {
            return prefabs.FirstOrDefault(prefab => prefab.name == prefabName);
        }

        protected virtual Transform GetObjectFromPool(Transform prefab)
        {
            foreach (var obj in objectPool.Where(obj => obj.name == prefab.name))
            {
                objectPool.Remove(obj);
                return obj;
            }

            var newPrefab = Instantiate(prefab);
            newPrefab.name = prefab.name;
            return newPrefab;
        }

        public virtual void Despawn(Transform obj)
        {
            obj.gameObject.SetActive(false);
            objectPool.Add(obj);
        }
    }
}