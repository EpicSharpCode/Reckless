using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Hotline/Weapon")]
    public class RL_WeaponPrefrence : ScriptableObject
    {
        [SerializeField] float fireRate = 0.5f;
        [Header("Damage Settings")]
        [SerializeField] float damageMin = 1;
        [SerializeField] float damageMax = 2;
        [SerializeField] RL_Bullet bulletPrefab;

        public RL_WeaponPrefrence(RL_WeaponPrefrence wp)
        {
            fireRate = wp.fireRate;
        }

        public float GetFireRate() => fireRate;
        public RL_Bullet GetBulletPrefab() => bulletPrefab;

        public float GetDamageMin() => damageMin;
        public float GetDamageMax() => damageMax;
    }
}
