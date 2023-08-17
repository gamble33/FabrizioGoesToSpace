using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
}
