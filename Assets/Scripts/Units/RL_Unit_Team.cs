using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless
{
    [System.Serializable]
    public class RL_Unit_Team
    {
        [SerializeField] string _teamName;
        [SerializeField] List<string> _allyTeams;
        [SerializeField] List<string> _enemiesTeams;
    }
}
