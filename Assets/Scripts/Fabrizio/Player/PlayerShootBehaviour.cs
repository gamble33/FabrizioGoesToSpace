using Fabrizio.Audio;
using Fabrizio.InstantiatedWeapons;
using Fabrizio.Spawning;
using UnityEngine;

namespace Fabrizio.Player
{
    public class PlayerShootBehaviour : MonoBehaviour
    {
        [SerializeField] private DespawnBehaviour despawnBehaviour;
        [SerializeField] private GameObject bullet;
        [SerializeField] private float fireRate;
        [SerializeField] private float bulletSpeed;

        private float _shotInterval;
        private float _timeSinceLastShot = 0f;

        private void Awake()
        {
            _shotInterval = 1f / fireRate;
            AudioController.Instance.PlayAudio(AudioKind.Ost02);
        }

        void Update()
        {
            _timeSinceLastShot += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.S) &&_timeSinceLastShot > _shotInterval)
            {
                Fire();
                _timeSinceLastShot = 0;
            }
        }

        private void Fire()
        {
            AudioController.Instance.PlayAudio(AudioKind.Sfx01);
            GameObject bulletObj = Instantiate(bullet, transform.position, Quaternion.identity);
            despawnBehaviour.AddEntity(bulletObj.transform);       
            bulletObj.GetComponent<BulletBehaviour>().Init(Vector2.right * bulletSpeed, gameObject);
        
        }
    }
}
