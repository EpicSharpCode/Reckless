using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless 
{
    [System.Serializable]
    public class UnitParameter
    {
        [SerializeField] string _parameterName;
        [SerializeField] float _value;
        [SerializeField] float _minValue;
        [SerializeField] float _maxValue;

        public string parameterName => _parameterName;
        public float value => _value;
        public float minValue => _minValue;
        public float maxValue => _maxValue;

        public UnitParameter(string parameterName, float value, float minValue = 0, float maxValue = 100)
        {
            _parameterName = parameterName;
            _value = value;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public float AddValue(float val)
        {
            if(val < 0) return 0;
            if(_value == _maxValue) return 0;
            float previousValue = _value;
            _value += val;
            if(_value > _maxValue) {_value = _maxValue;}
            return _value - previousValue;
        }
        
        public float ReduceValue(float val)
        {
            if(val < 0) return 0;
            if(_value == _minValue) return 0;
            float previousValue = _value;
            _value -= val;
            if(_value < _minValue) {_value = _minValue;}
            return previousValue - _value;
        }

    }
}
