using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Reckless.Unit.AI 
{
    public class RL_Unit_NPC_Movement : MonoBehaviour
    {
        [SerializeField] NavMeshAgent agent;
        [SerializeField] List<Transform> patrolingPoints;

        RL_Unit_NPC thisNPC;

        private void Awake()
        {
            thisNPC = GetComponent<RL_Unit_NPC>();
        }


        void Update()
        {
            if (thisNPC?.Goal == null) return;
            agent.SetDestination(thisNPC.Goal.transform.position);
        }
    }
}
