using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Items
{
    [CreateAssetMenu(fileName = "WeaponsDatabase", menuName = "Reckless/WeaponsDatabase")]
    public class RL_Weapons_Database : ScriptableObject
    {
        [SerializeField] List<RL_WeaponObject> weapons;

        public RL_WeaponObject GetWeapon(string _ID) => weapons.Find(x => x.itemID == _ID);
    }
}
