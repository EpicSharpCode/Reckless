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
        public static RL_Game_Variables instance { get; private set; }

        [SerializeField] RL_Items_Database itemsDatabase;
        [SerializeField] RL_Weapons_Database weaponsDatabase;
        [SerializeField] RL_GamePrefab_Database gamePrefabDatabase;
        public static RL_GamePrefab_Database GamePrefabDatabase => instance.gamePrefabDatabase;

        [SerializeField] bool hitBoxPopupState = true;
        public static bool HitBoxPopupState => instance.hitBoxPopupState;

        public void Awake()
        {
            instance = this;
        }

        public static RL_ItemObject GetItem(string _ID) => instance.itemsDatabase?.GetItem(_ID);
        public static RL_ItemObject GetItem(int _index) => instance.itemsDatabase?.GetItem(_index);
        public static List<RL_ItemObject> GetAllItems() => instance.itemsDatabase?.GetAllItems();
        public static RL_WeaponObject GetWeapon(string _ID) => instance.weaponsDatabase?.GetWeapon(_ID);
        public static RL_WeaponObject GetWeapon(int _index) => instance.weaponsDatabase?.GetWeapon(_index);
        public static List<RL_WeaponObject> GetAllWeapons() => instance.weaponsDatabase?.GetAllWeapons();
    }
}
