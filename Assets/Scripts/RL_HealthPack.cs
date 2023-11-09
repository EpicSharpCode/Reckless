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
        public void Pickup(RL_Unit player)
        {
            var status = player.AddHealth(healthPoints);
            if(status) Destroy(gameObject);
        }
    }
}
