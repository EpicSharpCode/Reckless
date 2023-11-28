using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public class RL_Unit_NPC_Ability : ScriptableObject
    {
        [field:SerializeField] public string AbilityName { get; private set; }
        [field:SerializeField] public float AbilityValue { get; private set; }

        public virtual void PerformUpdateAction(RL_Unit _thisUnit) {}
    }
}