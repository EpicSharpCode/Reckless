using Reckless.Weapon;
using System.Collections;
using System.Collections.Generic;
using Reckless.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Items
{
    [System.Serializable]
    public class WeaponObject : ItemObject
    {
        [SerializeField] WeaponPreference _weaponPrefrence;
        public WeaponPreference weaponPrefrence => _weaponPrefrence;


        public WeaponObject(WeaponObject weaponObject) : base(weaponObject)
        {
            _weaponPrefrence = weaponObject._weaponPrefrence;
        }
    }
}
