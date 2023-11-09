using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Environment
{
    public class RL_ArmorPack : MonoBehaviour, RL_IPickupable
    {
        [SerializeField] float armorPoints = 10;
        public void Pickup(RL_Unit player)
        {
            var status = player.AddArmor(armorPoints);
            if (status) { Destroy(gameObject); }
        }
    }
}
