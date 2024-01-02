using Reckless.Unit;
using Reckless.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Entities 
{
    public class RL_ParameterPack : MonoBehaviour, RL_IPickupable
    {
        [SerializeField] float healthPoints = 10;
        [SerializeField] string parameterName = "Health";
        [SerializeField] private bool onlyForPlayer = true;
        public void Pickup(RL_Unit unit)
        {
            if(onlyForPlayer) { if(unit is RL_Player == false) return; }
            float addedValue = unit.GetParameter(parameterName)?.AddValue(healthPoints) ?? 0;
            if(addedValue > 0) Destroy(gameObject);
        }
    }
}