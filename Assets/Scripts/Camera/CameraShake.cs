﻿using System.Collections;
using UnityEngine;

namespace Camera
{
    public class CameraShake : MonoBehaviour
    {
        public IEnumerator Shake(float duration, float magnitude, float speed)
        {
            Vector3 originalPosition = transform.localPosition;
            
            float elapsed = 0f;

            float seed = Random.Range(-50f, 50f);
            float sign = seed > 0 ? -1 : 1f;

            while (elapsed < duration)
            {
                // Vector3 displacement = new Vector3(
                //     (Mathf.PerlinNoise1D(elapsed * speed + seed) * 2f - 1f),
                //     (Mathf.PerlinNoise1D(elapsed * speed + seed) * 2f - 1f) * -1,
                //     0f
                // );

                Vector3 displacement = new Vector3(
                    sign * Mathf.Cos(elapsed * speed),
                    -sign * Mathf.Cos(elapsed * speed),
                    0f
                );

                displacement *= Damping(elapsed, magnitude, duration);
                displacement.z = originalPosition.z;
                

                transform.localPosition = originalPosition + displacement;

                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPosition;
        }

        private float Damping(float t, float m, float d)
        {
            // - (t * (m * m / d))^(0.5) + m
            return -Mathf.Pow(t * (m * m / d), 0.5f) + m;
        }
    }
}