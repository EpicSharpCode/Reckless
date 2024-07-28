using Reckless.Entities;
using UnityEngine;

namespace Reckless.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Reckless/Weapon")]
    public class WeaponPreference : ScriptableObject
    {
        [SerializeField] float _fireRate = 0.5f;
        [Header("Damage Settings")]
        [SerializeField] float _damageMin = 1;
        [SerializeField] float _damageMax = 2;
        [SerializeField] float _bulletPower = 2;
        [SerializeField] Bullet _bulletPrefab;
        [SerializeField] WeaponRepresentation _weaponRepresentationPrefab;
        public WeaponRepresentation weaponRepresentationPrefab => _weaponRepresentationPrefab;

        public float fireRate => _fireRate;
        public float damageMin => _damageMin;
        public float damageMax => _damageMax;
        public float bulletPower => _bulletPower * 1000; // Multiply by 1000 for balance
        public Bullet bulletPrefab => _bulletPrefab;

        public WeaponPreference(WeaponPreference wp)
        {
            _fireRate = wp.fireRate;
            _damageMin = wp.damageMin;
            _damageMax = wp.damageMax;
            _bulletPrefab = wp.bulletPrefab;
        }
    }
}
