using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Reckless.Unit {

    public class RL_Unit_NPC_Movement : MonoBehaviour
    {
        [SerializeField] NavMeshAgent agent;

        RL_Unit_NPC thisEnemy;

        private void Awake()
        {
            thisEnemy = GetComponent<RL_Unit_NPC>();
        }


        void Update()
        {
            if (thisEnemy.GetGoal() == null) return;
            agent.SetDestination(thisEnemy.GetGoal().transform.position);
        }
    }
}
