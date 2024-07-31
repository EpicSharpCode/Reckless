using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Units.AI
{
    public abstract class NpcAbility : MonoBehaviour, INpcAbility
    {
        protected int _patrollingIndex = 0;
        
        
        public virtual void PerformStart(Npc npc) { }
        public virtual void PerformUpdate(Npc npc)
        {
            switch (npc.npcState)
            {
                case NpcState.Idle :
                {
                    IdleState();
                    break;
                }
                case NpcState.Patrolling :
                {
                    PatrollingState();
                    break;
                }
                case NpcState.Pursuit :
                {
                    PursuitState();
                    break;
                }
                case NpcState.Attack :
                {
                    AttackState();
                    break;
                }
                case NpcState.AttackAndPursuit:
                {
                    AttackAndPursuitState();
                    break;
                }
                case NpcState.Defence :
                {
                    DefenceState();
                    break;
                }
            }
        }

        

        #region Ability state methods

        public abstract void IdleState();
        public abstract void PatrollingState();
        public abstract void PursuitState();
        public abstract void AttackState();
        public abstract void AttackAndPursuitState();
        public abstract void DefenceState();

        #endregion
    }
}