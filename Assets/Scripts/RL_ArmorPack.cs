using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Environment
{
    public class RL_ArmorPack : MonoBehaviour, RL_IPickupable
    {
        [SerializeField] float armorPoints = 10;
        [SerializeField] private bool onlyForPlayer = true;
        public void Pickup(RL_Unit unit)
        {
            if(onlyForPlayer) { if(unit is RL_Player == false) return; }
            float addedValue = unit.GetHealth().AddValue(armorPoints);
            if(addedValue > 0) Destroy(gameObject);
        }
    }
}
