using UnityEngine;

namespace Reckless.Unit.AI
{
    [System.Serializable]
    public class RL_Unit_NPC_AbilityWithWraper
    {
        [SerializeField] RL_Unit_NPC_Ability ability;
        public RL_Unit_NPC_Ability Ability => ability;
    }
}