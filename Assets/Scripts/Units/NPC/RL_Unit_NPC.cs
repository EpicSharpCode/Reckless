using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public class RL_Unit_NPC : RL_Unit
    {
        [field:Header("NPC Settings")]
        [field:SerializeField] public RL_Unit Goal { get; private set; }

        [field:SerializeField] public List<RL_Unit_NPC_Ability> Abilities { get; private set; }

        private void Update()
        {
            Abilities.ForEach(x => x.PerformUpdateAction(GetComponent<RL_Unit>()));
        }
    }
}
