using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Unit.AI
{
    public class RL_NPC : RL_Unit
    {
        [Header("NPC Settings")]

        [SerializeField] List<RL_NPC_AbilityWithWraper> _abilities;

        [SerializeField] NPC_State _npcState;
        public NPC_State NPCState => _npcState;
        
        [SerializeField] RL_Unit _goal;
        public RL_Unit Goal => _goal;
        public List<RL_NPC_AbilityWithWraper> Abilities => _abilities;
        

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
