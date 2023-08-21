using Audio;
using InstantiatedWeapons;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    private float _shotInterval;
    private float _timeSinceLastShot = 0f;

    private void Awake()
    {
        _shotInterval = 1f / fireRate;
        AudioController.Instance.PlayAudio(AudioKind.Ost01);
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
        Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<BulletBehaviour>()
            .Init(Vector2.right * bulletSpeed, gameObject);
        
    }
}
