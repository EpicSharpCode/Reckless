using Reckless.Environment;
using Reckless.UI;
using System.Collections;
using System.Collections.Generic;
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
    }
}
