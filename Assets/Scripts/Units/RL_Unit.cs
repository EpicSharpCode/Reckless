using Reckless.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit
{
    public class RL_Unit : MonoBehaviour
    {
        [NonReorderable] [SerializeField] protected List<RL_Unit_Parameter> parameters;
        public List<RL_Unit_Parameter> Parameters => parameters;

        void Awake() => InitParameters();

        public virtual void InitParameters()
        {
            parameters = new List<RL_Unit_Parameter>()
            {
                new RL_Unit_Parameter("Health", 100), 
                new RL_Unit_Parameter("Armor", 0)
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
