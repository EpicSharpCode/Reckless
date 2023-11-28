using Reckless.Unit;
using Reckless.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Environment 
{
    public class RL_HealthPack : MonoBehaviour, RL_IPickupable
    {
        [SerializeField] float healthPoints = 10;
        [SerializeField] private bool onlyForPlayer = true;
        public void Pickup(RL_Unit unit)
        {
            if(onlyForPlayer) { if(unit is RL_Player == false) return; }
            float addedValue = unit.Health.AddValue(healthPoints);
            if(addedValue > 0) Destroy(gameObject);
        }
    }
}
