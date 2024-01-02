using Reckless.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless
{
    public class RL_GlobalVariables : MonoBehaviour
    {
        public static RL_GlobalVariables instance { get; private set; }

        [SerializeField] RL_Items_Database itemsDatabase;
        [SerializeField] RL_Weapons_Database weaponsDatabase;

        public void Awake()
        {
            instance = this;
        }

        public static RL_ItemObject GetItem(string _ID) => instance.itemsDatabase.GetItem(_ID);
        public static RL_WeaponObject GetWeapon(string _ID) => instance.weaponsDatabase.GetWeapon(_ID);
    }
}
