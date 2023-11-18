using Reckless.Environment;
using Reckless.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit
{
    public class RL_Unit : MonoBehaviour
    {
        [SerializeField] RL_Unit_BehaviorPattern behaviorPattern;

        [SerializeField] RL_Unit_Parameter health;
        [SerializeField] RL_Unit_Parameter armor;

        private void Awake()
        {
            health = new RL_Unit_Parameter("Health", 100);
            armor = new RL_Unit_Parameter("Armor", 100);
        }


        public virtual void OnTriggerEnter(Collider other) { }

        public RL_Unit_Parameter GetHealth() => health;
        public RL_Unit_Parameter GetArmor() => armor;

        public void Damage(float _amount)
        {
            while (_amount > 0)
            {
                if(health.GetValue() == 0) return;
                var affectArmor = armor.ReduceValue(_amount);
                if (affectArmor > 0) _amount -= affectArmor;
                if (affectArmor == 0)
                {
                    var affectHealth = health.ReduceValue(_amount);
                    if (affectHealth > 0) _amount -= affectHealth;
                }
                if(_amount <= 0.001f ) {break;}
            }
        }
    }
}
