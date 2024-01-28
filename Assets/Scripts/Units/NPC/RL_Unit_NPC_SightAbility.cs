using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public class RL_Unit_NPC_SightAbility : RL_Unit_NPC_Ability
    {
        public List<RL_Unit> UnitsInSight => unitsInSight;

        [SerializeField] float sightAngle = 0;
        [SerializeField] List<RL_Unit> unitsInSight;
        [SerializeField] Vector3 scanOffset;
        public override void PerformUpdate(RL_Unit_NPC _npc)
        {
            unitsInSight = ScanForUnits(_npc);
        }

        public List<RL_Unit> ScanForUnits(RL_Unit _unit)
        {
            List<RL_Unit> foundedUnits = new List<RL_Unit>();
            for(float i = -sightAngle/2; i < sightAngle/2; i++)
            {
                var found = RaycastAngle(_unit, i, true);
                if(found == null) continue;
                if(foundedUnits.Contains(found)) continue;
                foundedUnits.Add(found);
            }

            return foundedUnits;
        }

        public RL_Unit RaycastAngle(RL_Unit _unit, float _angle, bool _debug = false)
        {
            var direction = Quaternion.AngleAxis(_angle, _unit.transform.up) * _unit.transform.forward;
            var origin = _unit.transform.position + scanOffset;
            Ray ray = new Ray(origin, direction);
            if (_debug)
            {
                Debug.DrawRay(origin, direction, Color.red,1);
                return null;
            }

            Physics.Raycast(ray, out RaycastHit raycastHit);
            return raycastHit.transform.GetComponent<RL_Unit>();
        }
    }
}
