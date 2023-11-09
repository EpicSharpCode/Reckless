using Reckless.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Items
{
    [System.Serializable]
    public class RL_WeaponObject : RL_ItemObject
    {
        [SerializeField] RL_WeaponPrefrence weaponPrefrence;

        public RL_WeaponObject(RL_WeaponObject _weaponObject) : base(_weaponObject)
        {
            weaponPrefrence = _weaponObject.weaponPrefrence;
        }

        public RL_WeaponPrefrence GetWeaponPrefrence() => weaponPrefrence;
    }
}
