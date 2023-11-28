using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Reckless/Weapon")]
    public class RL_WeaponPreference : ScriptableObject
    {
        [field:SerializeField] public float FireRate { get; private set; } = 0.5f;
        [field:Header("Damage Settings")]
        [field:SerializeField] public float DamageMin { get; private set; } = 1;
        [field:SerializeField] public float DamageMax { get; private set; } = 2;
        [field:SerializeField] public RL_Bullet BulletPrefab { get; private set; }

        public RL_WeaponPreference(RL_WeaponPreference wp)
        {
            FireRate = wp.FireRate;
            DamageMin = wp.DamageMin;
            DamageMax = wp.DamageMax;
            BulletPrefab = wp.BulletPrefab;
        }
    }
}
