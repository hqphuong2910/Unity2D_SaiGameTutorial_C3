using System.Collections.Generic;
using _Game.Scripts.Core;
using UnityEngine;

namespace _Game.Scripts.Spawner
{
    public abstract class SpawnPoints : MyBehaviour
    {
        [SerializeField] private List<Transform> points;

        protected override void OnLoadComponents()
        {
            base.OnLoadComponents();

            LoadPoints();
        }

        protected virtual void LoadPoints()
        {
            if (points.Count > 0) return;
            foreach (Transform child in transform) points.Add(child);

            Debug.Log(transform.name + ": " + nameof(LoadPoints), gameObject);
        }

        public virtual Transform GetRandomPoint()
        {
            var pointIndex = Random.Range(0, points.Count);
            return points[pointIndex];
        }
    }
}