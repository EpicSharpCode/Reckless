using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Units.AI
{
    public abstract class NpcAbility : MonoBehaviour, IAbilityNpc
    {
        protected int _patrollingIndex = 0;
        
        #region MonoBehavior
        
        public virtual void PerformStart(Npc npc) { }
        public virtual void PerformUpdate(Npc npc)
        {
            switch (npc.npcState)
            {
                case Npc.NpcState.Idle :
                {
                    Idle();
                    break;
                }
                case Npc.NpcState.Patrolling :
                {
                    Patrolling();
                    break;
                }
                case Npc.NpcState.Pursuit :
                {
                    Pursuit();
                    break;
                }
                case Npc.NpcState.Attack :
                {
                    Attack();
                    break;
                }
                case Npc.NpcState.AttackAndPursuit:
                {
                    AttackAndPursuit();
                    break;
                }
                case Npc.NpcState.Defence :
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