using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerBehaviour : EntityBehaviour
    {
        public UnityEvent<float> onTakeDamage = new();
        
        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);
            onTakeDamage.Invoke(Health);
        }
    }
}