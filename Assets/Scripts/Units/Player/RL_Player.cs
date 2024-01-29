using System.Collections.Generic;
using Reckless.Entities;
using UnityEngine;

namespace Reckless.Unit
{
    [RequireComponent(typeof(RL_Player_Inventory), typeof(RL_Player_Belt), typeof(RL_Player_Movement))]
    public class RL_Player : RL_Unit
    {
        public override void OnTriggerEnter(Collider other)
        {
            var pickupble = other.gameObject.GetComponent<RL_IPickupable>();
            if (pickupble != null) { pickupble.Pickup(this); }
        }
        public override void InitParameters()
        {
            
            parameters = new List<RL_Unit_Parameter>()
            {
                new("Health", 1000, 0, 1000), 
                new("Armor", 0)
            };
        }
    }
}
