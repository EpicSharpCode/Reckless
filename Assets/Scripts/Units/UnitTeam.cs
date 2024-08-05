using Reckless.Units.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless
{
    [System.Serializable]
    public class UnitTeam
    {
        [SerializeField] string _teamName;
        public string teamName => _teamName;
        [SerializeField] List<TeamRule> _allyTeams;
        [SerializeField] List<TeamRule> _enemiesTeams;

        [System.Serializable]
        public class TeamRule
        {
            [SerializeField] string _teamName;
            [SerializeField] NpcState _inSightBehaviour;
        }
    }
}
