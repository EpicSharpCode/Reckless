using Reckless.Units;
using Reckless.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Entities 
{
    public class ParameterPack : MonoBehaviour, IPickupable
    {
        [SerializeField] float _healthPoints = 10;
        [SerializeField] string _parameterName = "Health";
        [SerializeField] private bool _onlyForPlayer = true;
        public void Pickup(Unit unit)
        {
            if(_onlyForPlayer) { if(unit is Player == false) return; }
            float addedValue = unit.GetParameter(_parameterName)?.AddValue(_healthPoints) ?? 0;
            if(addedValue > 0) Destroy(gameObject);
        }
    }
}