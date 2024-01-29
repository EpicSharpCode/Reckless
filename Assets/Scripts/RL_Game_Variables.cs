using Reckless.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless
{
    public class RL_Game_Variables : MonoBehaviour
    {
        public static RL_Game_Variables instance { get; private set; }

        [SerializeField] RL_Items_Database itemsDatabase;
        [SerializeField] RL_Weapons_Database weaponsDatabase;
        [FormerlySerializedAs("bulletPower")]
        [SerializeField] float defaultBulletPower = 2000;

        public static float DefaultBulletPower => instance.defaultBulletPower;

        public void Awake()
        {
            instance = this;
        }

        public static RL_ItemObject GetItem(string _ID) => instance.itemsDatabase.GetItem(_ID);
        public static RL_WeaponObject GetWeapon(string _ID) => instance.weaponsDatabase.GetWeapon(_ID);
    }
}
