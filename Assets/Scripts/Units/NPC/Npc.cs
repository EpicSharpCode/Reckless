using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Units.AI
{
    public class Npc : Unit
    {
        [Header("NPC Settings")]

        [SerializeField] List<NpcAbilityWithWraper> _abilities;

        [SerializeField] NpcState _npcState;
        public NpcState npcState => _npcState;
        
        [SerializeField] Unit _goal;
        
        public Unit goal => _goal;
        public List<NpcAbilityWithWraper> abilities => _abilities;
        

        void Start() => abilities.ForEach(x => x.ability.PerformStart(this));
        void Update() => abilities.ForEach(x => x.ability.PerformUpdate(this));

        public enum NpcState
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
