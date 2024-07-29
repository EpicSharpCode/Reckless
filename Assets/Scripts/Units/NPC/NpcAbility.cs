using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Units.AI
{
    public abstract class NpcAbility : MonoBehaviour, INpcAbility
    {
        protected int _patrollingIndex = 0;
        
        #region MonoBehavior
        
        public virtual void PerformStart(Npc npc) { }
        public virtual void PerformUpdate(Npc npc)
        {
            switch (npc.npcState)
            {
                case NpcState.Idle :
                {
                    Idle();
                    break;
                }
                case NpcState.Patrolling :
                {
                    Patrolling();
                    break;
                }
                case NpcState.Pursuit :
                {
                    Pursuit();
                    break;
                }
                case NpcState.Attack :
                {
                    Attack();
                    break;
                }
                case NpcState.AttackAndPursuit:
                {
                    AttackAndPursuit();
                    break;
                }
                case NpcState.Defence :
                {
                    Defence();
                    break;
                }
            }
        }

        #endregion

        #region Ability state methods
        
        public virtual void Idle() { }
        public virtual void Patrolling() { }
        public virtual void Pursuit() { }
        public virtual void Attack() { }
        public virtual void AttackAndPursuit() { }
        public virtual void Defence() { }
        
        #endregion
    }
}