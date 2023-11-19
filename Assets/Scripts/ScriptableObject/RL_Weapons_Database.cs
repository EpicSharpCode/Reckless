using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Items
{
    [CreateAssetMenu(fileName = "WeaponsDatabase", menuName = "Reckless/WeaponsDatabase")]
    public class RL_Weapons_Database : ScriptableObject
    {
        [SerializeField] List<RL_WeaponObject> weapons;

        public RL_WeaponObject GetWeapon(string _name) => weapons.Find(x => x.GetName() == _name);
    }
}
