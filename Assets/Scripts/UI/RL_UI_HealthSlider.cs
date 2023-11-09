using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reckless.UI
{
    public class RL_UI_HealthSlider : MonoBehaviour
    {
        public static RL_UI_HealthSlider instance { get;private set; }
        Slider healthSlider;

        private void Awake()
        {
            instance = this;
            healthSlider = GetComponent<Slider>();
        }

        public static void UpdateHealth()
        {
            instance.healthSlider.value = RL_Player.GetHealth() / RL_Player.GetMaxHealth();
        }
    }
}
