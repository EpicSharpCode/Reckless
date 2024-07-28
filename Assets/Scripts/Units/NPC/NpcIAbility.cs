using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Units.AI
{ 
    public interface IAbilityNpc
    {
        public void PerformStart(Npc npc);
        public void PerformUpdate(Npc npc);
        
        public void Idle();
        public void Patrolling();
        public void Pursuit();
        public void AttackAndPursuit();
        public void Attack();
        public void Defence();
    }
}