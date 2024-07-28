using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Units.AI
{
    [System.Serializable]
    public class NpcAbilityWithWraper
    {
        [SerializeField] NpcAbility _ability;
        public NpcAbility ability => ability;
    }
}