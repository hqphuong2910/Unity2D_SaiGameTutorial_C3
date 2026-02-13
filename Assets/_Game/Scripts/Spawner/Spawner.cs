using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> prefabs;

        private void Reset()
        {
            LoadComponents();
        }

        private void LoadComponents()
        {
            LoadPrefabs();
        }

        private void LoadPrefabs()
        {
            var prefabObj = transform.Find("Prefabs");
            foreach (Transform prefab in prefabObj)
            {
                prefabs.Add(prefab);
                prefab.gameObject.SetActive(false);
            }

            Debug.Log(transform.name + ": " + nameof(LoadPrefabs), gameObject);
        }
    }
}