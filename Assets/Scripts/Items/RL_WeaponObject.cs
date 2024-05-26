using Reckless.Weapon;
using System.Collections;
using System.Collections.Generic;
using Reckless.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Items
{
    [System.Serializable]
    public class RL_WeaponObject : RL_ItemObject
    {
        [SerializeField] RL_WeaponPreference _weaponPrefrence;
        public RL_WeaponPreference WeaponPrefrence => _weaponPrefrence;


        public RL_WeaponObject(RL_WeaponObject _weaponObject) : base(_weaponObject)
        {
            _weaponPrefrence = _weaponObject._weaponPrefrence;
        }
    }
}
