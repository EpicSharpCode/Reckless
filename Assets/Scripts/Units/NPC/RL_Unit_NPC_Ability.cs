using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public abstract class RL_Unit_NPC_Ability : MonoBehaviour
    {
        public virtual void PerformUpdateAction(RL_Unit _thisUnit) {}
    }
}