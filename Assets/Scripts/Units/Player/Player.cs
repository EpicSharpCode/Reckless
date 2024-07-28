using System.Collections.Generic;
using Reckless.Entities;
using UnityEngine;

namespace Reckless.Units
{
    [RequireComponent(typeof(PlayerInventory), typeof(PlayerBelt), typeof(PlayerMovement))]
    public class Player : Unit
    {
        public override void OnTriggerEnter(Collider other)
        {
            var pickupble = other.gameObject.GetComponent<IPickupable>();
            if (pickupble != null) { pickupble.Pickup(this); }
        }
        public override void InitParameters()
        {
            _parameters = new List<UnitParameter>()
            {
                new("Health", 100, 0, 100), 
                new("Armor", 0)
            };
        }
    }
}
