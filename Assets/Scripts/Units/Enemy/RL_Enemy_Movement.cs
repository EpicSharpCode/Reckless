using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Reckless.Unit {

    public class RL_Enemy_Movement : MonoBehaviour
    {
        [SerializeField] NavMeshAgent agent;

        RL_Enemy thisEnemy;

        private void Awake()
        {
            thisEnemy = GetComponent<RL_Enemy>();
        }


        void Update()
        {
            if (thisEnemy.GetGoal() == null) return;
            agent.SetDestination(thisEnemy.GetGoal().transform.position);
        }
    }
}
