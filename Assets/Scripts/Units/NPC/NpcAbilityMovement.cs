using Reckless.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Reckless.Units.AI 
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Npc))]
    public class NpcAbilityMovement : NpcAbility
    {
        NavMeshAgent _agent;
        Npc _thisNpc;
        
        
        [SerializeField] List<Transform> _patrollingPoints;

        [Header("Stopping Distances")]
        [SerializeField] float _stoppingDistancePatrolling = 0;
        [SerializeField] float _stoppingDistancePursuit = 3;


        void Awake()
        {
            _thisNpc = GetComponent<Npc>();
            _agent = GetComponent<NavMeshAgent>();
        }
        
        void GoToGoal()
        {
            if (_thisNpc?.goal == null) return;
            _agent.SetDestination(_thisNpc.goal.transform.position);
            _agent.isStopped = false;
        }

        #region Ability state methods

        public override void IdleState() { _agent.isStopped = true; }
        public override void PursuitState() => GoToGoal();
        public override void AttackState() {}
        public override void DefenceState() {}
        public override void AttackAndPursuitState() => GoToGoal();

        public override void PatrollingState()
        {
            if(_patrollingPoints.Count == 0) return;
            
            int nextIndex = _patrollingIndex % _patrollingPoints.Count;
            _agent.SetDestination(_patrollingPoints[nextIndex].position);
            _agent.stoppingDistance = 0;
            _agent.isStopped = false;
            if (Vector3.Distance(_agent.transform.position, _patrollingPoints[nextIndex].position) <= 0.1f)
                _patrollingIndex++;
        }
        #endregion

    }
}
