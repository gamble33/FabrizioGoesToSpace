using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawnables.Fighter_Jet
{
    public class SimpleMoveBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }

    }
}