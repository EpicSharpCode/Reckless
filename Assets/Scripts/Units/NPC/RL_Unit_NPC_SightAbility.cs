using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    [CreateAssetMenu(fileName = "Unit_AI_SightAbility", menuName = "Reckless/AI/Abilities/Sight Ability")]
    public class RL_Unit_NPC_SightAbility : RL_Unit_NPC_Ability
    {
        [SerializeField] List<RL_Unit> unitsInSight;
        [SerializeField] Vector3 scanOffset;
        public override void PerformUpdateAction(RL_Unit _thisUnit)
        {
            unitsInSight = ScanForUnits(_thisUnit);
        }

        public List<RL_Unit> ScanForUnits(RL_Unit _thisUnit)
        {
            List<RL_Unit> foundedUnits = new List<RL_Unit>();
            for(float i = -AbilityValue/2; i < AbilityValue/2; i++)
            {
                var found = RaycastAngle(_thisUnit, i, true);
                if(found == null) continue;
                if(foundedUnits.Contains(found)) continue;
                foundedUnits.Add(found);
            }

            return foundedUnits;
        }

        public RL_Unit RaycastAngle(RL_Unit _thisUnit, float _angle, bool debug = false)
        {
            var direction = Quaternion.AngleAxis(_angle, _thisUnit.transform.up) * _thisUnit.transform.forward;
            var origin = _thisUnit.transform.position + scanOffset;
            Ray ray = new Ray(origin, direction);
            if (debug)
            {
                Debug.DrawRay(origin, direction, Color.red,1);
                return null;
            }

            Physics.Raycast(ray, out RaycastHit raycastHit);
            return raycastHit.transform.GetComponent<RL_Unit>();
        }
    }
}
