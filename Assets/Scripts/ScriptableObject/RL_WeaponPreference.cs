using Reckless.Entities;
using UnityEngine;

namespace Reckless.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Reckless/Weapon")]
    public class RL_WeaponPreference : ScriptableObject
    {
        [SerializeField] float fireRate = 0.5f;
        [Header("Damage Settings")]
        [SerializeField] float damageMin = 1;
        [SerializeField] float damageMax = 2;
        [SerializeField] float bulletPower = 2;
        [SerializeField] RL_Bullet bulletPrefab;

        public float FireRate => fireRate;
        public float DamageMin => damageMin;
        public float DamageMax => damageMax;
        public float BulletPower => bulletPower;
        public RL_Bullet BulletPrefab => bulletPrefab;

        public RL_WeaponPreference(RL_WeaponPreference wp)
        {
            fireRate = wp.FireRate;
            damageMin = wp.DamageMin;
            damageMax = wp.DamageMax;
            bulletPrefab = wp.BulletPrefab;
        }
    }
}
