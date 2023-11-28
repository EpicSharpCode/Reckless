using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless 
{
    [System.Serializable]
    public class RL_Unit_Parameter
    {
        [SerializeField] string parameterName;
        [field:SerializeField] public float Value { get; private set; }
        [field:SerializeField] public float MinValue { get; private set; }
        [field:SerializeField] public float MaxValue { get; private set; }

        public RL_Unit_Parameter(string _parameterName, float _value, float _minValue = 0, float _maxValue = 100)
        {
            parameterName = _parameterName;
            Value = _value;
            MinValue = _minValue;
            MaxValue = _maxValue;
        }

        public float AddValue(float _val)
        {
            if(_val < 0) return 0;
            if(Value == MaxValue) return 0;
            float previousValue = Value;
            Value += _val;
            if(Value > MaxValue) {Value = MaxValue;}
            return Value - previousValue;
        }
        
        public float ReduceValue(float _val)
        {
            if(_val < 0) return 0;
            if(Value == MinValue) return 0;
            float previousValue = Value;
            Value -= _val;
            if(Value < MinValue) {Value = MinValue;}
            return previousValue - Value;
        }

    }
}
