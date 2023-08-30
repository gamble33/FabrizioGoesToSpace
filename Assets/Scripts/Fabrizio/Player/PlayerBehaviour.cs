using Fabrizio.Audio;
using Fabrizio.Camera;
using Fabrizio.Entity;
using UnityEngine;
using UnityEngine.Events;

namespace Fabrizio.Player
{
    public class PlayerBehaviour : EntityBehaviour
    {
        public UnityEvent<float> onTakeDamage = new();

        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);
            onTakeDamage.Invoke(Health);
            AudioController.Instance.PlayAudio(AudioKind.SfxDamage);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            float impulse = Utils.Utils.Collision2DImpulse(col);
            AudioController.Instance.PlayAudio(AudioKind.SfxImpact);
            StartCoroutine(UnityEngine.Camera.main.GetComponent<CameraShake>().Shake(0.5f, impulse * 0.25f, 16f));
            if (impulse < 1f) return;
            TakeDamage(impulse * 2);
        }
    }
}