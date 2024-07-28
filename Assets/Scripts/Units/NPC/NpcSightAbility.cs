using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Units.AI
{
    public class NpcSightAbility : NpcAbility
    {
        public List<Unit> unitsInSight => _unitsInSight;

        [SerializeField] float _sightAngle;
        [SerializeField] List<Unit> _unitsInSight;
        [SerializeField] Vector3 _scanOffset;
        public override void PerformUpdate(Npc npc)
        {
            _unitsInSight = ScanForUnits(npc);
        }

        public List<Unit> ScanForUnits(Unit unit)
        {
            List<Unit> foundedUnits = new List<Unit>();
            for(float i = -_sightAngle/2; i < _sightAngle/2; i++)
            {
                var found = RaycastAngle(unit, i, true);
                if(found == null) continue;
                if(foundedUnits.Contains(found)) continue;
                foundedUnits.Add(found);
            }

            return foundedUnits;
        }

        public Unit RaycastAngle(Unit unit, float angle, bool debug = false)
        {
            var direction = Quaternion.AngleAxis(angle, unit.transform.up) * unit.transform.forward;
            var origin = unit.transform.position + _scanOffset;
            Ray ray = new Ray(origin, direction);
            if (debug)
            {
                Debug.DrawRay(origin, direction, Color.red,1);
                return null;
            }

            Physics.Raycast(ray, out RaycastHit raycastHit);
            return raycastHit.transform.GetComponent<Unit>();
        }
    }
}
