using Reckless.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Items
{
    [System.Serializable]
    public class RL_WeaponObject : RL_ItemObject
    {
        [SerializeField] RL_WeaponPreference weaponPrefrence;
        public RL_WeaponPreference WeaponPrefrence => weaponPrefrence;

        public RL_WeaponObject(RL_WeaponObject _weaponObject) : base(_weaponObject)
        {
            weaponPrefrence = _weaponObject.weaponPrefrence;
        }
    }
}
