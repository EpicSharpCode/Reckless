using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Units.AI
{ 
    public interface INpcAbility
    {
        public void PerformStart(Npc npc);
        public void PerformUpdate(Npc npc);
        
        public void IdleState();
        public void PatrollingState();
        public void PursuitState();
        public void AttackAndPursuitState();
        public void AttackState();
        public void DefenceState();
    }
}