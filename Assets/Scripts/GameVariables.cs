using Reckless.Items;
using System.Collections;
using System.Collections.Generic;
using Reckless.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless
{
    public class GameVariables : MonoBehaviour
    {
        public static GameVariables instance { get; private set; }

        [SerializeField] ItemsDatabase _itemsDatabase;
        [SerializeField] WeaponsDatabase _weaponsDatabase;
        [SerializeField] GamePrefabDatabase _gamePrefabDatabase;
        [SerializeField] UnitTeamDatabase _unitTeamDatabase;
        [SerializeField] bool _hitBoxPopupState = true;
        
        
        public static GamePrefabDatabase gamePrefabDatabase => instance._gamePrefabDatabase;
        public static bool hitBoxPopupState => instance._hitBoxPopupState;

        public void Awake()
        {
            instance = this;
        }

        public static ItemObject GetItem(string id) => instance._itemsDatabase?.GetItem(id);
        public static ItemObject GetItem(int index) => instance._itemsDatabase?.GetItem(index);
        public static List<ItemObject> GetAllItems() => instance._itemsDatabase?.GetAllItems();
        public static WeaponObject GetWeapon(string id) => instance._weaponsDatabase?.GetWeapon(id);
        public static WeaponObject GetWeapon(int index) => instance._weaponsDatabase?.GetWeapon(index);
        public static List<WeaponObject> GetAllWeapons() => instance._weaponsDatabase?.GetAllWeapons();
    }
}
