using Reckless.Items;
using System.Collections;
using System.Collections.Generic;
using Reckless.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless
{
    public class RL_Game_Variables : MonoBehaviour
    {
        public static RL_Game_Variables _instance { get; private set; }

        [SerializeField] RL_Items_Database _itemsDatabase;
        [SerializeField] RL_Weapons_Database _weaponsDatabase;
        [SerializeField] RL_GamePrefab_Database _gamePrefabDatabase;
        [SerializeField] RL_Unit_TeamDatabase _unitTeamDatabase;
        public static RL_GamePrefab_Database GamePrefabDatabase => _instance._gamePrefabDatabase;

        [SerializeField] bool _hitBoxPopupState = true;
        public static bool HitBoxPopupState => _instance._hitBoxPopupState;

        public void Awake()
        {
            _instance = this;
        }

        public static RL_ItemObject GetItem(string _ID) => _instance._itemsDatabase?.GetItem(_ID);
        public static RL_ItemObject GetItem(int _index) => _instance._itemsDatabase?.GetItem(_index);
        public static List<RL_ItemObject> GetAllItems() => _instance._itemsDatabase?.GetAllItems();
        public static RL_WeaponObject GetWeapon(string _ID) => _instance._weaponsDatabase?.GetWeapon(_ID);
        public static RL_WeaponObject GetWeapon(int _index) => _instance._weaponsDatabase?.GetWeapon(_index);
        public static List<RL_WeaponObject> GetAllWeapons() => _instance._weaponsDatabase?.GetAllWeapons();
    }
}
