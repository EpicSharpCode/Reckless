using Reckless.Environment;
using Reckless.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit
{
    public class RL_Unit : MonoBehaviour
    {
        [field:SerializeField] public List<RL_Unit_Parameter> Parameters { get; private set; }

        private void Awake()
        {
            Parameters = new List<RL_Unit_Parameter>()
            {
                new RL_Unit_Parameter("Health", 100), 
                new RL_Unit_Parameter("Armor", 100)
            };
        }


        public virtual void OnTriggerEnter(Collider other) { }


        public bool CheckDie()
        {
            if(Parameters[0].Value == 0) {
                Destroy(gameObject);
                return true;
            }
            return false;
        }

        public bool Damage(float _amount)
        {
            if (Parameters[0].Value == 0) return false;
            for (int i = Parameters.Count - 1; i >= 0; i--)
            {
                var affect = Parameters[i].ReduceValue(_amount);
                if (affect > 0)
                {
                    _amount -= affect;
                    if (_amount == 0) return true;
                }
            }
            CheckDie();
            return true;
        }

        public RL_Unit_Parameter GetParameter(string parameterName) =>
            Parameters.Find(x => x.ParameterName == parameterName);
    }
}
