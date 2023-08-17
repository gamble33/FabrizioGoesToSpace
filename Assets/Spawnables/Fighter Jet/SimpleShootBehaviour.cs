using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawnables.Fighter_Jet
{
    public class SimpleShootBehaviour : MonoBehaviour
    {
        [SerializeField] private float fireRate;
        [SerializeField] private float fireIntervalVariation;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bullet;

        private float _timeSinceLastShot;
        private float _shotInterval;

        private void Awake()
        {
            _shotInterval = 1f / fireRate;
        }

        private void Update()
        {
            if (_timeSinceLastShot > _shotInterval)
            {
                Fire();
                _timeSinceLastShot = 0;
                _shotInterval = 1f / fireRate + Random.Range(-fireIntervalVariation, fireIntervalVariation);
            }
            _timeSinceLastShot += Time.deltaTime;
        }

        private void Fire()
        {
            Instantiate(bullet, firePoint.position, Quaternion.identity);
        }
    }
}
