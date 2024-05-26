using Reckless.Entities;
using UnityEngine;

namespace Reckless.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Reckless/Weapon")]
    public class RL_WeaponPreference : ScriptableObject
    {
        [SerializeField] float _fireRate = 0.5f;
        [Header("Damage Settings")]
        [SerializeField] float _damageMin = 1;
        [SerializeField] float _damageMax = 2;
        [SerializeField] float _bulletPower = 2;
        [SerializeField] RL_Bullet _bulletPrefab;
        
        [SerializeField] RL_WeaponRepresentation _weaponRepresentationPrefab;
        public RL_WeaponRepresentation WeaponRepresentationPrefab => _weaponRepresentationPrefab;

        public float FireRate => _fireRate;
        public float DamageMin => _damageMin;
        public float DamageMax => _damageMax;
        public float BulletPower => _bulletPower * 1000; // Multiply by 1000 for balance
        public RL_Bullet BulletPrefab => _bulletPrefab;

        public RL_WeaponPreference(RL_WeaponPreference wp)
        {
            _fireRate = wp.FireRate;
            _damageMin = wp.DamageMin;
            _damageMax = wp.DamageMax;
            _bulletPrefab = wp.BulletPrefab;
        }
    }
}
