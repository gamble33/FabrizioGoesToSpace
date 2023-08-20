using InstantiatedWeapons;
using UnityEngine;

public class FighterBulletBehaviour : BulletBehaviour
{
    [SerializeField] private float speed;
    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

}
