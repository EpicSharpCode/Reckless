using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public abstract class RL_NPC_Ability : MonoBehaviour, RL_NPC_IAbility
    {
        #region MonoBehavior
        
        public virtual void PerformStart(RL_NPC _npc) { }
        public virtual void PerformUpdate(RL_NPC _npc)
        {
            switch (_npc.NPCState)
            {
                case RL_NPC.NPC_State.Idle :
                {
                    Idle();
                    break;
                }
                case RL_NPC.NPC_State.Patrolling :
                {
                    Patrolling();
                    break;
                }
                case RL_NPC.NPC_State.Pursuit :
                {
                    Pursuit();
                    break;
                }
                case RL_NPC.NPC_State.Attack :
                {
                    Attack();
                    break;
                }
                case RL_NPC.NPC_State.AttackAndPursuit:
                {
                    AttackAndPursuit();
                    break;
                }
                case RL_NPC.NPC_State.Defence :
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