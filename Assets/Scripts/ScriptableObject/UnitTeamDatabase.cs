using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless
{
    [CreateAssetMenu(fileName = "RL_Unit_TeamDatabase", menuName = "Reckless/TeamDatabase")]
    public class UnitTeamDatabase : ScriptableObject
    {
        [SerializeField] List<UnitTeam> _teams;
        public List<UnitTeam> teams => _teams;
    }
}
