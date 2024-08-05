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

        [SerializeField] List<NpcAbility> _abilities;

        [SerializeField] NpcState _npcState;
        [SerializeField] string _npcTeam;
        public UnitTeam npcTeam => GameController.GetTeam(_npcTeam);
        public NpcState npcState => _npcState;
        
        [SerializeField] Unit _goal;
        
        public Unit goal => _goal;
        public List<NpcAbility> abilities => _abilities;
        

        void Start() => abilities.ForEach(
            x => { if(x.isActiveAndEnabled) x.PerformStart(this); }
        );
        void Update() => abilities.ForEach(
            x => { if(x.isActiveAndEnabled) x.PerformUpdate(this); }
        );

    }
}
