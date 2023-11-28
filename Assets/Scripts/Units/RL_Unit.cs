using Reckless.Environment;
using Reckless.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit
{
    public class RL_Unit : MonoBehaviour
    {
        [field:SerializeField] public RL_Unit_Parameter Health { get; private set; }
        [field:SerializeField] public RL_Unit_Parameter Armor { get; private set; }

        private void Awake()
        {
            Health = new RL_Unit_Parameter("Health", 100);
            Armor = new RL_Unit_Parameter("Armor", 100);
        }


        public virtual void OnTriggerEnter(Collider other) { }


        public bool CheckDie()
        {
            if(Health.Value == 0) {
                Destroy(gameObject);
                return true;
            }
            return false;
        }
        public bool Damage(float _amount)
        {
            while (_amount > 0)
            {
                if(Health.Value == 0) break;
                var affectArmor = Armor.ReduceValue(_amount);
                if (affectArmor > 0) _amount -= affectArmor;
                if (affectArmor == 0)
                {
                    var affectHealth = Health.ReduceValue(_amount);
                    if (affectHealth > 0) _amount -= affectHealth;
                }
                if(_amount <= 0.001f ) {break;}
            }

            CheckDie();
            return true;
        }
    }
}
