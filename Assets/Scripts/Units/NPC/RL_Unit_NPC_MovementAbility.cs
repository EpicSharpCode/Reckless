using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Reckless.Unit.AI 
{
    public class RL_Unit_NPC_MovementAbility : RL_Unit_NPC_Ability
    {
        [SerializeField] NavMeshAgent agent;
        [SerializeField] List<Transform> patrollingPoints;

        RL_Unit_NPC thisNPC;

        void Awake()
        {
            thisNPC = GetComponent<RL_Unit_NPC>();
        }

        public override void Idle() { agent.isStopped = true; }
        public override void Pursuit()
        {
            if (thisNPC?.Goal == null) return;
            agent.SetDestination(thisNPC.Goal.transform.position);
            agent.isStopped = false;
        }
        public override void Attack() { }
        public override void Defence() { }
    }
}
