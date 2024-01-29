using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public class RL_Unit_NPC : RL_Unit
    {
        [Header("NPC Settings")]

        [SerializeField] List<RL_Unit_NPC_AbilityWithWraper> abilities;

        [SerializeField] NPC_State npcState;
        public NPC_State NPCState => npcState;
        
        [SerializeField] RL_Unit goal;
        public RL_Unit Goal => goal;
        public List<RL_Unit_NPC_AbilityWithWraper> Abilities => abilities;
        

        void Start() => Abilities.ForEach(x => x.Ability.PerformStart(this));
        void Update() => Abilities.ForEach(x => x.Ability.PerformUpdate(this));

        public enum NPC_State
        {
            Idle,
            Patrolling,
            Pursuit,
            AttackAndPursuit,
            Attack,
            Defence
        }
    }
}
