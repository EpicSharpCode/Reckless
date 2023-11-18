using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RL_Unit_BehaviorPattern", menuName = "Reckless/Create Unit Behavior Pattern")]
public class RL_Unit_BehaviorPattern : ScriptableObject
{
    [SerializeField] float hearRadius = 1;
    [SerializeField] float seeAngle = 90;
    [SerializeField] float seeDistance = 10;
    [SerializeField] List<BehaviorType> behaviorTypes;

    public enum BehaviorType
    {
        Patrolling,
        Attack,
        Defend
    }
    
}
