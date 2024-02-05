using UnityEngine;

namespace Reckless.Unit.AI
{
    [System.Serializable]
    public class RL_NPC_AbilityWithWraper
    {
        [SerializeField] RL_NPC_Ability ability;
        public RL_NPC_Ability Ability => ability;
    }
}