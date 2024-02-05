using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Reckless.Unit.AI 
{
    public class RL_NPC_MovementAbility : RL_NPC_Ability
    {
        [SerializeField] NavMeshAgent agent;
        [SerializeField] List<Transform> patrollingPoints;

        RL_NPC thisNPC;

        void Awake()
        {
            thisNPC = GetComponent<RL_NPC>();
        }

        public override void Idle() { agent.isStopped = true; }
        public override void Pursuit() => GoToGoal();
        public override void AttackAndPursuit() => GoToGoal();

        void GoToGoal()
        {
            if (thisNPC?.Goal == null) return;
            agent.SetDestination(thisNPC.Goal.transform.position);
            agent.isStopped = false;
        }
    }
}
