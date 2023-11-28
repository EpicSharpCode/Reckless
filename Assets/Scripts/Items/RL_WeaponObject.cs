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
        [field:SerializeField] public RL_WeaponPreference WeaponPrefrence { get; private set; }

        public RL_WeaponObject(RL_WeaponObject _weaponObject) : base(_weaponObject)
        {
            WeaponPrefrence = _weaponObject.WeaponPrefrence;
        }
    }
}
