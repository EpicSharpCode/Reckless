using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{ 
    public interface RL_Unit_NPC_IAbility
    {
        public void PerformStart(RL_Unit_NPC _npc);
        public void PerformUpdate(RL_Unit_NPC _npc);
        
        public void Idle();
        public void Patrolling();
        public void Pursuit();
        public void AttackAndPursuit();
        public void Attack();
        public void Defence();
    }
}