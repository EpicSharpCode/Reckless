using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public abstract class RL_Unit_NPC_Ability : MonoBehaviour, RL_Unit_NPC_IAbility
    {
        #region MonoBehavior

        
        public virtual void PerformStart(RL_Unit_NPC _npc) { }
        public virtual void PerformUpdate(RL_Unit_NPC _npc)
        {
            switch (_npc.NPCState)
            {
                case RL_Unit_NPC.NPC_State.Idle :
                {
                    Idle();
                    break;
                }
                case RL_Unit_NPC.NPC_State.Patrolling :
                {
                    Patrolling();
                    break;
                }
                case RL_Unit_NPC.NPC_State.Pursuit :
                {
                    Pursuit();
                    break;
                }
                case RL_Unit_NPC.NPC_State.Attack :
                {
                    Attack();
                    break;
                }
                case RL_Unit_NPC.NPC_State.Defence :
                {
                    Defence();
                    break;
                }
            }
        }

        #endregion
        
        public virtual void Idle() { }
        public virtual void Patrolling() { }
        public virtual void Pursuit() { }
        public virtual void Attack() { }
        public virtual void Defence() { }
    }
}