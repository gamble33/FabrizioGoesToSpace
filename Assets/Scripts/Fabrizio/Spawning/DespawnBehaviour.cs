using System.Collections.Generic;
using UnityEngine;

namespace Fabrizio.Spawning
{
    public class DespawnBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float despawnDistance;

        private readonly List<Transform> _entities = new();

        public void AddEntity(Transform entity)
        {
            _entities.Add(entity);
        }

        private void Update()
        {
            List<Transform> entitiesToRemove = new();
            foreach (Transform entity in _entities)
            {
                if (entity == null)
                {
                    entitiesToRemove.Add(entity);
                }
                else if (Vector2.Distance(entity.position, player.position) > despawnDistance)
                {
                    entitiesToRemove.Add(entity);
                }
            }

            foreach (Transform entity in entitiesToRemove)
            {
                _entities.Remove(entity);
                if (entity != null) Destroy(entity.gameObject);
            }
        }
    }
}