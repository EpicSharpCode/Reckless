using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public class RL_Unit_NPC : RL_Unit
    {
        [Header("NPC Settings")]
        [SerializeField] RL_Unit goal;
        [SerializeField] List<RL_Unit_NPC_Ability> abilities;

        private void Update()
        {
            abilities.ForEach(x => x.PerformUpdateAction(GetComponent<RL_Unit>()));
        }

        public RL_Unit GetGoal() => goal;
    }
}
