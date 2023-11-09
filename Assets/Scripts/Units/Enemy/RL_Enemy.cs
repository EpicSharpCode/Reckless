using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit
{
    public class RL_Enemy : RL_Unit
    {
        [Header("Enemy Settings")]
        [SerializeField] RL_Unit goal;

        public RL_Unit GetGoal() => goal;
    }
}
