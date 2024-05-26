using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Entities
{
    public class RL_WeaponRepresentation : MonoBehaviour
    {
        [SerializeField] Transform _shootSource;
        public Transform ShootSource => _shootSource;
        
    }
}
