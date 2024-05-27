using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless
{
    [CreateAssetMenu(fileName = "RL_Unit_TeamDatabase", menuName = "Reckless/TeamDatabase")]
    public class RL_Unit_TeamDatabase : ScriptableObject
    {
        [SerializeField] List<RL_Unit_Team> _teams;
        public List<RL_Unit_Team> Teams => _teams;
    }
}
