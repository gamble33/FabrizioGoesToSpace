using Fabrizio.InstantiatedWeapons;
using Fabrizio.Player;
using Fabrizio.Spawning;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Fabrizio.Spawnables.Fighter_Jet
{
    public class SimpleShootBehaviour : MonoBehaviour, ISpawner, IPlayerInjector
    {
        [SerializeField] private float fireRate;
        [SerializeField] private float fireIntervalVariation;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bullet;
        [SerializeField] private float bulletSpeed;

        private float _timeSinceLastShot;
        private float _shotInterval;
        private SpawnBehaviour _spawnBehaviour;
        private PlayerBehaviour _player;

        public void InjectSpawnBehaviour(SpawnBehaviour spawnBehaviour)
        {
            _spawnBehaviour = spawnBehaviour;
        }

        public void InjectPlayerBehaviour(PlayerBehaviour player)
        {
            _player = player;
        }


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
            GameObject bulletObj = Instantiate(bullet, firePoint.position, Quaternion.identity);
            bulletObj.GetComponent<BulletBehaviour>().Init(Vector2.left * bulletSpeed, gameObject);
            _spawnBehaviour.despawnBehaviour.AddEntity(bulletObj.transform);
            
        }
    }
}