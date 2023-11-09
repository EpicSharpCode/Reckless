using Reckless.Environment;
using Reckless.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit
{
    public class RL_Unit : MonoBehaviour
    {
        public static RL_Unit instance { get; private set; }

        [Header("Health")]
        [SerializeField] float maxHealth = 100;
        [SerializeField] float health = 0;
        [Header("Armor")]
        [SerializeField] float maxArmor = 100;
        [SerializeField] float armor = 0;

        private void Awake() => instance = this;

        void Start()
        {
            health = maxHealth / 2;
            RL_UI_HealthSlider.UpdateHealth();
        }


        public virtual void OnTriggerEnter(Collider other) { }

        public bool AddHealth(float amount)
        {
            if (health == maxHealth) { return false; }
            if (maxHealth < health + amount) { health = maxHealth; return true; }
            health += amount;
            RL_UI_HealthSlider.UpdateHealth();
            return true;
        }
        public bool AddArmor(float amount)
        {
            if (armor == maxArmor) { return false; }
            if (maxArmor < armor + amount) { armor = maxArmor; return true; }
            armor += amount;
            return true;
        }

        public bool ReduceHealth(float amount)
        {
            if (health == 0) { Destroy(gameObject); return false; }
            health -= amount;
            if (health < 0) { health = 0; return true; }

            if (this is RL_Player) RL_UI_HealthSlider.UpdateHealth();
            return true;
        }

        public static float GetHealth() => instance.health;
        public static float GetMaxHealth() => instance.maxHealth;
        public static float GetArmor() => instance.armor;
        public static float GetMaxArmor() => instance.maxArmor;
    }
}
