using Reckless.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Reckless.Units.AI 
{
    public class NpcAbilityMovement : NpcAbility
    {
        [SerializeField] NavMeshAgent _agent;
        [SerializeField] List<Transform> _patrollingPoints;

        [Header("Stopping Distances")]
        [SerializeField] float _stoppingDistancePatrolling = 0;
        [SerializeField] float _stoppingDistancePursuit = 3;

        Npc _thisNpc;

        void Awake()
        {
            _thisNpc = GetComponent<Npc>();
        }

        public override void Idle() { _agent.isStopped = true; }
        public override void Pursuit() => GoToGoal();
        public override void AttackAndPursuit() => GoToGoal();

        public override void Patrolling()
        {
            if(_patrollingPoints.Count == 0) return;
            
            int nextIndex = _patrollingIndex % _patrollingPoints.Count;
            _agent.SetDestination(_patrollingPoints[nextIndex].position);
            _agent.stoppingDistance = 0;
            _agent.isStopped = false;
            if (Vector3.Distance(_agent.transform.position, _patrollingPoints[nextIndex].position) <= 0.1f)
                _patrollingIndex++;
        }

        void GoToGoal()
        {
            if (_thisNpc?.goal == null) return;
            _agent.SetDestination(_thisNpc.goal.transform.position);
            _agent.isStopped = false;
        }
    }
}
