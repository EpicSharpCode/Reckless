using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Entities
{
    public class WeaponRepresentation : MonoBehaviour
    {
        [SerializeField] Transform _shootSource;
        public Transform shootSource => _shootSource;
        
    }
}
