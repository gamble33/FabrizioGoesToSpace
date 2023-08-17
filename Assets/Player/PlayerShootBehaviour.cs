using System;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bullet;

    private float _shotInterval;
    private float _timeSinceLastShot = 0f;

    private void Awake()
    {
        _shotInterval = 1f / fireRate;
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
        Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 90f));
    }
}
