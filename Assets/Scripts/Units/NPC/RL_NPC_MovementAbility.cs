using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Reckless.Unit.AI 
{
    public class RL_NPC_MovementAbility : RL_NPC_Ability
    {
        [SerializeField] NavMeshAgent _agent;
        [SerializeField] List<Transform> _patrollingPoints;

        [Header("Stopping Distances")]
        [SerializeField] float stoppingDistancePatrolling = 0;
        [SerializeField] float stoppingDistancePursuit = 3;

        RL_NPC _thisNPC;

        void Awake()
        {
            _thisNPC = GetComponent<RL_NPC>();
        }

        public override void Idle() { _agent.isStopped = true; }
        public override void Pursuit() => GoToGoal();
        public override void AttackAndPursuit() => GoToGoal();

        public override void Patrolling()
        {
            int nextIndex = _patrollingIndex % _patrollingPoints.Count;
            _agent.SetDestination(_patrollingPoints[nextIndex].position);
            _agent.stoppingDistance = 0;
            _agent.isStopped = false;
            if (Vector3.Distance(_agent.transform.position, _patrollingPoints[nextIndex].position) <= 0.1f)
                _patrollingIndex++;
        }

        void GoToGoal()
        {
            if (_thisNPC?.Goal == null) return;
            _agent.SetDestination(_thisNPC.Goal.transform.position);
            _agent.isStopped = false;
        }
    }
}
