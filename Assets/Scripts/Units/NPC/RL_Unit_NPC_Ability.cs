using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public class RL_Unit_NPC_Ability : ScriptableObject
    {
        [SerializeField] string abilityName;
        [SerializeField] float abilityValue;

        public float GetValue() => abilityValue;
        public virtual void PerformUpdateAction(RL_Unit _thisUnit) {}
    }
}