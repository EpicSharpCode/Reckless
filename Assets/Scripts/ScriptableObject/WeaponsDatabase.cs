using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Items
{
    [CreateAssetMenu(fileName = "WeaponsDatabase", menuName = "Reckless/WeaponsDatabase")]
    public class WeaponsDatabase : ScriptableObject
    {
        [SerializeField] List<WeaponObject> _weapons;

        public WeaponObject GetWeapon(string id) => new(_weapons.Find(x => x._itemID == id));
        public WeaponObject GetWeapon(int index) => new(_weapons[index]);
        public List<WeaponObject> GetAllWeapons() => _weapons;
    }
}
