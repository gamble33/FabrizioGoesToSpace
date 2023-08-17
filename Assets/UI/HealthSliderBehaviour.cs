using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class HealthSliderBehaviour : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private void Awake()
        {
            slider.value = 100f;
        }

        public void UpdateUIOnTakeDamage(float health)
        {
            slider.value = health / 100f;
        }

    }
}