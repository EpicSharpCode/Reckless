using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless 
{
    [System.Serializable]
    public class RL_Unit_Parameter
    {
        [SerializeField] string parameterName;
        [SerializeField] float value;
        [SerializeField] float minValue;
        [SerializeField] float maxValue;

        public RL_Unit_Parameter(string _parameterName, float _value, float _minValue = 0, float _maxValue = 100)
        {
            parameterName = _parameterName;
            value = _value;
            minValue = _minValue;
            maxValue = _maxValue;
        }

        public float AddValue(float _val)
        {
            if(_val < 0) return 0;
            if(value == maxValue) return 0;
            float previousValue = value;
            value += _val;
            if(value > maxValue) {value = maxValue;}
            return value - previousValue;
        }
        
        public float ReduceValue(float _val)
        {
            if(_val < 0) return 0;
            if(value == minValue) return 0;
            float previousValue = value;
            value -= _val;
            if(value < minValue) {value = minValue;}
            return previousValue - value;
        }

        public float GetMax() => maxValue;
        public float GetMin() => minValue;
        public float GetValue() => value;
    }
}
