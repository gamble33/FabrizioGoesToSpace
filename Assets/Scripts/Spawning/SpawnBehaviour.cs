using System;
using Spawning;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawning
{
    public class SpawnBehaviour : MonoBehaviour
    {
        [SerializeField] private float spawnFrequency;
        [SerializeField] private float spawnIntervalVariation;
        [SerializeField] private SpawnableAttributes[] spawnableAttributesArray;
        [SerializeField] private new UnityEngine.Camera camera;

        private float _spawnInterval;
        private float _timeSinceLastSpawn = 0f;
        private Vector2 _cameraExtents;

        private void Awake()
        {
            _cameraExtents = new Vector2(
                camera.orthographicSize * Screen.width / Screen.height,
                camera.orthographicSize
            );
        }

        void Update()
        {
            if (_timeSinceLastSpawn > _spawnInterval)
            {
                Spawn();
                _spawnInterval = 1f / spawnFrequency + Random.Range(-spawnIntervalVariation, spawnIntervalVariation);
                _timeSinceLastSpawn = 0f;
            }

            _timeSinceLastSpawn += Time.deltaTime;
        }

        private void Spawn()
        {
            SpawnableAttributes spawnableAttr =
                spawnableAttributesArray[Random.Range(0, spawnableAttributesArray.Length)];
            
            Vector2 spawnPosition = new Vector2(
                camera.transform.position.x + _cameraExtents.x + spawnableAttr.distancePastCamera,
                Random.Range(
                    camera.transform.position.y + _cameraExtents.y + spawnableAttr.rangeAboveCameraView,
                    camera.transform.position.y - _cameraExtents.y - spawnableAttr.rangeAboveCameraView
                    )
            );

            Instantiate(spawnableAttr.prefab, spawnPosition, Quaternion.identity);
        }
    }
}
