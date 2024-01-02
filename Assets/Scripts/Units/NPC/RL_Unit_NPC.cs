using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public class RL_Unit_NPC : RL_Unit
    {
        [field:Header("NPC Settings")]

        [SerializeField] List<RL_Unit_NPC_AbilityWithWraper> abilities;
        [SerializeField] RL_Unit goal;

        public RL_Unit Goal => goal;
        public List<RL_Unit_NPC_AbilityWithWraper> Abilities => abilities;

        private void Update()
        {
            Abilities.ForEach(x => x.Ability.PerformUpdateAction(GetComponent<RL_Unit>()));
        }

        public override void InitParameters()
        {
            Parameters = new List<RL_Unit_Parameter>()
            {
                new RL_Unit_Parameter("Health", 100)
            };
        }
    }
}
