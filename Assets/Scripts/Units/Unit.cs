using Reckless.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Units
{
    public class Unit : MonoBehaviour
    {
        [NonReorderable] [SerializeField] protected List<UnitParameter> _parameters;
        public List<UnitParameter> parameters => _parameters;

        void Awake() => InitParameters();

        public virtual void InitParameters()
        {
            _parameters = new List<UnitParameter>()
            {
                new ("Health", 100), 
                new ("Armor", 0)
            };
        }


        public virtual void OnTriggerEnter(Collider other) { }


        public bool CheckDie()
        {
            if(parameters[0].value == 0) {
                Destroy(gameObject);
                return true;
            }
            return false;
        }

        public bool Damage(float amount)
        {
            if (parameters[0].value == 0) return false;
            for (int i = parameters.Count - 1; i >= 0; i--)
            {
                var affect = parameters[i].ReduceValue(amount);
                if (affect > 0)
                {
                    amount -= affect;
                    if (amount == 0) return true;
                }
            }
            CheckDie();
            return true;
        }

        public UnitParameter GetParameter(string parameterName) =>
            parameters.Find(x => x.parameterName == parameterName);
    }
}
